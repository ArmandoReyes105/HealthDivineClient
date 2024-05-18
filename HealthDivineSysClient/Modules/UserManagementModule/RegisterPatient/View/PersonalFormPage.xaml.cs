using HealthDivineSysClient.Helpers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input; 

namespace HealthDivineSysClient.Modules.UserManagementModule.RegisterPatient.View
{
    public partial class PersonalFormPage : Page
    {

        public PersonalFormPage()
        {
            InitializeComponent();
            Loaded += PersonalFormPage_Loaded;
        }

        private void PersonalFormPage_Loaded(object sender, RoutedEventArgs e)
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
