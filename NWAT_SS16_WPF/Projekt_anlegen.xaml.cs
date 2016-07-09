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
    /// Interaktionslogik für Projekt_anlegen.xaml
    /// </summary>
    public partial class Projekt_anlegen : Window
    {
        private DatabaseAdapter db;
        private ControllerProjekt cp;
        public Projekt_anlegen(DatabaseAdapter db)
        {
            InitializeComponent();
            this.db = db;
            cp = new ControllerProjekt(db, this);

            cp.anzeigen(new Projekt());
      
 
        }
        private void speichern_Click(object sender, RoutedEventArgs e)
        {
        
            cp.anlegen();
            this.Close();
        }

        private void abbrechen_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

       
    }
}
