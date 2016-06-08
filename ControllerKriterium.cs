using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NWAT_SS_165
{
    abstract class BaseKriterium : Controller
    {
        public void anzeigen(Kriterium objekt, int ProjektID = 0, int ProduktID = 0);
        public void drucken(bool erfuellung = false, bool gewichtung = false, bool nutzwert = false, bool prozent = false, int ProjektID = 0, int[] ProduktID = new int[0]);
        public void aendern(Kriterium objekt, int ProjektID = 0, int ProduktID = 0);
        public void loeschen(Kriterium objekt);
        public void anlegen();

    }


    // Kommentar
    class Kriterium : BaseKriterium
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

        public void anlegen()
        {
        }


        public void onCreateView()
        {

        }

        public void onDestoryView()
        {

        }
    }

}
