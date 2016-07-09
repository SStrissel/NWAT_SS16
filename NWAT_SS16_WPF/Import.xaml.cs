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
    /// Interaktionslogik für Import.xaml
    /// </summary>
    public partial class Import : Window
    {
        private DatabaseAdapter db;
        private ControllerProjekt cp;
        Model temp;

        public Import(DatabaseAdapter db)
        {
            InitializeComponent();
            this.db = db;
            cp = new ControllerProjekt(db, this);
            cp.onCreateView();
        }

        private void ListBox_iauswahl(object sender, SelectionChangedEventArgs e)
        {
            Projekt p = ((sender as ListBox).SelectedItem as Projekt);
            temp = p;
            //cp.anzeigen(p);
        }

        private void abbrechen_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void importieren_Click(object sender, RoutedEventArgs e)
        {
            if (temp == null)
            {
                MessageBox.Show("Sie haben kein Projekt ausgewählt");
            }
            else
            {
                cp.import(temp);
                this.Close();
            }
          
        }
    }
}
