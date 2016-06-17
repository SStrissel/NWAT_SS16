using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NWAT_SS_165
{


     public class KriteriumController : Controller
    {
       public void aendern(Kriterium objekt, int ProjektID = 0, int ProduktID = 0)
        {

        }

        public void drucken(bool erfuellung, bool gewichtung, bool nutzwert, bool prozent, int ProjektID, int[] ProduktID)
        {

        }

        public void loeschen(Kriterium objekt)
        {
        }

        public override void anlegen()
        {
        }


        public override void onCreateView()
        {

        }

       public override void onDestroyView()
        {

        }

        public override void anzeigen(Model objekt, int ProduktID, int ProjektID)
        {
            throw new NotImplementedException();
        }

        public override void loeschen(Model objekt)
        {
            throw new NotImplementedException();
        }

        public override void aendern(Model objekt, int ProduktID, int ProjektID)
        {
            throw new NotImplementedException();
        }


    }

}
