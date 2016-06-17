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
                krit.listeKriterium.SelectedIndex = krit.listeKriterium.Items.Count - 1;
            }
        }


        public override void onCreateView()
        {
            if (frm.GetType().Name == "Kriteriumverwaltung")
            {
                Kriteriumverwaltung krit = (Kriteriumverwaltung)frm;
                List<Kriterium> items = db.get(new Kriterium());
                krit.listeKriterium.ItemsSource = items;
                
            }
        }

        public override void onUpdateView()
        {
            if (frm.GetType().Name == "Kriteriumverwaltung")
            {
                Kriteriumverwaltung krit = (Kriteriumverwaltung)frm;
                List<Kriterium> items = db.get(new Kriterium());
                krit.listeKriterium.ItemsSource = items;

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
            }
        }

        public override void loeschen(Model objekt)
        {
            if (objekt == null)
            {
                return;
            }
            if (MessageBox.Show("Sind Sie sich sicher, dass sie das ausgewählte Kriterium löschen wollen?", "Löschen", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                db.delete(objekt);
                onUpdateView();
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
