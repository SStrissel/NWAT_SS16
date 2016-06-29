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
        public ControllerProdukt(DatabaseAdapter db, Window frm) : base(db, frm){}

        public override void aendern()
        {
            if (frm.GetType().Name == "Produkt_aendern")
            {
                Produkt_aendern pa = (Produkt_aendern)frm;
                Projekt p = new Projekt();
                p.setProjektID(Int32.Parse(pa.textProduktIDaendern.Text));
                p.setBezeichnung(pa.textBezeichnungaendern.Text);

                db.update(p);
                onUpdateView();
                return;
            }
            else if (frm.GetType().Name == "Produktverwaltung")
            {
                Produkt_aendern pa = new Produkt_aendern(db);
                Produkt p = new Produkt();
                pa.ShowDialog();
                onUpdateData();
                return;
            }
            throw new NotImplementedException();
        }

        public override void anlegen()
        {


            if (frm.GetType().Name == "Produkt_anlegen")
            {
                Produkt_anlegen pa = (Produkt_anlegen)frm;
                Produkt p = new Produkt();
                p.setBezeichnung(pa.textBezeichnung.Text);

                db.insert(p);
                onUpdateView();
                return;
            }
            else if (frm.GetType().Name == "Produktverwaltung")
            {
                Produkt_anlegen pa = new Produkt_anlegen(db);
                pa.ShowDialog();
                onUpdateData();
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
            Produkt p = (Produkt)objekt;

            if (frm.GetType().Name == "Produktverwaltung")
            {

                Produktverwaltung pv = (Produktverwaltung)frm;

                pv.details_ProduktID.Text = p.getProduktID().ToString();
                pv.details_Bezeichnung.Text = p.getBezeichnung();

                //onUpdateData();
                return;
            }
            else if (frm.GetType().Name == "Produkt_anlegen")
            {
                Produkt_anlegen pa = (Produkt_anlegen)frm;
                pa.textProduktID.Text = db.getID(p).ToString();
                return;
            }
        }




        public override void loeschen(Model objekt)
        {
            if (objekt == null)
            {
                return;
            }
            if (frm.GetType().Name == "Produktverwaltung")
            {

                Produktverwaltung pv = (Produktverwaltung)frm;
                db.delete(objekt);
                pv.details_Bezeichnung.Text = "";
                pv.details_ProduktID.Text = "";
                onUpdateData();
                return;
            }
            throw new NotImplementedException();
        }




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
                //  if (produkte.Count() > 0)
                //  {
                prod.listeProdukt.ItemsSource = produkt;
                onUpdateView();
                // }
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
