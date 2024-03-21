using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using UserManagementService;

namespace HealthDivineSysClient.View
{
    /// <summary>
    /// Lógica de interacción para AddPatient1.xaml
    /// </summary>
    public partial class AddPatientPage: Page
    {
        int physicalActivity = 3; 

        public AddPatientPage()
        {
            InitializeComponent();
        }

        private void Next_Create(object sender, RoutedEventArgs e)
        {
            if((string)Next_Button.Content == "Siguiente")
            {
                Next_Button.Content = "Dar de alta";
                Cancel_Button.Content = "Regresar"; 
                First_Panel.Visibility = Visibility.Hidden; 
                Second_Panel.Visibility = Visibility.Visible;
            }
            else
            {
                CreateNewPatient();
            }

        }

        private void CreateNewPatient()
        {
            Person newPerson = new Person();
            newPerson.Names = Name_TextBox.Text; 
            newPerson.FirstLastName = FirstLastName_TextBox.Text;
            newPerson.SecondLastName = SecondLastName_TextBox.Text;
            newPerson.Phone = Phone_TextBox.Text;
            newPerson.Email = Email_TextBox.Text;

            MedicalInformation medicalInformation = new MedicalInformation();
            medicalInformation.Diseases = Disease_TextBox.Text;
            medicalInformation.Medicines = Medicines_TextBox.Text;
            medicalInformation.Allergies = Allergies_TextBox.Text;

            GeneralInformation generalInformation = new GeneralInformation();
            generalInformation.GeneralComments = Comments_TextBox.Text;
            generalInformation.PhysicalActivityComments = "Ninguno";
            generalInformation.FoodPreferences = Food_TextBox.Text;
            generalInformation.PhysicalActivity = physicalActivity; 

            Patient newPatient = new Patient();
            newPatient.Person = newPerson;
            newPatient.Height = double.Parse(Height_TextBox.Text);
            newPatient.Birthday = (DateTime)Birthday_TextBox.SelectedDate;
            newPatient.MedicalInformation = medicalInformation;
            newPatient.GeneralInfomation = generalInformation; 
            newPatient.Nutritionist = 2; 
            
             UserManagementClient client = new UserManagementClient();
            client.AddPatientAsync(newPatient);
        }

        private void Before_Out(object sender, RoutedEventArgs e)
        {
            if ((string)Cancel_Button.Content == "Regresar")
            {
                Next_Button.Content = "Siguiente";
                Cancel_Button.Content = "Cancelar";
                First_Panel.Visibility = Visibility.Visible;
                Second_Panel.Visibility = Visibility.Hidden;
            }
        }

        private void RBEvent(object sender, RoutedEventArgs e)
        {
            if (sender is RadioButton radioButton)
            {
                switch (radioButton.Name)
                {
                    case "RB1":
                        physicalActivity = 1; 
                        break;
                    case "RB2":
                        physicalActivity = 2;
                        break;
                    case "RB3":
                        physicalActivity = 3;
                        break;
                    case "RB4":
                        physicalActivity = 4;
                        break;
                }
            }
        }
    }
}
