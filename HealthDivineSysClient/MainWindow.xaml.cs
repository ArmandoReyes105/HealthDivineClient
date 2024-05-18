using HealthDivineSysClient.Helpers;
using HealthDivineSysClient.Modules.UserManagementModule.ConsultPatient.View;
using HealthDivineSysClient.Modules.SchedulingModule.CheckCalendar.View; 
using System.Windows;
using System.Windows.Controls;

namespace HealthDivineSysClient
{
    
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            /*Person person = new Person();
            person.Names = "Cinthia";
            person.FirstLastName = "Gonzalez";
            person.SecondLastName = "Hernandez";


            Patient patient = new Patient();
            patient.IdPatient = 1;
            patient.Person = person;*/


            NavigationManager.Instance.Initialize(Frame_Main, this);
            NavigationManager.Instance.NavigateTo(new PatientListPage()); 
        }

        public void DialogShown()
        {
            Opacity_Grid.Visibility = Visibility.Visible;
            AnimatorManager.FadeIn(Opacity_Grid, .3); 
        }

        public void DialogClose()
        {
            Opacity_Grid.Visibility=Visibility.Collapsed;
        }

        private void ChangeView(object sender, RoutedEventArgs e)
        {
            if (sender is Button button)
            {
                switch (button.Name)
                {
                    case "Patients_Button":
                        NavigationManager.Instance.NavigateTo(new PatientListPage());
                        break;
                    case "Calendar_Button":
                        NavigationManager.Instance.NavigateTo(new CalendarPage());
                        break; 
                }
            }
        }
    }
}
