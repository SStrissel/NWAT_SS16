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
using System.Windows.Navigation;
using System.Windows.Shapes;


using System.Drawing.Printing;

namespace NWAT_SS16
{
    /// <summary>
    /// Interaktionslogik für Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
            passwort.Focus();
            if (Keyboard.IsKeyToggled(Key.CapsLock))
            {
                warnung.Visibility = Visibility.Visible;
            }
            else
            {
                warnung.Visibility = Visibility.Hidden;
            }
        }


        public void Button_Click(object sender, RoutedEventArgs e)
        {
            infoBox.Text = "Verbindung zur Datenbank wird hergestellt...";
            mySQLAdapter db = new mySQLAdapter(server.Text, datenbank.Text, benutzer.Text, passwort.Password);
            var task = new Task(() => asyncTryToConnect(db));
            task.Start();
       } 

        bool view_hauptmenue(DatabaseAdapter db)
        {
            Hauptmenue frm = new Hauptmenue(db);
            frm.ShowDialog();
            return true;
        }

        bool changeInfoBox(string text)
        {
            infoBox.Text += text;
            return true;
        }

        public async void asyncTryToConnect(DatabaseAdapter db)
        {

            
            DateTime jetzt = DateTime.Now;
            bool result = false;
            try
            {
                result = await handleTryToConnect(db);
            }
            catch
            {
                infoBox.Dispatcher.BeginInvoke(new Action(() => { infoBox.Text += "...Verbindungsfehler."; }));
                return;
            }

            if (result)
            {
                TimeSpan difference = DateTime.Now - jetzt;
                infoBox.Dispatcher.BeginInvoke(new Action(() => { infoBox.Text += "...erfolgreich (" + difference.TotalSeconds + " s)"; }));
                Application.Current.Dispatcher.BeginInvoke(new Action(() => { view_hauptmenue(db); }));
             }
            else
            {
                await infoBox.Dispatcher.BeginInvoke((Action)(() => infoBox.Text += "...fehlgeschlagen."));
            }
        }

        async Task<bool> handleTryToConnect(DatabaseAdapter db)
        {
            if (db.checkConnection())
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void Passwort_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                Button_Click(this, new RoutedEventArgs());
            }
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (Keyboard.IsKeyToggled(Key.CapsLock))
            {
                warnung.Visibility = Visibility.Visible;
            }
            else
            {
                warnung.Visibility = Visibility.Hidden;
            }
        }
    }
}
