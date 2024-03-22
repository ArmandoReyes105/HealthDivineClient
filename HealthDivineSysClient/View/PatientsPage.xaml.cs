using HealthDivineSysClient.Helpers;
using HealthDivineSysClient.View.UserControls;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using UserManagementService;

namespace HealthDivineSysClient.View
{
    public partial class PatientsPage : Page
    {

        private Dictionary<PatientOptions, Patient> patientsDetails = new Dictionary<PatientOptions, Patient>();

        public PatientsPage()
        {
            InitializeComponent();
            LoadPatientsAsync();
        }

        private async void LoadPatientsAsync()
        {
            UserManagementClient client = new UserManagementClient();
            var list = await client.GetMyPatientsAsync(2);

            if (list != null)
            {
                foreach (var patient in list)
                {

                    PatientName patientName = new PatientName(patient.Person.Names, patient.Person.FirstLastName); 
                    Name_Panel.Children.Add(patientName);

                    var contact = new OnelineTableText();
                    contact.Text1_TextBlock.Text = patient.Person.Phone;
                    Contact_Panel.Children.Add(contact);

                    var email = new OnelineTableText();
                    email.Text1_TextBlock.Text = patient.Person.Email;
                    Email_Panel.Children.Add(email);

                    var birthday = new OnelineTableText();
                    birthday.Text1_TextBlock.Text = patient.Birthday.ToShortDateString();
                    Bithday_Panel.Children.Add(birthday);

                    var options = new PatientOptions(patient, this);
                    Options_Panel.Children.Add(options);

                }
            }
        }

        public void ShowDetails(Patient patient)
        {
            Details_Grid.IsEnabled = true;
            Details_Grid.Visibility = Visibility.Visible;

            Table_Grid.IsEnabled = false;

            string fullname = patient.Person.Names + " " + patient.Person.FirstLastName + " " + patient.Person.SecondLastName;
            PatientName_TextBlock.Text = fullname;

            int age = DateTime.Today.Year - patient.Birthday.Year - (DateTime.Today < patient.Birthday.AddYears(DateTime.Today.Year - patient.Birthday.Year) ? 1 : 0); ; 
            Age_TextBlock.Text = "Edad: " + age.ToString() + " años";
            Birthdate_TextBlock.Text = "Fecha de nacimiento: " + patient.Birthday.ToShortDateString();
            Email_TextBlock.Text = "Correo: " + patient.Person.Email;
            Phone_TextBlock.Text = "Telefono: " + patient.Person.Phone;

            Enfermedades_TextBlock.Text = patient.MedicalInformation.Diseases;
            Allergies_TextBlock.Text = patient.MedicalInformation.Allergies;
            Medicines_TextBlock.Text = patient.MedicalInformation.Medicines; 

            PhysicalActivity_TextBlock.Text = patient.GeneralInfomation.PhysicalActivityComments;
            FoodPreference_TextBlock.Text = patient.GeneralInfomation.FoodPreferences;
            GeneralComments_TextBlock.Text = patient.GeneralInfomation.GeneralComments; 

        }

        private void CloseDetails(object sender, RoutedEventArgs e)
        {
            Details_Grid.IsEnabled = false;
            Details_Grid.Visibility = Visibility.Hidden;

            Table_Grid.IsEnabled = true;
        }

        private void AddPatient(object sender, RoutedEventArgs e)
        {
            NavigationManager.Instance.NavigateTo(new AddPatient1()); 
        }
    }
}
