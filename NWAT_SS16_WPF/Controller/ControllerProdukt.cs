﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace NWAT_SS16
{
     public class ControllerProdukt : Controller
    {
        public ControllerProdukt(DatabaseAdapter db, Window frm) : base(db, frm){}

        public override void aendern()
        {
            throw new NotImplementedException();
        }

        public override void anlegen()
        {
            throw new NotImplementedException();
        }

        public override void anzeigen(Model objekt, int ProduktID, int ProjektID)
        {
            throw new NotImplementedException();
        }

        public override void loeschen(Model objekt)
        {
            throw new NotImplementedException();
        }

        public override void onCreateView()
        {
            throw new NotImplementedException();
        }

        public override void onUpdateView()
        {
            throw new NotImplementedException();
        }

        public override void onUpdateData()
        {
            throw new NotImplementedException();
        }


        public override void onDestroyView()
        {
            throw new NotImplementedException();
        }

    }
}
