using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using MySql.Data.MySqlClient;

namespace NWAT_SS16
{
     public class ControllerProjekt : Controller
    {

        public ControllerProjekt(DatabaseAdapter db, Window frm) : base(db, frm){}
      
        public override void aendern()
        {
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
            if (frm.GetType().Name == "Projektverwaltung")
            {
                Projekt p = (Projekt)objekt;
                Projektverwaltung pv = (Projektverwaltung)frm;

                pv.detailsProjektID.Text = p.getProjektID().ToString();
                pv.detailsBezeichnung.Text = p.getBezeichnung();
                /*krit.kriterium_aendern.IsEnabled = true;
                krit.kriterium_loeschen.IsEnabled = true;
                krit.details_Bezeichnung.IsEnabled = true;*/
                onUpdateData();
                return;
            }
            else if (frm.GetType().Name == "Projekt_anlegen")
            {

                return;
            }
        }
        public override void loeschen(Model objekt)
        {
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


            throw new NotImplementedException();
        }

        public override void onUpdateView()
        {
            return;
        }

        public override void onUpdateData()
        {
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
