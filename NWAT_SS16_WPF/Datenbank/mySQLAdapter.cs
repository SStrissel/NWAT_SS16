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
    public class mySQLAdapter : DatabaseAdapter
    {
        public MySqlConnection conn;
        public MySqlTransaction transaction;
        public MySqlDataReader reader;

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

        public override void insert(Model objekt)
        {
             if (objekt.GetType().Name == "Kriterium")
            {
                 Kriterium temp_objekt = (Kriterium)objekt;
                 openConnection();
                 ExecuteSQL("INSERT INTO Kriterium (KriteriumID, Bezeichnung) VALUES ( " + temp_objekt.getKriteriumID() + ", '" + temp_objekt.getBezeichnung() + "');");
                 closeConnection();
            }
             else if (objekt.GetType().Name == "Nutzwert")
             {
                 Nutzwert temp_obj = (Nutzwert)objekt;
                 throw new NotImplementedException();
             }
             else if (objekt.GetType().Name == "Produkt")
             {
                 Produkt temp_obj = (Produkt)objekt;
                 throw new NotImplementedException();
             }
             else if (objekt.GetType().Name == "Projekt")
             {
                 Projekt temp_obj = (Projekt)objekt;
                 throw new NotImplementedException();
             }
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

        /* Stephan Strissel 
            greift auf die generische get-Methode zu und wandelt sie in eine objektspezifische um
         */

        public override List<Kriterium> get(Kriterium objekt)
        {
            List<Model> temp_list = get((Model)objekt);
            List<Kriterium> return_list = new List<Kriterium>();
            foreach (Model temp_model in temp_list)
            {
                return_list.Add((Kriterium)temp_model);
            }
            return return_list;
        }

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

        public override List<Produkt> get(Produkt objekt)
        {
            List<Model> temp_list = get((Model)objekt);
            List<Produkt> return_list = new List<Produkt>();
            foreach (Model temp_model in temp_list)
            {
                return_list.Add((Produkt)temp_model);
            }
            return return_list;
        }


        public override List<Nutzwert> get(Nutzwert objekt)
        {
            List<Model> temp_list = get((Model)objekt);
            List<Nutzwert> return_list = new List<Nutzwert>();
            foreach (Model temp_model in temp_list)
            {
                return_list.Add((Nutzwert)temp_model);
            }
            return return_list;
        }

         /* Stephan Strissel 
            generische get-Methode
         */

        public List<Model> get(Model objekt)
        {
            List<Model> return_list = new List<Model>();
            if (objekt.GetType().Name == "Kriterium")
            {
                Kriterium temp_obj = (Kriterium)objekt;
                openConnection();
                if (temp_obj.getKriteriumID() == 0)
                {
                    DataTable temp_datatable = QuerySQL("SELECT * FROM Kriterium;");
                    foreach (DataRow row in temp_datatable.Rows)
                    {
                       Kriterium temp_model = new Kriterium();
                        temp_model.setKriteriumID((int)row[0]);
                        temp_model.setBezeichnung((string)row[1]);
                        return_list.Add(temp_model);
                    }

                }
                else
                {
                    throw new NotImplementedException();
                }
                closeConnection();
                return return_list;
            }
            else if (objekt.GetType().Name == "Nutzwert")
            {
                Nutzwert temp_obj = (Nutzwert)objekt;
                throw new NotImplementedException();
 }
            else if (objekt.GetType().Name == "Produkt")
            {
                Produkt temp_obj = (Produkt)objekt;
                throw new NotImplementedException();
                 }
            else if (objekt.GetType().Name == "Projekt")
            {
                Projekt temp_obj = (Projekt)objekt;
                throw new NotImplementedException();
            }
             throw new NotImplementedException();
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
