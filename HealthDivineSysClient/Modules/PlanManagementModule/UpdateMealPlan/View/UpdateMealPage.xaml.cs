using HealthDivineSysClient.Modules.PlanManagementModule.UpdateMealPlan.ViewModel;
using System.Windows.Controls;

namespace HealthDivineSysClient.Modules.PlanManagementModule.UpdateMealPlan.View
{
    
    public partial class UpdateMealPage : Page
    {
        public UpdateMealPage(int patientId)
        {
            InitializeComponent();
            DataContext = new UpdateMealViewModel(patientId); 
        }
    }
}
