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
    /// Teambasierte Ausarbeitung
    /// Hauptverantwortlicher: Wusterhausen
    /// </summary>
    public partial class NutzwertVerwaltung : Window
    {
        //Objekterzeugung des ConontrollerNutzwert
              private ControllerNutzwert cntrl;
        public NutzwertVerwaltung(DatabaseAdapter db)
        {
            InitializeComponent();
            cntrl = new ControllerNutzwert(db, this);
            //cntrl.onCreateView();
            cntrl.onUpdateData();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            int prod1 = ((Produkt)details_Prod1.SelectedItem).getProduktID();
            int prod2 = ((Produkt)details_Prod2.SelectedItem).getProduktID();
            int[] a =  { prod1, prod2};
            int proj =  ((Projekt)details_Proj.SelectedItem).getProjektID();
            
            cntrl.drucken(false, false, true, true, true, proj, a, true);
           
        }
        //Ruft die Funktion gleichgewichten der Klasse ControllerNutzwert auf
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            int prod1 = ((Produkt)details_Prod1.SelectedItem).getProduktID();
            int prod2 = ((Produkt)details_Prod2.SelectedItem).getProduktID();
            int proj = ((Projekt)details_Proj.SelectedItem).getProjektID();  
            cntrl.gleichgewichten(proj, prod1);
            cntrl.gleichgewichten(proj, prod2);
        }

        private void kundenanf_Click(object sender, RoutedEventArgs e)
        {
            int prod1 = ((Produkt)details_Prod1.SelectedItem).getProduktID();
            int prod2 = ((Produkt)details_Prod2.SelectedItem).getProduktID();
            int[] a = { prod1, prod2 };
            int proj = ((Projekt)details_Proj.SelectedItem).getProjektID();            

            cntrl.drucken(false, true, false, false, false, proj, a, false); 
        }

        private void prod1_Click(object sender, RoutedEventArgs e)
        {
            int prod1 = ((Produkt)details_Prod1.SelectedItem).getProduktID();
            int prod2 = ((Produkt)details_Prod2.SelectedItem).getProduktID();
            int[] a = { prod1};
            int proj = ((Projekt)details_Proj.SelectedItem).getProjektID();

            cntrl.drucken(true, false, false, false, false, proj, a, true); 
        }

        private void prod2_Click(object sender, RoutedEventArgs e)
        {
            int prod1 = ((Produkt)details_Prod1.SelectedItem).getProduktID();
            int prod2 = ((Produkt)details_Prod2.SelectedItem).getProduktID();
            int[] a = { prod2 };
            int proj = ((Projekt)details_Proj.SelectedItem).getProjektID();

            cntrl.drucken(true, false, false, false, false, proj, a, true); 
        }

        private void prod_table_Click(object sender, RoutedEventArgs e)
        {
            int prod1 = ((Produkt)details_Prod1.SelectedItem).getProduktID();
            int prod2 = ((Produkt)details_Prod2.SelectedItem).getProduktID();
            int[] a = { prod1, prod2 };
            int proj = ((Projekt)details_Proj.SelectedItem).getProjektID();

            cntrl.drucken(true, true, false, false, false, proj, a, true); 
        }
    }
}
