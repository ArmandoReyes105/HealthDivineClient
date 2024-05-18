using HealthDivineSysClient.Helpers;
using HealthDivineSysClient.Modules.UserManagementModule.ConsultPatient.ViewModel; 
using System.Windows.Controls;
using UserManagementService;

namespace HealthDivineSysClient.Modules.UserManagementModule.ConsultPatient.View
{
    public partial class PatientInfoPage : Page
    {
        public PatientInfoPage(Patient patient)
        {
            InitializeComponent();
            Loaded += PatientInfoPage_Loaded;
            DataContext = new PatientInfoViewModel(patient); 
        }

        private void PatientInfoPage_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            AnimatorManager.FadeIn(Main_Grid, .5); 
        }

    }
}
