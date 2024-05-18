using HealthDivineSysClient.Helpers;
using HealthDivineSysClient.ViewModel.ViewModelTemplates;
using PlanManagementService;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace HealthDivineSysClient.Modules.PlanManagementModule.UpdateMealPlan.ViewModel
{
    public class UpdateMealViewModel : ViewModelBase
    {
        //Atributes
        private int mealId = 0; 
        private string auxMealType = "";
        private string auxEquivalences = "";
        private string auxMealExamples = ""; 

        //Fields
        private ObservableCollection<Meal> _meals = new();
        private MealPlan _mealPlan = new();
        private string _mealType = "";
        private string _equivalences = "";
        private string _mealExamples = "";

        //Properties
        public ObservableCollection<Meal> Meals
        {
            get => _meals;
            set
            {
                _meals = value; OnPropertyChanged(nameof(Meals)); 
            }
        }

        public MealPlan MealPlan
        {
            get => _mealPlan;
            set
            {
                _mealPlan = value; 
                OnPropertyChanged(nameof(MealPlan));
            }
        }

        public string MealType
        {
            get => _mealType; 
            set
            {
                _mealType = value; OnPropertyChanged(nameof(MealType));
            }
        }

        public string Equivalences
        {
            get => _equivalences; 
            set
            {
                _equivalences = value; 
                OnPropertyChanged(nameof(Equivalences));
            }
        }

        public string MealExamples
        {
            get => _mealExamples; 
            set
            {
                _mealExamples = value; OnPropertyChanged(nameof(MealExamples));
            }
        }

        //Commands
        public ICommand SetMealCommand { get; }
        public ICommand ReturnCommand { get; }
        public ICommand UpdateMealCommand { get;  }

        //Constructor
        public UpdateMealViewModel(int patientId)
        {
            ReturnCommand = new RelayCommand(ExecuteReturnCommand); 
            SetMealCommand = new RelayCommand(ExecuteSetMealCommand);
            UpdateMealCommand = new RelayCommand(ExecuteUpdateCommand); 

            LoadInformation(patientId);
        }

        //Commands Implementation
        private void ExecuteReturnCommand(object obj)
        {
            NavigationManager.Instance.NavigateBack();
        }

        private void ExecuteSetMealCommand(object obj)
        {
            
            foreach (var meal in Meals)
            {
                if(meal.IdMeal == (int)obj)
                {
                    mealId = meal.IdMeal; 
                    Equivalences = meal.Equivalences;
                    MealExamples = meal.MealExamples;
                    MealType = meal.MealType;

                    auxEquivalences = meal.Equivalences; 
                    auxMealExamples = meal.MealExamples;
                    auxMealType = meal.MealType; 
                    break; 
                }
            }
        }

        private void ExecuteUpdateCommand(object obj)
        {
            if(mealId != 0)
            {
                if (IsInfoCorrect())
                {
                    Meal meal = new Meal();
                    meal.IdMeal = mealId; 
                    meal.Equivalences = Equivalences;
                    meal.MealType = MealType;
                    meal.MealExamples = MealExamples;

                    SaveChanges(meal); 
                }
            }
            else
            {
                DialogManager.ShowNotification("Selecciona antes de modificar", "Para realizar modificaciones a una comida, por favor seleccione primero la comida deseada. "); 
            }
        }

        //Methods
        private async void LoadInformation(int patientId)
        {
            PlanManagementServiceClient planClient = new();
            planClient.InnerChannel.OperationTimeout = TimeSpan.FromSeconds(10);

            try
            {
                MealPlan = await planClient.GetLastMealPlanAsync(patientId);

                if (MealPlan != null)
                {
                    if (MealPlan.IdMealPlan == 0)
                    {
                        DialogManager.ShowNotification("Plan alimenticio inexistente", "Lo sentimos, pero al parecer aun no hay ningun plan asignado a este paciente");
                        NavigationManager.Instance.NavigateBack();
                    }
                    else
                    {
                        foreach (var meal in MealPlan.Meals)
                        {
                            Meals.Add(meal);
                        }
                    }
                }
                else
                {
                    DialogManager.ShowNotification("Error con la base de datos", "Lo sentimos, ocurrio un error al intentar recuperar la información de la base de datos,estamos trabajando para solucionarlo, por favor intentelo más tarde");
                    NavigationManager.Instance.NavigateBack();
                }
            }
            catch
            {
                DialogManager.ShowNotification("Error con el servidor", "Lo sentimos, ocurrio un error al conectarse con el servidor, revise su conexión a internet o intentelo más tarde");
                NavigationManager.Instance.NavigateBack();
            }
            finally
            {
                planClient.Close();
            }
        }

        private bool IsInfoCorrect()
        {
            bool diferentInfoResult = false;

            List<string> oldInfo = new()
            {
                auxMealType, auxMealExamples, auxEquivalences
            };

            List<string> newInfo = new()
            {
                MealType, MealExamples, Equivalences
            }; 

            for (int i = 0; i < oldInfo.Count; i++)
            {
                if (oldInfo[i] != newInfo[i])
                {
                    diferentInfoResult = true;
                    break; 
                }
            }

            if(diferentInfoResult == false)
            {
                DialogManager.ShowNotification("Información identica", "La información que desea guardar es identica, por lo tanto no se realizara ningun cambio");
                return false; 
            }

            if (!ValidationManager.AreAllFieldsComplete(newInfo))
            {
                DialogManager.ShowNotification("Campos incompletos", "Todos los campos deben estar llenos");
                return false; 
            }

            return true; 
        }

        private async void SaveChanges(Meal meal)
        {
            PlanManagementServiceClient client = new();
            client.InnerChannel.OperationTimeout = TimeSpan.FromSeconds(10);

            try
            {
                int result = await client.UpdateMealAsync(meal);

                if (result != 0)
                {
                   DialogManager.ShowNotification("Actualización correcta", "La comida ah sido actualizada correctamente");
                   NavigationManager.Instance.NavigateBack();
                }
                else
                {
                    DialogManager.ShowNotification("Error con la base de datos", "Lo sentimos, ocurrio un error al intentar recuperar la información de la base de datos,estamos trabajando para solucionarlo, por favor intentelo más tarde");
                    NavigationManager.Instance.NavigateBack();
                }
            }
            catch
            {
                DialogManager.ShowNotification("Error con el servidor", "Lo sentimos, ocurrio un error al conectarse con el servidor, revise su conexión a internet o intentelo más tarde");
                NavigationManager.Instance.NavigateBack();
            }
            finally
            {
                client.Close();
            }
        }

    }
}
