using HealthDivineSysClient.Helpers;
using HealthDivineSysClient.Modules.SchedulingModule.ScheduleAppointment.ViewModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using UserManagementService;

namespace HealthDivineSysClient.Modules.SchedulingModule.ScheduleAppointment.View
{
    
    public partial class ScheduleAppointmentPage : Page
    {
        public ScheduleAppointmentPage(Patient patient)
        {
            InitializeComponent();
            DataContext = new ScheduleAppointmentViewModel(patient); 

            Loaded += ScheduleAppointmentPage_Loaded;
        }

        private void ScheduleAppointmentPage_Loaded(object sender, RoutedEventArgs e)
        {
            AnimatorManager.FadeIn(Main_Grid,.5); 
        }

        private void ValidateOnlyNumbers(object sender, TextCompositionEventArgs e)
        {
            if (!char.IsDigit(e.Text, e.Text.Length - 1) && e.Text != ":")
            {
                e.Handled = true;
            }

        }

        private void ValidateNoBlanckSpace(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                e.Handled = true;
            }
        }

        private void ValidateNoPaste(object sender, ExecutedRoutedEventArgs e)
        {
            if (e.Command == ApplicationCommands.Paste)
            {
                e.Handled = true;
            }
        }
    }
}
