﻿using System;
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
using System.Windows.Shapes;

namespace NWAT_SS16
{
    /// <summary>
    /// Interaktionslogik für Hauptmenue.xaml
    /// Die Views der Hauptankerpunkt sowie dazugehörigen Views wurden je nach Zugehörigkeit erstellt
    /// ProjektViews(zzgl. Import/Export): Tektas
    /// ProduktViews: Huber
    /// KriteriumViews(zzgl. Login/Hauptmenue/Nutzwertverwaltung): Strissel
    /// NutzwertViews. Wusterhausen
    /// </summary>
    public partial class Hauptmenue : Window
    {
        private DatabaseAdapter db;
       
      
        public Hauptmenue(DatabaseAdapter db)
        {
            this.db = db;
            InitializeComponent();
        }

        private void Projekt_Click(object sender, RoutedEventArgs e)
        {
            Projektverwaltung projv = new Projektverwaltung(db);
            projv.ShowDialog();
        }


        private void Produkt_Click(object sender, RoutedEventArgs e)
        {
            Produktverwaltung prod = new Produktverwaltung(db);
            prod.ShowDialog();

        }
        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            NutzwertVerwaltung frm = new NutzwertVerwaltung(db);
            frm.ShowDialog();
           // MessageBox.Show("Diese Funktion ist noch nicht integriert", "Die Waschmaschine hat eine Socke gefressen...", MessageBoxButton.OK);
        }

        private void kriterienverwaltung_click(object sender, RoutedEventArgs e)
        {
            Kriteriumverwaltung frm = new Kriteriumverwaltung(db);
            frm.ShowDialog();
        }

        private void einstellungen_Click(object sender, RoutedEventArgs e)
        {
            Einstellungen frm = new Einstellungen(db);
            frm.ShowDialog();
        }
    }
}
