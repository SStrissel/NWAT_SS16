using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NWAT_SS_165
{
    abstract class Controller
    {
        abstract public void onCreateView(); // wird aufgerufen, wenn ein View geöffnet wird
        abstract public void onDestroyView(); // wird aufgerufen, wenn ein View geschlossen wird
        abstract public void anlegen(); 
        abstract public void aendern();
        abstract public void loeschen();
        abstract public void anzeigen();
    }
}
