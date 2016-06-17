using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NWAT_SS16
{
    public class Kriterium : Model
    {
        int KriteriumID;
        string Bezeichnung;
        int KriterienoberID;
        int KriterienunterID;

        public override string ToString()
        {
            return "(" + KriteriumID + ") " + Bezeichnung;
        }

        public int getKriteriumID()
        {
            return KriteriumID;
        }
        public int getKriterienoberID()
        {
            return KriterienoberID;
        }

        public int getKriterienunterID()
        {
            return KriterienunterID;
        }

        public string getBezeichnung()
        {
            return Bezeichnung;
        }

        public void setKriteriumID(int KriteriumID)
        {
            this.KriteriumID = KriteriumID;
        }

        public void setKriterienoberID(int KriterienoberID)
        {
            this.KriterienoberID = KriterienoberID;
        }

        public void setKriterienunterID(int KriterienunterID)
        {
            this.KriterienunterID = KriterienunterID;
        }

        public void setBezeichnung(string Bezeichnung)
        {
            this.Bezeichnung = Bezeichnung;
        }

    }
}
