using HealthDivineSysClient.Helpers;
using HealthDivineSysClient.View.Dialogs;
using HealthDivineSysClient.ViewModel.ViewModelTemplates;
using LiveCharts;
using LiveCharts.Wpf;
using ProgressManagementService;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using static HealthDivineSysClient.Modules.ProgressManagementModule.ConsultHistory.ViewModel.MeasureHistoryViewModel;

namespace HealthDivineSysClient.Modules.ProgressManagementModule.ConsultHistory.ViewModel
{
    public class MeasureHistoryViewModel : ViewModelBase
    {
        //Atributes

        //Fields
        private ObservableCollection<MeasureInfo> _measures = new ObservableCollection<MeasureInfo>();
        private Diagnosis _currentDiagnosis = new();
        private SeriesCollection _lineSeriesCollection = new();
        private List<string> _labels = new();
        private string _chartSelected = ""; 


        //Properties
        public ObservableCollection<MeasureInfo> Measures
        {
            get => _measures;
            set { _measures = value; OnPropertyChanged(nameof(Measures)); }
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
        public MeasureHistoryViewModel(int id)
        {
            ShowChartCommand = new RelayCommand(ExecuteShowChartCommand); 

            LoadInfo(id);
        }

        //CommandsImplementation
        private void ExecuteShowChartCommand(object obj)
        {
            int option = (int)obj;

            ChartValues<double> values = new ChartValues<double>();
            List<MeasureInfo> measureInfos = Measures.ToList();

            switch (option)
            {
                case 1:
                    ChartSelected = "Pecho"; 
                    values = new ChartValues<double>(measureInfos.ConvertAll(m => m.Chest)); break; 
                case 2:
                    ChartSelected = "Brazo contraido"; 
                    values = new ChartValues<double>(measureInfos.ConvertAll(m => m.ContractedArm)); break;
                case 3:
                    ChartSelected = "Cadera"; 
                    values = new ChartValues<double>(measureInfos.ConvertAll(m => m.Hip)); break;
                case 4:
                    ChartSelected = "Muslo"; 
                    values = new ChartValues<double>(measureInfos.ConvertAll(m => m.Thigh)); break;
                case 5:
                    ChartSelected = "Brazo"; 
                    values = new ChartValues<double>(measureInfos.ConvertAll(m => m.Arm)); break;
                case 6:
                    ChartSelected = "Cintura"; 
                    values = new ChartValues<double>(measureInfos.ConvertAll(m => m.Waist)); break;
                case 7:
                    ChartSelected = "Antebrazo"; 
                    values = new ChartValues<double>(measureInfos.ConvertAll(m => m.Forearm)); break;
                case 8:
                    ChartSelected = "Pantorilla"; 
                    values = new ChartValues<double>(measureInfos.ConvertAll(m => m.Calf)); break;
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
                        MeasureInfo measure = new MeasureInfo();
                        measure.Date = diagnosis.DiagnosisDate.ToShortDateString();
                        measure.Chest = diagnosis.Measure.Chest; 
                        measure.Arm = diagnosis.Measure.Arm;
                        measure.ContractedArm = diagnosis.Measure.ContractedArm; 
                        measure.Hip = diagnosis.Measure.Hip;
                        measure.Calf = diagnosis.Measure.Calf;
                        measure.Waist = diagnosis.Measure.Waist;
                        measure.Thigh = diagnosis.Measure.Thigh; 
                        measure.Forearm = diagnosis.Measure.Forearm;

                        Measures.Add(measure);

                    }

                    CurrentDiagnosis = diagnosislist[diagnosislist.Length - 1];

                    List<MeasureInfo> measureInfos = Measures.ToList();
                    ChartSelected = "Pecho"; 
                    LoadChart(new ChartValues<double>(measureInfos.ConvertAll(m => m.Chest))); 
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
            List<MeasureInfo> measureInfos = Measures.ToList();

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
        public class MeasureInfo
        {
            public string Date { get; set; }
            public double Chest { get; set;}
            public double Arm {  get; set;}
            public double ContractedArm { get; set;}
            public double Thigh {  get; set;}
            public double Hip { get; set;}
            public double Forearm { get; set;}
            public double Waist { get; set;}
            public double Calf { get; set;}
        }
    }
}
