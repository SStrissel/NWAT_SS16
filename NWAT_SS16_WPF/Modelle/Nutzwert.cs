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
        double beitrag_absolut;
        bool beitrag_absolut_check;

        public override string ToString()
        {
            return "( Projekt " + ProjektID + " / Produkt " + ProduktID + " / Kriterium " + KriteriumID + " / + " + ") " + Kommentar;
        }

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

        public void setBeitragAbsolut(double wert)
        {
            this.beitrag_absolut = wert;
        }

        public double getBeitragAbsolut()
        {
            return this.beitrag_absolut;
        }

        public void setBeitragAbsolutCheck(bool wert)
        {
            this.beitrag_absolut_check = wert;
        }

        public bool getBeitragAbsolutCheck()
        {
            return this.beitrag_absolut_check;
        }

    }
}
