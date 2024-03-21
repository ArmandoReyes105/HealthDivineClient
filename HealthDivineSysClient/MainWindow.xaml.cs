using HealthDivineSysClient.Helpers;
using HealthDivineSysClient.View; 
using System.Windows;

namespace HealthDivineSysClient
{
    
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            NavigationManager.Instance.Initialize(Frame_Main);
            NavigationManager.Instance.NavigateTo(new PatientsPage()); 
        }
    }
}
