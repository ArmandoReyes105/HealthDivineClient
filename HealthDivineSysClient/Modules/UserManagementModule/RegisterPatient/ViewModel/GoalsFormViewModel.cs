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
    public class GoalsFormViewModel : ViewModelBase
    {
        //Fields
        private string _caffeine = "";
        private string _alcohol = "";
        private string _cigarette = "";
        private string _drugs = "";
        private string _healthGoals = "";
        private string _specificNutritionalGoals = "";
        private string _expectations = "";
        private string _generalComments = "";

        //Properties
        public string Caffeine
        {
            get => _caffeine;
            set
            {
                _caffeine = value;
                OnPropertyChanged(nameof(Caffeine));
            }
        }

        public string Alcohol
        {
            get => _alcohol;
            set
            {
                _alcohol = value;
                OnPropertyChanged(nameof(Alcohol));
            }
        }

        public string Cigarette
        {
            get => _cigarette;
            set
            {
                _cigarette = value;
                OnPropertyChanged(nameof(Cigarette));
            }
        }

        public string Drugs
        {
            get => _drugs;
            set
            {
                _drugs = value;
                OnPropertyChanged(nameof(Drugs));
            }
        }

        public string HealthGoals
        {
            get => _healthGoals;
            set
            {
                _healthGoals = value;
                OnPropertyChanged(nameof(HealthGoals));
            }
        }

        public string SpecificNutritionalGoals
        {
            get => _specificNutritionalGoals;
            set
            {
                _specificNutritionalGoals = value;
                OnPropertyChanged(nameof(SpecificNutritionalGoals));
            }
        }

        public string Expectations
        {
            get => _expectations;
            set
            {
                _expectations = value;
                OnPropertyChanged(nameof(Expectations));
            }
        }

        public string GeneralComments
        {
            get => _generalComments;
            set
            {
                _generalComments = value;
                OnPropertyChanged(nameof(GeneralComments));
            }
        }

        //Commands
        public ICommand RegisterPatientCommand { get; }
        public ICommand CancelCommand { get; }

        //Constructor
        public GoalsFormViewModel()
        {
            RegisterPatientCommand = new RelayCommand(ExecuteRegisterPatientCommand);
            CancelCommand = new RelayCommand(ExecuteCancelCommand);
        }

        //Commands Implementation
        private void ExecuteRegisterPatientCommand(object obj)
        {
            if (AreAllFieldsComplete())
            {
                RegisterPatientInfo.Instance.HabitsAndGoalsInfo = CreateGoalsInfo();

                RegistrationResultPage registrationResultPage = new RegistrationResultPage();
                NavigationManager.Instance.NavigateTo(registrationResultPage);
            }
            else
            {
                string title = "Campos incompletos";
                string message = "Por favor rellene todos los campos obligatorios, de lo contrario no podrá pasar a la siguiente etapa";
                DialogManager.ShowNotification(title, message);
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
        private bool AreAllFieldsComplete()
        {
            List<string> fields = new()
            {
                HealthGoals,
                SpecificNutritionalGoals,
                Expectations
            };

            return ValidationManager.AreAllFieldsComplete(fields);
        }

        private HabitsAndGoals CreateGoalsInfo()
        {
            HabitsAndGoals habitsAndGoals = new HabitsAndGoals();
            habitsAndGoals.Caffeine = Caffeine;
            habitsAndGoals.Alcohol = Alcohol;
            habitsAndGoals.Cigarette = Cigarette;
            habitsAndGoals.Drugs = Drugs;
            habitsAndGoals.HealthGoals = HealthGoals;
            habitsAndGoals.SpecificNutritionalGoals = SpecificNutritionalGoals;
            habitsAndGoals.Expectations = Expectations;
            habitsAndGoals.GeneralComment = GeneralComments;

            return habitsAndGoals;
        }



    }
}
