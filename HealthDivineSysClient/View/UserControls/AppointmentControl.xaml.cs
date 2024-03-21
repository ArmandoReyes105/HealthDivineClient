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

namespace HealthDivineSysClient.View.UserControls
{
    /// <summary>
    /// Lógica de interacción para AppointmentControl.xaml
    /// </summary>
    public partial class AppointmentControl : UserControl
    {
        public AppointmentControl(Appointment appointment)
        {
            InitializeComponent();

            Date_TextBlock.Text = appointment.AppointmentDate.ToShortDateString();
            Hour_TextBlock.Text = appointment.StartTime.ToString() + " - " + appointment.EndTime.ToString();
        }
    }
}
