using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NWAT_SS16
{
    public class Kriteriumstruktur : Model
    {
        int OberKriteriumID;
        int UnterKriteriumID;

        public Kriteriumstruktur(int OberKriteriumID = 0, int UnterKriteriumID = 0)
        {
            this.OberKriteriumID = OberKriteriumID;
            this.UnterKriteriumID = UnterKriteriumID;
        }

        public override string ToString()
        {
            return "(" + OberKriteriumID + "/" + UnterKriteriumID + ") ";
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
