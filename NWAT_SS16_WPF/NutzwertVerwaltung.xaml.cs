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
    /// Interaktionslogik für NutzwertVerwaltung.xaml
    /// </summary>
    public partial class NutzwertVerwaltung : Window
    {
              private ControllerNutzwert cntrl;
        public NutzwertVerwaltung(DatabaseAdapter db)
        {
            InitializeComponent();
            cntrl = new ControllerNutzwert(db, this);
            cntrl.onCreateView();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Nutzwert nutz = new Nutzwert();
            nutz.setKriteriumID(1);
            nutz.setProduktID(1);
            nutz.setProjektID(1);

            cntrl.funktionsabdeckungsgrad_berechnen(nutz);            
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Ranking");
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {            
            cntrl.gleichgewichten();
        }
    }
}
