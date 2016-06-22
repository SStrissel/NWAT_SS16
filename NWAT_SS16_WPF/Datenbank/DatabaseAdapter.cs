using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NWAT_SS16
{
    abstract public class DatabaseAdapter
    {
        abstract public bool checkConnection();
        abstract public int insert(Model objekt); // schreibe einen neuen Eintrag in die Datenbank (Autoincrement), schreibe das Model hinein
        abstract public void delete(Model objekt); // hole z.B. Namen/ID aus Model und suche danach in der Datenbank, lösche das Model, gib bei Erfolg true zurück
        abstract public void update(Model objekt);  // hole z.B. Namen/ID aus Model und suche danach in der Datenbank, überschreibe das Model mit dem übergebenen Model. Gib true bei Erfolg zurück
        abstract public List<Kriterium> get(Kriterium objekt); /* hole z.B. Namen/ID aus Model und suche danach in der Datenbank, gebe das vollständige Model zurück */
        abstract public List<Kriteriumstruktur> get(Kriteriumstruktur objekt); /* hole z.B. Namen/ID aus Model und suche danach in der Datenbank, gebe das vollständige Model zurück */
        abstract public List<Projekt> get(Projekt objekt);/* hole z.B. Namen/ID aus Model und suche danach in der Datenbank, gebe das vollständige Model zurück */
        abstract public List<Produkt> get(Produkt objekt);/* hole z.B. Namen/ID aus Model und suche danach in der Datenbank, gebe das vollständige Model zurück */
        abstract public List<Nutzwert> get(Nutzwert objekt);/* hole z.B. Namen/ID aus Model und suche danach in der Datenbank, gebe das vollständige Model zurück */
        abstract public void init_tables();
        abstract public void drop_tables();
        abstract public int getID(Model objekt);

    }
}
