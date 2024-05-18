using HealthDivineSysClient.Helpers;
using HealthDivineSysClient.Modules.ProgressManagementModule.CreateProgressRecord.ViewModel;
using System;
using System.Windows;
using System.Windows.Controls;

namespace HealthDivineSysClient.Modules.ProgressManagementModule.CreateProgressRecord.View
{
    public partial class DiagnosisFormPage : Page
    {
        public DiagnosisFormPage(int patientId)
        {
            InitializeComponent();
            Loaded += DiagnosisFormPage_Loaded;
            DataContext = new DiagnosisFormViewModel(patientId); 
        }

        private void DiagnosisFormPage_Loaded(object sender, RoutedEventArgs e)
        {
            AnimatorManager.FadeIn(Main_Grid, .5);
            Diagnosis_Control.MarkAsCurrent();
        }
    }
}
