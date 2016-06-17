using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace NWAT_SS16
{


     public class ControllerKriterium : Controller
    {


       public ControllerKriterium(DatabaseAdapter db, Window frm) : base(db, frm) { }

       public void aendern(Kriterium objekt, int ProjektID = 0, int ProduktID = 0)
        {
            throw new NotImplementedException();
        }

        public void drucken(bool erfuellung, bool gewichtung, bool nutzwert, bool prozent, int ProjektID, int[] ProduktID)
        {
            throw new NotImplementedException();
        }

        public void loeschen(Kriterium objekt)
        {
            throw new NotImplementedException();
        }

        public override void anlegen()
        {
            Random Rnd = new Random(); // initialisiert die Zufallsklasse
            Kriterium temp_objekt = new Kriterium();
            temp_objekt.setKriteriumID(Rnd.Next(9999));
            temp_objekt.setBezeichnung("Kriterium mit ZufallsID (1-9999)");
            db.insert(temp_objekt);
            onUpdateView();
        }


        public override void onCreateView()
        {
            if (frm.GetType().Name == "Kriteriumverwaltung")
            {
                Kriteriumverwaltung krit = (Kriteriumverwaltung)frm;
                List<Kriterium> items = db.get(new Kriterium());
                krit.listeKriterium.ItemsSource = items;
                
            }
        }

        public override void onUpdateView()
        {
            if (frm.GetType().Name == "Kriteriumverwaltung")
            {
                Kriteriumverwaltung krit = (Kriteriumverwaltung)frm;
                List<Kriterium> items = db.get(new Kriterium());
                krit.listeKriterium.ItemsSource = items;

            }
        }

       public override void onDestroyView()
        {
           // checken, ob Änderungen gemacht wurden
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
