using HealthDivineSysClient.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HealthDivineSysClient.Modules.SchedulingModule.CheckCalendar.View
{
    public partial class AppointmentControl : UserControl
    {
        public AppointmentControl()
        {
            InitializeComponent();
            Loaded += AppointmentControl_Loaded;
        }

        private void AppointmentControl_Loaded(object sender, RoutedEventArgs e)
        {
            AnimatorManager.FadeIn(Main_Grid, .5); 
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
