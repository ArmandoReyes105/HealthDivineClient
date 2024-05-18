using HealthDivineSysClient.Helpers;
using HealthDivineSysClient.Modules.UserManagementModule.ConsultPatient.View;
using HealthDivineSysClient.ViewModel.ViewModelTemplates;
using SchedulingService;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Windows;
using System;
using UserManagementService;
using HealthDivineSysClient.Modules.SchedulingModule.CheckCalendar.View;
using HealthDivineSysClient.ViewModel.UserControls;
using System.Diagnostics;

namespace HealthDivineSysClient.Modules.SchedulingModule.ModifyAppointment.ViewModel
{
    public class ModifyAppointmentViewModel : ViewModelBase
    {
        //Atributes
        private List<Appointment> DayAppointments = new(); 

        //Fields
        private ObservableCollection<ShortAppointmentViewModel> _appointments = new();
        private Visibility _appointmentMessageVisibility = Visibility.Collapsed;
        private string _errorMessage = "";
        private string _lottie = "pack://application:,,,/Resources/Images/Loading_Animation.json";
        private string _selectedDate = "";
        private string _fullName = "";
        private string _startHour = "";
        private string _endHour = "";
        private string _appointmentMinutes = "0";
        private Patient? _patient;
        private Appointment? _currentAppointment; 

        //Properties
        public ObservableCollection<ShortAppointmentViewModel> Appointments
        {
            get => _appointments;
            set
            {
                _appointments = value;
                OnPropertyChanged(nameof(Appointment));
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

        public Appointment CurrentAppointment
        {
            get => _currentAppointment; 
            set
            {
                _currentAppointment = value;
                OnPropertyChanged(nameof(CurrentAppointment));
            }
        }

        //Commands
        public ICommand ScheduleCommand { get; }
        public ICommand CancelCommand { get; }

        //Constructor
        public ModifyAppointmentViewModel(Patient patient, Appointment appointment)
        {
            ScheduleCommand = new RelayCommand(ExecuteScheduleCommand);
            CancelCommand = new RelayCommand(ExecuteCancelCommand);

            LoadInformation(patient, appointment); 
        }

        //Commands Implementations
        private void ExecuteScheduleCommand(object obj)
        {
            if (AreFieldsCorrect())
            {
                if (int.Parse(AppointmentMinutes) > 120)
                {
                    bool confirmation = DialogManager.ShowConfirmation(
                        "¿Seguro que desea agendar la cita?",
                        "¡Hola! Parece que la duración de tu cita excede las dos horas. ¿Estás seguro/a de que deseas agendarla?",
                        "Agendar", "Cancelar");
                    if (confirmation)
                    {
                        UpdateAppointment();
                    }
                }
                else
                {
                    UpdateAppointment();
                }
            }
        }

        private void ExecuteCancelCommand(object obj)
        {
            NavigationManager.Instance.NavigateTo(new CalendarPage());
        }

        //Methods
        private async void ShowAppointments()
        {
            SchedulingClient client = new SchedulingClient();
            client.InnerChannel.OperationTimeout = TimeSpan.FromSeconds(15);

            Appointments.Clear(); 

            try
            {
                var myAppointments = await client.GetAppointmentsByDayAsync(DateTime.ParseExact(SelectedDate, "dd/MM/yyyy", null), SessionManager.Instance.GetNutritionistId());

                if (myAppointments != null)
                {
                    if (myAppointments.Length != 0)
                    {
                        AppointmentMessageVisibility = Visibility.Collapsed;
                        foreach (var appointment in myAppointments)
                        {
                            if (appointment.IdAppointment != CurrentAppointment.IdAppointment)
                            {
                                Appointments.Add(new ShortAppointmentViewModel(appointment));
                                DayAppointments.Add(appointment);
                            }
                        }
                    }
                    else { ShowAppointmentPanel("NoResults"); }
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
            if (SelectedDate != "")
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
            if (ValidationManager.IsHourCorrect(StartHour) && ValidationManager.IsHourCorrect(EndHour))
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
            List<string> fields = new List<string> { SelectedDate, StartHour, EndHour };

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

            foreach (var appointment in DayAppointments)
            {
                if (currentStart < appointment.EndTime && currentStart > appointment.StartTime || currentEnd > appointment.StartTime && currentEnd < appointment.EndTime)
                {
                    result = false;
                    break;
                }
            }

            return result;
        }

        private async void UpdateAppointment()
        {
            CurrentAppointment.StartTime = new TimeSpan(ConvertHour(StartHour).Hour, ConvertHour(StartHour).Minute, 0);
            CurrentAppointment.EndTime = new TimeSpan(ConvertHour(EndHour).Hour, ConvertHour(EndHour).Minute, 0);
            CurrentAppointment.AppointmentDate = DateTime.ParseExact(SelectedDate, "dd/MM/yyyy", null);
            CurrentAppointment.IdPatient = Patient.IdPatient;
            CurrentAppointment.IdNutritionist = SessionManager.Instance.GetNutritionistId();

            SchedulingClient client = new SchedulingClient();
            client.InnerChannel.OperationTimeout = TimeSpan.FromSeconds(10);

            string title, message;
            try
            {
                int result = await client.UpdateAppointmentAsync(CurrentAppointment);

                if (result != 0)
                {
                    title = "Cita reprogramada exitosamente";
                    message = "¡Exelente!¡Su cita ha sido reprogramada exitosamente! ";
                }
                else
                {
                    title = "Error al guardar";
                    message = "Lo sentimos, ocurrio un error al intentar reprogramar su cita en la base de datos,estamos trabajando para solucionarlo, por favor intentelo más tarde";
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine("Ocurrio un error: " + ex);
                title = "Error de conexión";
                message = "Lo sentimos, ocurrio un error al conectarse con el servidor, revise su conexión a internet e intentelo más tarde";

            }

            DialogManager.ShowNotification(title, message);
            NavigationManager.Instance.NavigateTo(new CalendarPage());

        }

        private void LoadInformation(Patient patient, Appointment appointment)
        {
            Patient = patient;
            FullName = Patient.Person.Names + " " + Patient.Person.FirstLastName + " " + Patient.Person.SecondLastName;

            CurrentAppointment = appointment;
            SelectedDate = CurrentAppointment.AppointmentDate.ToShortDateString();
            StartHour = CurrentAppointment.StartTime.ToString(@"hh\:mm");
            EndHour = CurrentAppointment.EndTime.ToString(@"hh\:mm");
        }
    }
}
