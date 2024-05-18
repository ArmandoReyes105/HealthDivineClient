using HealthDivineSysClient.Helpers;
using HealthDivineSysClient.Modules.SchedulingModule.CheckCalendar.ViewModel; 
using System.Windows.Controls;

namespace HealthDivineSysClient.Modules.SchedulingModule.CheckCalendar.View
{

    public partial class CalendarPage : Page
    {
        public CalendarPage()
        {
            InitializeComponent();
            DataContext = new CalendarViewModel();
            Loaded += CalendarPage_Loaded;
        }

        private void CalendarPage_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            AnimatorManager.FadeIn(Main_Grid, .5); 
        }
    }
}
