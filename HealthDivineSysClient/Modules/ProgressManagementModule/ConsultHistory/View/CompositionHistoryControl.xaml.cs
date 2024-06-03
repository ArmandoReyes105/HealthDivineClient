using HealthDivineSysClient.Modules.ProgressManagementModule.ConsultHistory.ViewModel;
using System.Windows.Controls;

namespace HealthDivineSysClient.Modules.ProgressManagementModule.ConsultHistory.View
{
    public partial class CompositionHistoryControl : UserControl
    {
        public CompositionHistoryControl(int id)
        {
            InitializeComponent();

            DataContext = new CompositionHistoryViewModel(id); 
        }
    }
}
