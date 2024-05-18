using HealthDivineSysClient.Helpers;
using HealthDivineSysClient.Modules.ProgressManagementModule.CreateProgressRecord.ViewModel;
using ProgressManagementService;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace HealthDivineSysClient.Modules.ProgressManagementModule.CreateProgressRecord.View
{
    public partial class MeasuresFormPage : Page
    {
        public MeasuresFormPage(Diagnosis diagnosis)
        {
            InitializeComponent();
            Loaded += MeasuresFormPage_Loaded;
            DataContext = new MeasuresFormViewModel(diagnosis); 
        }

        private void MeasuresFormPage_Loaded(object sender, RoutedEventArgs e)
        {
            AnimatorManager.FadeIn(Main_Grid, .5);
            Measures_Control.MarkAsCurrent();
            Diagnosis_Control.MarkAsComplete(); 
        }

        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox? textBox = sender as TextBox;
            Uri uri; 

            if (textBox != null)
            {
                switch (textBox.Name)
                {
                    case "Chest_TextBox":
                        uri = new Uri("/HealthDivineSysClient;component/Resources/Images/Pecho_Image.png", UriKind.Relative);
                        Body_Image.Source = new BitmapImage(uri);
                        break;
                    case "Antebrazo_TextBox":
                        uri = new Uri("/HealthDivineSysClient;component/Resources/Images/Antebrazo_Image.png", UriKind.Relative);
                        Body_Image.Source = new BitmapImage(uri); 
                        break;
                    case "BrazoContraido_TextBox":
                        uri = new Uri("/HealthDivineSysClient;component/Resources/Images/Brazo_Image.png", UriKind.Relative);
                        Body_Image.Source = new BitmapImage(uri);
                        break;
                    case "BrazoRelajado_TextBox":
                        uri = new Uri("/HealthDivineSysClient;component/Resources/Images/Brazo_Image.png", UriKind.Relative);
                        Body_Image.Source = new BitmapImage(uri);
                        break;
                    case "Cintura_TextBox":
                        uri = new Uri("/HealthDivineSysClient;component/Resources/Images/Cintura_Image.png", UriKind.Relative);
                        Body_Image.Source = new BitmapImage(uri);
                        break;
                    case "Cadera_TextBox":
                        uri = new Uri("/HealthDivineSysClient;component/Resources/Images/Cadera_Image.png", UriKind.Relative);
                        Body_Image.Source = new BitmapImage(uri);
                        break;
                    case "Muslo_TextBox":
                        uri = new Uri("/HealthDivineSysClient;component/Resources/Images/Muslo_Image.png", UriKind.Relative);
                        Body_Image.Source = new BitmapImage(uri);
                        break;
                    case "Pantorilla_TextBox":
                        uri = new Uri("/HealthDivineSysClient;component/Resources/Images/Pantorrilla_Image.png", UriKind.Relative);
                        Body_Image.Source = new BitmapImage(uri);
                        break;
                }
            }
        }

        private void ValidateOnlyNumbers(object sender, TextCompositionEventArgs e)
        {
            if (!char.IsDigit(e.Text, e.Text.Length - 1) && e.Text != ".")
            {
                e.Handled = true;
            }

        }

        private void ValidateNoBlanckSpace(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                e.Handled = true;
            }
        }

        private void ValidateNoPaste(object sender, ExecutedRoutedEventArgs e)
        {
            if (e.Command == ApplicationCommands.Paste)
            {
                e.Handled = true;
            }
        }
    }
}
