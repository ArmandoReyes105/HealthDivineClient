using HealthDivineSysClient.Helpers;
using HealthDivineSysClient.Modules.PlanManagementModule.CreateMealPlan.View;
using HealthDivineSysClient.Modules.PlanManagementModule.ExportPDF.View;
using HealthDivineSysClient.Modules.PlanManagementModule.UpdateMealPlan.View;
using HealthDivineSysClient.Modules.ProgressManagementModule.ConsultHistory.View;
using HealthDivineSysClient.Modules.ProgressManagementModule.CreateProgressRecord.View;
using HealthDivineSysClient.Modules.ProgressManagementModule.ModifyProgressRecord.View;
using HealthDivineSysClient.Modules.UserManagementModule.ConsultPatient.View;
using HealthDivineSysClient.Modules.UserManagementModule.ModifyPatient.View; 
using HealthDivineSysClient.ViewModel.ViewModelTemplates;
using System;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using UserManagementService;

namespace HealthDivineSysClient.Modules.UserManagementModule.ConsultPatient.ViewModel
{
    public class PatientInfoViewModel : ViewModelBase
    {

        //Fields
        private ImageSource? _genderImage;
        private Patient _patient = new();
        private MedicalInformation _medicalInformation = new();
        private string _gender = "";
        private string _age = "";

        //Properties
        public ImageSource GenderImage
        {
            get => _genderImage;
            set
            {
                _genderImage = value; OnPropertyChanged(nameof(GenderImage));
            }
        }

        public Patient Patient
        {
            get => _patient;
            set
            {
                _patient = value; OnPropertyChanged(nameof(Patient));
            }
        }

        public MedicalInformation MedicalInformation
        {
            get => _medicalInformation;
            set { _medicalInformation = value; OnPropertyChanged(nameof(MedicalInformation)); }
        }

        public string Gender
        {
            get => _gender;
            set
            {
                _gender = value; OnPropertyChanged(nameof(Gender));
            }
        }

        public string Age
        {
            get => _age; 
            set
            {
                _age = value; OnPropertyChanged(nameof(Age));
            }
        }

        //Commands
        public ICommand EditInfoCommand { get; }
        public ICommand ReturnCommand { get; }
        public ICommand ProgressRecordCommand { get; }
        public ICommand MealPlanCommand { get; }
        public ICommand HistoryCommand { get; }

        //Constructor
        public PatientInfoViewModel(Patient patient)
        {
            EditInfoCommand = new RelayCommand(ExecuteEditInfoCommand);
            ReturnCommand = new RelayCommand(ExecuteReturnCommand);
            ProgressRecordCommand = new RelayCommand(ExecuteProgressRecordCommand);
            MealPlanCommand = new RelayCommand(ExecuteMealPlanCommand);
            HistoryCommand = new RelayCommand(ExecuteHistoryCommand);

            Patient = patient;
            MedicalInformation = patient.MedicalInformation; 

            LoadInformation(); 
        }

        //Commands Implementation
        private void ExecuteEditInfoCommand(object obj)
        {
            switch (int.Parse((string)obj))
            {
                case 1: NavigationManager.Instance.NavigateTo(new ModifyPatientPage(Patient)); break;
                case 2: NavigationManager.Instance.NavigateTo(new ModifyMedicalPage(MedicalInformation)); break;  
            }
            
        }

        private void ExecuteMealPlanCommand(object obj)
        {
            switch (int.Parse((string)obj))
            {
                case 1: NavigationManager.Instance.NavigateTo(new CreatePlanPage(Patient.IdPatient)); break;
                case 2: NavigationManager.Instance.NavigateTo(new UpdateMealPage(Patient.IdPatient)); break; 
                case 3: NavigationManager.Instance.NavigateTo(new ExportPlanPage(Patient.IdPatient)); break; 
            }
        }

        private void ExecuteReturnCommand(object obj)
        {
            NavigationManager.Instance.NavigateTo(new PatientListPage()); 
        }

        private void ExecuteProgressRecordCommand(object obj)
        {
            switch (int.Parse((string)obj))
            {
                case 1: NavigationManager.Instance.NavigateTo(new DiagnosisFormPage(Patient.IdPatient)); break;
                case 2: NavigationManager.Instance.NavigateTo(new ModifyDiagnosisPage(Patient.IdPatient)); break;  
            }
            
        }

        private void ExecuteHistoryCommand(object obj)
        {
            NavigationManager.Instance.NavigateTo(new HistoryPage(Patient.IdPatient)); 
        }

        //Methods
        private void LoadInformation()
        {
            switch(Patient.Gender)
            {
                case "M": 
                    Gender = "Masculino";
                    GenderImage = new BitmapImage(new Uri("/HealthDivineSysClient;component/Resources/Images/MaleUser_Image.png", UriKind.Relative)); 
                    break;
                case "F": 
                    Gender = "Femenino";
                    GenderImage = new BitmapImage(new Uri("/HealthDivineSysClient;component/Resources/Images/FemaleUser_Image.png", UriKind.Relative)); 
                    break; 
            }

            int age = DateTime.Today.Year - Patient.Birthday.Year;
            if (Patient.Birthday > DateTime.Today.AddYears(-age)) { age--; }
            Age = age + " Años";
        }
    }
}
