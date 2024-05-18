using HealthDivineSysClient.Helpers;
using HealthDivineSysClient.ViewModel.ViewModelTemplates;
using SchedulingService;
using System;
using System.Diagnostics;
using UserManagementService;

namespace HealthDivineSysClient.ViewModel.UserControls
{
    public class ShortAppointmentViewModel : ViewModelBase
    {

        //Fields
        private string _startHour = "";
        private string _endHour = "";
        private string _name = "";

        //Properties
        public string StartHour
        {
            get => _startHour;
            set
            {
                _startHour = value;
                OnPropertyChanged(nameof(StartHour));
            }
        }

        public string EndHour
        {
            get => _endHour;
            set
            {
                _endHour = value;
                OnPropertyChanged(nameof(EndHour));
            }
        }

        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        //Constructor
        public ShortAppointmentViewModel(Appointment appointment) 
        {
            LoadInformation(appointment); 
        }

        //Methods
        private async void LoadInformation(Appointment appointment)
        {

            UserManagementClient client = new();
            client.InnerChannel.OperationTimeout = TimeSpan.FromSeconds(15);

            try
            {
                Patient patient = await client.GetPatientAsync(appointment.IdPatient);

                Name = patient.Person.Names + " " + patient.Person.FirstLastName + " " + patient.Person.SecondLastName;
                StartHour = appointment.StartTime.ToString(@"hh\:mm");
                EndHour = appointment.EndTime.ToString(@"hh\:mm");
            }
            catch (Exception exc)
            {
                Debug.WriteLine(exc.ToString());
                DialogManager.ShowNotification("Error con el servidor", "Lo sentimos, ocurrio un error al conectarse con el servidor, revise su conexión a internet o intentelo más tarde");
            }

        }
    }
}
