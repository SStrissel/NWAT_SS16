using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NWAT_SS16
{
     public class Produkt : Model
     {
         /// <summary>
         /// Definition der setter und getter Funktionen
         /// Hauptverantwortlicher: Tektas
         /// </summary>
        int ProduktID;
        string Bezeichnung;
        private static int ProduktIDtemp;
        private static string Bezeichnungtemp;


       /* public Produkt(int ID, string Bezeichnung)
        {
            this.ProduktID = ID;
            this.Bezeichnung = Bezeichnung;
        }*/

        public Produkt(string ID)
        {
           setProduktID(Int32.Parse(ID));
        }

        public Produkt(int ID)
        {
            setProduktID(ID);
        }

        public Produkt(): base() {}

        public override string ToString()
        {
            return "( Produkt " + ProduktID + ") " + Bezeichnung;
        }

        public int getProduktID()
        {
            return ProduktID;
        }

        public string getBezeichnung()
        {
            return Bezeichnung;
        }

        public static int getProduktIDtemp()
        {
            return ProduktIDtemp;
        }

        public static string getBezeichnungtemp()
        {
            return Bezeichnungtemp;
        }

        public void setProduktID(int ProduktID)
        {
            this.ProduktID = ProduktID;
        }

        public void setProduktID(string ProduktID)
        {
             setProduktID(Int32.Parse(ProduktID));
        }

        public void setBezeichnung(string Bezeichnung)
        {
            this.Bezeichnung = Bezeichnung;
        }

        public static void setProduktIDtemp(string projektID)
        {
            ProduktIDtemp = Int32.Parse(projektID);
        }
        public static void setBezeichnungtemp(string bezeichnung)
        {
            Bezeichnungtemp = bezeichnung;
        }

        internal void setProduktID(Func<string> func)
        {
            throw new NotImplementedException();
        }

        internal void setBezeichnung(Func<string> func)
        {
            throw new NotImplementedException();
        }
    }
}
