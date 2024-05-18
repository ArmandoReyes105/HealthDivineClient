using HealthDivineSysClient.Modules.ProgressManagementModule.ConsultHistory.ViewModel;
using System.Windows.Controls;

namespace HealthDivineSysClient.Modules.ProgressManagementModule.ConsultHistory.View
{
    /// <summary>
    /// Lógica de interacción para MeasureHistoryControl.xaml
    /// </summary>
    public partial class MeasureHistoryControl : UserControl
    {
        public MeasureHistoryControl(int id)
        {
            InitializeComponent();
            DataContext = new MeasureHistoryViewModel(id); 
        }
    }
}
