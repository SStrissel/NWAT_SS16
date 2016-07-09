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
    /// </summary>
    public partial class Hauptmenue : Window
    {
        private DatabaseAdapter db;
        private DatabaseAdabter2 db2;
       
      
        public Hauptmenue(DatabaseAdapter db, DatabaseAdabter2 db2)
        {
            this.db = db;
            this.db2 = db2;
            InitializeComponent();
        }

        private void Projekt_Click(object sender, RoutedEventArgs e)
        {
            Projektverwaltung projv = new Projektverwaltung(db,db2);
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
