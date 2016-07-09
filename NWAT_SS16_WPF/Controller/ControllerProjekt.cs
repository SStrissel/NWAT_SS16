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

        public ControllerProjekt(DatabaseAdapter db, Window frm) : base(db,frm){}

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
            else if (frm.GetType().Name == "Export")
            {
                Export ex = (Export)frm;
                Projekt p = new Projekt();
                p.setProjektID(Int32.Parse(ex.textProjektIDexp.Text));
                p.setBezeichnung(ex.textBezeichnungexp.Text);
                db.delete(p);
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
            else if (frm.GetType().Name == "Import")
            {
                Import i = (Import)frm;
                DatabaseAdapter expdb = new mySQLAdapter("db4free.net", "nwat_expimp", "nutzwertexpimp", "ad.nutz#"); // Konstruktor
                List<Projekt> projekte = expdb.get(new Projekt());
                if (projekte.Count() > 0)
                {
                    i.listProjekte.ItemsSource = projekte;
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
            else if (frm.GetType().Name == "Export")
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
            else if (frm.GetType().Name == "Export")
            {

                return;
            }
            else if (frm.GetType().Name == "Import")
            {
                Import i = (Import)frm;
                DatabaseAdapter expdb = new mySQLAdapter("db4free.net", "nwat_expimp", "nutzwertexpimp", "ad.nutz#"); // Konstruktor

                List<Projekt> projekte = expdb.get(new Projekt());
                //if (projekte.Count() > 0)
                //{
                    i.listProjekte.ItemsSource = projekte;
                    onUpdateView();
               // }
                return;
            }
            return;
        }

        public override void onDestroyView()
        {
            throw new NotImplementedException();
        }

        public void export()
        {

            if (frm.GetType().Name == "Projektverwaltung")
            {
                Projektverwaltung pv = (Projektverwaltung)frm;
                Export ex = new Export(db);
                ex.ShowDialog();
                onUpdateData();
                pv.detailsBezeichnung.Text = "";
                pv.detailsProjektID.Text = "";
            }
            else if (frm.GetType().Name == "Export")
            {
                DatabaseAdapter expdb = new mySQLAdapter("db4free.net", "nwat_expimp", "nutzwertexpimp", "ad.nutz#"); // Konstruktor
                Export ex = (Export)frm;
                Projekt p = new Projekt();
                p.setProjektID(Int32.Parse(ex.textProjektIDexp.Text));
                p.setBezeichnung(ex.textBezeichnungexp.Text);
                expdb.exp(p, db, true);
            }
        }

        public void import(Model objekt)
        {
            if (frm.GetType().Name == "Projektverwaltung")
            {
                Import i = new Import(db);
                i.ShowDialog();
                onUpdateData();
            }
            else if (frm.GetType().Name == "Import")
            {
                DatabaseAdapter expdb = new mySQLAdapter("db4free.net", "nwat_expimp", "nutzwertexpimp", "ad.nutz#"); // Konstruktor

                Import i = (Import)frm;
                Projekt proj = (Projekt)objekt;
                db.exp(proj, expdb, false);
                expdb.delete(proj);
            }
            
        }

       
     
    }
}
