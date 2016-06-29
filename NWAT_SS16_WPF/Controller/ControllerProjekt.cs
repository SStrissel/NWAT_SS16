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
       
        public override void anzeigen(Model objekt)
        {
       
            if (objekt == null)
            {
                return;
            }
            Projekt p = (Projekt)objekt;

            if (frm.GetType().Name == "Projektverwaltung")
            {
               
               Projektverwaltung pv = (Projektverwaltung)frm;

                pv.detailsProjektID.Text = p.getProjektID().ToString();
                pv.detailsBezeichnung.Text = p.getBezeichnung();
               
                //onUpdateData();
                return;
            }
            else if (frm.GetType().Name == "Projekt_anlegen")
            {
                Projekt_anlegen pa = (Projekt_anlegen)frm;
                pa.textProjektID.Text = db.getID(p).ToString();
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
