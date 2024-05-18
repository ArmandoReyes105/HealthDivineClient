using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Animation;

namespace HealthDivineSysClient.View.UserControls
{
    public partial class BigButtonControl : UserControl
    {

        public static readonly DependencyProperty _titleProperty =
            DependencyProperty.Register("Title", typeof(string), typeof(BigButtonControl), new PropertyMetadata("Category name"));

        public static readonly DependencyProperty _messageProperty =
            DependencyProperty.Register("Message", typeof(string), typeof(BigButtonControl), new PropertyMetadata("Message"));

        public static readonly DependencyProperty _iconProperty =
            DependencyProperty.Register("Icon", typeof(string), typeof(BigButtonControl), new PropertyMetadata(""));

        public static readonly DependencyProperty _command =
            DependencyProperty.Register("Command", typeof(ICommand), typeof(BigButtonControl), new PropertyMetadata());

        //Properties
        public string Title
        {
            get { return (string)GetValue(_titleProperty); }
            set { SetValue(_titleProperty, value); }
        }

        public string Message
        {
            get { return (string)GetValue(_messageProperty); }
            set { SetValue(_messageProperty, value); }
        }

        public string Icon
        {
            get { return (string)GetValue(_iconProperty); }
            set { SetValue(_iconProperty, value); }
        }

        public ICommand Command
        {
            get { return (ICommand)GetValue(_command);  }
            set { SetValue(_command, value); }
        }

        public BigButtonControl()
        {
            InitializeComponent();
        }

        private void ShowHoverEffect(object sender, MouseEventArgs e)
        {
            Storyboard storyboard = (Storyboard)this.Resources["MouseEnter_StoryBoard"];
            storyboard.Begin();
        }

        private void HideHoverEffect(object sender, MouseEventArgs e)
        {
            Storyboard storyboard = (Storyboard)this.Resources["MouseLeave_StoryBoard"];
            storyboard.Begin();
        }
    }
}
