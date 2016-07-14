using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Drawing.Printing;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

namespace NWAT_SS16
{
    //Hauptverantwortlicher: Strissel
    class DruckDokument : PrintDocument
    {
        DataGridView dt = new DataGridView();

        public DruckDokument()
        {
            this.PrintPage += new PrintPageEventHandler(druck);
            this.DefaultPageSettings.Landscape = true;
            dt.AutoSize = true;
            dt.AutoGenerateColumns = false;
            dt.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
        }

        private void druck(object sender, PrintPageEventArgs e)
        {
            int offset_column = 0;
            int offset_row = 0;
            DataGridViewRow temp_row = new DataGridViewRow();
            foreach (DataGridViewColumn column in dt.Columns)
            {
                //Draws a rectangle with same width and height of first column of datagridview. 
                e.Graphics.DrawRectangle(Pens.Black, offset_column, offset_row,
                    column.Width, dt.Rows[0].Height);

                //Fills the above drawn rectangle with a light gray colour just to distinguish the header 
                e.Graphics.FillRectangle(Brushes.LightGray, new Rectangle
                    (offset_column, offset_row, column.Width, dt.Rows[0].Height));

                e.Graphics.DrawString(column.Name,
dt.Font, Brushes.Black, new RectangleF(offset_column, offset_row,
column.Width, dt.Rows[0].Height), new StringFormat());

                offset_column += column.Width;
            }

            offset_column = 0;
            offset_row = dt.Rows[0].Height;

                foreach (DataGridViewRow row in dt.Rows)
                {
                    for (int i = 0; i < row.Cells.Count; i++ )
                    {
                        //Draws a rectangle with same width and height of first column of datagridview. 
                        e.Graphics.DrawRectangle(Pens.Black, offset_column, offset_row,
                            dt.Columns[i].Width, row.GetPreferredHeight(row.Index, DataGridViewAutoSizeRowMode.AllCells, true));
                        if (row.Cells.Count > i)
                        {
                            if (row.Cells[i].Value != null)
                            {
                                e.Graphics.DrawString(row.Cells[i].Value.ToString(),
                                    dt.Font, Brushes.Black, new RectangleF(offset_column, offset_row,
                                    dt.Columns[i].Width, row.GetPreferredHeight(row.Index, DataGridViewAutoSizeRowMode.AllCells, true)), new StringFormat());
                            }
                        }
                        offset_column += dt.Columns[i].Width;
                        temp_row = row;
                    }
                    offset_row += temp_row.GetPreferredHeight(row.Index, DataGridViewAutoSizeRowMode.AllCells, true);
                    offset_column = 0;
                }
        }

        static string CONST_NUM = "Num.";
        static string CONST_BEZ = "Kriterium";
        static string CONST_ANF = "*"; // Anforderungen des Anwenders
        static string CONST_GEW = "Gew.";
        static string CONST_PROZ = "Proz";
        static int CONST_PROD_LENGTH = 10;
        static string CONST_KOM = "Kommentar";

        public void BuildDataTable(bool erfuellung, bool anforderungen, bool gewichtung, bool nutzwert, bool prozent, int ProjektID, int[] ProduktID, DatabaseAdapter db, bool produkte)
        {
            dt = new DataGridView();
            dt.ColumnCount = 1;
            dt.Columns[dt.ColumnCount - 1].Name = CONST_NUM;
            dt.Columns[dt.ColumnCount - 1].Width = 50;

            dt.ColumnCount += 1;
            dt.Columns[dt.ColumnCount - 1].Name = CONST_BEZ;
            dt.Columns[dt.ColumnCount - 1].Width = 300;

            if (gewichtung)
            {
                dt.ColumnCount += 1;
                dt.Columns[dt.ColumnCount - 1].Name = CONST_GEW;
                dt.Columns[dt.ColumnCount - 1].Width = 50;
            }

            if (anforderungen)
            {
                dt.ColumnCount += 1;
                dt.Columns[dt.ColumnCount - 1].Name = CONST_ANF;
                dt.Columns[dt.ColumnCount - 1].Width = 50;
            }

            Produkt temp_produkt = new Produkt(ProduktID[0]);
            ControllerNutzwert cntrl_nutzwer = new ControllerNutzwert(db, null);
            if (produkte)
            {
                foreach (int produkt in ProduktID)
                {
                    temp_produkt = db.get(new Produkt(produkt))[0];
                    dt.ColumnCount += 1;
                    string column_name = temp_produkt.getBezeichnung();
                    if (temp_produkt.getBezeichnung().Length > CONST_PROD_LENGTH)
                    {
                        column_name = column_name.Substring(0, CONST_PROD_LENGTH);
                    }
                    dt.Columns[dt.ColumnCount - 1].Name = column_name;
                }
            }

            dt.ColumnCount += 1;
            dt.Columns[dt.ColumnCount - 1].Name = CONST_KOM;
            dt.Columns[dt.ColumnCount - 1].Width = 300;

            Nutzwert temp_nwa = db.get(new Nutzwert(KriteriumID: 1, ProjektID: ProjektID, ProduktID: temp_produkt.getProduktID()))[0];
            Kriterium root_kriterium = temp_nwa.getKriterium(db).getRootKriterium(db)[0];

            if (root_kriterium.getErfuellung(db: db, ProjektID: ProjektID, ProduktID: temp_produkt.getProduktID()) == true || anforderungen == false)
            {

                if (prozent)
                {
                    dt.ColumnCount += 1;
                    dt.Columns[dt.ColumnCount - 1].Name = CONST_PROZ;
                    dt.Columns[dt.ColumnCount - 1].Width = 50;
                }
            }

  
            int row = dt.Rows.Add();

            dt.Rows[row].Cells[CONST_NUM].Value = "0";
            dt.Rows[row].Cells[CONST_BEZ].Value = root_kriterium.getBezeichnung();
            dt.Rows[row].Cells[CONST_KOM].Value = root_kriterium.getNutzwert(db, ProjektID, temp_produkt.getProduktID()).getKommentar();
            if (anforderungen)
            {
                if (root_kriterium.getNutzwert(db, 0, 0).getGewichtung() == 0)
                {
                    dt.Rows[row].Cells[CONST_ANF].Value = "-";
                }
                else
                {
                    dt.Rows[row].Cells[CONST_ANF].Value = "X";
                }
            }

            if (produkte)
            {
                foreach (int produkt in ProduktID)
                {
                    temp_produkt = db.get(new Produkt(produkt))[0];
                    string column_name = temp_produkt.getBezeichnung();
                    if (temp_produkt.getBezeichnung().Length > CONST_PROD_LENGTH)
                    {
                        column_name = column_name.Substring(0, CONST_PROD_LENGTH);
                    }

                    if (erfuellung == false)
                    {
                        cntrl_nutzwer.funktionsabdeckungsgrad_berechnen(root_kriterium.getNutzwert(db, ProjektID, temp_produkt.getProduktID()));
                    }

                    if (anforderungen == true)
                    {
                        dt.Rows[row].Cells[column_name].Value = root_kriterium.getNutzwert(db, ProjektID, temp_produkt.getProduktID()).getErfuellung();
                    }
                    else
                    {
                        dt.Rows[row].Cells[column_name].Value = root_kriterium.getNutzwert(db, ProjektID, temp_produkt.getProduktID()).getBeitragAbsolut();
                    }

                    if (erfuellung)
                    {
                        if (root_kriterium.getGewichtung(db: db, ProjektID: ProjektID, ProduktID: temp_produkt.getProduktID()) > 0)
                        {
                            dt.Rows[row].Cells[column_name].Value = "X";
                        }
                        else
                        {
                            dt.Rows[row].Cells[column_name].Value = "-";
                        }
                    }
                    else
                    {
                        dt.Rows[row].Cells[column_name].Value = root_kriterium.getNutzwert(db, ProjektID, temp_produkt.getProduktID()).getBeitragAbsolut();
                    }
                }
            }

            if (root_kriterium.getGewichtung(db: db, ProjektID: ProjektID, ProduktID: temp_produkt.getProduktID()) > 0 || anforderungen == false)
            {
                if (gewichtung)
                {
                    dt.Rows[row].Cells[CONST_GEW].Value = root_kriterium.getGewichtung(db, ProjektID, temp_produkt.getProduktID());
                }

                if (prozent)
                {
                    dt.Rows[row].Cells[CONST_PROZ].Value = cntrl_nutzwer.prozent(root_kriterium.getNutzwert(db: db, ProjektID: ProjektID, ProduktID: temp_produkt.getProduktID()));
                }
            }
                 addtorow(root_kriterium, erfuellung, anforderungen, gewichtung, nutzwert, prozent, ProjektID, ProduktID, db,  cntrl_nutzwer, "0", produkte);              
        }

        private void addtorow(Kriterium temp_objekt, bool erfuellung, bool anforderungen, bool gewichtung, bool nutzwert, bool prozent, int ProjektID, int[] ProduktID, DatabaseAdapter db, ControllerNutzwert  cntrl_nutzwer, string count, bool produkte)
        {
            int internal_count = 1;
            foreach (Kriterium temp_kriterium in temp_objekt.getUnterKriterium(db))
                {  
                    int row = dt.Rows.Add();
                    dt.Rows[row].Cells[CONST_NUM].Value = count + "." + internal_count;
                    dt.Rows[row].Cells[CONST_BEZ].Value = temp_kriterium.getBezeichnung();
                    dt.Rows[row].Cells[CONST_KOM].Value = temp_kriterium.getNutzwert(db: db, ProjektID: 0, ProduktID: 0).getKommentar();

                    Produkt temp_produkt = new Produkt(ProduktID[0]);
                    if (produkte)
                    {
                        foreach (int produkt in ProduktID)
                        {
                            temp_produkt = db.get(new Produkt(produkt))[0];
                            string column_name = temp_produkt.getBezeichnung();
                            if (temp_produkt.getBezeichnung().Length > CONST_PROD_LENGTH)
                            {
                                column_name = column_name.Substring(0, CONST_PROD_LENGTH);
                            }
                            dt.ColumnCount += 1;
                            if (temp_kriterium.getGewichtung(db, ProjektID: 0, ProduktID: 0) > 0 || anforderungen == true)
                            {
                                if (erfuellung == true)
                                {
                                    if (temp_kriterium.getErfuellung(db: db, ProjektID: ProjektID, ProduktID: produkt) == true)
                                    {
                                        dt.Rows[row].Cells[column_name].Value = "X";
                                    }
                                    else
                                    {
                                        dt.Rows[row].Cells[column_name].Value = "-";
                                    }
                                }
                                else
                                {

                                    dt.Rows[row].Cells[column_name].Value = temp_kriterium.getNutzwert(db, ProjektID, temp_produkt.getProduktID()).getBeitragAbsolut();
                                }
                            }
                        }
                    }

                    
                    if (anforderungen)
                    {
                        if (temp_kriterium.getGewichtung(db, ProjektID, temp_produkt.getProduktID()) > 0)
                        {
                            dt.Rows[row].Cells[CONST_ANF].Value = "X";
                        }
                        else
                        {
                            dt.Rows[row].Cells[CONST_ANF].Value = "-";
                        }
                    }

                    if (temp_kriterium.getGewichtung(db, ProjektID, temp_produkt.getProduktID()) > 0 || anforderungen == false)
                    {
                        if (gewichtung)
                        {
                            dt.Rows[row].Cells[CONST_GEW].Value = temp_kriterium.getGewichtung(db, ProjektID, temp_produkt.getProduktID());
                        }

                        if (prozent)
                        {
                            dt.Rows[row].Cells[CONST_PROZ].Value = cntrl_nutzwer.prozent(temp_kriterium.getNutzwert(db: db, ProjektID: ProjektID, ProduktID: temp_produkt.getProduktID()));
                        }
                    }

                    addtorow(temp_kriterium, erfuellung, anforderungen, gewichtung, nutzwert, prozent, ProjektID, ProduktID, db, cntrl_nutzwer, count + "." + internal_count, produkte);
                    internal_count++;
                }
        }

        private void print()
        {
            Print();
        }
    }
}
