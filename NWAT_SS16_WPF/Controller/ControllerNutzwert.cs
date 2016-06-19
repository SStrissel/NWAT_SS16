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

                ControllerNutzwert(DatabaseAdapter db, Window frm) : base(db, frm){}

        private void gleichgewichten(Kriterium objekt)
        {
        }

        public void funktionsabdeckungsgrad_berechnen(Nutzwert NWAobjekt, Kriterium objekt)
        {
        }

        public void funktionsabdeckungsgrad_aufsummieren(Nutzwert NWAobjekt, Kriterium objekt)
        {
        }

        public bool funktionsabdeckungsgrad_aufsummieren_check(Kriterium objekt)
        {
            return false;
        }
        
        private float funktionsabdeckungsgrad_beitrag(Nutzwert NWAobjekt, Kriterium objekt)
        {
            return 0;
        }

        private int funktionsabdeckungsgrad_beitrag_nenner(Nutzwert NWAobjekt, Kriterium objekt)
        {
            return 0;
        }

        private int funktionsabdeckungsgrad_beitrag_zaehler(Nutzwert NWAobjekt, Kriterium objekt)
        {
            return 0;
        }

        private float funktionsabdeckungsgrad_beitrag_absolut(Kriterium objekt, float erfuellung_einzel)
        {
            return 0;
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

        public override void anzeigen(Model objekt, int ProduktID, int ProjektID)
        {
            throw new NotImplementedException();
        }

        public override void loeschen(Model objekt)
        {
            throw new NotImplementedException();
        }

        public override void onCreateView()
        {
            throw new NotImplementedException();
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
