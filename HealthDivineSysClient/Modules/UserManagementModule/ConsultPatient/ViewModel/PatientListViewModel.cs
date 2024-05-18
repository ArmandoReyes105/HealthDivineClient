using HealthDivineSysClient.Helpers;
using HealthDivineSysClient.Modules.UserManagementModule.RegisterPatient.View;
using HealthDivineSysClient.ViewModel.UserControls;
using HealthDivineSysClient.ViewModel.ViewModelTemplates;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using UserManagementService;

namespace HealthDivineSysClient.Modules.UserManagementModule.ConsultPatient.ViewModel
{
    public class PatientListViewModel : ViewModelBase
    {
        //Atributes
        private Patient[] myPatients = Array.Empty<Patient>();

        //Fields
        private ObservableCollection<PatientCardViewModel> _patients = new();
        private Visibility _loadingVisibility = Visibility.Visible;
        private Visibility _listVisibility = Visibility.Collapsed;
        private Visibility _errorVisibility = Visibility.Collapsed;
        private Visibility _emptyVisibility = Visibility.Collapsed;
        private string _message = "";
        private string _searchText = "";
        private int _totalPatients = 0;
        private int _shownPatients = 0;

        //Properties
        public ObservableCollection<PatientCardViewModel> Patients
        {
            get => _patients;
            set
            {
                _patients = value;
                OnPropertyChanged(nameof(Patients));
            }
        }

        public Visibility LoadingVisibility
        {
            get => _loadingVisibility;
            set
            {
                _loadingVisibility = value;
                OnPropertyChanged(nameof(LoadingVisibility));
            }
        }

        public Visibility ListVisibility
        {
            get => _listVisibility;
            set
            {
                _listVisibility = value;
                OnPropertyChanged(nameof(ListVisibility));
            }
        }

        public Visibility ErrorVisibility
        {
            get => _errorVisibility;
            set
            {
                _errorVisibility = value;
                OnPropertyChanged(nameof(ErrorVisibility));
            }
        }

        public Visibility EmptyVisibility
        {
            get => _emptyVisibility;
            set
            {
                _emptyVisibility = value;
                OnPropertyChanged(nameof(EmptyVisibility));
            }
        }

        public string Message
        {
            get => _message;
            set
            {
                _message = value;
                OnPropertyChanged(nameof(Message));
            }
        }

        public string SearchText
        {
            get => _searchText;
            set
            {
                _searchText = value;
                OnPropertyChanged(nameof(SearchText));
                FilterPatients();
            }
        }

        public int TotalPatients
        {
            get => _totalPatients;
            set
            {
                _totalPatients = value;
                OnPropertyChanged(nameof(TotalPatients));
            }
        }

        public int ShownPatients
        {
            get => _shownPatients;
            set
            {
                _shownPatients = value;
                OnPropertyChanged(nameof(ShownPatients));
            }
        }

        //Commands
        public ICommand AddPatientCommand { get; }
        public ICommand TryAgainCommand { get; }

        //Constructor
        public PatientListViewModel()
        {
            AddPatientCommand = new RelayCommand(ExecuteAddPatientCommand);
            TryAgainCommand = new RelayCommand(ExecuteTryAgainCommand);

            InitializePatients();
        }

        //Commands Implementatio
        public void ExecuteAddPatientCommand(object obj)
        {
            NavigationManager.Instance.NavigateTo(new PersonalFormPage());
        }

        public void ExecuteTryAgainCommand(object obj)
        {
            ErrorVisibility = Visibility.Collapsed;
            LoadingVisibility = Visibility.Visible;
            InitializePatients();
        }

        //Methods
        private async void InitializePatients()
        {
            UserManagementClient client = new UserManagementClient();
            client.InnerChannel.OperationTimeout = TimeSpan.FromSeconds(15);

            try
            {
                myPatients = await client.GetMyPatientsAsync(1);

                if (myPatients != null)
                {
                    TotalPatients = myPatients.Length;
                    LoadPatients(myPatients);
                }
                else
                {
                    Message = "Lo sentimos, ocurrio un error al intentar recuperar los pacientes de la base de datos,estamos trabajando para solucionarlo, por favor intentelo más tarde";
                    LoadingVisibility = Visibility.Collapsed;
                    ErrorVisibility = Visibility.Visible;
                }
            }
            catch
            {
                Message = "Lo sentimos, ocurrio un error al conectarse con el servidor, revise su conexión a internet o intentelo más tarde";
                LoadingVisibility = Visibility.Collapsed;
                ErrorVisibility = Visibility.Visible;
            }
            finally
            {
                client.Close();
            }

        }

        private void LoadPatients(Patient[] patientList)
        {
            Patients.Clear();
            ShownPatients = patientList.Length;

            if (patientList.Length > 0)
            {
                LoadingVisibility = Visibility.Collapsed;
                EmptyVisibility = Visibility.Collapsed;
                ErrorVisibility = Visibility.Collapsed;
                ListVisibility = Visibility.Visible;

                foreach (var patient in patientList)
                {
                    PatientCardViewModel dataContext = new()
                    {
                        Patient = patient,
                        Lastname = patient.Person.FirstLastName + " " + patient.Person.SecondLastName
                    };
                    Patients.Add(dataContext);
                }
            }
            else
            {
                LoadingVisibility = Visibility.Collapsed;
                EmptyVisibility = Visibility.Visible;
                ErrorVisibility = Visibility.Collapsed;
                ListVisibility = Visibility.Visible;

                if (!string.IsNullOrWhiteSpace(SearchText))
                {
                    Message = "¡Oh, vaya! Parece que no encontramos ningún paciente que coincida con tu búsqueda.";
                }
                else
                {
                    Message = "¡Hola! Parece que aún no tienes pacientes registrados. No te preocupes, ¡puedes empezar a añadir pacientes en cualquier momento! ";
                }
            }
        }

        private void FilterPatients()
        {
            List<Patient> filterPatients = new();

            foreach (var patient in myPatients)
            {
                string fullname = patient.Person.Names + " " + patient.Person.FirstLastName + " " + patient.Person.SecondLastName;

                if (fullname.ToUpper().Contains(SearchText.ToUpper()))
                {
                    filterPatients.Add(patient);
                }
            }

            LoadPatients(filterPatients.ToArray());
        }
    }
}
