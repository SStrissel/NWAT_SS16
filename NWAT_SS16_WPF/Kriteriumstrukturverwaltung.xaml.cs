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
    /// Interaktionslogik für Kriteriumstrukturverwaltung.xaml
    /// </summary>
    public partial class Kriteriumstrukturverwaltung : Window
    {
        private ControllerKriterium cntrl;
        public Kriteriumstrukturverwaltung(DatabaseAdapter db, Kriterium objekt)
        {
            InitializeComponent();
            cntrl = new ControllerKriterium(db, this);
            cntrl.onCreateView();
            cntrl.anzeigen(objekt);
        }

        private void untkrit_hinzufuegen_Click(object sender, RoutedEventArgs e)
        {
            cntrl.UnterKriterium_hinzufuegen(details_Kriterium.SelectedItem as Kriterium);
        }

        private void untkrit_loeschen_Click(object sender, RoutedEventArgs e)
        {
            cntrl.UnterKriterium_loeschen(listeUnterKriterium.SelectedItem as Kriterium);
        }





        private void Kriterium_selected(object sender, SelectionChangedEventArgs e)
        {
            cntrl.onUpdateView();
        }

        private void listeUnterKriterium_selected(object sender, SelectionChangedEventArgs e)
        {
            cntrl.onUpdateView();
        }
    }
}
