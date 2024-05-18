using HealthDivineSysClient.Helpers;
using HealthDivineSysClient.ViewModel.ViewModelTemplates;
using HealthDivineSysClient.Modules.UserManagementModule.ConsultPatient.View; 
using System.Windows.Input;
using UserManagementService;
using System.Collections.ObjectModel;
using SchedulingService;
using System;
using System.Windows;
using System.Collections.Generic;

namespace HealthDivineSysClient.Modules.SchedulingModule.ScheduleAppointment.ViewModel
{
    public class ScheduleAppointmentViewModel : ViewModelBase
    {
        //Fields
        private ObservableCollection<Appointment> _appointments = new ObservableCollection<Appointment>();
        private ObservableCollection<AppointmentInfo> _appointmentsInfo = new ObservableCollection<AppointmentInfo>();
        private Visibility _appointmentMessageVisibility = Visibility.Collapsed;
        private string _errorMessage = "";
        private string _lottie = "pack://application:,,,/Resources/Images/Loading_Animation.json";
        private string _selectedDate = "";
        private string _fullName = "";
        private string _startHour = "";
        private string _endHour = "";
        private string _appointmentMinutes = "0"; 
        private Patient? _patient; 

        //Properties
        public ObservableCollection<Appointment> Appointments
        {
            get => _appointments;
            set
            {
                _appointments = value;
                OnPropertyChanged(nameof(Appointment));
            }
        }

        public ObservableCollection<AppointmentInfo> AppointmentsInfo
        {
            get => _appointmentsInfo;
            set
            {
                _appointmentsInfo = value;
                OnPropertyChanged(nameof(AppointmentInfo));
            }
        }

        public Visibility AppointmentMessageVisibility
        {
            get => _appointmentMessageVisibility; 
            set
            {
                _appointmentMessageVisibility = value;
                OnPropertyChanged(nameof(AppointmentMessageVisibility));
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

        public string Lottie
        {
            get => _lottie; 
            set
            {
                _lottie = value;
                OnPropertyChanged(nameof(Lottie)); 
            }
        }

        public string SelectedDate
        {
            get => _selectedDate; 
            set
            {
                _selectedDate = value;
                OnPropertyChanged(nameof(SelectedDate));
                ValidateDate(); 
            }
        }

        public string FullName
        {
            get => _fullName; 
            set
            {
                _fullName = value;
                OnPropertyChanged(nameof(FullName));
            }
        }

        public string StartHour
        {
            get => _startHour;
            set
            {
                _startHour = value;
                OnPropertyChanged(nameof(StartHour));
                CalculateMinutes();
            }
        }

        public string EndHour
        {
            get => _endHour; 
            set
            {
                _endHour = value;
                OnPropertyChanged(nameof(EndHour));
                CalculateMinutes();
            }
        }

        public string AppointmentMinutes
        {
            get => _appointmentMinutes; 
            set
            {
                _appointmentMinutes = value;
                OnPropertyChanged(nameof(AppointmentMinutes));
            }
        }

        public Patient Patient
        {
            get => _patient; 
            set
            {
                _patient = value;
                OnPropertyChanged(nameof(Patient));
            }
        }

        //Commands
        public ICommand ScheduleCommand { get;  }
        public ICommand CancelCommand { get;  }

        //Constructor
        public ScheduleAppointmentViewModel(Patient patient) 
        {
            ScheduleCommand = new RelayCommand(ExecuteScheduleCommand);
            CancelCommand = new RelayCommand(ExecuteCancelCommand); 

            Patient = patient;
            FullName = Patient.Person.Names + " " + Patient.Person.FirstLastName + " " + Patient.Person.SecondLastName; 
        }

        //Commands Implementations
        private void ExecuteScheduleCommand(object obj)
        {
            if (AreFieldsCorrect())
            {
                if(int.Parse(AppointmentMinutes) > 120)
                {
                    bool confirmation = DialogManager.ShowConfirmation(
                        "¿Seguro que desea agendar la cita?",
                        "¡Hola! Parece que la duración de tu cita excede las dos horas. ¿Estás seguro/a de que deseas agendarla?",
                        "Agendar", "Cancelar"); 
                    if (confirmation)
                    {
                        SaveAppointment(); 
                    }
                }
                else
                {
                    SaveAppointment();
                }
            }
        }

        private void ExecuteCancelCommand(object obj)
        {
            NavigationManager.Instance.NavigateTo(new PatientListPage()); 
        }

        //Methods
        private async void ShowAppointments()
        {

            SchedulingClient client = new SchedulingClient();
            client.InnerChannel.OperationTimeout = TimeSpan.FromSeconds(15);
            AppointmentsInfo.Clear();
            
            try
            {
                var myAppointments = await client.GetAppointmentsByDayAsync(DateTime.ParseExact(SelectedDate, "dd/MM/yyyy", null) ,SessionManager.Instance.GetNutritionistId());

                if (myAppointments != null)
                {
                    if(myAppointments.Length != 0)
                    {
                        AppointmentMessageVisibility = Visibility.Collapsed; 
                        foreach (var appointment in myAppointments)
                        {
                            Appointments.Add(appointment);
                            AppointmentInfo info = new AppointmentInfo();
                            info.StartHour = appointment.StartTime.ToString(@"hh\:mm");
                            info.EndHour = appointment.EndTime.ToString(@"hh\:mm"); 
                            AppointmentsInfo.Add(info); 
                        }
                    }
                    else ShowAppointmentPanel("NoResults"); 
                }
                else
                {
                    string title = "Error al recuperar";
                    string message = "Lo sentimos, ocurrio un error al intentar recuperar sus citas de la base de datos,estamos trabajando para solucionarlo, por favor intentelo más tarde";
                    DialogManager.ShowNotification(title, message);
                    NavigationManager.Instance.NavigateTo(new PatientListPage());
                }
            }
            catch
            {
                string title = "Error de conexión";
                string message = "Lo sentimos, ocurrio un error al conectarse con el servidor, revise su conexión a internet e intentelo más tarde"; 
                DialogManager.ShowNotification(title, message);
                NavigationManager.Instance.NavigateTo(new PatientListPage()); 
            }
            finally
            {
                client.Close();
            }

        }

        private void ValidateDate()
        {
            if(SelectedDate != "")
            {
                DateTime date = DateTime.ParseExact(SelectedDate, "dd/MM/yyyy", null);

                if (DateTime.Today > date)
                {
                    string title = "Fecha invalida";
                    string message = "Por favor, selecciona una fecha posterior a la fecha actual. La fecha actual es " + DateTime.Today.ToShortDateString();
                    DialogManager.ShowNotification(title, message);
                    SelectedDate = "";
                }
                else
                {
                    ErrorMessage = "";
                    ShowAppointments();
                    ShowAppointmentPanel("Loading");
                }
            }
        }

        private void ShowAppointmentPanel(string option)
        {
            AppointmentMessageVisibility = Visibility.Visible; 

            switch (option)
            {
                case "Loading":
                    Lottie = "pack://application:,,,/Resources/Images/Loading_Animation.json";
                    ErrorMessage = "Espere un momento en lo que recuperamos la citas de este dia."; 
                    break;
                case "NoResults":
                    Lottie = "pack://application:,,,/Resources/Images/Search_Animation.json";
                    ErrorMessage = "¡Oh, vaya! Al parecer no hay citas agendadas para este día"; 
                    break; 
            }

        }

        private void CalculateMinutes()
        {
            if(ValidationManager.IsHourCorrect(StartHour) && ValidationManager.IsHourCorrect(EndHour))
            {
                DateTime start = ConvertHour(StartHour);
                DateTime end = ConvertHour(EndHour);

                TimeSpan minutes = end - start;
                AppointmentMinutes = minutes.TotalMinutes.ToString();
            }
            else
            {
                AppointmentMinutes = "--"; 
            }
        }

        private static DateTime ConvertHour(string hour)
        {
            DateTime result;

            if (hour.Length == 4)
                result = DateTime.ParseExact(hour, "H:mm", System.Globalization.CultureInfo.InvariantCulture);
            else
                result = DateTime.ParseExact(hour, "HH:mm", System.Globalization.CultureInfo.InvariantCulture);

            return result;
        } 

        private bool AreFieldsCorrect()
        {
            List<string> fields = new List<string> { SelectedDate, StartHour, EndHour}; 

            if (!ValidationManager.AreAllFieldsComplete(fields))
            {
                DialogManager.ShowNotification("Campos vacios", "Para poder agendar su cita es necesario llenar todos los campos");
                return false; 
            }

            if (!ValidationManager.IsHourCorrect(StartHour) || !ValidationManager.IsHourCorrect(EndHour))
            {
                string title = "Horas incorrectas";
                string message = "Asegúrate de utilizar el formato correcto ('HH:mm') y de que los valores estén dentro del rango permitido. Las horas deben estar entre 0 y 23, y los minutos entre 0 y 59.";
                DialogManager.ShowNotification(title, message); 
                return false; 
            }

            DateTime startHour = ConvertHour(StartHour);
            DateTime endHour = ConvertHour(EndHour);

            if (startHour > endHour)
            {
                DialogManager.ShowNotification("Horario invalido", "La hora de inicio debe ser posterior a la hora de termino de la cita"); 
                return false;
            }

            if (!IsScheduleCorrect())
            {
                string title = "Horario truncado";
                string message = "Lo sentimos, la hora seleccionada para su cita interfiere con el horario de otra cita ya programada. Por favor, elija una hora diferente para evitar conflictos de horario.";
                DialogManager.ShowNotification(title, message); 
                return false;
            }

            return true; 
        }

        private bool IsScheduleCorrect()
        {
            bool result = true;

            TimeSpan currentStart = new TimeSpan(ConvertHour(StartHour).Hour, ConvertHour(StartHour).Minute, 0);
            TimeSpan currentEnd = new TimeSpan(ConvertHour(EndHour).Hour, ConvertHour(EndHour).Minute, 0);

            foreach(var appointment in Appointments)
            {
                if (currentStart < appointment.EndTime && currentStart > appointment.StartTime || currentEnd > appointment.StartTime && currentEnd < appointment.EndTime) 
                {
                    result = false;
                    break; 
                }
            }

            return result; 
        }

        private async void SaveAppointment()
        {
            Appointment appointment = new Appointment();
            appointment.StartTime = new TimeSpan(ConvertHour(StartHour).Hour, ConvertHour(StartHour).Minute, 0);
            appointment.EndTime = new TimeSpan(ConvertHour(EndHour).Hour, ConvertHour(EndHour).Minute, 0);
            appointment.AppointmentDate = DateTime.ParseExact(SelectedDate, "dd/MM/yyyy", null);
            appointment.IdPatient = Patient.IdPatient;
            appointment.IdNutritionist = SessionManager.Instance.GetNutritionistId();

            SchedulingClient client = new SchedulingClient();
            client.InnerChannel.OperationTimeout = TimeSpan.FromSeconds(10);

            string title, message; 
            try
            {
                int result =  await client.CreateAppointmentAsync(appointment);

                if(result != 0)
                {
                    title = "Cita agendada exitosamente";
                    message = "¡Exelente!¡Su cita ha sido guardada exitosamente! "; 
                }
                else
                {
                    title = "Error al recuperar";
                    message = "Lo sentimos, ocurrio un error al intentar guardar su cita en la base de datos,estamos trabajando para solucionarlo, por favor intentelo más tarde";
                }

            }catch(Exception ex)
            {
                title = "Error de conexión";
                message = "Lo sentimos, ocurrio un error al conectarse con el servidor, revise su conexión a internet e intentelo más tarde";
                
            }

            DialogManager.ShowNotification(title, message);
            NavigationManager.Instance.NavigateTo(new PatientListPage());

        }

        //Class
        public class AppointmentInfo
        {
            public string? StartHour { get; set; }
            public string? EndHour { get; set; }
            public string? Name { get; set; }
        }
    }
}
