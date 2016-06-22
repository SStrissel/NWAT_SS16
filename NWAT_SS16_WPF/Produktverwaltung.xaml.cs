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
            cntrl = new ControllerProdukt(db,this);
            
        }

            private void produktanlegen_Click(object sender, RoutedEventArgs e)
        {
            cntrl.anlegen();
        }

            private void produktloeschen_Click(object sender, RoutedEventArgs e)
        {
            cntrl.loeschen(listeProdukt.SelectedItem as Produkt);
        }



            private void produktanzeigen_Click(object sender, RoutedEventArgs e)
               {
                   cntrl.anzeigen();
               }

            private void produktaendern_Click(object sender, RoutedEventArgs e)
            {
                cntrl.aendern();
            }

                    
        
    }
}
