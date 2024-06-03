using HealthDivineSysClient.Helpers;
using HealthDivineSysClient.ViewModel.ViewModelTemplates;
using LiveCharts.Wpf;
using LiveCharts;
using ProgressManagementService;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media;

namespace HealthDivineSysClient.Modules.ProgressManagementModule.ConsultHistory.ViewModel
{
    public class CompositionHistoryViewModel : ViewModelBase
    {

        //Fields
        private ObservableCollection<CompositionInfo> _compositions = new ObservableCollection<CompositionInfo>();
        private Diagnosis _currentDiagnosis = new();
        private SeriesCollection _lineSeriesCollection = new();
        private List<string> _labels = new();
        private string _chartSelected = "";


        //Properties
        public ObservableCollection<CompositionInfo> Compositions
        {
            get => _compositions;
            set { _compositions = value; OnPropertyChanged(nameof(Compositions)); }
        }

        public Diagnosis CurrentDiagnosis
        {
            get => _currentDiagnosis;
            set { _currentDiagnosis = value; OnPropertyChanged(nameof(CurrentDiagnosis)); }
        }

        public SeriesCollection LineSeriesCollection
        {
            get => _lineSeriesCollection;
            set { _lineSeriesCollection = value; OnPropertyChanged(nameof(LineSeriesCollection)); }
        }

        public List<string> Labels
        {
            get => _labels;
            set { _labels = value; OnPropertyChanged(nameof(Labels)); }
        }

        public string ChartSelected
        {
            get => _chartSelected;
            set { _chartSelected = value; OnPropertyChanged(nameof(ChartSelected)); }
        }

        //Commands
        public ICommand ShowChartCommand { get; }

        //Constructor
        public CompositionHistoryViewModel(int id)
        {
            ShowChartCommand = new RelayCommand(ExecuteShowChartCommand);

            LoadInfo(id);
        }

        //CommandsImplementation
        private void ExecuteShowChartCommand(object obj)
        {
            int option = (int)obj;

            ChartValues<double> values = new ChartValues<double>();
            List<CompositionInfo> measureInfos = Compositions.ToList();

            switch (option)
            {
                case 1:
                    ChartSelected = "Peso total";
                    values = new ChartValues<double>(measureInfos.ConvertAll(m => m.TotalWeight)); break;
                case 2:
                    ChartSelected = "Grasa";
                    values = new ChartValues<double>(measureInfos.ConvertAll(m => m.FatPercentage)); break;
                case 3:
                    ChartSelected = "Grasa Visceral";
                    values = new ChartValues<double>(measureInfos.ConvertAll(m => m.VisceralFat)); break;
                case 4:
                    ChartSelected = "Musculo";
                    values = new ChartValues<double>(measureInfos.ConvertAll(m => m.MusclePercentage)); break;
                case 5:
                    ChartSelected = "Agua";
                    values = new ChartValues<double>(measureInfos.ConvertAll(m => m.WaterPercentage)); break;
            }

            LoadChart(values);
        }

        //Methods
        private async void LoadInfo(int patientId)
        {
            ProgressManagementServiceClient progressClient = new ProgressManagementServiceClient();
            progressClient.InnerChannel.OperationTimeout = TimeSpan.FromSeconds(10);

            try
            {
                Diagnosis[] diagnosislist = await progressClient.GetDiagnosisByPatientAsync(patientId);

                if (diagnosislist != null)
                {

                    foreach (var diagnosis in diagnosislist)
                    {
                        CompositionInfo measure = new CompositionInfo();
                        measure.Date = diagnosis.DiagnosisDate.ToShortDateString();
                        measure.TotalWeight = diagnosis.BodyComposition.TotalWeight;
                        measure.WaterPercentage = diagnosis.BodyComposition.WaterPercentage;
                        measure.MusclePercentage = diagnosis.BodyComposition.MusclePercentage;
                        measure.FatPercentage = diagnosis.BodyComposition.FatPercentage;
                        measure.VisceralFat = diagnosis.BodyComposition.VisceralFat;

                        Compositions.Add(measure);

                    }

                    CurrentDiagnosis = diagnosislist[diagnosislist.Length - 1];

                    List<CompositionInfo> measureInfos = Compositions.ToList();
                    ChartSelected = "Pecho";
                    LoadChart(new ChartValues<double>(measureInfos.ConvertAll(m => m.TotalWeight)));
                }
                else
                {
                    DialogManager.ShowNotification("Error con la base de datos", "Ocurrio un error al intentar recuperar los registros del paciente de la base de datos");
                    NavigationManager.Instance.NavigateBack();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                DialogManager.ShowNotification("Error de conexion con el servidor", "Ocurrio un error al intentar conectarse con el servidor, resive su conexion a internet o intentelo mas tarde");
                NavigationManager.Instance?.NavigateBack();
            }
            finally
            {
                progressClient.Close();
            }
        }

        private void LoadChart(ChartValues<double> values)
        {
            List<CompositionInfo> measureInfos = Compositions.ToList();

            Labels = measureInfos.Select(m => m.Date).ToList();

            var lineSeries = new LineSeries
            {
                Title = ChartSelected,
                Values = values,
                StrokeThickness = 3,
                Stroke = (SolidColorBrush)NavigationManager.Instance.GetMainWindow().Resources["AccentColor"],
                PointGeometrySize = 10
            };

            string hexColor = "#3BB6B7";
            Color accentColor = (Color)ColorConverter.ConvertFromString(hexColor);

            string secondaryColor = "#103BB6B7";
            Color secondary = (Color)ColorConverter.ConvertFromString(secondaryColor);

            var gradientBrush = new LinearGradientBrush();
            gradientBrush.GradientStops.Add(new GradientStop(accentColor, 0.1));
            gradientBrush.GradientStops.Add(new GradientStop(secondary, 1.0));

            lineSeries.Fill = gradientBrush;

            LineSeriesCollection = new SeriesCollection { lineSeries };
        }

        //Class 
        public class CompositionInfo
        {
            public string Date { get; set; }
            public double TotalWeight { get; set; }
            public double MusclePercentage { get; set; }
            public double WaterPercentage { get; set; }
            public double FatPercentage { get; set; }
            public double VisceralFat { get; set; }
        }

    }
}
