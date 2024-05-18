using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace HealthDivineSysClient.View.UserControls
{
    public partial class ProgressCircleControl : UserControl
    {
        //Attributes
        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register("Text", typeof(string), typeof(ProgressCircleControl), new PropertyMetadata("Category name"));

        public static readonly DependencyProperty IconProperty =
            DependencyProperty.Register("Icon", typeof(string), typeof(ProgressCircleControl), new PropertyMetadata(string.Empty));

        public static readonly DependencyProperty LineProgressProperty =
            DependencyProperty.Register("LineVisibility", typeof(Visibility), typeof(ProgressCircleControl), new PropertyMetadata(Visibility.Visible)); 

        //Properties
        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        public string Icon
        {
            get { return (string)GetValue(IconProperty); }
            set { SetValue(IconProperty, value);  }
        }

        public Visibility LineVisibility
        {
            get { return (Visibility)GetValue(LineProgressProperty); }
            set { SetValue(LineProgressProperty, value); }
        }

        //Constructor
        public ProgressCircleControl()
        {
            InitializeComponent();
        }

        //Methods
        public void SetAsComplete()
        {
            Icon_TextBlock.Foreground = (SolidColorBrush)Application.Current.Resources["SecondaryTextColor"];
            Circle_Border.BorderBrush = (SolidColorBrush)Application.Current.Resources["AccentColor"];
            Background_Border.Height = 48;
            Background_Border.Width = 48;
            border1.Height = 50;
            border2.Background = (SolidColorBrush)Application.Current.Resources["AccentColor"]; 
        }

        public void MarkAsComplete()
        {
            Storyboard storyboard = (Storyboard)this.Resources["Completed_StoryBoard"];
            storyboard.Begin();
        }

        public void MarkAsCurrent()
        {
            Storyboard storyboard = (Storyboard)this.Resources["Current_StoryBoard"];
            storyboard.Begin();
        }

    }
}
