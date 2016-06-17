using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace NWAT_SS16
{
    abstract  public class Controller
    {
        public DatabaseAdapter db;
        public Window frm;
        public Controller(DatabaseAdapter db, Window frm)
        {
            this.db = db;
            this.frm = frm;
            onCreateView();
        }
        abstract public void onCreateView(); // wird aufgerufen, wenn ein View geöffnet wird
        abstract public void onDestroyView(); // wird aufgerufen, wenn ein View geschlossen wird
        abstract public void onUpdateView(); // wird aufgerufen, wenn ein View geupdated wird
        abstract public void anlegen(); 
        abstract public void aendern();
        abstract public void loeschen(Model objekt);
        abstract public void anzeigen(Model objekt, int ProjektID, int ProduktID);
    }
}
