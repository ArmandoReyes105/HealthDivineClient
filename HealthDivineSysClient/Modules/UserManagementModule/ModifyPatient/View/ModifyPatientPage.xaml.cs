using HealthDivineSysClient.Helpers;
using HealthDivineSysClient.Modules.UserManagementModule.ModifyPatient.ViewModel; 
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using UserManagementService;

namespace HealthDivineSysClient.Modules.UserManagementModule.ModifyPatient.View
{
    public partial class ModifyPatientPage : Page
    {
        public ModifyPatientPage(Patient patient)
        {
            InitializeComponent();

            Loaded += ModifyPatientPage_Loaded;
            DataContext = new ModifyPatientViewModel(patient);

            switch (patient.Gender)
            {
                case "M": Male_RadioBtn.IsChecked = true; Female_RadioBtn.IsChecked = false;  break;
                case "F": Female_RadioBtn.IsChecked = true; Male_RadioBtn.IsChecked = false; break;
            }
        }

        private void ModifyPatientPage_Loaded(object sender, RoutedEventArgs e)
        {
            AnimatorManager.FadeIn(Main_Grid, .5);
            Personal_ProgressControl.MarkAsCurrent();
        }

        private void ValidateOnlyNumbers(object sender, TextCompositionEventArgs e)
        {
            if (!char.IsDigit(e.Text, e.Text.Length - 1))
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
