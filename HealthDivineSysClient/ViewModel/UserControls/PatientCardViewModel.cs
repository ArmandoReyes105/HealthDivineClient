using HealthDivineSysClient.ViewModel.ViewModelTemplates;
using HealthDivineSysClient.Modules.SchedulingModule.ScheduleAppointment.View;
using HealthDivineSysClient.Modules.UserManagementModule.ConsultPatient.View; 
using System;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using UserManagementService;
using System.Windows.Input;
using HealthDivineSysClient.Helpers;

namespace HealthDivineSysClient.ViewModel.UserControls
{
    public class PatientCardViewModel : ViewModelBase
    {
        //Fields
        private string _lastname = "";
        private Patient? _patient;
        private ImageSource? _genderImage;

        //Properties
        public string Lastname
        {
            get => _lastname;
            set
            {
                _lastname = value;
                OnPropertyChanged(nameof(Lastname));
            }
        }

        public Patient? Patient
        {
            get => _patient;
            set
            {
                _patient = value;
                OnPropertyChanged(nameof(Patient));
                SetGenderImage(); 
            }
        }

        public ImageSource? GenderImage
        {
            get => _genderImage; 
            set
            {
                _genderImage = value;
                OnPropertyChanged(nameof(GenderImage));
            }
        }

        //Commands
        public ICommand ScheduleAppointmentCommand { get; }
        public ICommand ConsultPatientCommand {  get; }

        //Constructor
        public PatientCardViewModel()
        {
            ScheduleAppointmentCommand = new RelayCommand(ExecuteScheduleAppointmentCommand);
            ConsultPatientCommand = new RelayCommand(ExecuteConsultPatientCommand); 
        }

        //CommandsImplementation
        private void ExecuteScheduleAppointmentCommand(object obj)
        {
            NavigationManager.Instance.NavigateTo(new ScheduleAppointmentPage(Patient)); 
        }

        private void ExecuteConsultPatientCommand(object obj)
        {
            NavigationManager.Instance.NavigateTo(new PatientInfoPage(Patient)); 
        }

        //Methods
        private void SetGenderImage()
        {
            Uri uri; 
            switch (Patient.Gender)
            {
                case "M":
                    uri = new Uri("/HealthDivineSysClient;component/Resources/Images/MaleUser_Image.png", UriKind.Relative);
                    GenderImage = new BitmapImage(uri); 
                    break;
                case "F":
                    uri = new Uri("/HealthDivineSysClient;component/Resources/Images/FemaleUser_Image.png", UriKind.Relative);
                    GenderImage = new BitmapImage(uri);
                    break;
            }

        }
    }
}
