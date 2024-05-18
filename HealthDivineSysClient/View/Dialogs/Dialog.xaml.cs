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
using System.Windows.Shapes;

namespace HealthDivineSysClient.View.Dialogs
{
    public partial class Dialog : Window
    {

        public bool Result { get; set; }
        private MainWindow mainWindow;

        public Dialog()
        {
            InitializeComponent();

            Loaded += StartAnimation;
            mainWindow = NavigationManager.Instance.GetMainWindow();
        }

        private void YesButton_Click(object sender, RoutedEventArgs e)
        {
            Result = true;
            
            Storyboard storyboard = (Storyboard)this.Resources["Close_StoryBoard"];
            storyboard.Completed += (s, args) =>
            {
                mainWindow.DialogClose();
                Close();
            };
            storyboard.Begin();
            
        }

        public void SetInfo(string title, string message)
        {
            Title_TextBlock.Text = title;
            Message_TextBlock.Text = message;
        }

        private void StartAnimation(object sender, RoutedEventArgs e)
        {
            Storyboard storyboard = (Storyboard)this.Resources["Start_StoryBoard"];
            storyboard.Begin();
            mainWindow.DialogShown(); 
        }
    }
}
