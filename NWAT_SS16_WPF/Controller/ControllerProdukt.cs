using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace NWAT_SS16
{
     public class ControllerProdukt : Controller
    {
        //Hauptverantworticher: Huber
        public ControllerProdukt(DatabaseAdapter db, Window frm) : base(db, frm){}
         //Funktion zur Änderung der Produktbezeichnung
        public override void aendern()
        {
            if (frm.GetType().Name == "Produkt_aendern")
            {
                Produkt_aendern prodaendern = (Produkt_aendern)frm;
                Produkt prod = new Produkt();
                prod.setProduktID(Int32.Parse(prodaendern.textProduktIDaendern.Text));
                prod.setBezeichnung(prodaendern.textBezeichnungaendern.Text);

                db.update(prod);
                onUpdateView();
                return;
            }
            else if (frm.GetType().Name == "Produktverwaltung")
            {
                Produkt_aendern prodaendern = new Produkt_aendern(db);
                Produkt prod = new Produkt();
                prodaendern.ShowDialog();
                onUpdateData();
                return;
            }
            throw new NotImplementedException();
        }
         //Funktion zum Anlegen eines neuen Produktes
         //Autoinkrementierung der ProduktID
        public override void anlegen()
        {
            if (frm.GetType().Name == "Produkt_anlegen")
            {
                Produkt_anlegen prodanlegen = (Produkt_anlegen)frm;

                Produkt prod = new Produkt();

                prod.setBezeichnung(prodanlegen.textBezeichnung.Text);

                db.insert(prod);

                onUpdateView();
                return;
            }
            else if (frm.GetType().Name == "Produktverwaltung")
            {
                Produkt_anlegen prodanlegen = new Produkt_anlegen(db);
                prodanlegen.ShowDialog();
                onUpdateData();
                return;
            }
            throw new NotImplementedException();
        }
         //Funktion zum Anzeigen der ProduktID und Bezeichnung innerhalb der Textboxen der View
        public override void anzeigen(Model objekt)
        {
            if (objekt == null)
            {
                return;
            }
            Produkt prod = (Produkt)objekt;

            if (frm.GetType().Name == "Produktverwaltung")
            {
                Produktverwaltung prodverwaltung = (Produktverwaltung)frm;

                prodverwaltung.details_ProduktID.Text = prod.getProduktID().ToString();

                prodverwaltung.details_Bezeichnung.Text = prod.getBezeichnung();
                               
                return;
            }
            else if (frm.GetType().Name == "Produkt_anlegen")
            {
                Produkt_anlegen prodanlegen = (Produkt_anlegen)frm;

                prodanlegen.textProduktID.Text = db.getID(prod).ToString();
                return;
            }
        }

         //Funktion zum Löschen der Produkte aus der Datenbank
        public override void loeschen(Model objekt)
        {
            if (objekt == null)
            {
                return;
            }
            if (frm.GetType().Name == "Produktverwaltung")
            {
                Produktverwaltung prodverwaltung = (Produktverwaltung)frm;

                db.delete(objekt);

                prodverwaltung.details_Bezeichnung.Text = "";
                prodverwaltung.details_ProduktID.Text = "";

                onUpdateData();
                return;
            }
            throw new NotImplementedException();
        }
         //Beim Erzeugen der View werden die vorhandenen Produkte aus der Datenbank in die ListBox übertragen
        public override void onCreateView()
        {
            if (frm.GetType().Name == "Produktverwaltung")
            {
                Produktverwaltung prod = (Produktverwaltung)frm;

                List<Produkt> produkt = db.get(new Produkt());
                  if (produkt.Count() > 0)
                 {
                prod.listeProdukt.ItemsSource = produkt;

                onUpdateView();
                 }
                return;
            }
            else if (frm.GetType().Name == "Produkt_anlegen")
            {

                return;
            }
            else if (frm.GetType().Name == "Produkt_aendern")
            {

                return;
            }
            return;
        }

        public override void onUpdateView()
        {
            return;
        }

        public override void onUpdateData()
        {
            if (frm.GetType().Name == "Produktverwaltung")
            {
                Produktverwaltung prod = (Produktverwaltung)frm;
                List<Produkt> produkt = db.get(new Produkt());
                
                prod.listeProdukt.ItemsSource = produkt;

                onUpdateView();
                
                return;
            }
            else if (frm.GetType().Name == "Produkt_anlegen")
            {

                return;
            }
            else if (frm.GetType().Name == "Produkt_aendern")
            {

                return;
            }
            return;
        }


        public override void onDestroyView()
        {
            throw new NotImplementedException();
        }

    }
}
