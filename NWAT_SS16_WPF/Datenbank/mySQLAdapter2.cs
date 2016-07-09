using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;

using System.Windows;

namespace NWAT_SS16
{
    public class mySQLAdapter2: DatabaseAdabter2
    {
    

        public MySqlConnection conn;
        public MySqlTransaction transaction;
        public MySqlDataReader reader;

        /* Team 
        initialisiert die Verbindung zur Datenbank

        /*
         * Import/Export
         * Server: db4free.net
         * Database: nwat_expimp
         * strUser: nutzwertexpimp
         * strPassword: ******
         * */

        public mySQLAdapter2() // Konstruktor
        {
            string strconn = "SERVER=db4free.net;DATABASE=nwat_expimp;UID=nutzwertexpimp;password=ad.nutz#;";
            conn = new MySqlConnection(strconn);

        }
       


        /* Team 
         öffnet eine Verbindung
        */

        private void openConnection() // Open database Connection
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

        /* Team 
         schließt eine Verbindung
        */

        private void closeConnection() // database connection close
        {
            try
            {
                if (transaction != null)
                {
                    transaction.Commit();
                    transaction = null;
                }
                if (reader != null)
                {
                    reader.Close();
                }
                if (conn != null)
                {
                    conn.Close();
                }
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

        /* Team 
         führt einen Befehl auf der Datenbank ohne Rückmeldung aus
        */

        protected void ExecuteSQL(string sSQL)
        {
            openConnection();
            MySqlCommand cmd = new MySqlCommand(sSQL, conn);
            try
            {
                //cmd.Connection = conn;
                //conn.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString(), "FEHLER in ExecuteSQL", MessageBoxButton.OK);
            }
            closeConnection();
        }
        
        /* Team 
         führt einen SQL-Befehl aus und gibt die Antwort als DataTable zurück (langsam)
        */
        
        protected DataTable QuerySQL(string sSQL)
        {
            openConnection();
            DataTable dataTable = new  DataTable();
                 MySqlCommand cmd = new MySqlCommand(sSQL, conn);
                 // create data adapter
                 MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                 // this will query your database and return the result to your datatable
                 try
                 {
                     da.Fill(dataTable);
                 }
                 catch (Exception e)
                 {
                     MessageBox.Show(e.ToString(), "FEHLER in ExecuteSQL", MessageBoxButton.OK);
                 }
                 closeConnection();
                 da.Dispose();
                 return dataTable;
        }


        public override  string exp(Model objekt)
        {
         
            if (objekt == null)
            {
           
            }
                if (objekt.GetType().Name == "Projekt")
                {
              
                    Projekt temp_objekt = (Projekt)objekt;
                   ExecuteSQL("INSERT INTO Projekt (ProjektID, Bezeichnung) VALUES ( " + temp_objekt.getProjektID() + ", '" + temp_objekt.getBezeichnung() + "');");
  
                }

                // string file = "C:\\backup.sql";
                string file = "C:\\Users\\Mehmet.T\\Pictures\\backup.sql";

                using (MySqlCommand cmd = new MySqlCommand())
                {
                    using (MySqlBackup mb = new MySqlBackup(cmd))
                    {
                        cmd.Connection = conn;
                        conn.Open();
                        mb.ExportToFile(file);
                        conn.Close();
                    }
                }

           return "";   
        }

        // import
        public override void imp(Model objekt)
        {
            if (objekt == null)
            {

            }
            if (objekt.GetType().Name == "Projekt")
            {
                Projekt temp_objekt = (Projekt)objekt;
                if (temp_objekt.getProjektID() != 0)
                {
                    ExecuteSQL("DELETE FROM Projekt WHERE ProjektID = '" + temp_objekt.getProjektID() + "';");
                }
                else
                {
                    throw new Exception("ID darf bei Delete nicht 0 sein");
                }
            }
        }

        //get
        public override List<Projekt> get(Projekt objekt)
        {
            List<Model> temp_list = get((Model)objekt);
            List<Projekt> return_list = new List<Projekt>();
            foreach (Model temp_model in temp_list)
            {
                return_list.Add((Projekt)temp_model);
            }
            return return_list;
        }

        /* Team 
            generische get-Methode
         */
        public List<Model> get(Model objekt)
        {
            List<Model> return_list = new List<Model>();
            if (objekt.GetType().Name == "Projekt")
            {
                Projekt temp_obj = (Projekt)objekt;
                DataTable temp_datatable = QuerySQL("SELECT * FROM Projekt;");
                foreach (DataRow row in temp_datatable.Rows)
                {
                    Projekt temp_model = new Projekt();
                    temp_model.setProjektID((int)row[0]);
                    temp_model.setBezeichnung((string)row[1]);
                    return_list.Add(temp_model);
                }
                return return_list;
     
            }
            throw new NotImplementedException();
        }

        /* Team 
        testet, ob eine Verbindung zur Datenbank besteht
       */
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
