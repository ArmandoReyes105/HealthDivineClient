using System.Windows;
using System.Windows.Controls; 

namespace HealthDivineSysClient.Helpers
{
    public class NavigationManager
    {

        private static NavigationManager _instance = new();
        private Frame _mainFrame;
        private MainWindow _window; 

        private NavigationManager() { }

        public static NavigationManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new NavigationManager();
                }
                return _instance;
            }
        }

        public void Initialize(Frame mainFrame, MainWindow mainWindow)
        {
            _mainFrame = mainFrame;
            _window = mainWindow;
        }

        public void NavigateTo(Page page)
        {
            if (_mainFrame != null)
            {
                _mainFrame.Navigate(page);
            }
        }

        public void NavigateBack()
        {
            if(_mainFrame != null)
            {
                _mainFrame.GoBack();
            }
        }

        public MainWindow GetMainWindow()
        {
            return _window; 
        }

    }
}
