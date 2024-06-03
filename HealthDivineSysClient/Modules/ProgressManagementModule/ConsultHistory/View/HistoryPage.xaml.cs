using HealthDivineSysClient.Helpers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using UserManagementService;

namespace HealthDivineSysClient.Modules.ProgressManagementModule.ConsultHistory.View
{
    
    public partial class HistoryPage : Page
    {

        private int patientId = 0;
        private int count = 0; 

        public HistoryPage(int patientId)
        {
            count = 0; 
            InitializeComponent();

            this.patientId = patientId;
            Loaded += HistoryPage_Loaded;
            
        }

        private void HistoryPage_Loaded(object sender, RoutedEventArgs e)
        {
            MeasureHistoryControl measureControl = new(patientId);
            Grid.SetRow(measureControl, 2);
            Principal_Grid.Children.Add(measureControl);
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            RemoveControlFromRow(2); 

            RadioButton radioButton = sender as RadioButton;
            if (radioButton != null)
            {
                switch (radioButton.Name)
                {
                    case "Measures_RadioButton":
                        if (count != 0)
                        {
                            MeasureHistoryControl measureControl = new(patientId);
                            Grid.SetRow(measureControl, 2);
                            Principal_Grid.Children.Add(measureControl);
                        }
                        count++; 
                        break;
                    case "Composition_RadioButton":
                        CompositionHistoryControl compositionControl = new(patientId);
                        Grid.SetRow(compositionControl, 2);
                        Principal_Grid.Children.Add(compositionControl);
                        break;
                }
            }
        }

        private void RemoveControlFromRow(int row)
        {
            UIElement elementToRemove = null;
            foreach (UIElement element in Principal_Grid.Children)
            {
                if (Grid.GetRow(element) == row)
                {
                    elementToRemove = element;
                    break;
                }
            }
            if (elementToRemove != null)
            {
                Principal_Grid.Children.Remove(elementToRemove);
            }
        }

        private void Return_Click(object sender, RoutedEventArgs e)
        {
            NavigationManager.Instance.NavigateBack(); 
        }
    }
}
