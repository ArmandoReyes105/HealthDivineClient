using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Animation;

namespace HealthDivineSysClient.View.UserControls
{
   
    public partial class ShortAppointmentControl : UserControl
    {

        public static readonly DependencyProperty StartProperty =
            DependencyProperty.Register("Start", typeof(string), typeof(ShortAppointmentControl), new PropertyMetadata("00:00"));

        public static readonly DependencyProperty EndProperty =
            DependencyProperty.Register("End", typeof(string), typeof(ShortAppointmentControl), new PropertyMetadata("00:00"));

        public string Start
        {
            get { return (string)GetValue(StartProperty); }
            set { SetValue(StartProperty, value); }
        }

        public string End
        {
            get { return (string)GetValue(EndProperty); }
            set { SetValue(EndProperty, value); }
        }

        public ShortAppointmentControl()
        {
            InitializeComponent();
        }

        private void Main_Grid_MouseEnter(object sender, MouseEventArgs e)
        {
            Storyboard storyboard = (Storyboard)this.Resources["Hover_StoryBoard"];
            storyboard.Begin();
        }

        private void Main_Grid_MouseLeave(object sender, MouseEventArgs e)
        {
            Storyboard storyboard = (Storyboard)this.Resources["ExitHover_StoryBoard"];
            storyboard.Begin();
        }
    }
}
