using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NWAT_SS16
{
     public class Nutzwert : Model
    {
        int KriteriumID;
        int ProduktID;
        int ProjektID;
        bool Erfuellung;
        int Gewichtung;
        string Kommentar;


        public int getKriteriumID()
        {
            return KriteriumID;
        }
        public int getProduktID()
        {
            return ProduktID;
        }

        public int getProjektID()
        {
            return ProjektID;
        }

        public bool getErfuellung()
        {
            return Erfuellung;
        }

        public int getGewichtung()
        {
            return Gewichtung;
        }

        public string getKommentar()
        {
            return Kommentar;
        }

        public void setKriteriumID(int KriteriumID)
        {
            KriteriumID = this.KriteriumID;
        }

        public void setProduktID(int ProduktID)
        {
            ProduktID = this.ProduktID;
        }

        public void setProjektID(int ProjektID)
        {
            ProjektID = this.ProjektID;
        }

        public void setErfuellung(bool Erfuellung)
        {
            Erfuellung = this.Erfuellung;
        }

        public void setGewichtung(int Gewichtung)
        {
            Gewichtung = this.Gewichtung;
        }

        public void setKommentar(string Kommentar)
        {
            Kommentar = this.Kommentar;
        }

    }
}
