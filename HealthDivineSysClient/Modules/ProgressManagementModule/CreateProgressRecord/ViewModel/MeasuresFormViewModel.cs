using HealthDivineSysClient.Helpers;
using HealthDivineSysClient.Modules.UserManagementModule.ConsultPatient.View;
using HealthDivineSysClient.ViewModel.ViewModelTemplates;
using ProgressManagementService;
using SchedulingService;
using System;
using System.Diagnostics;
using System.Windows.Input;

namespace HealthDivineSysClient.Modules.ProgressManagementModule.CreateProgressRecord.ViewModel
{
    class MeasuresFormViewModel : ViewModelBase
    {
        //Atributes
        private Diagnosis diagnosis;
        //Fields
        private Measure _measure = new(); 
        private BodyCompositions _bodyCompositions = new();

        //Properties
        public Measure Measure
        {
            get => _measure;
            set
            {
                _measure = value;
                OnPropertyChanged(nameof(Measure));
            }
        }

        public BodyCompositions BodyCompositions
        {
            get => _bodyCompositions; 
            set
            {
                _bodyCompositions = value;
                OnPropertyChanged(nameof(BodyCompositions));
            }
        }

        //Commands
        public ICommand SaveRecordCommand { get; }

        //Constructor
        public MeasuresFormViewModel(Diagnosis diagnosis)
        {
            SaveRecordCommand = new RelayCommand(ExecuteSaveRecordCommand);

            this.diagnosis = diagnosis;
        }

        //Command Implementation
        private void ExecuteSaveRecordCommand(object obj)
        {
            BodyCompositions.IdPatient = diagnosis.PatientId; 
            Measure.IdPatient = diagnosis.PatientId;
            
            diagnosis.BodyComposition = BodyCompositions; 
            diagnosis.Measure = Measure;

            SaveDiagnosis(); 
        }

        //Methods
        private async void SaveDiagnosis()
        {
            ProgressManagementServiceClient client = new();
            client.InnerChannel.OperationTimeout = TimeSpan.FromSeconds(10);

            string title, message;
            try
            {
                int result = await client.AddNewDiagnosisAsync(diagnosis);

                if (result != 0)
                {
                    title = "Registro guardado correctamente";
                    message = "¡Exelente!¡Su registro ha sido guardado exitosamente! ";
                }
                else
                {
                    title = "Error al guardar";
                    message = "Lo sentimos, ocurrio un error al intentar guardar su registro en la base de datos,estamos trabajando para solucionarlo, por favor intentelo más tarde";
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                title = "Error de conexión";
                message = "Lo sentimos, ocurrio un error al conectarse con el servidor, revise su conexión a internet o intentelo más tarde";

            }

            DialogManager.ShowNotification(title, message);
            NavigationManager.Instance.NavigateTo(new PatientListPage());
        }

    }
}
