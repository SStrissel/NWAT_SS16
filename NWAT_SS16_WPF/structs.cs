﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NWAT_SS16
{
 struct listItem
 {
     public int ID;
     public string Bezeichnung;

     public override string ToString()
     {
         return "(" + ID + ")" + Bezeichnung;
     }
 }
}
