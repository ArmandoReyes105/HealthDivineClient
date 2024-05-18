using HealthDivineSysClient.Helpers;
using HealthDivineSysClient.ViewModel.ViewModelTemplates;
using HealthDivineSysClient.Modules.UserManagementModule.RegisterPatient.View;
using System;
using System.Windows.Input;
using System.Collections.Generic;
using System.Linq;
using UserManagementService;
using HealthDivineSysClient.Modules.UserManagementModule.ConsultPatient.View;
using HealthDivineSysClient.Modules.UserManagementModule.RegisterPatient.Data;

namespace HealthDivineSysClient.Modules.UserManagementModule.RegisterPatient.ViewModel
{
    class PersonalFormViewModel : ViewModelBase
    {

        //Fields
        private string _name = "";
        private string _firstLastName = "";
        private string _secondLastName = "";
        private string _phone = "";
        private string _email = "";
        private string _height = "";
        private string _birthday = "";
        private string _gender = "M";

        //Properties
        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        public string FirstLastName
        {
            get => _firstLastName;
            set
            {
                _firstLastName = value;
                OnPropertyChanged(nameof(FirstLastName));
            }
        }

        public string SecondLastName
        {
            get => _secondLastName;
            set
            {
                _secondLastName = value;
                OnPropertyChanged(nameof(SecondLastName));
            }
        }

        public string Phone
        {
            get => _phone;
            set
            {
                _phone = value;
                FormatPhone();
                OnPropertyChanged(nameof(Phone));
            }
        }

        public string Email
        {
            get => _email;
            set
            {
                _email = value;
                OnPropertyChanged(nameof(Email));
            }
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
        public ICommand NextCommand { get; }
        public ICommand ChangeGender { get; }

        //Constructor
        public PersonalFormViewModel()
        {
            CancelCommand = new RelayCommand(ExecuteCancelCommand);
            NextCommand = new RelayCommand(ExecuteNextCommand);
            ChangeGender = new RelayCommand(ExecuteChangeGenderCommand);
        }

        //Commands Implementation
        private void ExecuteCancelCommand(object obj)
        {
            string title = "¿Estás seguro de que deseas salir?";
            string message = "Recuerda que si sales ahora sin guardar, perderás el progreso que hayas realizado.";
            bool result = DialogManager.ShowConfirmation(title, message, "Aceptar", "Cancelar");
            if (result)
            {
                NavigationManager.Instance.NavigateTo(new PatientListPage());
            }
        }

        private void ExecuteNextCommand(object obj)
        {
            if (AreFieldsComplete())
            {
                Dictionary<string, string> errors = ValidateInformation();
                if (errors.Count == 0)
                {
                    RegisterPatientInfo.Instance.NewPatient = CreateNewPatient();

                    MedicalFormPage medicalFormPage = new MedicalFormPage();
                    NavigationManager.Instance.NavigateTo(medicalFormPage);
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

            if (string.IsNullOrWhiteSpace(Name) || string.IsNullOrWhiteSpace(FirstLastName) || string.IsNullOrWhiteSpace(SecondLastName))
            {
                result = false;
            }

            if (string.IsNullOrWhiteSpace(Phone) || string.IsNullOrWhiteSpace(Email))
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

            if (!ValidationManager.IsEmailCorrect(Email))
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

        private Patient CreateNewPatient()
        {

            DateTime patientBirthday = DateTime.ParseExact(Birthday, "dd/MM/yyyy", null);

            Person newPerson = new Person();
            newPerson.Names = Name;
            newPerson.FirstLastName = FirstLastName;
            newPerson.SecondLastName = SecondLastName;
            newPerson.Email = Email;
            newPerson.Phone = Phone;

            Patient newPatient = new Patient();
            newPatient.Birthday = patientBirthday;
            newPatient.Gender = Gender;
            newPatient.Height = float.Parse(Height);
            newPatient.Person = newPerson;

            return newPatient;
        }
    }
}
