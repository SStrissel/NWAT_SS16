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

        public void gleichgewichten()
        {
            db.gleichgewichtenDB();
        }

        public void funktionsabdeckungsgrad_berechnen(Nutzwert NWAobjekt)
        {
            NWAobjekt.setBeitragAbsolutCheck(false);
            //NWAobjekt.getKriterium(db); 
            List<Kriterium> list = NWAobjekt.getKriterium(db).getUnterKriterium(db);
            if (list.Count > 0)
            {
                foreach (Kriterium temp_obj in list)
                {
                    funktionsabdeckungsgrad_berechnen(temp_obj.getNutzwert(db));
                }
                
            }
            else
            {
                double temp_beitrag = funktionsabdeckungsgrad_beitrag(NWAobjekt);
                if (temp_beitrag != 0)
                {
                    double beitrag_absolut = funktionsabdeckungsgrad_beitrag_absolut(NWAobjekt.getKriterium(db).getOberKriterium(db)[0].getNutzwert(db), temp_beitrag);
                    NWAobjekt.setBeitragAbsolut(beitrag_absolut);
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
                        temp_beitrag += temp.getNutzwert(db).getBeitragAbsolut();
                    }
                NWAobjekt.setBeitragAbsolut(temp_beitrag);
                NWAobjekt.setBeitragAbsolutCheck(true);
                db.update(NWAobjekt);
                }
            }
            List<Kriterium> temp_oberkriterien = NWAobjekt.getKriterium(db).getOberKriterium(db);
            if (temp_oberkriterien.Count > 0)
            {
                funktionsabdeckungsgrad_aufsummieren(temp_oberkriterien[0].getNutzwert(db));
            }
        }

        private bool funktionsabdeckungsgrad_aufsummieren_check(Nutzwert NWAobjekt)
        {
            List<Kriterium> list = NWAobjekt.getKriterium(db).getUnterKriterium(db);
            foreach (Kriterium temp_obj in list)
            {
                if (temp_obj.getNutzwert(db).getBeitragAbsolutCheck() == false)
                {
                    return true;
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

        private int funktionsabdeckungsgrad_beitrag_nenner(Nutzwert NWAobjekt)
        {
            int nenner = 0;
            List<Kriterium> temp_krit = NWAobjekt.getKriterium(db).getOberKriterium(db);
            if (temp_krit.Count > 0)
            {
                List<Kriterium> list = temp_krit[0].getUnterKriterium(db);

                foreach (Kriterium temp_obj in list)
                {
                    nenner += temp_obj.getGewichtung(db);
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

        private double funktionsabdeckungsgrad_beitrag_absolut(Nutzwert NWAobjekt, double beitrag_einzel)
        {
            int nenner = funktionsabdeckungsgrad_beitrag_nenner(NWAobjekt);
            double result = beitrag_einzel * (double)NWAobjekt.getGewichtung() / (double)nenner;
            
            List<Kriterium> list  = NWAobjekt.getKriterium(db).getOberKriterium(db);
            foreach (Kriterium temp_objekt in list)
            {
               result = funktionsabdeckungsgrad_beitrag_absolut(temp_objekt.getNutzwert(db), result);
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