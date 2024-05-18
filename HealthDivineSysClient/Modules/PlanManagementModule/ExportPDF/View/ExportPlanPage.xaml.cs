using HealthDivineSysClient.Modules.PlanManagementModule.ExportPDF.ViewModel;
using System.Windows.Controls;


namespace HealthDivineSysClient.Modules.PlanManagementModule.ExportPDF.View
{
    
    public partial class ExportPlanPage : Page
    {
        public ExportPlanPage(int patientId)
        {
            InitializeComponent();
            DataContext = new ExportPlanViewModel(patientId); 
        }
    }
}
