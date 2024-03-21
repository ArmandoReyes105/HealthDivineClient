using HealthDivineSysClient.View.UserControls;
using SchedulingService;
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
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using UserManagementService;

namespace HealthDivineSysClient.View
{
    /// <summary>
    /// Lógica de interacción para AppointmentsPage.xaml
    /// </summary>
    public partial class AppointmentsPage : Page
    {
        public AppointmentsPage()
        {
            InitializeComponent();
            LoadAppointments();
        }

        private async void LoadAppointments()
        {
            SchedulingClient client = new SchedulingClient();
            var list = await client.GetAppointmentsByNutritionistAsync(2);

            if (list != null)
            {
                foreach (var appointment in list)
                {

                    AppointmentControl control = new AppointmentControl(appointment);
                    Appointment_Panel.Children.Add(control);

                }
            }
        }
    }
}
