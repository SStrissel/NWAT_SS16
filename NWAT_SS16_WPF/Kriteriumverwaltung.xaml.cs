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
    /// Teambasierte Ausarbeitung 
    /// Hauptverantwortlicher: Strissel
    /// </summary>
    public partial class Kriteriumverwaltung : Window
    {
        private ControllerKriterium cntrl;

        //Erzeugen des Objekts der ControllerKriterium Klasse
        public Kriteriumverwaltung(DatabaseAdapter db)
        {
            InitializeComponent();
            cntrl = new ControllerKriterium(db, this);
            cntrl.onCreateView();
        }

        //Aufruf der onDestroyView beim Verlassen des Bildschirms
        private void KriteriumverwaltungClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            cntrl.onDestroyView();
        }

        //Aufruf der anlegen-Funktion der ControllerKriterium Klasse
        private void anlegen_Click(object sender, RoutedEventArgs e)
        {
            cntrl.anlegen();
        }

        //Aufruf der anzeigen-Funktion der ControllerKriterium Klasse
        private void item_selected(object sender, SelectionChangedEventArgs e)
        {
            Kriterium objekt = ((sender as ListBox).SelectedItem as Kriterium);
            cntrl.anzeigen(objekt);
        }

        //Aufruf der View der Kriteriumstrukturverwaltung in neuem Fenster
        private void struktur_Click(object sender, RoutedEventArgs e)
        {
            Kriterium objekt = new Kriterium(details_ID.Text, details_Bezeichnung.Text);
            cntrl.show_kriteriumstrukturverwaltung(objekt);
        }

        //Aufruf der löschen-Funktion in der ControllerKriterium Klasse
        private void kriterium_loeschen_Click(object sender, RoutedEventArgs e)
        {
            Kriterium objekt = new Kriterium(details_ID.Text);
            cntrl.loeschen(objekt);
        }

        //Aufruf der ändern-Funktion in der ControllerKriterium Klasse
        private void kriteriumAendern_Click(object sender, RoutedEventArgs e)
        {
            cntrl.aendern();
        }

        //Erzeugen eines Objekts der Klasse Nutzwert
        //Aufruf der show_kriteriumnutzwertverwaltung-Funktion in der ControllerKriterium Klasse
        private void nutzwert_Click(object sender, RoutedEventArgs e)
        {
            Nutzwert objekt = new Nutzwert(ProjektID: ((Projekt)listeProjektID.SelectedItem).getProjektID().ToString(), ProduktID: ((Produkt)listeProduktID.SelectedItem).getProduktID().ToString(), KriteriumID: details_ID.Text);
            cntrl.show_kriteriumnutzwertverwaltung(objekt);
        }
        //Erzeugen eines Objekts der Klasse Kriterium
        //Aufruf der show_kriteriumnutzwertverwaltung-Funktion in der ControllerKriterium Klasse       
        private void Tree_Click(object sender, RoutedEventArgs e)
        {
            Kriterium objekt = new Kriterium(details_ID.Text);
            cntrl.show_kriteriumtree(objekt);
        }

        //Aufruf der drucken-Funktion in der Klasse ControllerKriterium
        private void drucken_Click(object sender, RoutedEventArgs e)
        {
            cntrl.drucken(true, true, true, true, ((Projekt)listeProjektID.SelectedItem).getProjektID(), new int[] { ((Produkt)listeProduktID.SelectedItem).getProduktID() }, true);
        }
    }
}
