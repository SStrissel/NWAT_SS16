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
    /// Interaktionslogik für Produkt_anlegen.xaml
    /// </summary>
    public partial class Produkt_anlegen : Window
    {
        DatabaseAdapter db;
        private ControllerProdukt cprod;
        public Produkt_anlegen(DatabaseAdapter db)
        {
            
            InitializeComponent();
            this.db = db;
            cprod = new ControllerProdukt(db,this);
            cprod.anzeigen(new Produkt());
        }

        private void speichern_Click(object sender, RoutedEventArgs e)
        {
            cprod.anlegen();
            this.Close();
        }

        private void abbrechen_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
