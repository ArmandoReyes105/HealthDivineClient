using HealthDivineSysClient.Helpers;
using HealthDivineSysClient.Modules.UserManagementModule.RegisterPatient.Data;
using HealthDivineSysClient.Modules.UserManagementModule.ConsultPatient.View;
using HealthDivineSysClient.Modules.UserManagementModule.RegisterPatient.View;
using HealthDivineSysClient.ViewModel.ViewModelTemplates;
using System.Collections.Generic;
using System.Windows.Input;
using UserManagementService;

namespace HealthDivineSysClient.Modules.UserManagementModule.RegisterPatient.ViewModel
{
    class MedicalFormViewModel : ViewModelBase
    {
        //Fields
        private Patient _newPatient = new Patient();
        private string _chronicDiseases = "";
        private string _hereditaryFamilyHitory = "";
        private string _gastrointestinalDiseases = "";
        private string _foodAllergies = "";
        private string _nonFoodAllergies = "";
        private string _surgicalHistory = "";
        private string _medications = "";
        private string _generalMedicalComments = "";

        //Properties
        public Patient NewPatient
        {
            get => _newPatient;
            set
            {
                _newPatient = value;
                OnPropertyChanged(nameof(NewPatient));
            }
        }

        public string ChronicalDiseases
        {
            get => _chronicDiseases;
            set
            {
                _chronicDiseases = value;
                OnPropertyChanged(nameof(ChronicalDiseases));
            }
        }

        public string HereditaryFamilyHistory
        {
            get => _hereditaryFamilyHitory;
            set
            {
                _hereditaryFamilyHitory = value;
                OnPropertyChanged(nameof(HereditaryFamilyHistory));
            }
        }

        public string GastrointestinalDiseases
        {
            get => _gastrointestinalDiseases;
            set
            {
                _gastrointestinalDiseases = value;
                OnPropertyChanged(nameof(GastrointestinalDiseases));
            }
        }

        public string FoodAllergies
        {
            get => _foodAllergies;
            set
            {
                _foodAllergies = value;
                OnPropertyChanged(nameof(FoodAllergies));
            }
        }

        public string NonFoodAllergies
        {
            get => _nonFoodAllergies; set
            {
                _nonFoodAllergies = value;
                OnPropertyChanged(nameof(NonFoodAllergies));
            }
        }

        public string SurgicalHistory
        {
            get => _surgicalHistory; set
            {
                _surgicalHistory = value;
                OnPropertyChanged(nameof(SurgicalHistory));
            }
        }

        public string Medications
        {
            get => _medications; set
            {
                _medications = value;
                OnPropertyChanged(nameof(Medications));
            }
        }

        public string GeneralMedicalComments
        {
            get => _generalMedicalComments; set
            {
                _generalMedicalComments = value;
                OnPropertyChanged(nameof(GeneralMedicalComments));
            }
        }

        //Commands
        public ICommand NextCommand { get; }
        public ICommand CancelCommand { get; }

        //Constructor
        public MedicalFormViewModel()
        {
            NextCommand = new RelayCommand(ExecuteNextCommand);
            CancelCommand = new RelayCommand(ExecuteCancelCommand);
        }

        //Commands Implementation
        private void ExecuteNextCommand(object obj)
        {

            if (AreFieldsComplete())
            {
                RegisterPatientInfo.Instance.MedicalInfo = CreateMedicalInfo();

                NutritionalFormPage nutritionalForm = new NutritionalFormPage();
                NavigationManager.Instance.NavigateTo(nutritionalForm);
            }
            else
            {
                string title = "¿Seguro que desea continuar?";
                string message = "Aún quedan campos vaciós, ¿Esta seguro que desea continuar?";
                bool result = DialogManager.ShowConfirmation(title, message, "Continuar", "Cancelar");

                if (result == true)
                {
                    NutritionalFormPage nutritionalForm = new NutritionalFormPage();
                    NavigationManager.Instance.NavigateTo(nutritionalForm);
                }
            }
        }

        private void ExecuteCancelCommand(object obj)
        {
            string title = "¿Estás seguro de que deseas salir?";
            string message = "Recuerda que si sales ahora sin guardar, perderás el progreso que hayas realizado.";
            bool result = DialogManager.ShowConfirmation(title, message, "Aceptar", "Cancelar");
            if (result)
            {
                NavigationManager.Instance.NavigateTo(new PatientListPage());
            }
        }

        //Methods 
        private bool AreFieldsComplete()
        {

            List<string> fields = new()
            {
                ChronicalDiseases,
                HereditaryFamilyHistory,
                GastrointestinalDiseases,
                FoodAllergies,
                NonFoodAllergies,
                Medications,
                SurgicalHistory,
                GeneralMedicalComments
            };

            return ValidationManager.AreAllFieldsComplete(fields);
        }

        private MedicalInformation CreateMedicalInfo()
        {
            MedicalInformation medicalInfo = new MedicalInformation();
            medicalInfo.ChronicDiseases = ChronicalDiseases;
            medicalInfo.HereditaryFamilyHistory = HereditaryFamilyHistory;
            medicalInfo.GastrointestinalDiseases = GastrointestinalDiseases;
            medicalInfo.FoodAllergies = FoodAllergies;
            medicalInfo.NonFoodAllergies = NonFoodAllergies;
            medicalInfo.SurgicalHistory = SurgicalHistory;
            medicalInfo.Medications = Medications;
            medicalInfo.GeneralMedicalComments = GeneralMedicalComments;

            return medicalInfo;
        }
    }
}
