using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Animation;

namespace HealthDivineSysClient.View.UserControls
{
    
    public partial class DatePickerControl : UserControl
    {

        private int state = 0;

        public static readonly DependencyProperty _text = 
            DependencyProperty.Register("Text", typeof(string), typeof(DatePickerControl), new PropertyMetadata("")); 

        public string Text
        {
            get { return (string)GetValue(_text);  }
            set { SetValue(_text, value);  }
        }

        public DatePickerControl()
        {
            InitializeComponent();
        }

        private void ShowCalendar(object sender, RoutedEventArgs e)
        {
            if(state == 0)
            {
                Storyboard storyboard = (Storyboard)this.Resources["ShowCalendar_Storyboard"];
                storyboard.Begin();
                state = 1;
            }
            else
            {
                Storyboard storyboard = (Storyboard)this.Resources["CloseCalendar_Storyboard"];
                storyboard.Begin();
                state = 0;
            }
            
            
        }

        private void HideCalendar(object sender, MouseEventArgs e)
        {
            if(state == 1)
            {
                Storyboard storyboard = (Storyboard)this.Resources["CloseCalendar_Storyboard"];
                storyboard.Begin();
            }

            state = 0; 
            
        }

        private void SetDateText(object sender, SelectionChangedEventArgs e)
        {
            if(Date_Calendar.SelectedDate != null)
            {
                Text = Date_Calendar.SelectedDate.Value.ToShortDateString();
                
            }
            
        }
    }
}
