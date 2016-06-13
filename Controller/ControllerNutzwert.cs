using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NWAT_SS_165
{
     public class ControllerNutzwert : Controller
    {

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

        private int funktionsabdeckungsgrad_beitrag_zähler(Nutzwert NWAobjekt, Kriterium objekt)
        {
            return 0;
        }

        private float funktionsabdeckungsgrad_beitrag_absolut(Kriterium objekt, float erfüllung_einzel)
        {
            return 0;
        }

        private void ranking_anzeigen()
        {
        }

        public override void aendern(Model objekt, int ProduktID, int ProjektID)
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

        public override void onDestroyView()
        {
            throw new NotImplementedException();
        }
    }
}
