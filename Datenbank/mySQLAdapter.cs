using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace NWAT_SS_165
{
    class mySQLAdapter : DatabaseAdapter
    {

    static string strProject = "db4free.net:3306"; //Enter your SQL server instance name
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

        public void openConnection() // Open database Connection
        {
            conn.Close();
            conn.Open();
            transaction = conn.BeginTransaction();
        }

        public void closeConnection() // database connection close
        {
            transaction.Commit();
            conn.Close();
        }

        public void errorTransaction()
        {
            transaction.Rollback();
            conn.Close();
        }

        protected void ExecuteSQL(string sSQL)
        {
            MySqlCommand cmd = new MySqlCommand(sSQL, conn);
            cmd.ExecuteNonQuery();
        }
    }
}
