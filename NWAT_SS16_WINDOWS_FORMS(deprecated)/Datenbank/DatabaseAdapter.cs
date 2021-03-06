﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NWAT_SS_165
{
    abstract public class DatabaseAdapter
    {
        abstract public void openConnection();
        abstract public void closeConnection();
        abstract public bool checkConnection();
        abstract public void insert(Model objekt); // schreibe einen neuen Eintrag in die Datenbank (Autoincrement), schreibe das Model hinein
        abstract public bool delete(Model objekt); // hole z.B. Namen/ID aus Model und suche danach in der Datenbank, lösche das Model, gib bei Erfolg true zurück
        abstract public bool update(Model objekt);  // hole z.B. Namen/ID aus Model und suche danach in der Datenbank, überschreibe das Model mit dem übergebenen Model. Gib true bei Erfolg zurück
        abstract public Model[] get(Model objekt); // hole z.B. Namen/ID aus Model und suche danach in der Datenbank, gebe das vollständige Model zurück
    }
}
