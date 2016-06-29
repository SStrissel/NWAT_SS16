using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace NWAT_SS16
{
    public class ControllerNutzwert : Controller
    {         
        public ControllerNutzwert(DatabaseAdapter db, Window frm) : base(db, frm){}

        private void gleichgewichten(Kriterium objekt)
        {
            /* TBD Strissel*/
        }

        public void funktionsabdeckungsgrad_berechnen(Nutzwert NWAobjekt, Kriterium objekt)
        {
            NWAobjekt.setBeitragAbsolutCheck(false);
            NWAobjekt.getKriterium();
            List<Kriterium> list = NWAobjekt.getKriterium().getUnterKriterium(db);
            if (NWAobjekt.getKriterium().getUnterKriterium(db).Count == 0)
                foreach (Kriterium temp_obj in list)
                {
                    funktionsabdeckungsgrad_berechnen(NWAobjekt, objekt);
                }
            //ZWEITE ZEILE NICHT LAUFFÄHIG!!! WARUM ZUR HÖLLE?!
            /*else
            {
                double temp_beitrag = funktionsabdeckungsgrad_beitrag(NWAobjekt);
                NWAobjekt.setBeitragAbsolut() += funktionsabdeckungsgrad_beitrag_absolut(NWAobjekt, temp_beitrag);
                NWAobjekt.setBeitragAbsolutCheck(true);
            }
                          */

               
        }

        public void funktionsabdeckungsgrad_aufsummieren(Nutzwert NWAobjekt, Kriterium objekt)
        {
            bool change = false;
            double temp_beitrag = 0;
            funktionsabdeckungsgrad_aufsummieren_check(objekt);
            List<Kriterium> list = NWAobjekt.getKriterium().getUnterKriterium(db);
            if (change == false)
            {
                foreach (Kriterium temp in list)
                {
                    temp_beitrag += NWAobjekt.getBeitragAbsolut();
                }
            }
            NWAobjekt.setBeitragAbsolut(temp_beitrag);


        }

        public bool funktionsabdeckungsgrad_aufsummieren_check(Kriterium objekt)
        {
            List<Kriterium> list = objekt.getUnterKriterium(db);
            foreach (Kriterium temp_obj in list)
            {
                //STRUKTOGRAMM NICHT VERSTANDEN NOCHMAL PRÜFEN!!!!!
            }
          
            return true;
        }
        
        private float funktionsabdeckungsgrad_beitrag(Nutzwert NWAobjekt)
        {
            int nenner = funktionsabdeckungsgrad_beitrag_nenner(NWAobjekt);

            if (nenner == 0)
            {
                throw new NotImplementedException();
            }
            else
            {
                return funktionsabdeckungsgrad_beitrag_zaehler(NWAobjekt) / nenner;
            }
        }

        private int funktionsabdeckungsgrad_beitrag_nenner(Nutzwert NWAobjekt)
        {
            int nenner = 0;
            NWAobjekt.getKriterium().getOberKriterium(db);
            NWAobjekt.getKriterium().getUnterKriterium(db);
            List<Kriterium> list = NWAobjekt.getKriterium().getUnterKriterium(db);
                
                foreach (Kriterium temp_obj in list)
                {
                    nenner += temp_obj.getGewichtung();
                }
                
       
            return nenner;
        }

        private int funktionsabdeckungsgrad_beitrag_zaehler(Nutzwert NWAobjekt)
        {
            int zaehler = 0;            
              
            int GW = NWAobjekt.getGewichtung();
            int EF = Convert.ToInt32(NWAobjekt.getErfuellung());

            if (GW == 0 || EF == 0)
            {
                return 0;
            }
            else
            {
                zaehler = GW * EF;
            }
            return zaehler;
        }

        private double funktionsabdeckungsgrad_beitrag_absolut(Nutzwert NWAobjekt, double beitrag_einzel)
        {
            double result = 0;
            
            List<Kriterium> list  = NWAobjekt.getKriterium().getOberKriterium(db);
            foreach (Kriterium temp_objekt in list)
            {
               int nenner = funktionsabdeckungsgrad_beitrag_nenner(NWAobjekt);
               result =  beitrag_einzel * NWAobjekt.getGewichtung()/nenner;  
                Nutzwert temp_nutzwert = new Nutzwert(KriteriumID: temp_objekt.getKriteriumID(), ProjektID: NWAobjekt.getProjektID(), ProduktID: NWAobjekt.getProduktID());
               return funktionsabdeckungsgrad_beitrag_absolut(temp_nutzwert, result);
            }
            return result;   
        }

        private void ranking_anzeigen()
        {
        }

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
            
        }

        public override void onUpdateView()
        {
            throw new NotImplementedException();
        }

        public override void onUpdateData()
        {
            throw new NotImplementedException();
        }


        public override void onDestroyView()
        {
            throw new NotImplementedException();
        }
    }
}
