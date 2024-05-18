using HealthDivineSysClient.Helpers;
using HealthDivineSysClient.Modules.UserManagementModule.ModifyPatient.ViewModel;
using System.Windows;
using System.Windows.Controls;
using UserManagementService;

namespace HealthDivineSysClient.Modules.UserManagementModule.ModifyPatient.View
{
    /// <summary>
    /// Lógica de interacción para ModifyMedicalPage.xaml
    /// </summary>
    public partial class ModifyMedicalPage : Page
    {
        public ModifyMedicalPage(MedicalInformation medicalInfo)
        {
            InitializeComponent();
            Loaded += PageLoaded;
            DataContext = new ModifyMedicalViewModel(medicalInfo); 
        }

        private void PageLoaded(object sender, RoutedEventArgs e)
        {
            Medical_ProgressControl.MarkAsCurrent();
            AnimatorManager.FadeIn(Form_Grid, 1);
        }
    }
}
