using HealthDivineSysClient.Helpers;
using HealthDivineSysClient.Modules.SchedulingModule.ModifyAppointment.View;
using HealthDivineSysClient.ViewModel.ViewModelTemplates;
using SchedulingService;
using System;
using System.Windows.Input;
using UserManagementService;

namespace HealthDivineSysClient.Modules.SchedulingModule.CheckCalendar.ViewModel
{
    public class AppointmentControlViewModel : ViewModelBase
    {
        //Atributes
        private Appointment appointment;
        private Patient? patient = null; 
        private CalendarViewModel calendarViewModel; 

        //Fields
        private string _startHour = "";
        private string _endHour = "";
        private string _date = "";
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

        public string Date
        {
            get => _date;
            set
            {
                _date = value;
                OnPropertyChanged(nameof(Date));
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

        //Commands
        public ICommand DeleteAppointmentCommand { get; } 
        public ICommand ModifyAppointmentCommand { get; }

        //Constructor
        public AppointmentControlViewModel(Appointment appointment, CalendarViewModel viewModel)
        {
            DeleteAppointmentCommand = new RelayCommand(ExecuteDeleteAppointmentCommand);
            ModifyAppointmentCommand = new RelayCommand(ExecuteModifyAppointmentCommand); 

            this.appointment = appointment;
            this.calendarViewModel = viewModel;

            LoadInformation(appointment); 
        }

        //CommandsImplementation
        private void ExecuteDeleteAppointmentCommand(object obj)
        {
            string title = "¿Seguro que desea eliminar la cita?";
            string message = "Esta acción no se puede desaser, ¿Seguro que desea continuar?" + appointment.IdAppointment; 
            bool confirmation = DialogManager.ShowConfirmation(title, message, "Eliminar", "Cancelar"); 

            if(confirmation == true)
            {
                DeleteAppointment(); 
            }
        }

        private void ExecuteModifyAppointmentCommand(object obj)
        {
            if(patient != null)
            {
                NavigationManager.Instance.NavigateTo(new ModifyAppointmentPage(appointment, patient));
            }
        }

        //Methods
        private async void LoadInformation(Appointment appointment)
        {

            UserManagementClient client = new();
            client.InnerChannel.OperationTimeout = TimeSpan.FromSeconds(15);

            try 
            {
                Patient patient = await client.GetPatientAsync(appointment.IdPatient);
                this.patient = patient; 

                Name = patient.Person.Names + " " + patient.Person.FirstLastName + " " + patient.Person.SecondLastName;
                StartHour = appointment.StartTime.ToString(@"hh\:mm");
                EndHour = appointment.EndTime.ToString(@"hh\:mm");
                Date = appointment.AppointmentDate.ToLongDateString();
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.ToString());
                DialogManager.ShowNotification("Error con el servidor", "Lo sentimos, ocurrio un error al conectarse con el servidor, revise su conexión a internet o intentelo más tarde"); 
            }

        }

        private async void DeleteAppointment()
        {
            SchedulingClient client = new();
            client.InnerChannel.OperationTimeout = TimeSpan.FromSeconds(10);

            try
            {
                int result = await client.DeleteAppointmentAsync(appointment.IdAppointment);

                if (result == 1)
                {
                    DialogManager.ShowNotification("Eliminación exitosa", "La cita ha sido cancelada exitosamente");
                    calendarViewModel.LoadAppointments(); 
                }
                else
                {
                    DialogManager.ShowNotification("Error con la base de datos", "Lo sentimos, ocurrio un error al intentar eliminar la cita de la base de datos,estamos trabajando para solucionarlo, por favor intentelo más tarde");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                DialogManager.ShowNotification("Error con el servidor", "Lo sentimos, ocurrio un error al conectarse con el servidor, revise su conexión a internet o intentelo más tarde");
            }
        }
    }
}
