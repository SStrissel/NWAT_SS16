using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    class Kriterium : Model
    {
        int KriteriumID;
        string Bezeichnung;
        int KriterienoberID;
        int KriterienunterID;

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
            KriteriumID = this.KriteriumID;
        }

        public void setKriterienoberID(int KriterienoberID)
        {
            KriterienoberID = this.KriterienoberID;
        }

        public void setKriterienunterID(int KriterienunterID)
        {
            KriterienunterID = this.KriterienunterID;
        }

        public void setBezeichnung(string Bezeichnung)
        {
            Bezeichnung = this.Bezeichnung;
        }

    }
}
