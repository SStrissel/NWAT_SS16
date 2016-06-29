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
    /// Interaktionslogik für Einstellungen.xaml
    /// </summary>
    public partial class Einstellungen : Window
    {
        DatabaseAdapter db;
        public Einstellungen(DatabaseAdapter db)
        {
            this.db = db;
            InitializeComponent();
        }

         private void resetProdukt_Click(object sender, RoutedEventArgs e)
        {
            db.reset_produkt();
            infoBox.Dispatcher.BeginInvoke(new Action(() => { infoBox.Text = "Produkt-Tabelle neu initalisiert."; }));
        }

         private void resetKritierium_Click(object sender, RoutedEventArgs e)
         {
             db.reset_kriterium();
             infoBox.Dispatcher.BeginInvoke(new Action(() => { infoBox.Text = "Kriterium-Tabelle neu initalisiert."; }));
         }

         private void initTables_Click(object sender, RoutedEventArgs e)
         {
             db.init_tables();
             infoBox.Dispatcher.BeginInvoke(new Action(() => { infoBox.Text = "Tables initialisiert."; }));
         }
    }
}
