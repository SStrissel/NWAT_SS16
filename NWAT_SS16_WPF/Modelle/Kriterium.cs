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

        public override string ToString()
        {
            return "(" + KriteriumID + ") " + Bezeichnung;
        }

        public int getKriteriumID()
        {
            return KriteriumID;
        }

        public string getBezeichnung()
        {
            return Bezeichnung;
        }

        public void setKriteriumID(int KriteriumID)
        {
            this.KriteriumID = KriteriumID;
        }

        public void setBezeichnung(string Bezeichnung)
        {
            this.Bezeichnung = Bezeichnung;
        }

        public List<Kriterium> getOberKriterium(DatabaseAdapter db)
        {
            Kriteriumstruktur temp_objekt = new Kriteriumstruktur();
            temp_objekt.setUnterKriteriumID(this.KriteriumID);

            List<Kriterium> return_list = new List<Kriterium>();


            /* Abfrage sollte im Normalfall nur ein Kriterium zurückgeben in return_list*/
            foreach (Kriteriumstruktur temp_kritstruktur in db.get(temp_objekt))
            {
                Kriterium temp_krit = new Kriterium();
                temp_krit.setKriteriumID(temp_kritstruktur.getOberKriteriumID());
                foreach (Kriterium temp_krit2 in db.get(temp_krit))
                {
                    return_list.Add(temp_krit2);
                }
                
            }
            return return_list;

        }
    }
}
