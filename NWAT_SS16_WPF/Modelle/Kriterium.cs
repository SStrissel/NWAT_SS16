using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NWAT_SS16
{
    public class Kriterium : Model
    {
        private int KriteriumID;
        private string Bezeichnung;

        public Kriterium(Kriterium objekt)
        {
            this.KriteriumID = objekt.getKriteriumID();
            this.Bezeichnung = objekt.getBezeichnung();
        }

        public Kriterium(int ID, string Bezeichnung)
        {
            this.KriteriumID = ID;
            this.Bezeichnung = Bezeichnung;
        }

        public Kriterium(string ID, string Bezeichnung)
        {
            this.KriteriumID = Int32.Parse(ID);
            this.Bezeichnung = Bezeichnung;
        }

        public Kriterium(int ID)
        {
            this.KriteriumID = ID;
        }

        public Kriterium(string ID)
        {
            this. KriteriumID = Int32.Parse(ID);
        }

        public Kriterium(): base() {}
 

        public override string ToString()
        {
            return "( Kriterium " + KriteriumID + ") " + Bezeichnung;
        }

        public int getKriteriumID()
        {
            return KriteriumID;
        }

        public string getBezeichnung()
        {
            return Bezeichnung;
        }

        public void setKriteriumID(string KriteriumID)
        {
            setKriteriumID(Int32.Parse(KriteriumID));
        }

        public void setKriteriumID(int KriteriumID)
        {
            this.KriteriumID = KriteriumID;
        }

        public void setBezeichnung(string Bezeichnung)
        {
            this.Bezeichnung = Bezeichnung;
        }

        public List<Kriterium> getUnterKriterium(DatabaseAdapter db)
        {
            Kriteriumstruktur temp_objekt = new Kriteriumstruktur(OberKriteriumID: this.getKriteriumID());
            List<Kriterium> return_list = new List<Kriterium>();            
            Kriterium return_krit;
            Kriterium temp_krit;

            foreach (Kriteriumstruktur temp_kritstruktur in db.get(temp_objekt))
            {
                temp_krit = new Kriterium(temp_kritstruktur.getUnterKriteriumID());
                foreach (Kriterium temp_krit2 in db.get(temp_krit))
                {
                    return_krit = new Kriterium(temp_krit2);
                    return_list.Add(return_krit);
                }
            }
            return return_list;
        }

        public List<Kriterium> getOberKriterium(DatabaseAdapter db)
        {
            Kriteriumstruktur temp_objekt = new Kriteriumstruktur(UnterKriteriumID : this.getKriteriumID());
            List<Kriterium> return_list = new List<Kriterium>();
            Kriterium return_krit;
            Kriterium temp_krit;

            foreach (Kriteriumstruktur temp_kritstruktur in db.get(temp_objekt))
            {
                temp_krit = new Kriterium(temp_kritstruktur.getOberKriteriumID());
                foreach (Kriterium temp_krit2 in db.get(temp_krit))
                {
                    return_krit = new Kriterium(temp_krit2);
                    return_list.Add(return_krit);
                }
            }
            return return_list;
        }

        public void addUnterKriterium(Kriterium objekt, DatabaseAdapter db)
        {
            if (objekt == null)
            {
                return;
            }
            Kriteriumstruktur temp_objekt = new Kriteriumstruktur(this.KriteriumID, objekt.getKriteriumID());
            if (db.get(temp_objekt).Count() == 0)
            {
                db.insert(temp_objekt);
            }
        }

        public List<Kriterium> getRootKriterium(DatabaseAdapter db)
        {
            List<Kriterium> temp_list = this.getOberKriterium(db);
            List<Kriterium> return_list = new List<Kriterium>();
            if (temp_list.Count == 0)
            {
                return_list.Add(this);
            }
            foreach (Kriterium temp_objekt in temp_list)
            {
                foreach (Kriterium temp_objekt2 in temp_objekt.getRootKriterium(db))
                {
                    return_list.Add(temp_objekt2);
                }
            }
            return return_list;

        }

        public bool isUnterKriterium(Kriterium objekt, DatabaseAdapter db)
        {
            foreach (Kriterium temp_krit in this.getUnterKriterium(db))
            {
                if (temp_krit.getKriteriumID() == objekt.getKriteriumID())
                {
                    return true;
                }
                if (temp_krit.isUnterKriterium(objekt, db))
                {
                    return true;
                }
            }
            return false;
        }

        public bool isOberKriterium(Kriterium objekt, DatabaseAdapter db)
        {
            foreach (Kriterium temp_krit in this.getOberKriterium(db))
            {
                if (temp_krit.getKriteriumID() == objekt.getKriteriumID())
                {
                    return true;
                }
                if (temp_krit.isOberKriterium(objekt, db))
                {
                    return true;
                }
            }
            return false;
        }

        public void removeUnterKriterium(Kriterium objekt, DatabaseAdapter db)
        {
            if (objekt == null)
            {
                return;
            }
            Kriteriumstruktur temp_objekt = new Kriteriumstruktur(this.KriteriumID, objekt.getKriteriumID());
            if (db.get(temp_objekt).Count() > 0)
            {
                db.delete(temp_objekt);
            }
        }

        public int getGewichtung()
        {
            throw new NotImplementedException();
        }

        public bool getErfüllung()
        {
            throw new NotImplementedException();
        }
    }
}
