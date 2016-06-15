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
    public partial class Hauptwaschgang : Form
    {

        private DatabaseAdapter db;

        public Hauptwaschgang(DatabaseAdapter database)
        {
            db = database;
            InitializeComponent();
        }

        private void Hauptwaschgang_Load(object sender, EventArgs e)
        {
 
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Projektverwaltung frm = new Projektverwaltung();
            this.WindowState = FormWindowState.Minimized;
            frm.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Ups...Dieser Bereich wurde noch nicht implementiert!", "Die Waschmaschine hat eine Socke Socke gefressen...", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Ups...Dieser Bereich wurde noch nicht implementiert!", "Die Waschmaschine hat eine Socke Socke gefressen...", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Ups...Dieser Bereich wurde noch nicht implementiert!", "Die Waschmaschine hat eine Socke Socke gefressen...", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
