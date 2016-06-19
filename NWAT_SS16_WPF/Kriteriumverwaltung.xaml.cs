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
    /// Interaktionslogik für Kriteriumverwaltung.xaml
    /// </summary>
    public partial class Kriteriumverwaltung : Window
    {
        private ControllerKriterium cntrl;
        public Kriteriumverwaltung(DatabaseAdapter db)
        {
            InitializeComponent();
            cntrl = new ControllerKriterium(db, this);
            cntrl.onCreateView();
        }

        private void KriteriumverwaltungClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            cntrl.onDestroyView();
        }

        private void anlegen_Click(object sender, RoutedEventArgs e)
        {
            cntrl.anlegen();
        }

        private void item_selected(object sender, SelectionChangedEventArgs e)
        {
            Kriterium objekt = ((sender as ListBox).SelectedItem as Kriterium);
            cntrl.anzeigen(objekt);
        }

        private void struktur_Click(object sender, RoutedEventArgs e)
        {
            Kriterium objekt = new Kriterium(details_ID.Text, details_Bezeichnung.Text);
            cntrl.show_kriteriumstrukturverwaltung(objekt);
        }

        private void kriterium_loeschen_Click(object sender, RoutedEventArgs e)
        {
            Kriterium objekt = (listeKriterium.SelectedItem as Kriterium);
            cntrl.loeschen(objekt);
        }

        private void kriteriumAendern_Click(object sender, RoutedEventArgs e)
        {
            cntrl.aendern();
        }
    }
}
