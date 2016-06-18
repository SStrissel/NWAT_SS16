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

        private void kriterium_loeschen_Click(object sender, RoutedEventArgs e)
        {          
            Kriterium objekt = (listeKriterium.SelectedItem as Kriterium);
            cntrl.loeschen(objekt);
        }

        private void kriteriumAendern_Click(object sender, RoutedEventArgs e)
        {
            cntrl.aendern();
        }

        private void oberKriterium_selected(object sender, SelectionChangedEventArgs e)
        {
            Kriterium kriterium = (listeKriterium.SelectedItem as Kriterium);
            Kriterium oberkriterium = (details_OberKriterium.SelectedItem as Kriterium);

            if (kriterium == null || oberkriterium == null)
            {
                return;
            }
            if (kriterium.getKriteriumID() == oberkriterium.getKriteriumID())
            {
                MessageBox.Show("Kriterium kann nicht auf sich selbst verweisen.", "OberKriterium", MessageBoxButton.OK, MessageBoxImage.Warning);
                details_OberKriterium.SelectedIndex = details_OberKriterium.Items.Count - 1; // letztes OberKriterium auswählen
            }
        }
    }
}
