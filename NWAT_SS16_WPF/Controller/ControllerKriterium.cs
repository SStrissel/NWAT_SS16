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
                return;
            }
            throw new NotImplementedException();
        }


        public override void onCreateView()
        {
            if (frm.GetType().Name == "Kriteriumverwaltung")
            {
                Kriteriumverwaltung krit = (Kriteriumverwaltung)frm;
                List<Kriterium> kriterien = db.get(new Kriterium());
                krit.listeKriterium.ItemsSource = kriterien;
                return;
            } else if (frm.GetType().Name == "Kriteriumstrukturverwaltung")
            {
                Kriteriumstrukturverwaltung krit = (Kriteriumstrukturverwaltung)frm;
                List<Kriterium> kriterien = db.get(new Kriterium());
                krit.details_Kriterium.ItemsSource = kriterien;
                if (krit.details_ID.Text != "")
                {
                    Kriterium temp_objekt = new Kriterium();
                    temp_objekt.setKriteriumID(Int32.Parse(krit.details_ID.Text));
                    krit.details_Kriterium.ItemsSource = temp_objekt.getUnterKriterium(db);
                }
                return;
            }
            throw new NotImplementedException();
        }

        public override void onUpdateData()
        {
            if (frm.GetType().Name == "Kriteriumverwaltung")
            {
                Kriteriumverwaltung krit = (Kriteriumverwaltung)frm;

                List<Kriterium> kriterien = db.get(new Kriterium()); // alle Kriterien

                krit.listeKriterium.ItemsSource = kriterien;
                onUpdateView();
                return;
            }
            else if (frm.GetType().Name == "Kriteriumstrukturverwaltung")
            {
                Kriteriumstrukturverwaltung krit = (Kriteriumstrukturverwaltung)frm;
                List<Kriterium> kriterien = db.get(new Kriterium()); // alle Kriterien
                krit.details_Kriterium.ItemsSource = kriterien;

                if (krit.details_ID.Text != "")
                {
                    Kriterium temp_objekt = new Kriterium();
                    temp_objekt.setKriteriumID(Int32.Parse(krit.details_ID.Text));
                    krit.listeUnterKriterium.ItemsSource = temp_objekt.getUnterKriterium(db);
                }
                onUpdateView();
                return;
            }
            throw new NotImplementedException();
        }

        private bool find(List<Kriterium> list, int ID)
        {
            foreach (Kriterium item in list)
            {
                if (item.getKriteriumID() == ID)
                {
                    return true;
                }
            }

            return false;
        }

        public override void onUpdateView()
        {
            if (frm.GetType().Name == "Kriteriumstrukturverwaltung")
            {
                Kriteriumstrukturverwaltung krit = (Kriteriumstrukturverwaltung)frm;

                if (krit.details_Kriterium.SelectedItem != null)
                {
                    Kriterium temp_objekt = (Kriterium)krit.details_Kriterium.SelectedItem;
                    if (temp_objekt.getKriteriumID() != Int32.Parse(krit.details_ID.Text) && find(krit.listeUnterKriterium.ItemsSource as List<Kriterium>, temp_objekt.getKriteriumID()) == false)
                    {
                        krit.untkrit_hinzufuegen.IsEnabled = true;
                    }
                    else
                    {
                        krit.untkrit_hinzufuegen.IsEnabled = false;
                    }
                }
                else
                {
                    krit.untkrit_hinzufuegen.IsEnabled = false;
                }
                if (krit.listeUnterKriterium.SelectedItem != null)
                {
                    krit.untkrit_loeschen.IsEnabled = true;
                }
                else
                {
                    krit.untkrit_loeschen.IsEnabled = false;
                }
                return;
            }
            else if (frm.GetType().Name == "Kriteriumverwaltung")
            {
                Kriteriumverwaltung krit = (Kriteriumverwaltung)frm;
                if (Int32.Parse(krit.details_ID.Text) != 0)
                {
                    krit.struktur.IsEnabled = true;
                }
                else 
                {
                    krit.struktur.IsEnabled = false;
                }
                return;
            }
            throw new NotImplementedException();
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
                krit.details_ProduktID.Text = ProduktID.ToString();
                krit.details_ProjektID.Text = ProjektID.ToString();
                krit.kriterium_aendern.IsEnabled = true;
                krit.kriterium_loeschen.IsEnabled = true;
                krit.details_Bezeichnung.IsEnabled = true;
                onUpdateData();
                return;
            } 
                else if (frm.GetType().Name == "Kriteriumstrukturverwaltung")
            {
                Kriterium temp_objekt = (Kriterium)objekt;
                Kriteriumstrukturverwaltung krit = (Kriteriumstrukturverwaltung)frm;

                krit.details_ID.Text = temp_objekt.getKriteriumID().ToString();
                krit.details_Bezeichnung.Text = temp_objekt.getBezeichnung();
                krit.details_ProduktID.Text = ProduktID.ToString();
                krit.details_ProjektID.Text = ProjektID.ToString();
                krit.details_Kriterium.IsEnabled = true;
                krit.listeUnterKriterium.IsEnabled = true;
                krit.listeUnterKriterium.ItemsSource = temp_objekt.getUnterKriterium(db);
                onUpdateData();
                return;
            }
            throw new NotImplementedException();
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
                    krit.details_Bezeichnung.IsEnabled = false;
                    krit.details_Bezeichnung.Text = "";
                    krit.details_ID.Text = "";
                    krit.details_ProduktID.Text = "";
                    krit.details_ProjektID.Text = "";
                    onUpdateData();
                }
                return;
            }
            else if (frm.GetType().Name == "Kriteriumstrukturverwaltung")
            {
                Kriteriumstrukturverwaltung krit = (Kriteriumstrukturverwaltung)frm;
                if (MessageBox.Show("Sind Sie sich sicher, dass sie das ausgewählte Kriterium löschen wollen?", "Löschen", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                {
                    db.delete(objekt);
                    krit.details_Kriterium.IsEnabled = false;
                    krit.details_Bezeichnung.IsEnabled = false;
                    krit.listeUnterKriterium.IsEnabled = false;
                    krit.untkrit_hinzufuegen.IsEnabled = false;
                    krit.untkrit_loeschen.IsEnabled = false;
                    krit.details_Bezeichnung.Text = "";
                    krit.details_ID.Text = "";
                    krit.details_ProduktID.Text = "";
                    krit.details_ProjektID.Text = "";
                    onUpdateData();
                }
                return;
            }
            throw new NotImplementedException();
        }

         public void show_kriteriumstrukturverwaltung(Kriterium objekt)
         {
             Kriteriumstrukturverwaltung frm = new Kriteriumstrukturverwaltung(db, objekt);
             frm.ShowDialog();
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
                        onUpdateData();
                    }
                }
                return;
            }
            throw new NotImplementedException();
        }

        public void UnterKriterium_hinzufuegen(Kriterium objekt)
        {
            if (frm.GetType().Name == "Kriteriumstrukturverwaltung")
            {
                Kriteriumstrukturverwaltung krit = (Kriteriumstrukturverwaltung)frm;
                if (krit.details_ID.Text != "")
                {
                    if (MessageBox.Show("Sind Sie sich sicher, dass sie das ausgewählte Kriterium hinzufügen wollen?", "Hinzufügen", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                    {
                        Kriterium temp_objekt = new Kriterium();
                        temp_objekt.setKriteriumID(Int32.Parse(krit.details_ID.Text));

                        temp_objekt.addUnterKriterium(objekt, db);
                        onUpdateData();
                    }
                }
                return;
            }
            throw new NotImplementedException();
        }

        public void UnterKriterium_loeschen(Kriterium objekt)
        {
            if (frm.GetType().Name == "Kriteriumstrukturverwaltung")
            {
                if (MessageBox.Show("Sind Sie sich sicher, dass sie das ausgewählte Kriterium löschen wollen?", "Löschen", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                {
                    Kriteriumstrukturverwaltung krit = (Kriteriumstrukturverwaltung)frm;
                    if (krit.details_ID.Text != "")
                    {
                        Kriterium temp_objekt = new Kriterium();
                        temp_objekt.setKriteriumID(Int32.Parse(krit.details_ID.Text));

                        temp_objekt.removeUnterKriterium(objekt, db);
                        onUpdateData();
                    }
                }
                return;
            }
            throw new NotImplementedException();
        }     


    }

}
