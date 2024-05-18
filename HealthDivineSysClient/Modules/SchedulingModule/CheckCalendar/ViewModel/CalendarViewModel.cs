using HealthDivineSysClient.Helpers;
using HealthDivineSysClient.ViewModel.ViewModelTemplates;
using SchedulingService;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace HealthDivineSysClient.Modules.SchedulingModule.CheckCalendar.ViewModel
{
    public class CalendarViewModel : ViewModelBase
    {

        //Fields
        private int _selectedYear = DateTime.Today.Year;
        private ObservableCollection<int> _nextYears = new();
        private string _selectedMonth = DateTime.Today.ToString("MMM").ToUpper();
        private ObservableCollection<string> _nextMonths = new();  
        private ObservableCollection<AppointmentControlViewModel> _appointments = new();

        //Properties
        public int SelectedYear
        {
            get => _selectedYear;
            set
            {
                _selectedYear = value;
                OnPropertyChanged(nameof(SelectedYear));
            }
        }

        public ObservableCollection<int> NextYears
        {
            get => _nextYears; 
            set
            {
                _nextYears = value;
                OnPropertyChanged(nameof(NextYears));
            }
        }

        public string SelectedMonth
        {
            get => _selectedMonth; 
            set
            {
                _selectedMonth = value;
                OnPropertyChanged(nameof(SelectedMonth));
            }
        }

        public ObservableCollection<string> NextMonths
        {
            get => _nextMonths; 
            set
            {
                _nextMonths = value;
                OnPropertyChanged(nameof(NextMonths));
            }
        }

        public ObservableCollection<AppointmentControlViewModel> Appointments
        {
            get => _appointments; 
            set
            {
                _appointments = value;
                OnPropertyChanged(nameof(Appointments));
            }
        }

        //Commands
        public ICommand ChangeYearCommand { get; }
        public ICommand ChangeMonthCommand { get; }

        //Constructor
        public CalendarViewModel()
        {
            ChangeYearCommand = new RelayCommand(ExecuteChangeYearCommand);
            ChangeMonthCommand = new RelayCommand(ExecuteChangeMonthCommand); 

            LoadYears();
            LoadMonths();
            LoadAppointments();
        }

        //Commands Implementation
        private void ExecuteChangeYearCommand(object obj)
        {
            string operation = (string)obj;
            switch (operation)
            {
                case "+":
                    SelectedYear++;
                    break;
                case "-": 
                    if(SelectedYear > DateTime.Today.Year)
                    {
                        SelectedYear--;
                    }
                    break;
            }

            LoadYears();
            LoadAppointments(); 
        }

        private void ExecuteChangeMonthCommand(object obj)
        {
            NextMonths.Clear();

            DateTime month = DateTime.ParseExact(SelectedMonth, "MMM", null);
            DateTime newMonth = new(); 

            string operation = (string)obj;
            switch (operation)
            {
                case "+":
                    newMonth = month.AddMonths(1);
                    break;
                case "-":
                    newMonth = month.AddMonths(-1);
                    break;
            }

            SelectedMonth = newMonth.ToString("MMM").ToUpper();
            LoadMonths();
            LoadAppointments(); 
        }

        //Methods
        private void LoadYears()
        {
            NextYears.Clear();

            NextYears.Add(SelectedYear + 1);
            NextYears.Add(SelectedYear + 2);
            NextYears.Add(SelectedYear + 3);
        }

        private void LoadMonths()
        {
            DateTime month = DateTime.ParseExact(SelectedMonth, "MMM", null);

            NextMonths.Add(month.AddMonths(1).ToString("MMM"));
            NextMonths.Add(month.AddMonths(2).ToString("MMM"));
            NextMonths.Add(month.AddMonths(3).ToString("MMM"));
            NextMonths.Add(month.AddMonths(4).ToString("MMM"));
            NextMonths.Add(month.AddMonths(5).ToString("MMM"));
            NextMonths.Add(month.AddMonths(6).ToString("MMM"));
            NextMonths.Add(month.AddMonths(7).ToString("MMM"));
            NextMonths.Add(month.AddMonths(8).ToString("MMM"));
            NextMonths.Add(month.AddMonths(9).ToString("MMM"));
            NextMonths.Add(month.AddMonths(10).ToString("MMM"));
            NextMonths.Add(month.AddMonths(11).ToString("MMM"));
        }

        public async void LoadAppointments()
        {
            Appointments.Clear(); 
            SchedulingClient client = new();
            client.InnerChannel.OperationTimeout = TimeSpan.FromSeconds(15);

            int nutritionistId = SessionManager.Instance.GetNutritionistId();
            int year = SelectedYear;
            int month = DateTime.ParseExact(SelectedMonth, "MMM", null).Month; 
            try
            {
                var appointments = await client.GetAppointmentsByMonthAsync(nutritionistId, month, year); 

                foreach(var appointment in appointments)
                {
                    AppointmentControlViewModel appointmentControl = new AppointmentControlViewModel(appointment, this);
                    Appointments.Add(appointmentControl); 
                }
            }
            catch
            {
                DialogManager.ShowNotification("Error con el servidor", "Lo sentimos, ocurrio un error al conectarse con el servidor, revise su conexión a internet o intentelo más tarde"); 
            }
        }

    }
}
