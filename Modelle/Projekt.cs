using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NWAT_SS_165
{
    class Projekt : Model
    {
        int ProjektID;
        string Bezeichnung;


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
            ProjektID = this.ProjektID;
        }

        public void setBezeichnung(string Bezeichnung)
        {
            Bezeichnung = this.Bezeichnung;
        }


    }
}
