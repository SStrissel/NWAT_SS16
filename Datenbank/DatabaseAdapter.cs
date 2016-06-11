using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NWAT_SS_165
{
    abstract class DatabaseAdapter
    {
        abstract public void connect();
        abstract public void insert(Model objekt); // schreibe einen neuen Eintrag in die Datenbank (Autoincrement), schreibe das Model hinein
        abstract public bool delete(Model objekt); // hole z.B. Namen/ID aus Model und suche danach in der Datenbank, lösche das Model, gib bei Erfolg true zurück
        abstract public bool update(Model objekt);  // hole z.B. Namen/ID aus Model und suche danach in der Datenbank, überschreibe das Model mit dem übergebenen Model. Gib true bei Erfolg zurück
        abstract public Model get(Model objekt); // hole z.B. Namen/ID aus Model und suche danach in der Datenbank, gebe das vollständige Model zurück
        abstract public long getAutoincrement(Model objekt); // vergebe eine neues Autoincrement für Objekt
    }
}
