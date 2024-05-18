using HealthDivineSysClient.Helpers;
using HealthDivineSysClient.Modules.UserManagementModule.ConsultPatient.View;
using HealthDivineSysClient.ViewModel.ViewModelTemplates;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows.Input;
using UserManagementService;

namespace HealthDivineSysClient.Modules.UserManagementModule.ModifyPatient.ViewModel
{
    public class ModifyPatientViewModel : ViewModelBase
    {
        //Fields
        private Patient _patient = new(); 
        private string _phone = "";
        private string _height = "";
        private string _birthday = "";
        private string _gender = "M";

        //Properties
        public Patient Patient
        {
            get => _patient;
            set { _patient = value; OnPropertyChanged(nameof(Patient)); }
        }

        public string Phone
        {
            get => _phone;
            set { _phone = value; FormatPhone(); OnPropertyChanged(nameof(Phone)); }
        }

        public string Height
        {
            get => _height;
            set
            {
                _height = value;
                FormatHeight();
                OnPropertyChanged(nameof(Height));
            }
        }

        public string Birthday
        {
            get => _birthday;
            set
            {
                _birthday = value;
                OnPropertyChanged(nameof(Birthday));
            }
        }

        public string Gender
        {
            get => _gender;
            set
            {
                _gender = value;
                OnPropertyChanged(nameof(Gender));
            }
        }

        //Commands
        public ICommand CancelCommand { get; }
        public ICommand UpdateCommand { get; }
        public ICommand ChangeGender { get; }

        //Constructor
        public ModifyPatientViewModel(Patient patient)
        {
            CancelCommand = new RelayCommand(ExecuteCancelCommand);
            UpdateCommand = new RelayCommand(ExecuteUpdateCommand);
            ChangeGender = new RelayCommand(ExecuteChangeGenderCommand);

            Patient = patient;
            LoadInformation(); 
        }

        //Commands Implementation
        private void ExecuteCancelCommand(object obj)
        {
            string title = "¿Estás seguro de que deseas salir?";
            string message = "Recuerda que si sales ahora sin guardar, perderás el progreso que hayas realizado.";
            bool result = DialogManager.ShowConfirmation(title, message, "Aceptar", "Cancelar");
            if (result)
            {
                NavigationManager.Instance.NavigateBack();
            }
        }

        private void ExecuteUpdateCommand(object obj)
        {
            if (AreFieldsComplete())
            {
                Dictionary<string, string> errors = ValidateInformation();
                if (errors.Count == 0)
                {
                    SaveChanges(); 
                }
                else
                {
                    DialogManager.ShowNotification(errors.First().Key, errors.First().Value);
                }
            }
            else
            {
                string title = "Campos incompletos";
                string message = "Por favor rellene todos los campos, de lo contrario no podrá pasar a la siguiente etapa";
                DialogManager.ShowNotification(title, message);
            }

        }

        private void ExecuteChangeGenderCommand(object obj)
        {
            string selectedGender = (string)obj;
            Gender = selectedGender;
        }

        //Methods
        private bool AreFieldsComplete()
        {
            bool result = true;

            if (string.IsNullOrWhiteSpace(Patient.Person.Names) || string.IsNullOrWhiteSpace(Patient.Person.FirstLastName) || string.IsNullOrWhiteSpace(Patient.Person.SecondLastName))
            {
                result = false;
            }

            if (string.IsNullOrWhiteSpace(Phone) || string.IsNullOrWhiteSpace(Patient.Person.Email))
            {
                result = false;
            }

            if (string.IsNullOrWhiteSpace(Height) || string.IsNullOrWhiteSpace(Birthday))
            {
                result = false;
            }

            return result;
        }

        private Dictionary<string, string> ValidateInformation()
        {
            Dictionary<string, string> errors = new Dictionary<string, string>();
            DateTime birthday = DateTime.ParseExact(Birthday, "dd/MM/yyyy", null);

            if (!ValidationManager.IsEmailCorrect(Patient.Person.Email))
            {
                string title = "Correo invalido";
                string message = "El correo debe ser @gmail.com para que pueda recibir correos";
                errors.Add(title, message);
            }

            if (!ValidationManager.IsOfLegalAge(birthday))
            {
                string title = "Paciente muy joven";
                string message = "Lo sentimos, pero el paciente debe ser mayor de edad, " +
                    "por el momento Health Divine no tiene soporte para pacientes menores de edad";
                errors.Add(title, message);
            }

            if (float.Parse(Height) > 3)
            {
                string title = "Estatura ingresada no válida";
                string message = "Lo sentimos pero la estatura ingresada no es realista, por lo general las personas miden entre 1 y 2 metros, " +
                    "por favor ingrese una estatura más realista, por ejemplo 1.68";
                errors.Add(title, message);
            }

            if (Phone.Length != 12)
            {
                string title = "Teléfono incompleto";
                string message = "El número de teléfono está incompleto, por favor coloque el número completo";
                errors.Add(title, message);
            }

            return errors;
        }

        private void FormatPhone()
        {

            int lenght = Phone.Length;

            if (lenght == 4 || lenght == 8)
            {
                if (Phone[lenght - 1] == '-')
                {
                    Phone = Phone.Remove(lenght - 1);
                }
                else
                {
                    Phone = Phone.Insert(lenght - 1, "-");
                }
            }

        }

        private void FormatHeight()
        {

            int lenght = Height.Length;

            if (lenght == 2)
            {
                if (Height[lenght - 1] == '.')
                {
                    Height = Height.Remove(lenght - 1);
                }
                else
                {
                    Height = Height.Insert(lenght - 1, ".");
                }
            }
        }

        private Patient CreatePatient()
        {
            DateTime patientBirthday = DateTime.ParseExact(Birthday, "dd/MM/yyyy", null);

            Patient patient = Patient;
            patient.Birthday = patientBirthday;
            patient.Gender = Gender;
            patient.Height = float.Parse(Height);

            patient.Person.Phone = Phone; 

            return patient;
        }

        private void LoadInformation()
        {
            Phone = Patient.Person.Phone;
            Phone = Phone.Insert(3,"-");
            Phone = Phone.Insert(7, "-");

            Birthday = Patient.Birthday.ToShortDateString();
            Height = Patient.Height.ToString();
            Gender = Patient.Gender; 
        }

        private async void SaveChanges()
        {
            UserManagementClient client = new();
            client.InnerChannel.OperationTimeout = TimeSpan.FromSeconds(10);

            try
            {
                Patient patient = CreatePatient();
                patient.Person.Phone = ConvertPhone(Phone); 

                int result = await client.UpdatePatientAsync(patient);
                if (result != 0)
                {
                    DialogManager.ShowNotification("Actualización exitosa","La actualización de la infomrción ah sido realizada correctamente");
                    NavigationManager.Instance.NavigateTo(new PatientInfoPage(patient)); 
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

        private static string ConvertPhone(string phone)
        {
            return phone.Replace("-", "");
        }
    }
}
