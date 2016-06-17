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

        private void drop_Click(object sender, RoutedEventArgs e)
        {
            db.drop_tables();
            infoBox.Dispatcher.BeginInvoke(new Action(() => { infoBox.Text = "Tables gedroppt."; }));
        }

        private void init_Click(object sender, RoutedEventArgs e)
        {
            db.init_tables();
            infoBox.Dispatcher.BeginInvoke(new Action(() => { infoBox.Text = "Tables initialisiert."; }));
        }
    }
}
