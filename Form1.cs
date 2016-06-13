using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NWAT_SS_165
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            infoBox.Text = "Verbindung zur Datenbank wird hergestellt...";

            Task task = new Task(asyncTryToConnect);
            task.Start();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        bool changeInfoBox(string text)
        {
            infoBox.Text += text;
            return true;
        }

        async void asyncTryToConnect()
        {
            mySQLAdapter db = new mySQLAdapter(server.Text, datenbank.Text, benutzer.Text, passwort.Text);
            DateTime jetzt = DateTime.Now;
            bool result = false;
            try
            {
                result = await handleTryToConnect(db);
            }
            catch
            {
                this.Invoke((Func<string, bool>)changeInfoBox, "...Verbindungsfehler.");
                return;
            }
            
            if (result)
            {
                TimeSpan difference = DateTime.Now - jetzt;
                this.Invoke((Func<string, bool>)changeInfoBox, "...erfolgreich (" + difference.TotalSeconds + " s)");
            }
            else
            {
                this.Invoke((Func<string, bool>)changeInfoBox, "...fehlgeschlagen.");
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

        private void button2_Click(object sender, EventArgs e)
        {
            mySQLAdapter db = new mySQLAdapter(server.Text, datenbank.Text, benutzer.Text, passwort.Text);
            db.test_delete();
            MessageBox.Show("Befehl ausgeführt.", "fertig", MessageBoxButtons.OK);
        }

        private void label2_Click_1(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
    }
}
