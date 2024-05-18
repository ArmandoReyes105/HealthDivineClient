using HealthDivineSysClient.Helpers;
using HealthDivineSysClient.Modules.ProgressManagementModule.CreateProgressRecord.View;
using HealthDivineSysClient.Modules.UserManagementModule.ConsultPatient.View;
using HealthDivineSysClient.ViewModel.ViewModelTemplates;
using ProgressManagementService;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Input;

namespace HealthDivineSysClient.Modules.ProgressManagementModule.ModifyProgressRecord.ViewModel
{
    public class ModifyDiagnosisViewModel : ViewModelBase
    {
        //Atributes
        private int patientId = 0;
        private Diagnosis auxDiagnosis = new(); 

        //Fields
        private Diagnosis _diagnosis = new();

        //Properties
        public Diagnosis Diagnosis
        {
            get => _diagnosis;
            set
            {
                _diagnosis = value; OnPropertyChanged(nameof(Diagnosis));
            }
        }

        //Commands
        public ICommand UpdateCommand { get; }
        public ICommand ReturnCommand { get; }

        //Constructor
        public ModifyDiagnosisViewModel(int id)
        {
            UpdateCommand = new RelayCommand(ExecuteUpdateCommand);
            ReturnCommand = new RelayCommand(ExecuteReturnCommand);

            patientId = id;
            Diagnosis.PatientId = patientId;

            LoadInformation(); 
        }

        //Commands Methods
        private void ExecuteUpdateCommand(object obj)
        {
            if (AreFieldsComplete())
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
            else
            {
                DialogManager.ShowNotification("Campos incompletos", "Para poder pasar a la siguiente etapa todos los campos deben estar completos");
            }
        }

        private void ExecuteReturnCommand(object obj)
        {
            NavigationManager.Instance.NavigateBack();
        }

        //Methods
        private bool AreFieldsComplete()
        {
            List<string> fields = new()
            {
                Diagnosis.PhysicalActivity,
                Diagnosis.PhysicalPerception,
                Diagnosis.StomachUpset,
                Diagnosis.Dream,
                Diagnosis.EnergyLevel,
                Diagnosis.StressLevel,
                Diagnosis.Feeding,
                Diagnosis.Appetite,
                Diagnosis.WaterConsumption,
                Diagnosis.SubstanceUse,
                Diagnosis.GeneralComments
            };

            return ValidationManager.AreAllFieldsComplete(fields);
        }

        private bool IsDifferentInfo()
        {
            bool result = false;

            List<string> newInfo = new()
            {
                Diagnosis.PhysicalActivity,
                Diagnosis.PhysicalPerception,
                Diagnosis.StomachUpset,
                Diagnosis.Dream,
                Diagnosis.EnergyLevel,
                Diagnosis.StressLevel,
                Diagnosis.Feeding,
                Diagnosis.Appetite,
                Diagnosis.WaterConsumption,
                Diagnosis.SubstanceUse,
                Diagnosis.GeneralComments
            };

            List<string> currentInfo = new()
            {
                auxDiagnosis.PhysicalActivity,
                auxDiagnosis.PhysicalPerception,
                auxDiagnosis.StomachUpset,
                auxDiagnosis.Dream,
                auxDiagnosis.EnergyLevel,
                auxDiagnosis.StressLevel,
                auxDiagnosis.Feeding,
                auxDiagnosis.Appetite,
                auxDiagnosis.WaterConsumption,
                auxDiagnosis.SubstanceUse,
                auxDiagnosis.GeneralComments
            };

            for (int i = 0; i < newInfo.Count; i++)
            {
                if (newInfo[i] != currentInfo[i])
                {
                    result = true;
                    break;
                }
            }

            return result;
        }

        private async void LoadInformation()
        {
            ProgressManagementServiceClient client = new();
            client.InnerChannel.OperationTimeout = TimeSpan.FromSeconds(10);

            string title, message;
            try
            {
                Diagnosis result = await client.GetLastDiagnosisAsync(patientId);

                if(result != null)
                {
                    if(result.IdDiagnosis != 0)
                    {
                        auxDiagnosis.IdDiagnosis = result.IdDiagnosis;
                        auxDiagnosis.PhysicalActivity = result.PhysicalActivity;
                        auxDiagnosis.StomachUpset = result.StomachUpset;
                        auxDiagnosis.PhysicalPerception = result.PhysicalPerception;
                        auxDiagnosis.Dream = result.Dream;
                        auxDiagnosis.EnergyLevel = result.EnergyLevel;
                        auxDiagnosis.StressLevel = result.StressLevel;
                        auxDiagnosis.Feeding = result.Feeding;
                        auxDiagnosis.Appetite = result.Appetite;
                        auxDiagnosis.WaterConsumption = result.WaterConsumption;
                        auxDiagnosis.SubstanceUse = result.SubstanceUse;
                        auxDiagnosis.GeneralComments = result.GeneralComments;

                        Diagnosis = result; 
                    }
                    else
                    {
                        title = "Aun no tiene registros";
                        message = "Lo sentimos, pero para modificar el ultimo registro de progreso primero debe registrar uno, actualmente no tiene ninguno";
                        DialogManager.ShowNotification(title, message);
                        NavigationManager.Instance.NavigateBack();
                    }
                }
                else
                {
                    title = "Error con la base de datos";
                    message = "Lo sentimos, ocurrio un error al recuperar el registro de la base de datos, estamos intentando solucionarlo, por favor intentelo más tarde";
                    DialogManager.ShowNotification(title, message);
                    NavigationManager.Instance.NavigateBack();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                title = "Error de conexión";
                message = "Lo sentimos, ocurrio un error al conectarse con el servidor, revise su conexión a internet o intentelo más tarde";
                DialogManager.ShowNotification(title, message);
                NavigationManager.Instance.NavigateBack();
            }

        }

        private async void SaveChanges()
        {
            ProgressManagementServiceClient client = new();
            client.InnerChannel.OperationTimeout = TimeSpan.FromSeconds(10);

            string title, message;
            try
            {
                int result = await client.UpdateDiagnosisAsync(Diagnosis);

                if (result != 0)
                {
                    
                    title = "Actualización exitosa";
                    message = "La actualización de la infomrción ah sido realizada correctamente";
                }
                else
                {
                    title = "Error con la base de datos";
                    message = "Lo sentimos, ocurrio un error al actualizar el registro de la base de datos, estamos intentando solucionarlo, por favor intentelo más tarde";
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                title = "Error de conexión";
                message = "Lo sentimos, ocurrio un error al conectarse con el servidor, revise su conexión a internet o intentelo más tarde"; 
            }

            DialogManager.ShowNotification(title, message);
            NavigationManager.Instance.NavigateBack();
        }
    }
}
