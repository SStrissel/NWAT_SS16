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
        protected DatabaseAdapter db;
        protected DatabaseAdabter2 db2;
        protected Window frm;
        public Controller(DatabaseAdapter db, Window frm)
        {
            this.db = db;

            this.frm = frm;
            onCreateView();
        }

        public Controller(DatabaseAdapter db, DatabaseAdabter2 db2, Window frm)
        {
            this.db = db;
            this.db2 = db2;
            this.frm = frm;
            onCreateView();
        }
        abstract public void onCreateView(); // wird aufgerufen, wenn ein View geöffnet wird
        abstract public void onDestroyView(); // wird aufgerufen, wenn ein View geschlossen wird
        abstract public void onUpdateView(); // wird aufgerufen, wenn ein View geupdated wird
        abstract public void onUpdateData(); // wird aufgerufen, wenn sich die Daten für die View geändert haben
        abstract public void anlegen(); 
        abstract public void aendern();
        abstract public void loeschen(Model objekt);
        abstract public void anzeigen(Model objekt);
    }
}
