using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using MySql.Data.MySqlClient;
using System.Collections;

namespace NWAT_SS16
{
     public class ControllerProjekt : Controller
    {

        public ControllerProjekt(DatabaseAdapter db, Window frm) : base(db, frm){}
      
        public override void aendern()
        {
            if (frm.GetType().Name == "Projekt_aendern")
            {
                Projekt_aendern pa = (Projekt_aendern)frm;
                Projekt p = new Projekt();
                p.setProjektID(Int32.Parse(pa.textProjektIDaendern.Text));
                p.setBezeichnung(pa.textBezeichnungaendern.Text);

                db.update(p);
                onUpdateView();
                return;
            }
            else if (frm.GetType().Name == "Projektverwaltung")
            {
                Projekt_aendern pa = new Projekt_aendern(db);
                Projekt p = new Projekt();
                pa.ShowDialog();
                onUpdateData();
                return;
            }
            throw new NotImplementedException();
        }

        public override void anlegen()
        {


            if (frm.GetType().Name == "Projekt_anlegen")
                {
                    Projekt_anlegen pa = (Projekt_anlegen)frm;
                    Projekt p = new Projekt();
                    p.setBezeichnung(pa.textBezeichnung.Text);
               
                    db.insert(p);
                    onUpdateView();
                    return;
                }
            else if (frm.GetType().Name == "Projektverwaltung")
            {
                    Projekt_anlegen pa = new Projekt_anlegen(db);
                    pa.ShowDialog();
                    onUpdateData();
                    return;
            }
            throw new NotImplementedException();
        }
        public void temp(Model objekt)
        {
            Projekt p = (Projekt)objekt;
            //Projekt p = new Projekt();
            Projekt_aendern pa = new Projekt_aendern(db);
           
            ArrayList array = new ArrayList();
            array.Add(p.getProjektID().ToString());
            array.Add(p.getBezeichnung());
            for (int i = 0; i <= array.Count-1; i++)
            {
                pa.textProjektIDaendern.Text = array[array.Count - 1].ToString();
                pa.textBezeichnungaendern.Text = array[array.Count-1].ToString();
            }
            /*pa.textProjektIDaendern.Text = p.getProjektID().ToString();
            pa.textBezeichnungaendern.Text = p.getBezeichnung();*/

        }
        public override void anzeigen(Model objekt)
        {
            Projekt p = (Projekt)objekt;
            ArrayList array = new ArrayList();
           
            string id="123";
            string bez="falsch";
            if (objekt == null)
            {
                return;
            }
            if (frm.GetType().Name == "Projektverwaltung")
            {
               
                Projektverwaltung pv = (Projektverwaltung)frm;
               Projekt_aendern pa = new Projekt_aendern(db);

               array.Add(p.getProjektID().ToString());
               array.Add(p.getBezeichnung());
                pv.detailsProjektID.Text = p.getProjektID().ToString();
                pv.detailsBezeichnung.Text = p.getBezeichnung();
                id = pv.detailsProjektID.Text;
                bez = pv.detailsBezeichnung.Text;
                //pa.textProjektIDaendern.Text = pv.detailsProjektID.Text;
                //pa.textBezeichnungaendern.Text = pv.detailsBezeichnung.Text;
               
                //onUpdateData();
                return;
            }
            else if (frm.GetType().Name == "Projekt_anlegen")
            {
                Projekt_anlegen pa = (Projekt_anlegen)frm;
                pa.textProjektID.Text = db.getID(p).ToString();
                return;
            }
            else if (frm.GetType().Name == "Projekt_aendern")
            {
                Projekt_aendern pa = (Projekt_aendern)frm;
                
                //pa.textProjektIDaendern.Text = p.getProjektID().ToString();
                //pa.textBezeichnungaendern.Text = p.getBezeichnung();
               /* pa.textProjektIDaendern.Text = id;
                pa.textBezeichnungaendern.Text = bez;*/
                for (int i = 0; i <= array.Count - 1; i++)
                {
                    pa.textProjektIDaendern.Text = array[array.Count - 2].ToString();
                    pa.textBezeichnungaendern.Text = array[array.Count - 2].ToString();
                }
                return;
            }
        }
        public override void loeschen(Model objekt)
        {
            if (objekt == null)
            {
                return;
            }
            if (frm.GetType().Name == "Projektverwaltung")
            {

                Projektverwaltung pv = (Projektverwaltung)frm;
                db.delete(objekt);
                pv.detailsBezeichnung.Text = "";
                pv.detailsProjektID.Text = "";
                onUpdateData();
                return;
            }
            throw new NotImplementedException();
        }

        public override void onCreateView()
        {

            if (frm.GetType().Name == "Projektverwaltung")
            {
                Projektverwaltung pa = (Projektverwaltung)frm;
                List<Projekt> projekte = db.get(new Projekt());
                if (projekte.Count() > 0)
                {
                    pa.listProjekte.ItemsSource = projekte;
                    onUpdateView();
                }
                return;
            }
            else if (frm.GetType().Name == "Projekt_anlegen")
            {

                return;
            }
            else if (frm.GetType().Name == "Projekt_aendern")
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
            if (frm.GetType().Name == "Projektverwaltung")
            {
                Projektverwaltung pa = (Projektverwaltung)frm;
                List<Projekt> projekte = db.get(new Projekt()); //alle Projekte
              //  if (projekte.Count() > 0)
              //  {
                    pa.listProjekte.ItemsSource = projekte;
                    onUpdateView();
               // }
                return;
            }
            else if (frm.GetType().Name == "Projekt_anlegen")
            {

                return;
            }
            else if (frm.GetType().Name == "Projekt_aendern")
            {

                return;
            }
            return;
        }

        public override void onDestroyView()
        {
            throw new NotImplementedException();
        }

        public void import()
        {
        }

        public void export()
        {
        }

     
    }
}
