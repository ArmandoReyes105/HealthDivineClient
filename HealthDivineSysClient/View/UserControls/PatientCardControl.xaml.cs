using HealthDivineSysClient.Helpers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Animation;

namespace HealthDivineSysClient.View.UserControls
{
    public partial class PatientCardControl : UserControl
    {
        public PatientCardControl()
        {
            InitializeComponent();
            Loaded += PatientCardControl_Loaded;
        }

        private void PatientCardControl_Loaded(object sender, RoutedEventArgs e)
        {
            AnimatorManager.FadeIn(Main_Grid, .3); 
        }

        private void ShowEnterAnimation(object sender, MouseEventArgs e)
        {
            Storyboard storyboard = (Storyboard)this.Resources["ShowButtons_StoryBoard"];
            storyboard.Begin();
        }

        private void ShowLeaveAnimation(object sender, MouseEventArgs e)
        {
            Storyboard storyboard = (Storyboard)this.Resources["HideButtons_StoryBoard"];
            storyboard.Begin();
        }
    }
}
