﻿#pragma checksum "..\..\..\..\..\..\..\Modules\SchedulingModule\CheckCalendar\View\AppointmentControl.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "42E0BB9B61458F17C4C341815E8F48A3B92E4EB7"
//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

using HealthDivineSysClient.Modules.SchedulingModule.CheckCalendar.View;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace HealthDivineSysClient.Modules.SchedulingModule.CheckCalendar.View {
    
    
    /// <summary>
    /// AppointmentControl
    /// </summary>
    public partial class AppointmentControl : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 66 "..\..\..\..\..\..\..\Modules\SchedulingModule\CheckCalendar\View\AppointmentControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid Main_Grid;
        
        #line default
        #line hidden
        
        
        #line 76 "..\..\..\..\..\..\..\Modules\SchedulingModule\CheckCalendar\View\AppointmentControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Border Circle_Border;
        
        #line default
        #line hidden
        
        
        #line 77 "..\..\..\..\..\..\..\Modules\SchedulingModule\CheckCalendar\View\AppointmentControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Border InnerCircle_Border;
        
        #line default
        #line hidden
        
        
        #line 80 "..\..\..\..\..\..\..\Modules\SchedulingModule\CheckCalendar\View\AppointmentControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Border Line_Border;
        
        #line default
        #line hidden
        
        
        #line 83 "..\..\..\..\..\..\..\Modules\SchedulingModule\CheckCalendar\View\AppointmentControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Border Content_Border;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.10.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/HealthDivineSysClient;component/modules/schedulingmodule/checkcalendar/view/appo" +
                    "intmentcontrol.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\..\..\Modules\SchedulingModule\CheckCalendar\View\AppointmentControl.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.10.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.Main_Grid = ((System.Windows.Controls.Grid)(target));
            
            #line 66 "..\..\..\..\..\..\..\Modules\SchedulingModule\CheckCalendar\View\AppointmentControl.xaml"
            this.Main_Grid.MouseEnter += new System.Windows.Input.MouseEventHandler(this.Main_Grid_MouseEnter);
            
            #line default
            #line hidden
            
            #line 66 "..\..\..\..\..\..\..\Modules\SchedulingModule\CheckCalendar\View\AppointmentControl.xaml"
            this.Main_Grid.MouseLeave += new System.Windows.Input.MouseEventHandler(this.Main_Grid_MouseLeave);
            
            #line default
            #line hidden
            return;
            case 2:
            this.Circle_Border = ((System.Windows.Controls.Border)(target));
            return;
            case 3:
            this.InnerCircle_Border = ((System.Windows.Controls.Border)(target));
            return;
            case 4:
            this.Line_Border = ((System.Windows.Controls.Border)(target));
            return;
            case 5:
            this.Content_Border = ((System.Windows.Controls.Border)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}
