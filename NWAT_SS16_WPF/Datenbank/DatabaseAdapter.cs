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
        abstract public Model insert(Model objekt); // schreibe einen neuen Eintrag in die Datenbank (Autoincrement), schreibe das Model hinein, gebe eine Liste des Models zurück
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
        abstract public void gleichgewichtenDB();

        abstract public void exp(Model objekt, DatabaseAdapter db, bool savetofile);
        abstract public Model force_insert(Model objekt);



        abstract public void reset_projekt();
        abstract public void reset_produkt();
        abstract public void reset_kriterium();
        abstract public void reset_nwa();
        abstract public void reset_kriteriumstruktur();

        abstract public void create_projekt();
        abstract public void create_produkt();
        abstract public void create_kriterium();
        abstract public void create_nwa();
        abstract public void create_autoincrement();
        abstract public void create_kriteriumstruktur();

        abstract public void drop_projekt();
        abstract public void drop_produkt();
        abstract public void drop_kriterium();
        abstract public void drop_nwa();
        abstract public void drop_autoincrement();
        abstract public void drop_kriteriumstruktur();

    }
}
