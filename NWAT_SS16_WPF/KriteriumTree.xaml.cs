using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace NWAT_SS16
{
    /// <summary>
    /// Interaktionslogik für KriteriumTree.xaml
    /// </summary>
    public partial class KriteriumTree : Window
    {
        private ControllerKriterium cntrl;
        public KriteriumTree(DatabaseAdapter db, Kriterium objekt)
        {
            InitializeComponent();
            cntrl = new ControllerKriterium(db, this);
            cntrl.onCreateView();
            cntrl.anzeigen(objekt);
        }
    }
}
