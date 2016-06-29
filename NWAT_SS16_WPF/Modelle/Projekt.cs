using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NWAT_SS16
{
     public class Projekt : Model
    {
        int ProjektID;
        string Bezeichnung;
        private static int ProjektIDtemp;
        private static string Bezeichnungtemp;


       /* public Projekt(int ID, string Bezeichnung)
        {
            this.ProjektID = ID;
            this.Bezeichnung = Bezeichnung;
        }*/

        public Projekt(string ID)
        {
            this.ProjektID = Int32.Parse(ID);
        }

        public Projekt(): base() {}

        public override string ToString()
        {
            return "( Projekt " + ProjektID + ") " + Bezeichnung;
        }

        public int getProjektID()
        {
            return ProjektID;
        }

        public string getBezeichnung()
        {
            return Bezeichnung;
        }

        public static int getProjektIDtemp()
        {
            return ProjektIDtemp;
        }

        public static string getBezeichnungtemp()
        {
            return Bezeichnungtemp;
        }

        public void setProjektID(int ProjektID)
        {
            this.ProjektID = ProjektID;
        }

        public void setProjektID(string ProjektID)
        {
            this.ProjektID = Int32.Parse(ProjektID);
        }

        public void setBezeichnung(string Bezeichnung)
        {
            this.Bezeichnung = Bezeichnung;
        }

        public static void setProjektIDtemp(string projektID)
        {
            ProjektIDtemp = Int32.Parse(projektID);
        }
        public static void setBezeichnungtemp(string bezeichnung)
        {
            Bezeichnungtemp = bezeichnung;
        }

        internal void setProjektID(Func<string> func)
        {
            throw new NotImplementedException();
        }

        internal void setBezeichnung(Func<string> func)
        {
            throw new NotImplementedException();
        }
    }
}
