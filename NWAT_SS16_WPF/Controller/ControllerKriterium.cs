using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace NWAT_SS16
{


     public class ControllerKriterium : Controller
    {


       public ControllerKriterium(DatabaseAdapter db, Window frm) : base(db, frm) { }

       public void aendern(Kriterium objekt, int ProjektID = 0, int ProduktID = 0)
        {
            throw new NotImplementedException();
        }

        public void drucken(bool erfuellung, bool gewichtung, bool nutzwert, bool prozent, int ProjektID, int[] ProduktID)
        {
            throw new NotImplementedException();
        }

        public override void anlegen()
        {
            if (frm.GetType().Name == "Kriteriumverwaltung")
            {
                Kriteriumverwaltung krit = (Kriteriumverwaltung)frm;
                Kriterium temp_objekt = new Kriterium();
                temp_objekt.setBezeichnung("Neues Kriterium");
                db.insert(temp_objekt);
                onUpdateView();
                krit.listeKriterium.SelectedIndex = krit.listeKriterium.Items.Count - 1; // letztes Kriterium auswählen
            }
        }


        public override void onCreateView()
        {
            if (frm.GetType().Name == "Kriteriumverwaltung")
            {
                Kriteriumverwaltung krit = (Kriteriumverwaltung)frm;
                List<Kriterium> kriterien = db.get(new Kriterium());
                krit.listeKriterium.ItemsSource = kriterien;

                List<Kriterium> oberkriterien = kriterien;
                Kriterium temp_objekt = new Kriterium();
                temp_objekt.setBezeichnung("Kein Oberkriterium");
                oberkriterien.Add(temp_objekt);
                krit.details_OberKriterium.ItemsSource = oberkriterien;
                krit.details_OberKriterium.SelectedIndex = krit.details_OberKriterium.Items.Count - 1; // letztes OberKriterium auswählen
            }
        }

        public override void onUpdateView()
        {
            if (frm.GetType().Name == "Kriteriumverwaltung")
            {
                Kriteriumverwaltung krit = (Kriteriumverwaltung)frm;
                List<Kriterium> kriterien = db.get(new Kriterium());
                krit.listeKriterium.ItemsSource = kriterien;

                List<Kriterium> oberkriterien = kriterien;
                Kriterium temp_objekt = new Kriterium();
                temp_objekt.setBezeichnung("Kein Oberkriterium");
                oberkriterien.Add(temp_objekt);
                krit.details_OberKriterium.ItemsSource = oberkriterien;


                krit.details_OberKriterium.SelectedIndex = krit.details_OberKriterium.Items.Count - 1; // letztes OberKriterium auswählen
            }
        }

       public override void onDestroyView()
        {
           // checken, ob Änderungen gemacht wurden
        }

        public override void anzeigen(Model objekt, int ProduktID = 0, int ProjektID = 0)
        {
            if (objekt == null)
            {
                return;
            }
            if (frm.GetType().Name == "Kriteriumverwaltung")
            {
                Kriterium temp_objekt = (Kriterium)objekt;
                Kriteriumverwaltung krit = (Kriteriumverwaltung)frm;

                krit.details_ID.Text = temp_objekt.getKriteriumID().ToString();
                krit.details_Bezeichnung.Text = temp_objekt.getBezeichnung();
                krit.details_ProduktID.Text = "0"; // Standard
                krit.details_ProjektID.Text = "0"; // Standard
                krit.kriterium_aendern.IsEnabled = true;
                krit.kriterium_loeschen.IsEnabled = true;
                krit.details_OberKriterium.IsEnabled = true;
                krit.details_Bezeichnung.IsEnabled = true;
            }
        }

        public override void loeschen(Model objekt)
        {
            if (objekt == null)
            {
                return;
            }
            if (frm.GetType().Name == "Kriteriumverwaltung")
            {
                Kriteriumverwaltung krit = (Kriteriumverwaltung)frm;
                if (MessageBox.Show("Sind Sie sich sicher, dass sie das ausgewählte Kriterium löschen wollen?", "Löschen", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                {
                    db.delete(objekt);
                    krit.kriterium_aendern.IsEnabled = false;
                    krit.kriterium_loeschen.IsEnabled = false;
                    krit.details_OberKriterium.IsEnabled = false;
                    krit.details_Bezeichnung.IsEnabled = false;
                    krit.details_Bezeichnung.Text = "";
                    krit.details_ID.Text = "";
                    krit.details_ProduktID.Text = "";
                    krit.details_ProjektID.Text = "";
                    onUpdateView();
                }
            }
        }

        public override void aendern()
        {
            if (frm.GetType().Name == "Kriteriumverwaltung")
            {
                Kriteriumverwaltung krit = (Kriteriumverwaltung)frm;
                if (krit.details_ID.Text != "")
                {
                    if (MessageBox.Show("Sind Sie sich sicher, dass sie das ausgewählte Kriterium ändern wollen?", "Ändern", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                    {

                        Kriterium temp_objekt = new Kriterium();
                        temp_objekt.setKriteriumID(Int32.Parse(krit.details_ID.Text));
                        temp_objekt.setBezeichnung(krit.details_Bezeichnung.Text);
                        db.update(temp_objekt);
                        onUpdateView();
                    }
                }
            }
        }


    }

}
