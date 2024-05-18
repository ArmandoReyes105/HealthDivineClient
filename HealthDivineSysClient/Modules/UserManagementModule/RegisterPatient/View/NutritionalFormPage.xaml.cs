using HealthDivineSysClient.Helpers;
using System.Windows;
using System.Windows.Controls;

namespace HealthDivineSysClient.Modules.UserManagementModule.RegisterPatient.View
{
    public partial class NutritionalFormPage : Page
    {
        public NutritionalFormPage()
        {
            InitializeComponent();
            Loaded += PageLoaded; 
        }

        private void PageLoaded(object sender, RoutedEventArgs e)
        {
            Personal_ProgressControl.SetAsComplete(); 
            Medical_ProgressControl.MarkAsComplete();
            Nutritional_ProgressControl.MarkAsCurrent();
            AnimatorManager.FadeIn(Form_Grid, 1); 
        }
    }
}
