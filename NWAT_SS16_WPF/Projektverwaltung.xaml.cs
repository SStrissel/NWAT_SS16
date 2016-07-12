using System;
using System.Collections.Generic;
using System.Data;
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
    /// Interaktionslogik für Projektverwaltung.xaml
    /// </summary>
    public partial class Projektverwaltung : Window
    {
        //private DatabaseAdabter2 db2;
        private ControllerProjekt cp;
    
       
        public Projektverwaltung(DatabaseAdapter db)
        {
            InitializeComponent();
            cp = new ControllerProjekt(db, this);
            cp.onCreateView();
            
  
        }

        private void anlegen_Click(object sender, RoutedEventArgs e)
        {
            cp.anlegen();
        }

        private void ListBox_auswahl(object sender, SelectionChangedEventArgs e)
        {
            Projekt p  = ((sender as ListBox).SelectedItem as Projekt);
            cp.anzeigen(p);
        }

        private void loeschen_Click(object sender, RoutedEventArgs e)
        {
            if (detailsProjektID.Text == "")
            {
                MessageBox.Show("Sie haben kein Projekt ausgewählt");
            }
            else
            {
                    Projekt p = new Projekt(detailsProjektID.Text);
                    cp.loeschen(p);
            }
        }
        private void aendern_Click(object sender, RoutedEventArgs e)
        {
            if (detailsProjektID.Text == "")
            {
                MessageBox.Show("Sie haben kein Projekt ausgewählt");
            }
            else
            {
                Projekt.setProjektIDtemp(detailsProjektID.Text);
                Projekt.setBezeichnungtemp(detailsBezeichnung.Text);
                cp.aendern();
            }
        }

        private void export_Click(object sender, RoutedEventArgs e)
        {
            if (detailsProjektID.Text == "")
            {
                MessageBox.Show("Sie haben kein Projekt ausgewählt");
            }
            else
            {
                Projekt.setProjektIDtemp(detailsProjektID.Text);
                Projekt.setBezeichnungtemp(detailsBezeichnung.Text);
                cp.export();
            }
        }

        private void import_Click(object sender, RoutedEventArgs e)
        {
            cp.import(new Projekt());
        }

    }
}
