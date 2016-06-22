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
    /// Interaktionslogik für NutzwertVerwaltung.xaml
    /// </summary>
    public partial class NutzwertVerwaltung : Window
    {
              private ControllerNutzwert cntrl;
        public NutzwertVerwaltung(DatabaseAdapter db)
        {
            InitializeComponent();
            cntrl = new ControllerNutzwert(db, this);
            cntrl.onCreateView();
        }
    }
}
