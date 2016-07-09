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
    /// Interaktionslogik für Export.xaml
    /// </summary>
    public partial class Export : Window
    {
        private DatabaseAdapter db;
        private DatabaseAdabter2 db2;
        private ControllerProjekt cp;

        public Export(DatabaseAdapter db, DatabaseAdabter2 db2)
        {
            InitializeComponent();
            this.db = db;
            this.db2 = db2;
            cp = new ControllerProjekt(db, db2, this);
            textProjektIDexp.Text = Projekt.getProjektIDtemp().ToString();
            textBezeichnungexp.Text = Projekt.getBezeichnungtemp();
        }

        private void abbrechen_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void exportieren_Click(object sender, RoutedEventArgs e)
        {
            cp.export();

            Projekt p = new Projekt(textProjektIDexp.Text);
            cp.loeschen(p);

            this.Close();
        }
    }
}
