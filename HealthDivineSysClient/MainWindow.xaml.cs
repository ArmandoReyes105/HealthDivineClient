using HealthDivineSysClient.Helpers;
using HealthDivineSysClient.View; 
using System.Windows;
using UserManagementService;

namespace HealthDivineSysClient
{
    
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            Person person = new Person();
            person.Names = "Cinthia";
            person.FirstLastName = "Gonzalez";
            person.SecondLastName = "Hernandez";


            Patient patient = new Patient();
            patient.IdPatient = 1;
            patient.Person = person;


            NavigationManager.Instance.Initialize(Frame_Main);
            NavigationManager.Instance.NavigateTo(new AppointmentsPage()); 
        }
    }
}
