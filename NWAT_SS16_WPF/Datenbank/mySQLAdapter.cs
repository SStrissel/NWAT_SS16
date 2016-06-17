using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

using System.Windows;

namespace NWAT_SS16
{
    public class mySQLAdapter : DatabaseAdapter
    {
        public MySqlConnection conn;
        public MySqlTransaction transaction;

        public mySQLAdapter()
        {
        }

        public mySQLAdapter(string strServer, string strDatabase, string strUserID, string strPassword) // Konstruktor
        {
            string strconn = "SERVER=" + strServer + ";" +
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
                MessageBox.Show(e.ToString(), "FEHLER in ExecuteSQL", MessageBoxButton.OK);
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
                MessageBox.Show(e.ToString(), "FEHLER in ExecuteSQL", MessageBoxButton.OK);
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
                MessageBox.Show(e.ToString(), "FEHLER in ExecuteSQL",MessageBoxButton.OK);
            }
        }

        public override void insert(Model objekt)
        {
        }

        public override void init_tables()
        {
            openConnection();
            ExecuteSQL("CREATE TABLE Projekt (ProjektID int, Bezeichnung varchar(255));");
            ExecuteSQL("CREATE TABLE Produkt (ProduktID int, Bezeichnung varchar(255));");
            ExecuteSQL("CREATE TABLE Kriterium (KriteriumID int, Bezeichnung varchar(255));");
            ExecuteSQL("CREATE TABLE Kriterienstruktur (OberKriteriumID int, UnterKriteriumID int);");
            ExecuteSQL("CREATE TABLE NWA (ProjektID int, KriteriumID int, ProduktID int, Erfuellung boolean, Gewichtung int, Kommentare varchar(255), beitrag_absolut double, beitrag_absolut_check boolean);");
            closeConnection();
        }

        public override void drop_tables()
        {
            openConnection();
            ExecuteSQL("DROP TABLE Projekt;");
            ExecuteSQL("DROP TABLE Produkt;");
            ExecuteSQL("DROP TABLE Kriterium;");
            ExecuteSQL("DROP TABLE Kriterienstruktur;");
            ExecuteSQL("DROP TABLE NWA;");
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

        public override Model[] get(Model objekt)
        {
            return new Kriterium[5];
        }


        public override bool checkConnection()
        {
            try
            {
                    conn.Open();
                    return true;
            }
            catch
            {
                return false; // any error is considered as db connection error for now
            }
        }
    }
}
