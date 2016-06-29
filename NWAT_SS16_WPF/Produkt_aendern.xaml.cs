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
    /// Interaktionslogik für Produkt_aendern.xaml
    /// </summary>
    public partial class Produkt_aendern : Window
    {
        DatabaseAdapter db;
        public Produkt_aendern(DatabaseAdapter db)
        {
            this.db = db;
            InitializeComponent();
        }

        private void abbrechen_Click(object sender, RoutedEventArgs e)
        {

        }

        private void aendern_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
