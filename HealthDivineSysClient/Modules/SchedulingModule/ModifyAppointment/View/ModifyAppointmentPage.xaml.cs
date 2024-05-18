using HealthDivineSysClient.Helpers;
using HealthDivineSysClient.Modules.SchedulingModule.ModifyAppointment.ViewModel;
using SchedulingService;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using UserManagementService;

namespace HealthDivineSysClient.Modules.SchedulingModule.ModifyAppointment.View
{
    
    public partial class ModifyAppointmentPage : Page
    {
        public ModifyAppointmentPage(Appointment appointment, Patient patient)
        {
            InitializeComponent();
            Loaded += ModifyAppointmentPage_Loaded;

            DataContext = new ModifyAppointmentViewModel(patient, appointment); 
        }

        private void ModifyAppointmentPage_Loaded(object sender, RoutedEventArgs e)
        {
            AnimatorManager.FadeIn(Main_Grid, .5); 
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
