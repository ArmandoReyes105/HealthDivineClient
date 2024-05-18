using HealthDivineSysClient.Helpers;
using System.Windows;
using System.Windows.Controls;

namespace HealthDivineSysClient.Modules.UserManagementModule.RegisterPatient.View
{
    
    public partial class MedicalFormPage : Page
    {
        public MedicalFormPage()
        {
            InitializeComponent();
            Loaded += PageLoaded;  
        }

        private void PageLoaded(object sender, RoutedEventArgs e)
        {
            Personal_ProgressControl.MarkAsComplete();
            Medical_ProgressControl.MarkAsCurrent();
            AnimatorManager.FadeIn(Form_Grid, 1);
        }

        
    }
}
