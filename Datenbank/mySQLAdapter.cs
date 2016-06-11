using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace NWAT_SS_165
{
    class mySQLAdapter : DatabaseAdapter
    {

        static string strProject = "db4free.net"; //Enter your SQL server instance name
        static string strDatabase = "nwat"; //Enter your database name
        static string strUserID = "nutzwertadmin"; // Enter your SQL Server User Name

        public MySqlConnection conn;
        public MySqlTransaction transaction;


        public mySQLAdapter(string strPassword) // Konstruktor
        {
            string strconn = "SERVER=" + strProject + ";" +
            "DATABASE=" + strDatabase + ";" +
            "UID=" + strUserID + ";" +
            "password=" + strPassword + ";";
            conn = new MySqlConnection(strconn);

        }

        public override void openConnection() // Open database Connection
        {
 
            try
            {
                           conn.Close();
                conn.Open();
                transaction = conn.BeginTransaction();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString(), "FEHLER in ExecuteSQL", MessageBoxButtons.OK);
            }

        }

        public override void closeConnection() // database connection close
        {
            try
            {
                transaction.Commit();
                conn.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString(), "FEHLER in ExecuteSQL", MessageBoxButtons.OK);
            }

        }

        public void errorTransaction()
        {
            transaction.Rollback();
            conn.Close();
        }

        protected void ExecuteSQL(string sSQL)
        {
            MySqlCommand cmd = new MySqlCommand(sSQL, conn);
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString(), "FEHLER in ExecuteSQL",MessageBoxButtons.OK);
            }
        }

        public override void insert(Model objekt)
        {
        }

        public void test_create()
        {
            openConnection();
            ExecuteSQL("CREATE TABLE Persons(PersonID int,LastName varchar(255),FirstName varchar(255),Address varchar(255),City varchar(255));");
            closeConnection();
        }

        public void test_delete()
        {
            openConnection();
            ExecuteSQL("DROP TABLE Persons;");
            closeConnection();
        }

        public override bool delete(Model objekt)
        {
            return true;
        }
        public override bool update(Model objekt)
        {
            return true;
        }

        public override Model get(Model objekt)
        {
            return new Kriterium();
        }

        public override long getAutoincrement(Model objekt)
        {
            return 0;
        }
    }
}
