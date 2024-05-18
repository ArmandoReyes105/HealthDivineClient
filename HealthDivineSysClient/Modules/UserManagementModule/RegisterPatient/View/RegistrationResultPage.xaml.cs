using System.Windows.Controls;
using System.Windows;
using HealthDivineSysClient.Helpers;

namespace HealthDivineSysClient.Modules.UserManagementModule.RegisterPatient.View
{

    public partial class RegistrationResultPage : Page
    {
        public RegistrationResultPage()
        {
            InitializeComponent();
            Loaded += Page_Loaded;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            AnimatorManager.FadeIn(Main_Grid, 1); 
        }
    }
}
