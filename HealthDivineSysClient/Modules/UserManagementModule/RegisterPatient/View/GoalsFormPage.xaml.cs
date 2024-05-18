using HealthDivineSysClient.Helpers;
using System.Windows;
using System.Windows.Controls;

namespace HealthDivineSysClient.Modules.UserManagementModule.RegisterPatient.View
{

    public partial class GoalsFormPage : Page
    {
        public GoalsFormPage()
        {
            InitializeComponent();
            Loaded += PageLoaded; 
        }

        private void PageLoaded(object sender, RoutedEventArgs e)
        {
            Personal_ProgressControl.SetAsComplete();
            Medical_ProgressControl.SetAsComplete();
            Nutritional_ProgressControl.MarkAsComplete();
            Objectives_ProgressControl.MarkAsCurrent();
            AnimatorManager.FadeIn(Form_Grid, 1);
        }
    }
}
