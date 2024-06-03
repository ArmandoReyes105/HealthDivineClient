using HealthDivineSysClient.Helpers;
using HealthDivineSysClient.Modules.UserManagementModule.RegisterPatient.Data;
using HealthDivineSysClient.Modules.UserManagementModule.ConsultPatient.View; 
using HealthDivineSysClient.ViewModel.ViewModelTemplates;
using System;
using System.Timers;
using System.Windows;
using System.Windows.Input;
using UserManagementService;

namespace HealthDivineSysClient.Modules.UserManagementModule.RegisterPatient.ViewModel
{
    public class RegistrationResultViewModel : ViewModelBase
    {
        //Fields
        private double _opacity = 1;
        private string _patientName = "";
        private string _errorMessage = "";
        private Visibility _successPanelVisibility = Visibility.Collapsed;
        private Visibility _loadingPanelVisibility = Visibility.Visible;
        private Visibility _errorPanelVisibility = Visibility.Collapsed;

        //Properties
        public double Opacity
        {
            get => _opacity;
            set
            {
                _opacity = value;
                OnPropertyChanged(nameof(Opacity));
            }
        }

        public string PatientName
        {
            get => _patientName;
            set
            {
                _patientName = value;
                OnPropertyChanged(nameof(PatientName));
            }
        }

        public string ErrorMessage
        {
            get => _errorMessage;
            set
            {
                _errorMessage = value;
                OnPropertyChanged(nameof(ErrorMessage));
            }
        }

        public Visibility SuccessPanelVisibility
        {
            get => _successPanelVisibility;
            set
            {
                _successPanelVisibility = value;
                OnPropertyChanged(nameof(SuccessPanelVisibility));
            }
        }

        public Visibility LoadingPanelVisibility
        {
            get => _loadingPanelVisibility;
            set
            {
                _loadingPanelVisibility = value;
                OnPropertyChanged(nameof(LoadingPanelVisibility));
            }
        }

        public Visibility ErrorPanelVisibility
        {
            get => _errorPanelVisibility;
            set
            {
                _errorPanelVisibility = value;
                OnPropertyChanged(nameof(ErrorPanelVisibility));
            }
        }

        //Commands
        public ICommand CreateDiagnosisCommand { get; }
        public ICommand CreateAppointmentCommand { get; }
        public ICommand GoToMenuCommand { get; }
        public ICommand RetryCommand { get; }

        //Constructor 
        public RegistrationResultViewModel()
        {
            CreateDiagnosisCommand = new RelayCommand(ExecuteCreateDiagnosisCommand);
            CreateAppointmentCommand = new RelayCommand(ExecuteCreateAppointmentCommand);
            GoToMenuCommand = new RelayCommand(ExecuteGoToMenuCommand);
            RetryCommand = new RelayCommand(ExecuteRetryCommand);

            RegisterPatient();
        }

        //Commands Implementation
        private void ExecuteCreateDiagnosisCommand(object obj)
        {
            DialogManager.ShowNotification("Crear diagnostico", "Navega a la página crear diagnostico");
        }

        private void ExecuteCreateAppointmentCommand(object obj)
        {
            DialogManager.ShowNotification("Crear cita", "Navega a la página crear cita");
        }

        private void ExecuteGoToMenuCommand(object obj)
        {
            NavigationManager.Instance.NavigateTo(new PatientListPage());
        }

        private void ExecuteRetryCommand(object obj)
        {
            ErrorPanelVisibility = Visibility.Collapsed;
            LoadingPanelVisibility = Visibility.Visible;
            FadeInAnimation();
            RegisterPatient();
        }

        //Methods
        private async void RegisterPatient()
        {
            Patient newPatient = RegisterPatientInfo.Instance.NewPatient;
            newPatient.MedicalInformation = RegisterPatientInfo.Instance.MedicalInfo;
            newPatient.GeneralInfomation = RegisterPatientInfo.Instance.NutritionalInfo;
            newPatient.HabitsAndGoals = RegisterPatientInfo.Instance.HabitsAndGoalsInfo;
            newPatient.Person.Phone = ConvertPhone(newPatient.Person.Phone);
            newPatient.Nutritionist = SessionManager.Instance.GetNutritionistId();

            PatientName = newPatient.Person.Names + " " + newPatient.Person.FirstLastName + " " + newPatient.Person.SecondLastName;

            UserManagementClient client = new UserManagementClient();
            client.InnerChannel.OperationTimeout = TimeSpan.FromSeconds(20);

            try
            {
                int result = await client.AddPatientAsync(newPatient);
                if (result == 1)
                {
                    SuccessPanelVisibility = Visibility.Visible;
                    LoadingPanelVisibility = Visibility.Collapsed;
                    FadeInAnimation();
                }
                else
                {
                    ErrorPanelVisibility = Visibility.Visible;
                    LoadingPanelVisibility = Visibility.Collapsed;
                    FadeInAnimation();
                    ErrorMessage = "Lo sentimos, se produjo un error al intentar guardar los datos en la base de datos. La operación no se completó con éxito y los cambios no se guardaron correctamente. Por favor, inténtalo de nuevo más tarde";
                }

            }
            catch (Exception ex)
            {
                ErrorPanelVisibility = Visibility.Visible;
                LoadingPanelVisibility = Visibility.Collapsed;
                FadeInAnimation();
                ErrorMessage = "Lo sentimos, no se pudo establecer una conexión con el servidor. Por favor, comprueba tu conexión a Internet o intenta nuevamente más tarde.";
            }
            finally
            {
                client.Close();
            }
        }

        private void FadeInAnimation()
        {
            double initialValue = 0;
            double endValue = 1;
            double time = 0.5;
            int steps = 100; // Número de pasos para la interpolación

            double step = (endValue - initialValue) / steps;
            double currentValue = initialValue;

            Timer timer = new Timer(time * 1000 / steps);
            timer.Elapsed += (sender, e) =>
            {
                currentValue += step;
                Opacity = currentValue;
                Console.WriteLine($"Valor actual: {currentValue}");
                if (currentValue >= endValue)
                {
                    timer.Stop();
                }
            };

            timer.Start();
        }

        static string ConvertPhone(string phone)
        {
            return phone.Replace("-", "");
        }
    }
}
