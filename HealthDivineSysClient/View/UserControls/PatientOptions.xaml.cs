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

namespace HealthDivineSysClient.View.UserControls
{
    /// <summary>
    /// Lógica de interacción para PatientOptions.xaml
    /// </summary>
    public partial class PatientOptions : UserControl
    {
        Patient patient = new Patient();
        PatientsPage patientsPage = new PatientsPage();

        public PatientOptions()
        {
            InitializeComponent();
        }

        public PatientOptions(Patient patient, PatientsPage page)
        {
            InitializeComponent();
            this.patient = patient;
            this.patientsPage = page;
        }

        private void ShowDetails(object sender, RoutedEventArgs e)
        {
            this.patientsPage.ShowDetails(this.patient);
        }
    }
}
