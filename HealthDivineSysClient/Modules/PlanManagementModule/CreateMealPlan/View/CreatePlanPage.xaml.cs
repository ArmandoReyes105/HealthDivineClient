using HealthDivineSysClient.Helpers;
using HealthDivineSysClient.Modules.PlanManagementModule.CreateMealPlan.ViewModel;
using System.Windows.Controls;

namespace HealthDivineSysClient.Modules.PlanManagementModule.CreateMealPlan.View
{
    public partial class CreatePlanPage : Page
    {
        public CreatePlanPage(int patientId)
        {
            InitializeComponent();
            Loaded += CreatePlanPage_Loaded;
            DataContext = new CreatePlanViewModel(patientId); 
        }

        private void CreatePlanPage_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            AnimatorManager.FadeIn(Main_Grid, .5); 
        }
    }
}
