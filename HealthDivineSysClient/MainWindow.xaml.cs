using HealthDivineSysClient.Helpers;
using HealthDivineSysClient.Modules.UserManagementModule.ConsultPatient.View;
using HealthDivineSysClient.Modules.SchedulingModule.CheckCalendar.View; 
using System.Windows;
using System.Windows.Controls;
using HealthDivineSysClient.Modules.UserManagementModule.LogIn.View;

namespace HealthDivineSysClient
{
    
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            CloseSideBar(); 
            NavigationManager.Instance.Initialize(Frame_Main, this);
            NavigationManager.Instance.NavigateTo(new LogInPage()); 
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
                    case "Logout_Button":
                        NavigationManager.Instance.NavigateTo(new LogInPage());
                        CloseSideBar();
                        SessionManager.Instance.CloseSession();
                        break; 
                }
            }
        }

        public void OpenSideBar()
        {
            SideBar_Grid.Width = 64;
        }

        public void CloseSideBar()
        {
            SideBar_Grid.Width = 0; 
        }
    }
}
