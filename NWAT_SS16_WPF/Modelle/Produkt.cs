using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NWAT_SS16
{
     public class Produkt : Model
    {
        int ProduktID;
        string Bezeichnung;


        public override string ToString()
        {
            return "(" + ProduktID + ")" + Bezeichnung;
        }

        public int getProduktID()
        {
            return ProduktID;
        }

        public string getBezeichnung()
        {
            return Bezeichnung;
        }

        public void setProduktID(int ProduktID)
        {
            ProduktID = this.ProduktID;
        }

        public void setBezeichnung(string Bezeichnung)
        {
            Bezeichnung = this.Bezeichnung;
        }


    }
}
