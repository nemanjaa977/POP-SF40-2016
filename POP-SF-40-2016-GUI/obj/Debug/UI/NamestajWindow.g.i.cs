﻿#pragma checksum "..\..\..\UI\NamestajWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "A3A261D221107171C25D640FD6991345090FCA6B"
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
    /// NamestajWindow
    /// </summary>
    public partial class NamestajWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 11 "..\..\..\UI\NamestajWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnDodaj;
        
        #line default
        #line hidden
        
        
        #line 12 "..\..\..\UI\NamestajWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dgNamestaj;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\..\UI\NamestajWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnIzmeni;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\..\UI\NamestajWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnIzbrisi;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\..\UI\NamestajWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnZatvori;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\..\UI\NamestajWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnPreuzmi;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\..\UI\NamestajWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label labKolicina;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\..\UI\NamestajWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbKolicina;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\..\UI\NamestajWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label labSort;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\..\UI\NamestajWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cbSortiranjeNAmestaj;
        
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
            System.Uri resourceLocater = new System.Uri("/POP-SF-40-2016-GUI;component/ui/namestajwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\UI\NamestajWindow.xaml"
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
            this.btnDodaj = ((System.Windows.Controls.Button)(target));
            
            #line 11 "..\..\..\UI\NamestajWindow.xaml"
            this.btnDodaj.Click += new System.Windows.RoutedEventHandler(this.DodajNamestaj);
            
            #line default
            #line hidden
            return;
            case 2:
            this.dgNamestaj = ((System.Windows.Controls.DataGrid)(target));
            
            #line 12 "..\..\..\UI\NamestajWindow.xaml"
            this.dgNamestaj.LostFocus += new System.Windows.RoutedEventHandler(this.dgNamestaj_LostFocus);
            
            #line default
            #line hidden
            
            #line 12 "..\..\..\UI\NamestajWindow.xaml"
            this.dgNamestaj.AutoGeneratingColumn += new System.EventHandler<System.Windows.Controls.DataGridAutoGeneratingColumnEventArgs>(this.dgNamestaj_AutoGeneratingColumn);
            
            #line default
            #line hidden
            return;
            case 3:
            this.btnIzmeni = ((System.Windows.Controls.Button)(target));
            
            #line 13 "..\..\..\UI\NamestajWindow.xaml"
            this.btnIzmeni.Click += new System.Windows.RoutedEventHandler(this.IzmeniNamestaj);
            
            #line default
            #line hidden
            return;
            case 4:
            this.btnIzbrisi = ((System.Windows.Controls.Button)(target));
            
            #line 14 "..\..\..\UI\NamestajWindow.xaml"
            this.btnIzbrisi.Click += new System.Windows.RoutedEventHandler(this.IzbrisiNamestaj);
            
            #line default
            #line hidden
            return;
            case 5:
            this.btnZatvori = ((System.Windows.Controls.Button)(target));
            
            #line 15 "..\..\..\UI\NamestajWindow.xaml"
            this.btnZatvori.Click += new System.Windows.RoutedEventHandler(this.ZatvoriNamestaj);
            
            #line default
            #line hidden
            return;
            case 6:
            this.btnPreuzmi = ((System.Windows.Controls.Button)(target));
            
            #line 16 "..\..\..\UI\NamestajWindow.xaml"
            this.btnPreuzmi.Click += new System.Windows.RoutedEventHandler(this.PreuzmiNamestaj);
            
            #line default
            #line hidden
            return;
            case 7:
            this.labKolicina = ((System.Windows.Controls.Label)(target));
            return;
            case 8:
            this.tbKolicina = ((System.Windows.Controls.TextBox)(target));
            return;
            case 9:
            this.labSort = ((System.Windows.Controls.Label)(target));
            return;
            case 10:
            this.cbSortiranjeNAmestaj = ((System.Windows.Controls.ComboBox)(target));
            
            #line 20 "..\..\..\UI\NamestajWindow.xaml"
            this.cbSortiranjeNAmestaj.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.ComboBox_SelectionChanged);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

