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
    /// Teambasierte Ausarbeitung
    /// Hauptverantwortlicher: Wusterhausen
    /// </summary>
    public partial class NutzwertVerwaltung : Window
    {
        //Objekterzeugung des ConontrollerNutzwert
              private ControllerNutzwert cntrl;
        public NutzwertVerwaltung(DatabaseAdapter db)
        {
            InitializeComponent();
            cntrl = new ControllerNutzwert(db, this);
            cntrl.onCreateView();
            cntrl.onUpdateData();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Ranking");            
        }
        //Ruft die Funktion gleichgewichten der Klasse ControllerNutzwert auf
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {            
            cntrl.gleichgewichten();
        }
    }
}
