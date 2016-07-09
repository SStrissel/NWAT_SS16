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
    /// Interaktionslogik für Projekt_aendern.xaml
    /// </summary>
    public partial class Projekt_aendern : Window
    {
        private DatabaseAdapter db;
        private DatabaseAdabter2 db2;
        private ControllerProjekt cp;
        public Projekt_aendern(DatabaseAdapter db)
        {
            InitializeComponent();
            this.db = db;
            cp = new ControllerProjekt(db,db2, this);
  
            textProjektIDaendern.Text = Projekt.getProjektIDtemp().ToString();
            textBezeichnungaendern.Text = Projekt.getBezeichnungtemp();
        
            
        }

        private void abbrechen_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void aendern_Click(object sender, RoutedEventArgs e)
        {
            cp.aendern();
            this.Close();
        }
    }
}
