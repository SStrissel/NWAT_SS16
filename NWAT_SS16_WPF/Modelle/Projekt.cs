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

       /* public Projekt(Kriterium objekt)
        {
            this.ProjektID = objekt.getProjektID();
            this.Bezeichnung = objekt.getBezeichnung();
        }

        public Projekt(int ID, string Bezeichnung)
        {
            this.ProjektID = ID;
            this.Bezeichnung = Bezeichnung;
        }
        */
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
