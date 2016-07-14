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
    /// Interaktionslogik für KriteriumNutzwertVerwaltung.xaml
    /// </summary>
    public partial class KriteriumNutzwertVerwaltung : Window
    {
        private ControllerKriterium cntrl;
        public KriteriumNutzwertVerwaltung(DatabaseAdapter db, Nutzwert objekt)
        {
            InitializeComponent();
            cntrl = new ControllerKriterium(db, this);
            cntrl.onCreateView();
            cntrl.anzeigen(objekt);
        }

        private void aendern_Click(object sender, RoutedEventArgs e)
        {
            cntrl.aendern();
        }

        private void loeschen_Click(object sender, RoutedEventArgs e)
        {
            Nutzwert objekt = new Nutzwert(KriteriumID: details_KriteriumID.Text, ProduktID: details_ProduktID.Text, ProjektID: details_ProjektID.Text);
            cntrl.loeschen(objekt);
        }

        private void details_Abstufung_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
