﻿#pragma checksum "..\..\..\UI\KorisnikWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5D0A18F372AA040E2826E55696184F19851021BC"
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
    /// KorisnikWindow
    /// </summary>
    public partial class KorisnikWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 10 "..\..\..\UI\KorisnikWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dgKorisnik;
        
        #line default
        #line hidden
        
        
        #line 11 "..\..\..\UI\KorisnikWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnDodaj;
        
        #line default
        #line hidden
        
        
        #line 12 "..\..\..\UI\KorisnikWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnIzmeni;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\..\UI\KorisnikWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnIzbrisi;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\..\UI\KorisnikWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnZatvori;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\..\UI\KorisnikWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cbSortKorisnik;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\..\UI\KorisnikWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnPretragaKorisnik;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\..\UI\KorisnikWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbPretragaKorisnik;
        
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
            System.Uri resourceLocater = new System.Uri("/POP-SF-40-2016-GUI;component/ui/korisnikwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\UI\KorisnikWindow.xaml"
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
            this.dgKorisnik = ((System.Windows.Controls.DataGrid)(target));
            
            #line 10 "..\..\..\UI\KorisnikWindow.xaml"
            this.dgKorisnik.AutoGeneratingColumn += new System.EventHandler<System.Windows.Controls.DataGridAutoGeneratingColumnEventArgs>(this.dgKorisnik_AutoGeneratingColumn);
            
            #line default
            #line hidden
            return;
            case 2:
            this.btnDodaj = ((System.Windows.Controls.Button)(target));
            
            #line 11 "..\..\..\UI\KorisnikWindow.xaml"
            this.btnDodaj.Click += new System.Windows.RoutedEventHandler(this.DodajKorisnika);
            
            #line default
            #line hidden
            return;
            case 3:
            this.btnIzmeni = ((System.Windows.Controls.Button)(target));
            
            #line 12 "..\..\..\UI\KorisnikWindow.xaml"
            this.btnIzmeni.Click += new System.Windows.RoutedEventHandler(this.IzmeniKorisnika);
            
            #line default
            #line hidden
            return;
            case 4:
            this.btnIzbrisi = ((System.Windows.Controls.Button)(target));
            
            #line 13 "..\..\..\UI\KorisnikWindow.xaml"
            this.btnIzbrisi.Click += new System.Windows.RoutedEventHandler(this.IzbrisiKorisnika);
            
            #line default
            #line hidden
            return;
            case 5:
            this.btnZatvori = ((System.Windows.Controls.Button)(target));
            
            #line 14 "..\..\..\UI\KorisnikWindow.xaml"
            this.btnZatvori.Click += new System.Windows.RoutedEventHandler(this.ZatvoriKorisnika);
            
            #line default
            #line hidden
            return;
            case 6:
            this.cbSortKorisnik = ((System.Windows.Controls.ComboBox)(target));
            
            #line 16 "..\..\..\UI\KorisnikWindow.xaml"
            this.cbSortKorisnik.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.cbSortKorisnik_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 7:
            this.btnPretragaKorisnik = ((System.Windows.Controls.Button)(target));
            
            #line 17 "..\..\..\UI\KorisnikWindow.xaml"
            this.btnPretragaKorisnik.Click += new System.Windows.RoutedEventHandler(this.PretragaKorisnika);
            
            #line default
            #line hidden
            return;
            case 8:
            this.tbPretragaKorisnik = ((System.Windows.Controls.TextBox)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

