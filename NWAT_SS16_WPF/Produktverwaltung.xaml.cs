using System;
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
    /// Interaktionslogik für Produktverwaltung.xaml
    /// </summary>
    public partial class Produktverwaltung : Window
    {
          private ControllerProdukt cntrl;
        private DatabaseAdapter db;
        public Produktverwaltung(DatabaseAdapter db)
        {
            InitializeComponent();
            this.db = db;
            cntrl = new ControllerProdukt(db,this);
            cntrl.onCreateView();
            
        }

            private void produktanlegen_Click(object sender, RoutedEventArgs e)
        {
            cntrl.anlegen();
        }

            private void produktloeschen_Click(object sender, RoutedEventArgs e)
        {
            Produkt p = new Produkt(details_ProduktID.Text);
            cntrl.loeschen(p);
        }



            

            private void produktaendern_Click(object sender, RoutedEventArgs e)
            {
                Produkt.setProduktIDtemp(details_ProduktID.Text);
                Projekt.setBezeichnungtemp(details_Bezeichnung.Text);
                cntrl.aendern();
            }

            private void Listchanged(object sender, SelectionChangedEventArgs e)
            {
                Produkt p = ((sender as ListBox).SelectedItem as Produkt);
                cntrl.anzeigen(p);
            }

                    
        
    }
}
