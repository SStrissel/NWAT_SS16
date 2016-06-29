﻿using System;
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

                Nutzwert temp_objekt2 = new Nutzwert(KriteriumID: temp_objekt.getKriteriumID(), ProjektID: 0, ProduktID: 0);
                db.insert(temp_objekt2);
                anzeigen(temp_objekt);
                return;
            }
            throw new NotImplementedException();
        }


        public override void onCreateView()
        {

            if (frm.GetType().Name == "Kriteriumverwaltung")
            {
                Kriteriumverwaltung krit = (Kriteriumverwaltung)frm;
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

                List<Projekt> projekte = db.get(new Projekt()); // alle Projekte
                krit.listeProjektID.ItemsSource = projekte;

                List<Produkt> produkte = db.get(new Produkt()); // alle Produkte
                krit.listeProduktID.ItemsSource = produkte;

                krit.listeProjektID.SelectedIndex = 0;
                krit.listeProduktID.SelectedIndex = 0;

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
                if (krit.details_ID.Text.Equals("") == false)
                {
                    krit.nutzwert.IsEnabled = true;
                    if (Int32.Parse(krit.details_ID.Text) != 0)
                    {
                        krit.struktur.IsEnabled = true;
                    }
                    else
                    {
                        krit.struktur.IsEnabled = false;
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

                if (krit.details_ProjektID.Text.Equals("0") == false && krit.details_ProduktID.Text.Equals("0") == false)
                {
                    krit.loeschen.IsEnabled = true;
                }
                else
                {
                    krit.loeschen.IsEnabled = false;
                }
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
                 List<Nutzwert> temp_list = db.get((Nutzwert)objekt);
                 if (temp_list.Count > 0)
                 {
                     Nutzwert temp_objekt = temp_list[0];
                     KriteriumNutzwertVerwaltung krit = (KriteriumNutzwertVerwaltung)frm;
                     krit.details_ProjektID.Text = temp_objekt.getProjektID().ToString();
                     krit.details_ProduktID.Text = temp_objekt.getProduktID().ToString();
                     krit.details_KriteriumID.Text = temp_objekt.getKriteriumID().ToString();
                     krit.details_Erfuellung.IsChecked = temp_objekt.getErfuellung();
                     krit.details_Gewichtung.Text = temp_objekt.getGewichtung().ToString();
                     krit.details_kommentar.Text = temp_objekt.getKommentar();
                     onUpdateData();
                     return;
                 }
                 else
                 {
                     throw new NotImplementedException();
                 }

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
                KriteriumNutzwertVerwaltung krit = (KriteriumNutzwertVerwaltung)frm;
                if (MessageBox.Show("Sind Sie sich sicher, dass sie das ausgewählte Nutzwert löschen wollen?", "Löschen", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                {
                    db.delete(objekt);
                    krit.Close();
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
            else if (frm.GetType().Name == "KriteriumNutzwertVerwaltung")
            {
                if (MessageBox.Show("Sind Sie sich sicher, dass sie das ausgewählte KriteriumNutzwert ändern wollen?", "Ändern", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                {
                    KriteriumNutzwertVerwaltung krit = (KriteriumNutzwertVerwaltung)frm;
                    Nutzwert temp_objekt = new Nutzwert(KriteriumID: krit.details_KriteriumID.Text, ProjektID: krit.details_ProjektID.Text, ProduktID: krit.details_ProduktID.Text, Erfuellung: krit.details_Erfuellung.IsChecked.ToString(), Gewichtung: krit.details_Gewichtung.Text, Kommentar: krit.details_kommentar.Text);
                    db.update(temp_objekt);
                    krit.Close();
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
            if (frm.GetType().Name=="Kriteriumverwaltung")
            {
                Kriteriumverwaltung krit = (Kriteriumverwaltung)frm;
            if (((Produkt)krit.listeProduktID.SelectedItem).getProduktID() == 0 && ((Projekt)krit.listeProjektID.SelectedItem).getProjektID() == 0)
            {
            }
            else if (((Produkt)krit.listeProduktID.SelectedItem).getProduktID() != 0 && ((Projekt)krit.listeProjektID.SelectedItem).getProjektID() != 0)
            {
            }
            else
            {
                MessageBox.Show("Produkt und Projekt müssen entweder beide 0 sein (Standard) oder beide NICHT 0 sein", "Nutzwert", MessageBoxButton.OK);
                return;
            }
            KriteriumNutzwertVerwaltung new_frm = new KriteriumNutzwertVerwaltung(db, objekt);
            new_frm.ShowDialog();
                return;
            }
              throw new NotImplementedException();
        }


    }

}
