﻿#pragma checksum "..\..\Kriteriumverwaltung.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "FFD243395B93D3B8D3389689D0D2EFE4"
//------------------------------------------------------------------------------
// <auto-generated>
//     Dieser Code wurde von einem Tool generiert.
//     Laufzeitversion:4.0.30319.42000
//
//     Änderungen an dieser Datei können falsches Verhalten verursachen und gehen verloren, wenn
//     der Code erneut generiert wird.
// </auto-generated>
//------------------------------------------------------------------------------

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


namespace NWAT_SS16 {
    
    
    /// <summary>
    /// Kriteriumverwaltung
    /// </summary>
    public partial class Kriteriumverwaltung : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 6 "..\..\Kriteriumverwaltung.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox listeKriterium;
        
        #line default
        #line hidden
        
        
        #line 7 "..\..\Kriteriumverwaltung.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button kriterium_anlegen;
        
        #line default
        #line hidden
        
        
        #line 8 "..\..\Kriteriumverwaltung.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button kriterium_loeschen;
        
        #line default
        #line hidden
        
        
        #line 9 "..\..\Kriteriumverwaltung.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button kriterium_aendern;
        
        #line default
        #line hidden
        
        
        #line 12 "..\..\Kriteriumverwaltung.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox details_ID;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\Kriteriumverwaltung.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox details_Bezeichnung;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\Kriteriumverwaltung.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox details_ProduktID;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\Kriteriumverwaltung.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox details_ProjektID;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\Kriteriumverwaltung.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button struktur;
        
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
            System.Uri resourceLocater = new System.Uri("/NWAT_SS16;component/kriteriumverwaltung.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\Kriteriumverwaltung.xaml"
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
            
            #line 4 "..\..\Kriteriumverwaltung.xaml"
            ((NWAT_SS16.Kriteriumverwaltung)(target)).Closing += new System.ComponentModel.CancelEventHandler(this.KriteriumverwaltungClosing);
            
            #line default
            #line hidden
            return;
            case 2:
            this.listeKriterium = ((System.Windows.Controls.ListBox)(target));
            
            #line 6 "..\..\Kriteriumverwaltung.xaml"
            this.listeKriterium.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.item_selected);
            
            #line default
            #line hidden
            return;
            case 3:
            this.kriterium_anlegen = ((System.Windows.Controls.Button)(target));
            
            #line 7 "..\..\Kriteriumverwaltung.xaml"
            this.kriterium_anlegen.Click += new System.Windows.RoutedEventHandler(this.anlegen_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.kriterium_loeschen = ((System.Windows.Controls.Button)(target));
            
            #line 8 "..\..\Kriteriumverwaltung.xaml"
            this.kriterium_loeschen.Click += new System.Windows.RoutedEventHandler(this.kriterium_loeschen_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.kriterium_aendern = ((System.Windows.Controls.Button)(target));
            
            #line 9 "..\..\Kriteriumverwaltung.xaml"
            this.kriterium_aendern.Click += new System.Windows.RoutedEventHandler(this.kriteriumAendern_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.details_ID = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.details_Bezeichnung = ((System.Windows.Controls.TextBox)(target));
            return;
            case 8:
            this.details_ProduktID = ((System.Windows.Controls.TextBox)(target));
            return;
            case 9:
            this.details_ProjektID = ((System.Windows.Controls.TextBox)(target));
            return;
            case 10:
            this.struktur = ((System.Windows.Controls.Button)(target));
            
            #line 18 "..\..\Kriteriumverwaltung.xaml"
            this.struktur.Click += new System.Windows.RoutedEventHandler(this.struktur_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

