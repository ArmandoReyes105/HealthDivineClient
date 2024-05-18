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
    public class NutritionalFormViewModel : ViewModelBase
    {
        //fields
        private int _physicalActivityLevel = 3;
        private string _physicalActivityComment = "";
        private string _favoriteFoods = "";
        private string _nonFavoriteFoods = "";
        private string _dietarySupplements = "";
        private string _nutritionalFamiliarity = "";
        private string _foodEmotionalBehavior = "";
        private string _generalComments = "";

        //Properties
        public int PhysicalActivityLevel
        {
            get => _physicalActivityLevel; set
            {
                _physicalActivityLevel = value;
                OnPropertyChanged(nameof(PhysicalActivityLevel));
            }
        }

        public string PhysicalActivityComment
        {
            get => _physicalActivityComment; set
            {
                _physicalActivityComment = value;
                OnPropertyChanged(nameof(PhysicalActivityComment));
            }
        }

        public string FavoriteFoods
        {
            get => _favoriteFoods;
            set
            {
                _favoriteFoods = value;
                OnPropertyChanged(nameof(FavoriteFoods));
            }
        }

        public string NonFavoriteFoods
        {
            get => _nonFavoriteFoods;
            set
            {
                _nonFavoriteFoods = value;
                OnPropertyChanged(nameof(NonFavoriteFoods));
            }
        }

        public string DietarySupplements
        {
            get => _dietarySupplements;
            set
            {
                _dietarySupplements = value;
                OnPropertyChanged(nameof(DietarySupplements));
            }
        }

        public string NutritionalFamiliarity
        {
            get => _nutritionalFamiliarity; set
            {
                _nutritionalFamiliarity = value;
                OnPropertyChanged(nameof(NutritionalFamiliarity));
            }
        }

        public string FoodEmotionalBehavior
        {
            get => _foodEmotionalBehavior;
            set
            {
                _foodEmotionalBehavior = value;
                OnPropertyChanged(nameof(FoodEmotionalBehavior));
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
        public ICommand NextCommand { get; }
        public ICommand ChangeActivityLevelCommand { get; }
        public ICommand CancelCommand { get; }

        //Constructor
        public NutritionalFormViewModel()
        {
            NextCommand = new RelayCommand(ExecuteNextCommand);
            ChangeActivityLevelCommand = new RelayCommand(ExecuteChangeActivityLevelCommand);
            CancelCommand = new RelayCommand(ExecuteCancelCommand);
        }

        //Commands Implementation

        private void ExecuteNextCommand(object obj)
        {
            if (AreAllFieldsComplete())
            {
                RegisterPatientInfo.Instance.NutritionalInfo = CreateGeneralInfo();

                GoalsFormPage goalsForm = new GoalsFormPage();
                NavigationManager.Instance.NavigateTo(goalsForm);
            }
            else
            {
                string title = "Campos incompletos";
                string message = "Por favor rellene todos los campos obligatorios, de lo contrario no podrá pasar a la siguiente etapa";
                DialogManager.ShowNotification(title, message);
            }
        }

        private void ExecuteChangeActivityLevelCommand(object obj)
        {
            int activityLevel = int.Parse((string)obj);
            PhysicalActivityLevel = activityLevel;
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
                PhysicalActivityComment,
                FavoriteFoods,
                NonFavoriteFoods,
                NutritionalFamiliarity,
                FoodEmotionalBehavior,
            };

            return ValidationManager.AreAllFieldsComplete(fields);
        }

        private GeneralInformation CreateGeneralInfo()
        {
            GeneralInformation generalInformation = new GeneralInformation();
            generalInformation.PhysicalActivity = PhysicalActivityLevel;
            generalInformation.PhysicalActivityComments = PhysicalActivityComment;
            generalInformation.FavoriteFoods = FavoriteFoods;
            generalInformation.NonFavoriteFoods = NonFavoriteFoods;
            generalInformation.DietarySupplements = DietarySupplements;
            generalInformation.NutritionalFamiliarity = NutritionalFamiliarity;
            generalInformation.EatingEmotionalBehavior = FoodEmotionalBehavior;
            generalInformation.GeneralComments = GeneralComments;

            return generalInformation;
        }
    }
}
