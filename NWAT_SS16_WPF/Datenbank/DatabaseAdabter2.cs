using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NWAT_SS16
{
    abstract public class DatabaseAdabter2
    {
        abstract public bool checkConnection();
        abstract public List<Projekt> get(Projekt objekt);
        abstract public string exp(Model objekt);
        abstract public void imp(Model objekt);
    }
}
