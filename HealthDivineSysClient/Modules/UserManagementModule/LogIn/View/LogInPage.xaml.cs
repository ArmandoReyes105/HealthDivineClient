using HealthDivineSysClient.Helpers;
using HealthDivineSysClient.Modules.UserManagementModule.ConsultPatient.View;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using UserManagementService;

namespace HealthDivineSysClient.Modules.UserManagementModule.LogIn.View
{
    
    public partial class LogInPage : Page
    {
        public LogInPage()
        {
            InitializeComponent();

            Loaded += LogInPage_Loaded;
        }

        private void LogInPage_Loaded(object sender, RoutedEventArgs e)
        {
            AnimatorManager.FadeIn(Main_Grid, .5); 
        }

        private async void LogIn_Click(object sender, RoutedEventArgs e)
        {
            UserManagementClient client = new UserManagementClient();
            string username = Username_Textbox.Text;
            string password = Password_Textbox.Password;

            try
            {
                var nutritionist =  await client.LogInAsync(username, password);
                
                if (nutritionist != null)
                {
                    LogIn(nutritionist); 
                }
                else
                {
                    DialogManager.ShowNotification("Error con la base de datos", "Lo sentimos, ocurrio un error al intentar recuperar las credenciales de la base de datos"); 
                }
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex);
                DialogManager.ShowNotification("Erro con el servidor", "Ocurrió un error al intentar conectarse con el servidor, revise su conexión a internet o intentelo más tarde"); 
            }
            finally
            {
                client.Close(); 
            }
        }

        private void LogIn(Nutritionist nutritionist)
        {
            if(nutritionist.IdNutritionist != 0)
            {
                SessionManager.Instance.SetNutritionist(nutritionist);
                var mainWindow = NavigationManager.Instance.GetMainWindow();
                mainWindow.OpenSideBar();
                NavigationManager.Instance.NavigateTo(new PatientListPage());
            }
            else
            {
                DialogManager.ShowNotification("Campos incorrectos", "Nombre de usuario o contraseña incorrectos"); 
            }
        }
    }
}
