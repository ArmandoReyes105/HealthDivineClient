using HealthDivineSysClient.Helpers;
using HealthDivineSysClient.Modules.ProgressManagementModule.ModifyProgressRecord.ViewModel;
using System.Windows;
using System.Windows.Controls;

namespace HealthDivineSysClient.Modules.ProgressManagementModule.ModifyProgressRecord.View
{
    public partial class ModifyDiagnosisPage : Page
    {
        public ModifyDiagnosisPage(int patientId)
        {
            InitializeComponent();
            Loaded += DiagnosisFormPage_Loaded;
            DataContext = new ModifyDiagnosisViewModel(patientId); 
        }

        private void DiagnosisFormPage_Loaded(object sender, RoutedEventArgs e)
        {
            AnimatorManager.FadeIn(Main_Grid, .5);
        }
    }
}
