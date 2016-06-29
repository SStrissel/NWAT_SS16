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
                temp_objekt = db.insert(temp_objekt) as Kriterium;
                anzeigen(temp_objekt);
                return;
            }
            throw new NotImplementedException();
        }


        public override void onCreateView()
        {

            if (frm.GetType().Name == "Kriteriumverwaltung")
            {
                onUpdateData();
                return;
            } else if (frm.GetType().Name == "Kriteriumstrukturverwaltung")
            {
                onUpdateData();
                return;
            }
            else if (frm.GetType().Name == "KriteriumNutzwertVerwaltung")
            {
                onUpdateData();
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
                    krit.listeWurzelKriterium.ItemsSource = temp_objekt.getRootKriterium(db);
                    krit.listeUnterKriterium.ItemsSource = temp_objekt.getUnterKriterium(db);
                    krit.listeOberKriterium.ItemsSource = temp_objekt.getOberKriterium(db);
                }
                onUpdateView();
                return;
            }
            else if (frm.GetType().Name == "KriteriumNutzwertVerwaltung")
            {
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
                    Kriterium choosen_objekt = (Kriterium)krit.details_Kriterium.SelectedItem;
                    Kriterium actual_objekt = new Kriterium(krit.details_ID.Text);
                    if (choosen_objekt.getKriteriumID() != actual_objekt.getKriteriumID() && find(krit.listeUnterKriterium.ItemsSource as List<Kriterium>, choosen_objekt.getKriteriumID()) == false && actual_objekt.isOberKriterium(choosen_objekt, db) == false)
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
                if (krit.details_ID.Text != "")
                {
                    if (Int32.Parse(krit.details_ID.Text) != 0)
                    {
                        krit.struktur.IsEnabled = true;
                        krit.nutzwert.IsEnabled = true;
                    }
                    else
                    {
                        krit.struktur.IsEnabled = false;
                        krit.nutzwert.IsEnabled = false;
                    }
                }
                else
                {
                    krit.struktur.IsEnabled = false;
                    krit.nutzwert.IsEnabled = false;
                }
                return;
            }
            else if (frm.GetType().Name == "KriteriumNutzwertVerwaltung")
            {
                KriteriumNutzwertVerwaltung krit = (KriteriumNutzwertVerwaltung)frm;
                return;
            }
            throw new NotImplementedException();
        }

       public override void onDestroyView()
        {
            if (frm.GetType().Name == "Kriteriumverwaltung")
            {
                return;
            }
            else if (frm.GetType().Name == "Kriteriumstrukturverwaltung")
            {
                return;
            }
            else if (frm.GetType().Name == "KriteriumNutzwertVerwaltung")
            {
                return;
            }
            throw new NotImplementedException();
        }

 
        public override void anzeigen(Model objekt)
        {
            if (objekt == null)
            {
                return;
            }
            if (frm.GetType().Name == "Kriteriumverwaltung")
            {
                Kriteriumverwaltung krit = (Kriteriumverwaltung)frm;
                if (objekt.GetType().Name == "Kriterium")
                {
                    Kriterium temp_objekt = (Kriterium)objekt;
                    

                    krit.details_ID.Text = temp_objekt.getKriteriumID().ToString();
                    krit.details_Bezeichnung.Text = temp_objekt.getBezeichnung();
                    krit.details_ProduktID.Text = "0"; // auto set
                    krit.details_ProjektID.Text = "0"; // auto set
                    krit.kriterium_aendern.IsEnabled = true;
                    krit.kriterium_loeschen.IsEnabled = true;
                    krit.details_Bezeichnung.IsEnabled = true;
                    onUpdateData();
                    return;
                }
                throw new NotImplementedException();
            } 
                else if (frm.GetType().Name == "Kriteriumstrukturverwaltung")
            {
                    Kriteriumstrukturverwaltung krit = (Kriteriumstrukturverwaltung)frm;
                      if (objekt.GetType().Name == "Kriterium")
                {
                Kriterium temp_objekt = (Kriterium)objekt;
                

                krit.details_ID.Text = temp_objekt.getKriteriumID().ToString();
                krit.details_Bezeichnung.Text = temp_objekt.getBezeichnung();
                krit.details_ProduktID.Text = "0"; // auto set
                krit.details_ProjektID.Text = "0"; // auto set
                krit.details_Kriterium.IsEnabled = true;
                krit.listeUnterKriterium.IsEnabled = true;
                krit.listeUnterKriterium.ItemsSource = temp_objekt.getUnterKriterium(db);
                onUpdateData();
                return;
                }
                      throw new NotImplementedException();
            }
            else if (frm.GetType().Name == "KriteriumNutzwertVerwaltung")
            {
                Nutzwert temp_objekt = (Nutzwert)objekt;
                KriteriumNutzwertVerwaltung krit = (KriteriumNutzwertVerwaltung)frm;
                krit.details_ProjektID.Text = temp_objekt.getProjektID().ToString();
                krit.details_ProduktID.Text = temp_objekt.getProduktID().ToString();
                krit.details_KriteriumID.Text = temp_objekt.getKriteriumID().ToString();
                krit.details_Erfuellung.IsChecked = temp_objekt.getErfuellung();
                krit.details_Gewichtung.Text = temp_objekt.getGewichtung().ToString();
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
                    Kriterium temp_objekt = (Kriterium)objekt;
                    if (temp_objekt.getUnterKriterium(db).Count > 0)
                    {
                        MessageBox.Show("Sie können das Kriterium nicht löschen, solange es ein UnterKriterium besitzt. Gehen Sie in die Strukturverwaltung und löschen Sie alle UnterKriterien.", "Löschen", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                    else if (temp_objekt.getOberKriterium(db).Count > 0)
                    {
                        MessageBox.Show("Sie können das Kriterium nicht löschen, solange es ein OberKriterium besitzt. Gehen Sie in die Strukturverwaltung des OberKriteriums und löschen Sie das Kriterium aus der UnterKriterium-Liste.", "Löschen", MessageBoxButton.OK, MessageBoxImage.Warning);
                    } else
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
            else if (frm.GetType().Name == "KriteriumNutzwertVerwaltung")
            {
                onUpdateData();
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

        public void show_kriteriumnutzwertverwaltung(Nutzwert objekt)
        {
            KriteriumNutzwertVerwaltung frm = new KriteriumNutzwertVerwaltung(db, objekt);
            frm.ShowDialog();
        }


    }

}
