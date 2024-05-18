using HealthDivineSysClient.View.Dialogs;
using System.Windows;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace HealthDivineSysClient.Helpers
{
    public static class DialogManager
    {

        public static void ShowNotification(string title, string message)
        {
            Dialog dialog = new Dialog();
            dialog.SetInfo(title, message);
            dialog.Owner = NavigationManager.Instance.GetMainWindow();
            dialog.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            dialog.ShowDialog();
        }

        public static bool ShowConfirmation(string title, string message, string confirmationText, string cancelText)
        {
            bool result = false; 

            ConfirmationDialog dialog = new ConfirmationDialog();
            dialog.SetInfo(title, message, confirmationText, cancelText);
            dialog.Owner = NavigationManager.Instance.GetMainWindow(); 
            dialog.WindowStartupLocation= WindowStartupLocation.CenterOwner;
            dialog.ShowDialog();
            result = dialog.result; 

            return result;
        }

    }
}
