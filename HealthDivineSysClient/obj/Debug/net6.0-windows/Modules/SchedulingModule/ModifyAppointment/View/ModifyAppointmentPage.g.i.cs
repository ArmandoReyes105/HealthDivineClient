﻿#pragma checksum "..\..\..\..\..\..\..\Modules\SchedulingModule\ModifyAppointment\View\ModifyAppointmentPage.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7BD77DD684309A0252B4D8648BD4D8EF49FFF183"
//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

using HealthDivineSysClient.Modules.SchedulingModule.ModifyAppointment;
using HealthDivineSysClient.View.UserControls;
using LottieSharp.WPF;
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


namespace HealthDivineSysClient.Modules.SchedulingModule.ModifyAppointment.View {
    
    
    /// <summary>
    /// ModifyAppointmentPage
    /// </summary>
    public partial class ModifyAppointmentPage : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 13 "..\..\..\..\..\..\..\Modules\SchedulingModule\ModifyAppointment\View\ModifyAppointmentPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid Main_Grid;
        
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
            System.Uri resourceLocater = new System.Uri("/HealthDivineSysClient;component/modules/schedulingmodule/modifyappointment/view/" +
                    "modifyappointmentpage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\..\..\Modules\SchedulingModule\ModifyAppointment\View\ModifyAppointmentPage.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.10.0")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal System.Delegate _CreateDelegate(System.Type delegateType, string handler) {
            return System.Delegate.CreateDelegate(delegateType, this, handler);
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
            return;
            case 2:
            
            #line 92 "..\..\..\..\..\..\..\Modules\SchedulingModule\ModifyAppointment\View\ModifyAppointmentPage.xaml"
            ((System.Windows.Controls.TextBox)(target)).AddHandler(System.Windows.Input.CommandManager.PreviewExecutedEvent, new System.Windows.Input.ExecutedRoutedEventHandler(this.ValidateNoPaste));
            
            #line default
            #line hidden
            
            #line 93 "..\..\..\..\..\..\..\Modules\SchedulingModule\ModifyAppointment\View\ModifyAppointmentPage.xaml"
            ((System.Windows.Controls.TextBox)(target)).PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.ValidateOnlyNumbers);
            
            #line default
            #line hidden
            
            #line 94 "..\..\..\..\..\..\..\Modules\SchedulingModule\ModifyAppointment\View\ModifyAppointmentPage.xaml"
            ((System.Windows.Controls.TextBox)(target)).PreviewKeyDown += new System.Windows.Input.KeyEventHandler(this.ValidateNoBlanckSpace);
            
            #line default
            #line hidden
            return;
            case 3:
            
            #line 98 "..\..\..\..\..\..\..\Modules\SchedulingModule\ModifyAppointment\View\ModifyAppointmentPage.xaml"
            ((System.Windows.Controls.TextBox)(target)).AddHandler(System.Windows.Input.CommandManager.PreviewExecutedEvent, new System.Windows.Input.ExecutedRoutedEventHandler(this.ValidateNoPaste));
            
            #line default
            #line hidden
            
            #line 99 "..\..\..\..\..\..\..\Modules\SchedulingModule\ModifyAppointment\View\ModifyAppointmentPage.xaml"
            ((System.Windows.Controls.TextBox)(target)).PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.ValidateOnlyNumbers);
            
            #line default
            #line hidden
            
            #line 100 "..\..\..\..\..\..\..\Modules\SchedulingModule\ModifyAppointment\View\ModifyAppointmentPage.xaml"
            ((System.Windows.Controls.TextBox)(target)).PreviewKeyDown += new System.Windows.Input.KeyEventHandler(this.ValidateNoBlanckSpace);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

