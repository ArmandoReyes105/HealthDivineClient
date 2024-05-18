using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;

namespace HealthDivineSysClient.View.UserControls
{
    
    public partial class ConsultChartControl : UserControl
    {

        public static readonly DependencyProperty _headerText = 
            DependencyProperty.Register("Header", typeof(string), typeof(ConsultChartControl), new PropertyMetadata("")); 

        public static readonly DependencyProperty _valueText =
            DependencyProperty.Register("Value", typeof(string), typeof(ConsultChartControl), new PropertyMetadata(""));

        public static readonly DependencyProperty _valueTypeText =
            DependencyProperty.Register("ValueType", typeof(string), typeof(ConsultChartControl), new PropertyMetadata(""));

        public static readonly DependencyProperty _icon =
            DependencyProperty.Register("Icon", typeof(string), typeof(ConsultChartControl), new PropertyMetadata(""));

        public static readonly DependencyProperty _command =
            DependencyProperty.Register("Command", typeof(ICommand), typeof(ConsultChartControl), new PropertyMetadata());

        public static readonly DependencyProperty _commandParameter =
            DependencyProperty.Register("CommandParameter", typeof(int), typeof(ConsultChartControl), new PropertyMetadata()); 

        public string Header
        {
            get { return (string)GetValue(_headerText); }
            set { SetValue(_headerText, value); }
        }

        public string Value
        {
            get { return (string)GetValue(_valueText); }
            set { SetValue(_valueText, value);}
        }

        public string ValueType
        {
            get { return (string)GetValue(_valueTypeText); }
            set { SetValue(_valueTypeText, value); }
        }

        public string Icon
        {
            get { return (string)GetValue(_icon); }
            set { SetValue(_icon, value); }
        }

        public ICommand Command
        {
            get { return (ICommand)GetValue(_command); }
            set { SetValue(_command, value); }
        }

        public int CommandParameter
        {
            get { return (int)GetValue(_commandParameter); }
            set { SetValue(_commandParameter, value); }
        }

        public ConsultChartControl()
        {
            InitializeComponent();
        }
    }
}
