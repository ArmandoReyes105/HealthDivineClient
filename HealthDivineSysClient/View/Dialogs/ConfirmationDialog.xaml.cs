using HealthDivineSysClient.Helpers;
using System.Windows;
using System.Windows.Media.Animation;

namespace HealthDivineSysClient.View.Dialogs
{

    public partial class ConfirmationDialog : Window
    {

        public bool result { get; set; }
        private MainWindow mainWindow;

        public ConfirmationDialog()
        {
            InitializeComponent();
            Loaded += StartAnimation;
            mainWindow = NavigationManager.Instance.GetMainWindow();
        }

        private void StartAnimation(object sender, RoutedEventArgs e)
        {
            Storyboard storyboard = (Storyboard)this.Resources["Start_StoryBoard"];
            storyboard.Begin();
            mainWindow.DialogShown();
        }

        public void SetInfo(string title, string message, string yesBtnText, string noBtnText)
        {
            Title_TextBlock.Text = title;
            Message_TextBlock.Text = message;
            Yes_Button.Content = yesBtnText;
            No_Button.Content = noBtnText;
        }

        private void YesButton_Click(object sender, RoutedEventArgs e)
        {
            result = true;

            Storyboard storyboard = (Storyboard)this.Resources["Close_StoryBoard"];
            storyboard.Completed += (s, args) =>
            {
                mainWindow.DialogClose();
                Close();
            };
            storyboard.Begin();

        }

        private void NoButton_Click(object sender, RoutedEventArgs e)
        {
            result = false;

            Storyboard storyboard = (Storyboard)this.Resources["Close_StoryBoard"];
            storyboard.Completed += (s, args) =>
            {
                mainWindow.DialogClose();
                Close();
            };
            storyboard.Begin();

        }

        
    }
}
