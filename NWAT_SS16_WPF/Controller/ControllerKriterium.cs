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
            throw new NotImplementedException();
        }


        public override void onCreateView()
        {
            if (frm.GetType().Name == "Kriteriumverwaltung")
            {
                Kriteriumverwaltung krit = (Kriteriumverwaltung)frm;
                List<listItem> items = new List<listItem>();
                items.Add(new listItem() { Title = "Kriterium", ID = 15 });
                items.Add(new listItem() { Title = "Kriterium", ID = 252 });
                items.Add(new listItem() { Title = "Kriterium", ID = 341 });
                krit.listeKriterium.ItemsSource = items;
                
            }
        }

        public override void onUpdateView()
        {
            throw new NotImplementedException();
        }

       public override void onDestroyView()
        {
            throw new NotImplementedException();
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
