using HealthDivineSysClient.Helpers;
using HealthDivineSysClient.View; 
using System.Windows;

namespace HealthDivineSysClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            NavigationManager.Instance.Initialize(Frame_Main);
            NavigationManager.Instance.NavigateTo(new AddPatient1()); 
        }
    }
}
