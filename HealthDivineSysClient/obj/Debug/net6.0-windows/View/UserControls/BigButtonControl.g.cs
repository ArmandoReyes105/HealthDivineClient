﻿#pragma checksum "..\..\..\..\..\View\UserControls\BigButtonControl.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "44527B7CE94C0088167B1274D6DF2908F0A5E83D"
//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

using HealthDivineSysClient.View.UserControls;
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


namespace HealthDivineSysClient.View.UserControls {
    
    
    /// <summary>
    /// BigButtonControl
    /// </summary>
    public partial class BigButtonControl : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 67 "..\..\..\..\..\View\UserControls\BigButtonControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Border Background_Border;
        
        #line default
        #line hidden
        
        
        #line 76 "..\..\..\..\..\View\UserControls\BigButtonControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock Icon_TextBlock;
        
        #line default
        #line hidden
        
        
        #line 80 "..\..\..\..\..\View\UserControls\BigButtonControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock Title_TextBlock;
        
        #line default
        #line hidden
        
        
        #line 82 "..\..\..\..\..\View\UserControls\BigButtonControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock Message_TextBlock;
        
        #line default
        #line hidden
        
        
        #line 86 "..\..\..\..\..\View\UserControls\BigButtonControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock Button_TextBlock;
        
        #line default
        #line hidden
        
        
        #line 87 "..\..\..\..\..\View\UserControls\BigButtonControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Arrow_Button;
        
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
            System.Uri resourceLocater = new System.Uri("/HealthDivineSysClient;component/view/usercontrols/bigbuttoncontrol.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\View\UserControls\BigButtonControl.xaml"
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
            
            #line 66 "..\..\..\..\..\View\UserControls\BigButtonControl.xaml"
            ((System.Windows.Controls.Grid)(target)).MouseEnter += new System.Windows.Input.MouseEventHandler(this.ShowHoverEffect);
            
            #line default
            #line hidden
            
            #line 66 "..\..\..\..\..\View\UserControls\BigButtonControl.xaml"
            ((System.Windows.Controls.Grid)(target)).MouseLeave += new System.Windows.Input.MouseEventHandler(this.HideHoverEffect);
            
            #line default
            #line hidden
            return;
            case 2:
            this.Background_Border = ((System.Windows.Controls.Border)(target));
            return;
            case 3:
            this.Icon_TextBlock = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 4:
            this.Title_TextBlock = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 5:
            this.Message_TextBlock = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 6:
            this.Button_TextBlock = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 7:
            this.Arrow_Button = ((System.Windows.Controls.Button)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}
