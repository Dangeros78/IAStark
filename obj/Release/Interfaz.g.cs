﻿#pragma checksum "..\..\Interfaz.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "3F6B16D5C4C8F96A943F62AAAF7E9D13018517D397FB538BF7278A809841E6AA"
//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

using STARK;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
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


namespace STARK {
    
    
    /// <summary>
    /// Interfaz
    /// </summary>
    public partial class Interfaz : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 27 "..\..\Interfaz.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image image;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\Interfaz.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnComandos;
        
        #line default
        #line hidden
        
        
        #line 39 "..\..\Interfaz.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnAjustes;
        
        #line default
        #line hidden
        
        
        #line 40 "..\..\Interfaz.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnNotificaciones;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\Interfaz.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnAlarma;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/STARK;component/interfaz.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\Interfaz.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 8 "..\..\Interfaz.xaml"
            ((STARK.Interfaz)(target)).Activated += new System.EventHandler(this.Window_Activated);
            
            #line default
            #line hidden
            
            #line 8 "..\..\Interfaz.xaml"
            ((STARK.Interfaz)(target)).Closing += new System.ComponentModel.CancelEventHandler(this.Window_Closing);
            
            #line default
            #line hidden
            return;
            case 2:
            this.image = ((System.Windows.Controls.Image)(target));
            return;
            case 3:
            this.btnComandos = ((System.Windows.Controls.Button)(target));
            
            #line 38 "..\..\Interfaz.xaml"
            this.btnComandos.Click += new System.Windows.RoutedEventHandler(this.btnComandos_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.btnAjustes = ((System.Windows.Controls.Button)(target));
            
            #line 39 "..\..\Interfaz.xaml"
            this.btnAjustes.Click += new System.Windows.RoutedEventHandler(this.btnAjustes_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.btnNotificaciones = ((System.Windows.Controls.Button)(target));
            
            #line 40 "..\..\Interfaz.xaml"
            this.btnNotificaciones.Click += new System.Windows.RoutedEventHandler(this.btnNotificaciones_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.btnAlarma = ((System.Windows.Controls.Button)(target));
            
            #line 41 "..\..\Interfaz.xaml"
            this.btnAlarma.Click += new System.Windows.RoutedEventHandler(this.btnAlarma_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
