using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace NWAT_SS16
{
   /* public class ControllerNutzwert : Controller
    {         
        public ControllerNutzwert(DatabaseAdapter db, Window frm) : base(db, frm){}

        private void gleichgewichten(Kriterium objekt)
        {

        }

        public void funktionsabdeckungsgrad_berechnen(Nutzwert NWAobjekt, Kriterium objekt)
        {
        }

        public void funktionsabdeckungsgrad_aufsummieren(Nutzwert NWAobjekt, Kriterium objekt)
        {
            bool change = false;
            funktionsabdeckungsgrad_aufsummieren_check(Kriterium objekt);
            List<Kriterium> list = NWAobjekt.getKriterium().getUnterKriterium(db);
            if (change == false)
            {
                foreach (Kriterium temp in list)
                {
                    float temp_beitrag += NWAobjekt.getKriterium().getUnterKriterium();
                }
            }
            NWAobjekt.getKriterium().


        }

        public bool funktionsabdeckungsgrad_aufsummieren_check(Kriterium objekt)
        {
            List<Kriterium> list = objekt.getUnterKriterium(db);
            for (int i = 0; i <= List<Kriterium>; i++)
            {
            }
          
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

        private float funktionsabdeckungsgrad_beitrag_absolut(Nutzwert NWAobjekt, float beitrag_einzel)
        {
            float absolut1;
            
            List<Kriterium> list  = NWAobjekt.getKriterium().getOberKriterium(db);
            while (list.Count != 0)
            {
               int nenner = funktionsabdeckungsgrad_beitrag_nenner(Nutzwert NWAobjekt);
               float  result =  beitrag_einzel * list.count();
               absolut1 = result / nenner;

            }
            return absolut1;

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
