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
    /// Interaktionslogik für Projektverwaltung.xaml
    /// </summary>
    public partial class Projektverwaltung : Window
    {
        private ControllerProjekt cp;
       
        public Projektverwaltung(DatabaseAdapter db)
        {
            InitializeComponent();
            cp = new ControllerProjekt(db, this);
            cp.onCreateView();

            
  
        }

        private void anlegen_Click(object sender, RoutedEventArgs e)
        {
            cp.anlegen();
        }

    }
}
