using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NWAT_SS16
{
    public class Kriteriumstruktur : Model
    {
        int OberKriteriumID = -1;
        int UnterKriteriumID = -1;

        public Kriteriumstruktur(int OberKriteriumID = -1, int UnterKriteriumID = -1)
        {
            this.OberKriteriumID = OberKriteriumID;
            this.UnterKriteriumID = UnterKriteriumID;
        }

        public override string ToString()
        {
            return "( OberKriterium " + OberKriteriumID + "/ UnterKriterium " + UnterKriteriumID + ") ";
        }


        public void setOberKriteriumID(int ID)
        {
            this.OberKriteriumID = ID;
        }

        public int getOberKriteriumID()
        {
            return this.OberKriteriumID;
        }

        public void setUnterKriteriumID(int ID)
        {
            this.UnterKriteriumID = ID;
        }

        public int getUnterKriteriumID()
        {
            return this.UnterKriteriumID;
        }
    }
}
