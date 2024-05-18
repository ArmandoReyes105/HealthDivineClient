using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HealthDivineSysClient.View.UserControls
{
    /// <summary>
    /// Lógica de interacción para DividerControl.xaml
    /// </summary>
    public partial class DividerControl : UserControl
    {

        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register("DividerText", typeof(string), typeof(ProgressCircleControl), new PropertyMetadata("Content"));

        public string DividerText
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        public DividerControl()
        {
            InitializeComponent();
        }
    }
}
