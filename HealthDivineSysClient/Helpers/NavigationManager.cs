using System.Windows.Controls; 

namespace HealthDivineSysClient.Helpers
{
    public class NavigationManager
    {

        private static NavigationManager _instance;
        private Frame _mainFrame;

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

        public void Initialize(Frame mainFrame)
        {
            _mainFrame = mainFrame;
        }

        public void NavigateTo(Page page)
        {
            if (_mainFrame != null)
            {
                _mainFrame.Navigate(page);
            }
        }

    }
}
