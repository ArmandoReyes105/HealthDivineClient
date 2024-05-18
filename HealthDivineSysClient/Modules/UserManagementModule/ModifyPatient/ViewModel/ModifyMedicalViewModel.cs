using HealthDivineSysClient.Helpers;
using HealthDivineSysClient.Modules.UserManagementModule.ConsultPatient.View;
using HealthDivineSysClient.ViewModel.ViewModelTemplates;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.DirectoryServices;
using System.Windows.Input;
using UserManagementService;

namespace HealthDivineSysClient.Modules.UserManagementModule.ModifyPatient.ViewModel
{
    public class ModifyMedicalViewModel : ViewModelBase
    {
        //Atributes
        private MedicalInformation medicalInformation = new();
        
        //Field
        private string _chronicDiseases = "";
        private string _hereditaryFamilyHitory = "";
        private string _gastrointestinalDiseases = "";
        private string _foodAllergies = "";
        private string _nonFoodAllergies = "";
        private string _surgicalHistory = "";
        private string _medications = "";
        private string _generalMedicalComments = "";

        //Properties
        public string ChronicalDiseases
        {
            get => _chronicDiseases;
            set
            {
                _chronicDiseases = value; OnPropertyChanged(nameof(ChronicalDiseases));
            }
        }

        public string HereditaryFamilyHistory
        {
            get => _hereditaryFamilyHitory;
            set
            {
                _hereditaryFamilyHitory = value; OnPropertyChanged(nameof(HereditaryFamilyHistory));
            }
        }

        public string GastrointestinalDiseases
        {
            get => _gastrointestinalDiseases;
            set
            {
                _gastrointestinalDiseases = value; OnPropertyChanged(nameof(GastrointestinalDiseases));
            }
        }

        public string FoodAllergies
        {
            get => _foodAllergies;
            set
            {
                _foodAllergies = value; OnPropertyChanged(nameof(FoodAllergies));
            }
        }

        public string NonFoodAllergies
        {
            get => _nonFoodAllergies; set
            {
                _nonFoodAllergies = value; OnPropertyChanged(nameof(NonFoodAllergies));
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
        public ICommand ReturnCommand { get; }
        public ICommand UpdateInfo { get; }

        //Constructor
        public ModifyMedicalViewModel(MedicalInformation medicalInfo) 
        {
            ReturnCommand = new RelayCommand(ExecuteReturnCommand);
            UpdateInfo = new RelayCommand(ExecuteUpdateInfoCommand); 

            medicalInformation = medicalInfo;

            LoadInfo(); 
        }

        //Commands Implementation
        private void ExecuteReturnCommand(object obj)
        {
            NavigationManager.Instance.NavigateBack(); 
        }

        private void ExecuteUpdateInfoCommand(object obj) 
        {
            if (IsDifferentInfo())
            {
                SaveChanges(); 
            }
            else
            {
                DialogManager.ShowNotification("Información identica", "La información que estás intentando guardar es idéntica a la que ya está almacenada. Por lo tanto, no se realizará ningún cambio.");
            }
        }

        //Methods
        private void LoadInfo()
        {
            ChronicalDiseases = medicalInformation.ChronicDiseases;
            HereditaryFamilyHistory = medicalInformation.HereditaryFamilyHistory;
            GastrointestinalDiseases = medicalInformation.GastrointestinalDiseases;
            FoodAllergies = medicalInformation.FoodAllergies;
            NonFoodAllergies = medicalInformation.NonFoodAllergies; 
            SurgicalHistory = medicalInformation.SurgicalHistory;
            Medications = medicalInformation.Medications;
            GeneralMedicalComments = medicalInformation.GeneralMedicalComments; 
        }

        private bool IsDifferentInfo()
        {
            bool result = false; 

            List<string> newInfo = new()
            {
                ChronicalDiseases, HereditaryFamilyHistory,
                GastrointestinalDiseases, FoodAllergies,
                NonFoodAllergies, Medications,
                SurgicalHistory, GeneralMedicalComments
            };

            List<string> currentInfo = new()
            {
                medicalInformation.ChronicDiseases, medicalInformation.HereditaryFamilyHistory,
                medicalInformation.GastrointestinalDiseases, medicalInformation.FoodAllergies,
                medicalInformation.NonFoodAllergies, medicalInformation.Medications,
                medicalInformation.SurgicalHistory, medicalInformation.GeneralMedicalComments
            }; 

            for(int i = 0; i < newInfo.Count; i++)
            {
                if (newInfo[i] != currentInfo[i])
                {
                    result = true; 
                    break; 
                }
            }

            return result; 
        }

        private MedicalInformation CreateMedicalInfo()
        {
            MedicalInformation medicalInfo = new MedicalInformation();
            medicalInfo.IdMedicalInformation = medicalInformation.IdMedicalInformation; 
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

        private async void SaveChanges()
        {
            UserManagementClient client = new();
            client.InnerChannel.OperationTimeout = TimeSpan.FromSeconds(10);

            try
            {
                MedicalInformation medicalInfo = CreateMedicalInfo();

                int result = await client.UpdateMedicalInformationAsync(medicalInfo);
                if (result != 0)
                {
                    DialogManager.ShowNotification("Actualización exitosa", "La actualización de la infomrción ah sido realizada correctamente");
                    //
                }
                else
                {
                    DialogManager.ShowNotification("Error con la base de datos", "Lo sentimos, ocurrio un error al intentar actualizar la información de la base de datos,estamos trabajando para solucionarlo, por favor intentelo más tarde");
                    NavigationManager.Instance.NavigateTo(new PatientListPage());
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine("Ocurrio un error: " + ex.ToString());
                DialogManager.ShowNotification("Error con el servidor", "Lo sentimos, ocurrio un error al conectarse con el servidor, revise su conexión a internet o intentelo más tarde");
                NavigationManager.Instance.NavigateTo(new PatientListPage());
            }
            finally
            {
                client.Close();
            }
        }
    }
}
