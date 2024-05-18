using HealthDivineSysClient.Helpers;
using HealthDivineSysClient.ViewModel.ViewModelTemplates;
using PlanManagementService;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.ServiceModel.Channels;
using System.Windows;
using System.Windows.Input;
using UserManagementService;

namespace HealthDivineSysClient.Modules.PlanManagementModule.CreateMealPlan.ViewModel
{
    public class CreatePlanViewModel : ViewModelBase
    {

        //Fields
        private string _mealType = "";
        private string _equivalences = "";
        private string _mealExamples = "";
        private MealPlan _mealPlan = new(); 
        private ObservableCollection<Meal> _meals = new ObservableCollection<Meal>();

        //Properties
        public string MealType
        {
            get => _mealType; 
            set
            {
                _mealType = value;
                OnPropertyChanged(nameof(MealType));
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
                _mealExamples = value;
                OnPropertyChanged(nameof(MealExamples));
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

        public ObservableCollection<Meal> Meals
        {
            get => _meals;
            set
            {
                _meals = value;
                OnPropertyChanged(nameof(Meals));
            }
        }

        //Commands
        public ICommand ReturnCommand { get; }
        public ICommand AddMealCommand { get; }
        public ICommand SavePlanCommand { get; }

        //Constructor
        public CreatePlanViewModel(int patientId)
        {
            ReturnCommand = new RelayCommand(ExecuteReturnCommand);
            AddMealCommand = new RelayCommand(ExecuteAddMealCommand);
            SavePlanCommand = new RelayCommand(ExecuteSavePlanCommand);

            MealPlan.IdPatient = patientId;
            MealPlan.Comments = "";
            MealPlan.PlanDescription = "";
            MealPlan.Recommendations = ""; 
            MealPlan.PlanDate = DateTime.Today; 

        }

        //Commands Implementation
        private void ExecuteReturnCommand(object obj)
        {
            NavigationManager.Instance.NavigateBack(); 
        }

        private void ExecuteAddMealCommand(object obj)
        {
            List<string> fields = new()
            {
                MealType,
                Equivalences,
                MealExamples
            };

            if (ValidationManager.AreAllFieldsComplete(fields))
            {
                Meal meal = new Meal();
                meal.MealExamples = MealExamples;
                meal.Equivalences = Equivalences;
                meal.MealType = MealType;

                
                Meals.Add(meal);

                MealExamples = "";
                Equivalences = "";
                MealType = "";
            }
            else
            {
                DialogManager.ShowNotification("Campos incompletos", "Por favor rellene todos los campos sobre la información de la comida"); 
            }
        }

        private void ExecuteSavePlanCommand(object obj)
        {

            if (IsInfoCorrect())
            {

                Meal[] meals = Meals.ToArray();
                MealPlan.Meals = meals; 

                SavePlan(); 
            }

        }

        //Methods
        private bool IsInfoCorrect()
        {

            List<string> fields = new()
            {
                MealPlan.Recommendations,
                MealPlan.PlanDescription,
                MealPlan.Comments
            };

            if (!ValidationManager.AreAllFieldsComplete(fields))
            {
                DialogManager.ShowNotification("Campos incompletos", "Por favor rellene todos los campos sobre el plan alimenticio");
                return false; 
            }

            if(Meals.Count == 0)
            {
                DialogManager.ShowNotification("No hay comidas", "Para crear un plan alimenticio por lo menos debe existir una comida registrada"); 
                return false; 
            }

            return true;    
        }

        private async void SavePlan()
        {
            PlanManagementServiceClient client = new();
            client.InnerChannel.OperationTimeout = TimeSpan.FromSeconds(10);

            try
            {
                int result = await client.AddNewMealPlanAsync(MealPlan);

                if (result != 0)
                {
                    DialogManager.ShowNotification("Registro exitoso", "El plan alimenticio fue guardado correctamente en la base de datos");
                }
                else
                {
                    DialogManager.ShowNotification("Error con la base de datos", "Lo sentimos, ocurrio un error al intentar guardar el plan alimenticio,estamos trabajando para solucionarlo, por favor intentelo más tarde");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString()); 
                DialogManager.ShowNotification("Error con el servidor", "Lo sentimos, ocurrio un error al conectarse con el servidor, revise su conexión a internet o intentelo más tarde");
            }
            finally
            {
                client.Close();
            }

            NavigationManager.Instance.NavigateBack();
        }
    }
}
