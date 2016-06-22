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

        /* Team 
        initialisiert die Verbindung zur Datenbank
         */
        public mySQLAdapter(string strServer, string strDatabase, string strUserID, string strPassword) // Konstruktor
        {
            string strconn = "SERVER=" + strServer + ";" +
            "DATABASE=" + strDatabase + ";" +
            "UID=" + strUserID + ";" +
            "password=" + strPassword + ";";
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
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString(), "FEHLER in ExecuteSQL",MessageBoxButton.OK);
            }
            closeConnection();
        }

        /* Team 
         vergibt eine neue ID (Autoincrement)
        */

        private int newID(Model objekt)
        {
            int value = 0;
            openConnection();
            if (objekt.GetType().Name == "Kriterium")
            {
                MySqlCommand command = new MySqlCommand("SELECT KriteriumID FROM Autoincrement;", conn);
                MySqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        value = (int)reader[0];
                    }
                    value = value + 1;
                reader.Close();
                if (value != 0)
                {
                    ExecuteSQL("UPDATE Autoincrement SET KriteriumID = '" + value + "' WHERE KriteriumID = '" + (value - 1) + "';");
                }
            }
            else if (objekt.GetType().Name == "Nutzwert")
            {
                throw new NotImplementedException();
            }
            else if (objekt.GetType().Name == "Produkt")
            {
                throw new NotImplementedException();
            }
            else if (objekt.GetType().Name == "Projekt")
            {
                MySqlCommand command = new MySqlCommand("SELECT ProjektID FROM Autoincrement;", conn);
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    value = (int)reader[0];
                }
                value = value + 1;
                reader.Close();
                if (value != 0)
                {
                    ExecuteSQL("UPDATE Autoincrement SET ProjektID = '" + value + "' WHERE ProjektID = '" + (value - 1) + "';");
                }
            }
            else if (objekt.GetType().Name == "Kriteriumstruktur")
            {
                return 0; // braucht keine ID
            }
            if (value == 0)
            {
                throw new Exception("Die neue ID kann nicht 0 sein");
            }
            closeConnection();
            return value;
        }

        public override int getID(Model objekt)
        {
            openConnection();
            int value = 0;
            if (objekt.GetType().Name == "Projekt")
            {
               
                MySqlCommand command = new MySqlCommand("SELECT ProjektID FROM Autoincrement;", conn);
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    value = (int)reader[0];
                }
                value = value + 1;
                reader.Close();
                return value;
            }
            closeConnection();
            throw new Exception("Die neue ID kann nicht 0 sein");
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

        /* Team 
        fügt ein neues Model in die Datenbank ein
        */

        public override int insert(Model objekt)
        {
            int myID = 0;
             if (objekt.GetType().Name == "Kriterium")
            {
                 myID = newID(objekt); // Autoincrement vergeben
                 Kriterium temp_objekt = (Kriterium)objekt;
                 ExecuteSQL("INSERT INTO Kriterium (KriteriumID, Bezeichnung) VALUES ( " + myID + ", '" + temp_objekt.getBezeichnung() + "');");
            }
             else if (objekt.GetType().Name == "Nutzwert")
             {
                 Nutzwert temp_obj = (Nutzwert)objekt;
                 throw new NotImplementedException();
             }
             else if (objekt.GetType().Name == "Produkt")
             {
                 Produkt p = (Produkt)objekt;
                 
             }
             else if (objekt.GetType().Name == "Projekt")
             {
                 myID = newID(objekt); // Autoincrement vergeben
                 Projekt proj = (Projekt)objekt;
                 ExecuteSQL("INSERT INTO Projekt (ProjektID, Bezeichnung) VALUES ( " + myID + ", '" + proj.getBezeichnung() + "');");
             }
             else if (objekt.GetType().Name == "Kriteriumstruktur")
             {
                 Kriteriumstruktur temp_objekt = (Kriteriumstruktur)objekt;
                 myID = temp_objekt.getOberKriteriumID(); // Hat kein Autoincrement
                 ExecuteSQL("INSERT INTO Kriteriumstruktur (OberKriteriumID, UnterKriteriumID) VALUES ( " +  temp_objekt.getOberKriteriumID() + ", '" + temp_objekt.getUnterKriteriumID() + "');");
             }
             return myID;
        }


        /* Team 
         initialisiert alle Tabellen
        */
        public override void init_tables()
        {
            ExecuteSQL("CREATE TABLE Autoincrement (ProjektID int, KriteriumID int, ProduktID int);");
            ExecuteSQL("INSERT INTO Autoincrement (ProjektID, KriteriumID, ProduktID) VALUES (0,0,0);");
            ExecuteSQL("CREATE TABLE Projekt (ProjektID int, Bezeichnung varchar(255));");
            ExecuteSQL("CREATE TABLE Produkt (ProduktID int, Bezeichnung varchar(255));");
            ExecuteSQL("CREATE TABLE Kriterium (KriteriumID int, Bezeichnung varchar(255));");
            ExecuteSQL("CREATE TABLE Kriteriumstruktur (OberKriteriumID int, UnterKriteriumID int);");
            ExecuteSQL("CREATE TABLE NWA (ProjektID int, KriteriumID int, ProduktID int, Erfuellung boolean, Gewichtung int, Kommentare varchar(255), beitrag_absolut double, beitrag_absolut_check boolean);");
        }

        /* Team 
         löscht alle Tabellen
        */
        public override void drop_tables()
        {
            ExecuteSQL("DROP TABLE Projekt;");
            ExecuteSQL("DROP TABLE Produkt;");
            ExecuteSQL("DROP TABLE Kriterium;");
            ExecuteSQL("DROP TABLE Kriteriumstruktur;");
            ExecuteSQL("DROP TABLE NWA;");
            ExecuteSQL("DROP TABLE Autoincrement;");
        }

        /* Team 
         löscht das Model in der Datenbank
         * Key-Überprüfung fehlt!
        */

        public override void delete(Model objekt)
        {
            if (objekt == null)
            {
                throw new Exception("Objekt darf nicht null sein");
            }
            if (objekt.GetType().Name == "Kriterium")
            {
                Kriterium temp_objekt = (Kriterium)objekt;
                if (temp_objekt.getKriteriumID() != 0)
                {
                    ExecuteSQL("DELETE FROM Kriterium WHERE KriteriumID = '" + temp_objekt.getKriteriumID() + "';");
                }
                else
                {
                    throw new Exception("ID darf bei delete nicht 0 sein");
                }
            }
            else if (objekt.GetType().Name == "Nutzwert")
            {
                Nutzwert temp_obj = (Nutzwert)objekt;
                throw new NotImplementedException();
            }
            else if (objekt.GetType().Name == "Produkt")
            {
                Produkt temp_objekt = (Produkt)objekt;
                if (temp_objekt.getProduktID() != 0)
                {
                    ExecuteSQL("DELETE FROM Produkt WHERE ProduktID = '" + temp_objekt.getProduktID() + "';");
                }
                else
                {
                    throw new Exception("ID darf bei delete nicht 0 sein");
                }
            }
            else if (objekt.GetType().Name == "Projekt")
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
            else if (objekt.GetType().Name == "Kriteriumstruktur")
            {
                Kriteriumstruktur temp_obj = (Kriteriumstruktur)objekt;
                if (temp_obj.getOberKriteriumID() != 0 && temp_obj.getUnterKriteriumID() == 0)
                {
                    ExecuteSQL("DELETE * FROM Kriteriumstruktur WHERE OberKriteriumID = '" + temp_obj.getOberKriteriumID() + "';");
                }
                else if (temp_obj.getUnterKriteriumID() != 0 && temp_obj.getOberKriteriumID() == 0)
                {
                    ExecuteSQL("DELETE * FROM Kriteriumstruktur WHERE UnterKriteriumID = '" + temp_obj.getUnterKriteriumID() + "';");
                }
                else if (temp_obj.getUnterKriteriumID() != 0 && temp_obj.getOberKriteriumID() != 0)
                {
                    ExecuteSQL("DELETE FROM Kriteriumstruktur WHERE UnterKriteriumID=" + temp_obj.getUnterKriteriumID() + " AND OberKriteriumID=" + temp_obj.getOberKriteriumID() + ";");
                }
            }
        }

        /* Team 
         updated das Model in der Datenbank
        */
        public override void update(Model objekt)
        {
            if (objekt == null)
            {
                throw new Exception("Objekt darf nicht null sein");
            }
            if (objekt.GetType().Name == "Kriterium")
            {
                Kriterium temp_objekt = (Kriterium)objekt;
                if (temp_objekt.getKriteriumID() != 0)
                {
                    ExecuteSQL("UPDATE Kriterium SET Bezeichnung='" + temp_objekt.getBezeichnung() + "' WHERE KriteriumID = '" + temp_objekt.getKriteriumID() + "';");
                }
                else
                {
                    throw new Exception("ID darf bei delete nicht 0 sein");
                }
            }
            else if (objekt.GetType().Name == "Nutzwert")
            {
                Nutzwert temp_obj = (Nutzwert)objekt;
                throw new NotImplementedException();
            }
            else if (objekt.GetType().Name == "Produkt")
            {
                Produkt temp_objekt = (Produkt)objekt;
                if (temp_objekt.getProduktID() != 0)
                {
                    ExecuteSQL("UPDATE Produkt SET (Bezeichnung) VALUES ( + " + temp_objekt.getBezeichnung() + " ) WHERE ProduktID = '" + temp_objekt.getProduktID() + "';");
                }
                else
                {
                    throw new Exception("ID darf bei delete nicht 0 sein");
                }
            }
            else if (objekt.GetType().Name == "Projekt")
            {
                Projekt temp_objekt = (Projekt)objekt;
                if (temp_objekt.getProjektID() != 0)
                {
                    ExecuteSQL("UPDATE Projekt SET (Bezeichnung) VALUES ( + " + temp_objekt.getBezeichnung() + " ) WHERE ProjektmID = '" + temp_objekt.getProjektID() + "';");  
                }
                else
                {
                    throw new Exception("ID darf bei Update nicht 0 sein");
                }
            }
        }

        /* Team 
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

        public override List<Kriteriumstruktur> get(Kriteriumstruktur objekt)
        {
            List<Model> temp_list = get((Model)objekt);
            List<Kriteriumstruktur> return_list = new List<Kriteriumstruktur>();
            foreach (Model temp_model in temp_list)
            {
                return_list.Add((Kriteriumstruktur)temp_model);
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

         /* Team 
            generische get-Methode
         */
        public List<Model> get(Model objekt)
        {
            List<Model> return_list = new List<Model>();
            if (objekt.GetType().Name == "Kriterium")
            {
                Kriterium temp_obj = (Kriterium)objekt;
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
                    DataTable temp_datatable = QuerySQL("SELECT * FROM Kriterium WHERE KriteriumID = " + temp_obj.getKriteriumID() + ";");
                    foreach (DataRow row in temp_datatable.Rows)
                    {
                       Kriterium temp_model = new Kriterium();
                        temp_model.setKriteriumID((int)row[0]);
                        temp_model.setBezeichnung((string)row[1]);
                        return_list.Add(temp_model);
                    }
                }
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
            else if (objekt.GetType().Name == "Kriteriumstruktur")
            {
                Kriteriumstruktur temp_obj = (Kriteriumstruktur)objekt;
                DataTable temp_datatable;
                if (temp_obj.getOberKriteriumID() != 0 && temp_obj.getUnterKriteriumID() == 0)
                {
                    temp_datatable = QuerySQL("SELECT * FROM Kriteriumstruktur WHERE OberKriteriumID = " + temp_obj.getOberKriteriumID() + ";");
                    foreach (DataRow row in temp_datatable.Rows)
                    {
                        Kriteriumstruktur temp_model = new Kriteriumstruktur();
                        temp_model.setOberKriteriumID((int)row[0]);
                        temp_model.setUnterKriteriumID((int)row[1]);
                        return_list.Add(temp_model);
                    }
                }
                else if (temp_obj.getUnterKriteriumID() != 0 && temp_obj.getOberKriteriumID() == 0)
                {
                    temp_datatable = QuerySQL("SELECT * FROM Kriteriumstruktur WHERE UnterKriteriumID = " + temp_obj.getUnterKriteriumID() + ";");
                    foreach (DataRow row in temp_datatable.Rows)
                    {
                        Kriteriumstruktur temp_model = new Kriteriumstruktur();
                        temp_model.setOberKriteriumID((int)row[0]);
                        temp_model.setUnterKriteriumID((int)row[1]);
                        return_list.Add(temp_model);
                    }
                }
                else if (temp_obj.getUnterKriteriumID() != 0 && temp_obj.getOberKriteriumID() != 0)
                {
                    temp_datatable = QuerySQL("SELECT * FROM Kriteriumstruktur WHERE UnterKriteriumID = " + temp_obj.getUnterKriteriumID() + " AND OberKriteriumID = " + temp_obj.getOberKriteriumID() + ";");
                    foreach (DataRow row in temp_datatable.Rows)
                    {
                        Kriteriumstruktur temp_model = new Kriteriumstruktur();
                        temp_model.setOberKriteriumID((int)row[0]);
                        temp_model.setUnterKriteriumID((int)row[1]);
                        return_list.Add(temp_model);
                    }
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
