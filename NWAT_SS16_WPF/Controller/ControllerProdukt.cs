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
                Produkt_aendern prodan = (Produkt_aendern)frm;
                Produkt P = new Produkt();
                P.setProduktID(Int32.Parse(prodan.textProduktIDaendern.Text));
                P.setBezeichnung(prodan.textBezeichnungaendern.Text);

                db.update(P);
                onUpdateView();
                return;
            }
            else if (frm.GetType().Name == "Produktverwaltung")
            {
                Produkt_aendern prodan = new Produkt_aendern(db);
                Produkt P = new Produkt();
                prodan.ShowDialog();
                onUpdateData();
                return;
            }
            throw new NotImplementedException();
        }

        public override void anlegen()
        {


            if (frm.GetType().Name == "Produkt_anlegen")
            {
                Produkt_anlegen prodan = (Produkt_anlegen)frm;
                Produkt P = new Produkt();
                P.setBezeichnung(prodan.textBezeichnung.Text);

                db.insert(P);
                onUpdateView();
                return;
            }
            else if (frm.GetType().Name == "Produktverwaltung")
            {
                Produkt_anlegen prodan = new Projekt_anlegen(db);
                prodan.ShowDialog();
                onUpdateData();
                return;
            }
            throw new NotImplementedException();
        }

        public override void anzeigen(Model objekt)
         
        {
            Produkt P = (Produkt)objekt;
            ArrayList array = new ArrayList();
           
            string id="456";
            string bez="falsch";



            if (objekt == null)
            {
                return;
            }
            if (frm.GetType().Name == "Produktverwaltung")
            {
               
                Produktverwaltung PV = (Produktverwaltung)frm;
               Produkt_aendern prodan = new Produkt_aendern(db);

               array.Add(P.getProduktID().ToString());
               array.Add(P.getBezeichnung());
                PV.detailsProduktID.Text = P.getProduktID().ToString();
                PV.detailsBezeichnung.Text = P.getBezeichnung();
                id = PV.detailsProduktID.Text;
                bez = PV.detailsBezeichnung.Text;
                //prodan.textProduktIDaendern.Text = PV.detailsProduktID.Text;
                //prodan.textBezeichnungaendern.Text = PV.detailsBezeichnung.Text;
               
                //onUpdateData();
                return;
            }
            else if (frm.GetType().Name == "Produkt_anlegen")
            {
                Produkt_anlegen prodan = (Produkt_anlegen)frm;
                prodan.textProduktID.Text = db.getID(P).ToString();
                return;
            }
            else if (frm.GetType().Name == "Produkt_aendern")
            {
                Produkt_aendern prodan = (Produkt_aendern)frm;
                
                //prodan.textProduktIDaendern.Text = P.getProduktID().ToString();
                //prodan.textBezeichnungaendern.Text = P.getBezeichnung();
               /* prodan.textProjektIDaendern.Text = id;
                prodan.textBezeichnungaendern.Text = bez;*/
                for (int i = 0; i <= array.Count - 1; i++)
                {
                    prodan.textProduktIDaendern.Text = array[array.Count - 2].ToString();
                    prodan.textBezeichnungaendern.Text = array[array.Count - 2].ToString();
                }
                return;
            }




        public override void loeschen(Model objekt)
        {
            if (objekt == null)
            {
                return;
            }
            if (frm.GetType().Name == "Produktverwaltung")
            {

                Produktverwaltung PV = (Produktverwaltung)frm;
                db.delete(objekt);
                PV.detailsBezeichnung.Text = "";
                PV.detailsProduktID.Text = "";
                onUpdateData();
                return;
            }
            throw new NotImplementedException();
        }

        public override void onCreateView()
        {

            if (frm.GetType().Name == "Produktverwaltung")
            {
                Produktverwaltung prodan = (Produktverwaltung)frm;
                List<Produkt> produkte = db.get(new Produkt());
                if (produkte.Count() > 0)
                {
                    prodan.listProdukte.ItemsSource = produkte;
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

            throw new NotImplementedException();
        }

        public override void onUpdateView()
        {
            return;
        }

        public override void onUpdateData()
       {
            if (frm.GetType().Name == "Produktverwaltung")
            {
                Produktverwaltung prodan = (Produktverwaltung)frm;
                List<Produkt> produkte = db.get(new Produkt()); //alle Produkte
              //  if (produkte.Count() > 0)
              //  {
                    prodan.listProdukte.ItemsSource = produkte;
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
