using HealthDivineSysClient.View.UserControls;
using SchedulingService;
using System;
using System.Windows;
using System.Windows.Controls;
using UserManagementService;

namespace HealthDivineSysClient.View
{
    
    public partial class ScheduleAppointmentPage : Page
    {

        private int STH= 00, ETH = 00, STM = 00, ETM = 00;
        private DateTime selectedDate;
        private Patient patient; 

        public ScheduleAppointmentPage(Patient patient)
        {
            InitializeComponent();
            LoadComboboxes();
            CurrentDate_TextBlock.Text = "La fecha de hoy es: " + DateTime.Now.ToShortDateString();
            this.patient = patient;
            PatientName_TextBlock.Text = patient.Person.Names + " " + patient.Person.FirstLastName + " " + patient.Person.SecondLastName; 
        }

        private void ConfigSelectedDate(object sender, SelectionChangedEventArgs e)
        {
            if (sender is DatePicker datePicker)
            {
                DateTime selectedDate = datePicker.SelectedDate ?? DateTime.MinValue;
                this.selectedDate = selectedDate;

                Appointments_TextBlock.Text = "Mis citas de: " + selectedDate.ToShortDateString();
                SelectedDate_TextBlock.Text = "La fecha seleccionada es: " + selectedDate.ToShortDateString(); 

                LoadAppointmentsAsync();
            }
            
        }

        private void SaveAppointment(object sender, RoutedEventArgs e)
        {
            Appointment appointment = new Appointment();
            appointment.AppointmentDate = selectedDate; 
            appointment.StartTime = new TimeSpan(STH, STM, 00);
            appointment.EndTime = new TimeSpan(ETH, ETM, 00);
            appointment.IdPatient = patient.IdPatient;
            appointment.IdNutritionist = 2; 

            SchedulingClient cliente = new SchedulingClient();
            cliente.CreateAppointmentAsync(appointment); 
        }

        private async void LoadAppointmentsAsync()
        {
            SchedulingClient client = new SchedulingClient();
            var list = await client.GetAppointmentsByNutritionistAsync(2);

            if (list != null)
            {
                foreach (var appointment in list)
                {

                    var appointmentPanel = new OnelineTableText();
                    appointmentPanel.Height = 30;
                    appointmentPanel.Text1_TextBlock.FontSize = 12; 
                    appointmentPanel.Text1_TextBlock.Text = appointment.StartTime.ToString() + " " + appointment.EndTime.ToString();
                    Appointments_StackPanel.Children.Add(appointmentPanel);

                }
            }
        }

        private void LoadComboboxes()
        {
            for (int i = 0; i <= 60; i++)
            {
                ETMinutes_Combobox.Items.Add(i.ToString("00"));
                STMinutes_Combobox.Items.Add(i.ToString("00"));
            }

            for (int i = 0; i <= 24; i++)
            {
                ETHour_Combobox.Items.Add(i.ToString("00"));
                STHour_Combobox.Items.Add(i.ToString("00"));
            }
        }

        private void UpdateTime(object sender, SelectionChangedEventArgs e)
        {

            if (sender is ComboBox comboBox)
            {
                switch (comboBox.Name)
                {
                    case "STHour_Combobox":
                        if (int.TryParse(STHour_Combobox.SelectedItem?.ToString(), out int STHV))
                        {
                            STH = STHV;
                        }
                        break;
                    case "STMinutes_Combobox":
                        if (int.TryParse(STMinutes_Combobox.SelectedItem?.ToString(), out int STMV))
                        {
                            STM = STMV;
                        }
                        break;
                    case "ETHour_Combobox":
                        if (int.TryParse(ETHour_Combobox.SelectedItem?.ToString(), out int ETHV))
                        {
                            ETH = ETHV;
                        }
                        break;
                    case "ETMinutes_Combobox":
                        if (int.TryParse(ETMinutes_Combobox.SelectedItem?.ToString(), out int ETMV))
                        {
                            ETM = ETMV;
                        }
                        break;
                }

                SelectedTime_TextBlock.Text = "Horario: " + STH + ":" + STM + "-" + ETH + ":" + ETM;
            }

        }
    }
}
