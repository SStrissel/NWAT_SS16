using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace NWAT_SS16
{
    //Hauptverantwortlicher: Wusterhausen
    public class ControllerNutzwert : Controller
    {        
        //Kontruktor der Klasse ControllerNutzwert
        public ControllerNutzwert(DatabaseAdapter db, Window frm) : base(db, frm){}
        private DruckDokument dok = new DruckDokument();

        //Funktion gleichgewichten ruft die im DatabaseAdapter befindliche Funktion gleichgewichtenDB auf
        public void gleichgewichten()
        {
            db.gleichgewichtenDB();
        }

        //Hauptfunktion der Nutzwertanalyse, die in die anderen Funktionen verzweigt
        public void funktionsabdeckungsgrad_berechnen(Nutzwert NWAobjekt)
        {
            NWAobjekt.setBeitragAbsolutCheck(false);
            db.update(NWAobjekt);            
            List<Kriterium> list = NWAobjekt.getKriterium(db).getUnterKriterium(db);
            if (list.Count > 0)
            {
                foreach (Kriterium temp_obj in list)
                {
                    funktionsabdeckungsgrad_berechnen(temp_obj.getNutzwert(db: db, ProjektID: NWAobjekt.getProjektID(), ProduktID: NWAobjekt.getProduktID()));
                }                
            }
            else
            {
                double temp_beitrag = funktionsabdeckungsgrad_beitrag(NWAobjekt);
                if (temp_beitrag != 0)
                {
                    double beitrag_absolut = funktionsabdeckungsgrad_beitrag_absolut(NWAobjekt.getKriterium(db).getOberKriterium(db)[0].getNutzwert(db, NWAobjekt.getProjektID(), NWAobjekt.getProduktID()), temp_beitrag);
                    NWAobjekt.setBeitragAbsolut(beitrag_absolut*NWAobjekt.getAbstufung());
                }
                else
                {
                    NWAobjekt.setBeitragAbsolut(0);
                }
                NWAobjekt.setBeitragAbsolutCheck(true);
                db.update(NWAobjekt);
                funktionsabdeckungsgrad_aufsummieren(NWAobjekt);
            }
        }

        //Summiert die Ergebnisse aller Kriterien (Unterkriterium und Oberkriterium) 
        private void funktionsabdeckungsgrad_aufsummieren(Nutzwert NWAobjekt)
        {
            bool change = funktionsabdeckungsgrad_aufsummieren_check(NWAobjekt);
            double temp_beitrag = 0;
            if (change == false)
            {
                List<Kriterium> list = NWAobjekt.getKriterium(db).getUnterKriterium(db);
                if (list.Count > 0)
                {
                    foreach (Kriterium temp in list)
                    {
                        temp_beitrag += temp.getNutzwert(db: db, ProjektID: NWAobjekt.getProjektID(), ProduktID: NWAobjekt.getProduktID()).getBeitragAbsolut() * NWAobjekt.getAbstufung();
                    }
                NWAobjekt.setBeitragAbsolut(temp_beitrag);
                NWAobjekt.setBeitragAbsolutCheck(true);
                db.update(NWAobjekt);
                }
            }
            List<Kriterium> temp_oberkriterien = NWAobjekt.getKriterium(db).getOberKriterium(db);
            if (temp_oberkriterien.Count > 0)
            {
                funktionsabdeckungsgrad_aufsummieren(temp_oberkriterien[0].getNutzwert(db, NWAobjekt.getProjektID(), NWAobjekt.getProduktID()));
            }
        }

        private bool funktionsabdeckungsgrad_aufsummieren_check(Nutzwert NWAobjekt)
        {
            List<Kriterium> list = NWAobjekt.getKriterium(db).getUnterKriterium(db);
            foreach (Kriterium temp_obj in list)
            {
                if (new Nutzwert(ProjektID: 0, ProduktID: 0, KriteriumID: NWAobjekt.getKriteriumID()).getErfuellung() != false)
                {
                    if (temp_obj.getNutzwert(db, NWAobjekt.getProjektID(), NWAobjekt.getProduktID()).getBeitragAbsolutCheck() == false)
                    {
                        return true;
                    }
                }
            }          
            return false;
        }
        
        private double funktionsabdeckungsgrad_beitrag(Nutzwert NWAobjekt)
        {
            int nenner = funktionsabdeckungsgrad_beitrag_nenner(NWAobjekt);

            if (nenner == 0)
            {
                return 0;
                throw new NotImplementedException();
            }
            else
            {
                double result = (((double)funktionsabdeckungsgrad_beitrag_zaehler(NWAobjekt)) / ((double)(nenner)));
                return result;
            }
        }

        //Funktion zur Berechnung des Nenners innerhalb der Nutzweranalysefunktion
        private int funktionsabdeckungsgrad_beitrag_nenner(Nutzwert NWAobjekt)
        {
            int nenner = 0;
            List<Kriterium> temp_krit = NWAobjekt.getKriterium(db).getOberKriterium(db);
            if (temp_krit.Count > 0)
            {
                List<Kriterium> list = temp_krit[0].getUnterKriterium(db);

                foreach (Kriterium temp_obj in list)
                {
                        nenner += temp_obj.getGewichtung(db: db, ProjektID: NWAobjekt.getProjektID(), ProduktID: NWAobjekt.getProduktID());
                }
            }
            else
            {
                nenner = NWAobjekt.getGewichtung();
            }
            if (nenner == 0)
            {
                return 0;
            }
            return nenner;
        }
        //Funktion zur Berechnung des Zaehlers innerhalb der Nutzweranalysefunktion
        private int funktionsabdeckungsgrad_beitrag_zaehler(Nutzwert NWAobjekt)
        {
            if (NWAobjekt.getErfuellung() == false)
            {
                return 0;
            }
            else 
            {
                return NWAobjekt.getGewichtung();
            }
        }

        public double prozent(Nutzwert NWAobjekt)
        {
            int nenner = funktionsabdeckungsgrad_beitrag_nenner(NWAobjekt);
            if (nenner == 0)
            {
                return 0;
            }
            return Math.Round((double)NWAobjekt.getGewichtung() / (double)nenner * 100,3);
        }

        //Funktion der Nutzwertanalyse, ruft die Zaehler und Nenner Funktion und verarbeitet die Ergebnisse in der Funktion
        private double funktionsabdeckungsgrad_beitrag_absolut(Nutzwert NWAobjekt, double beitrag_einzel)
        {
            int nenner = funktionsabdeckungsgrad_beitrag_nenner(NWAobjekt);
            double result = beitrag_einzel * (double)NWAobjekt.getGewichtung() / (double)nenner;
            
            List<Kriterium> list  = NWAobjekt.getKriterium(db).getOberKriterium(db);
            foreach (Kriterium temp_objekt in list)
            {
                result = funktionsabdeckungsgrad_beitrag_absolut(temp_objekt.getNutzwert(db: db, ProjektID: NWAobjekt.getProjektID(), ProduktID: NWAobjekt.getProduktID()), result);
            }
            return Math.Round(result,3);   
        }
        
        /// <summary>
        /// Die folgenden Funktionen sind aus dem Standard Controller und werden in dieser Klasse nicht weiter 
        /// verwendet. Daher werden diese hier nur mit einer "NotImplementedException" implementiert
        /// </summary>


        public override void aendern()
        {
            throw new NotImplementedException();
         }

        public override void anlegen()
        {
            throw new NotImplementedException();
        }

        public override void anzeigen(Model objekt)
        {
            throw new NotImplementedException();
        }

        public override void loeschen(Model objekt)
        {
            throw new NotImplementedException();
        }

        public override void onCreateView()
        {
          /*  if (frm.GetType().Name == "NutzwertVerwaltung")
            {
                NutzwertVerwaltung nutz = (NutzwertVerwaltung)frm;
                this.onUpdateData();
                return;
            }
            */
        }

        public override void onUpdateView()
        {
            throw new NotImplementedException();
        }

        public override void onUpdateData()
        {
             NutzwertVerwaltung nutz = (NutzwertVerwaltung)frm;

               

                List<Projekt> projekte = db.get(new Projekt(-1)); // alle Projekte
                nutz.details_Proj.ItemsSource = projekte;

                List<Produkt> produkte = db.get(new Produkt(-1)); // alle Produkte
                nutz.details_Prod1.ItemsSource = produkte;
                nutz.details_Prod2.ItemsSource = produkte;
        }


        public override void onDestroyView()
        {
            throw new NotImplementedException();
        }

        public void drucken(bool erfuellung, bool anforderungen, bool gewichtung, bool nutzwert, bool prozent, int ProjektID, int[] ProduktID, bool produkte)
        {
            dok.BuildDataTable(erfuellung: erfuellung, anforderungen: anforderungen, gewichtung: gewichtung, nutzwert: nutzwert, prozent: prozent, ProjektID: ProjektID, ProduktID: ProduktID, db: db, produkte: produkte);

            System.Windows.Forms.PrintPreviewDialog dialog = new System.Windows.Forms.PrintPreviewDialog();
            dialog.Document = dok;

            dialog.ShowDialog();
        }
    }
}