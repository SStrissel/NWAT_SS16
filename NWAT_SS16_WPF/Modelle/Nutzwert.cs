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

        public Nutzwert (int KriteriumID, int ProjektID = 0, int ProduktID = 0, bool Erfuellung = false, int Gewichtung = 0, string Kommentar = "", double BeitragAbsolut = 0, bool BeitragAbsolutCheck = false)
        {
            setProjektID(ProjektID);
            setProduktID(ProduktID);
            setKriteriumID(KriteriumID);
            setGewichtung(Gewichtung);
            setErfuellung(Erfuellung);
            setKommentar(Kommentar);
        }

        public Nutzwert(string KriteriumID, string ProjektID = "0", string ProduktID = "0", string Erfuellung = "0", string Gewichtung = "0", string Kommentar = "", string BeitragAbsolut = "0", string BeitragAbsolutCheck = "0")
        {
            setProjektID(ProjektID);
            setProduktID(ProduktID);
            setKriteriumID(KriteriumID);
            setGewichtung(Gewichtung);
            setErfuellung(Erfuellung);
            setKommentar(Kommentar);
        }

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

        public void setKriteriumID(string KriteriumID)
        {
            setKriteriumID(Int32.Parse(KriteriumID));
        }

        public void setKriteriumID(int KriteriumID)
        {
            this.KriteriumID = KriteriumID;
        }

        public void setProduktID(string ProduktID)
        {
            setProduktID(Int32.Parse(ProduktID));
        }

        public void setProduktID(int ProduktID)
        {
            this.ProduktID = ProduktID;
        }

        public void setProjektID(string ProjektID)
        {
            setProjektID(Int32.Parse(ProjektID));
        }

        public void setProjektID(int ProjektID)
        {
            this.ProjektID = ProjektID;
        }

        public void setErfuellung(string Erfuellung)
        {
            if (Erfuellung.ToLower().Equals("true"))
            {
                setErfuellung(true);
            } else if (Erfuellung.ToLower().Equals("false")){

             setErfuellung(false);
            }
            else if (Erfuellung.Equals("0"))
            {

                setErfuellung(false);
            }
            else if (Erfuellung.Equals("1"))
            {

                setErfuellung(true);
            }
            else
            {
                throw new NotImplementedException();
            }
        }

        public void setErfuellung(bool Erfuellung)
        {
            this.Erfuellung = Erfuellung;
        }

        public void setGewichtung(string Gewichtung)
        {
            setGewichtung(Int32.Parse(Gewichtung));
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

        public Kriterium getKriterium()
        {
            throw new NotImplementedException();
        }

    }
}
