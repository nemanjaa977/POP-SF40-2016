﻿#pragma checksum "..\..\..\UI\GlavniMeniWindow.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "91AAAF90C9CDE2853274288F676F816F"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using POP_SF_40_2016_GUI.UI;
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


namespace POP_SF_40_2016_GUI.UI {
    
    
    /// <summary>
    /// GlavniMeniWindow
    /// </summary>
    public partial class GlavniMeniWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 11 "..\..\..\UI\GlavniMeniWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnPrikazi;
        
        #line default
        #line hidden
        
        
        #line 12 "..\..\..\UI\GlavniMeniWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnPrikaziTip;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\..\UI\GlavniMeniWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnAkcije;
        
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
            System.Uri resourceLocater = new System.Uri("/POP-SF-40-2016-GUI;component/ui/glavnimeniwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\UI\GlavniMeniWindow.xaml"
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
            this.btnPrikazi = ((System.Windows.Controls.Button)(target));
            
            #line 11 "..\..\..\UI\GlavniMeniWindow.xaml"
            this.btnPrikazi.Click += new System.Windows.RoutedEventHandler(this.PrikaziNamestaj);
            
            #line default
            #line hidden
            return;
            case 2:
            this.btnPrikaziTip = ((System.Windows.Controls.Button)(target));
            
            #line 12 "..\..\..\UI\GlavniMeniWindow.xaml"
            this.btnPrikaziTip.Click += new System.Windows.RoutedEventHandler(this.PrikaziTipNamestaja);
            
            #line default
            #line hidden
            return;
            case 3:
            this.btnAkcije = ((System.Windows.Controls.Button)(target));
            
            #line 13 "..\..\..\UI\GlavniMeniWindow.xaml"
            this.btnAkcije.Click += new System.Windows.RoutedEventHandler(this.PrikaziAkcije_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

