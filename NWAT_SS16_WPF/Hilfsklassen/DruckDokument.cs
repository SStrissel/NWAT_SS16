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
        static string CONST_ERF = "E";
        static string CONST_GEW = "Gew.";
        static string CONST_NUTZ = "Nutz.";
        static string CONST_PROZ = "Proz";
        static int CONST_PROD_LENGTH = 10;
        static string CONST_KOM = "Kommentar";

        public void BuildDataTable(bool erfuellung, bool gewichtung, bool nutzwert, bool prozent, int ProjektID, int[] ProduktID, DatabaseAdapter db)
        {
            dt.ColumnCount = 1;
            dt.Columns[dt.ColumnCount - 1].Name = CONST_NUM;
            dt.Columns[dt.ColumnCount - 1].Width = 50;

            dt.ColumnCount += 1;
            dt.Columns[dt.ColumnCount - 1].Name = CONST_BEZ;
            dt.Columns[dt.ColumnCount - 1].Width = 300;

            if (erfuellung)
            {
                dt.ColumnCount += 1;
                dt.Columns[dt.ColumnCount - 1].Name = CONST_ERF;
                dt.Columns[dt.ColumnCount - 1].Width = 10;
            }

            if (gewichtung)
            {
                dt.ColumnCount += 1;
                dt.Columns[dt.ColumnCount - 1].Name = CONST_GEW;
                dt.Columns[dt.ColumnCount - 1].Width = 50;
            }

            if (nutzwert)
            {
                dt.ColumnCount += 1;
                dt.Columns[dt.ColumnCount - 1].Name = CONST_NUTZ;
                dt.Columns[dt.ColumnCount - 1].Width = 50;
            }

            if (prozent)
            {
                dt.ColumnCount += 1;
                dt.Columns[dt.ColumnCount - 1].Name = CONST_PROZ;
                dt.Columns[dt.ColumnCount - 1].Width = 50;
            }

            Produkt temp_produkt = new Produkt(ProduktID[0]);
            foreach (int produkt in ProduktID)
            {
                temp_produkt = db.get(new Produkt(produkt))[0];
                dt.ColumnCount += 1;
                dt.Columns[dt.ColumnCount - 1].Name = temp_produkt.getBezeichnung().Substring(0,CONST_PROD_LENGTH);
            }

            dt.ColumnCount += 1;
            dt.Columns[dt.ColumnCount - 1].Name = CONST_KOM;
            dt.Columns[dt.ColumnCount - 1].Width = 300;


            Nutzwert temp_nwa = db.get(new Nutzwert(KriteriumID: 1, ProjektID: ProjektID, ProduktID: temp_produkt.getProduktID()))[0];
            Kriterium root_kriterium = temp_nwa.getKriterium(db).getRootKriterium(db)[0];

            int row = dt.Rows.Add();

            dt.Rows[row].Cells[CONST_NUM].Value = "0";
            dt.Rows[row].Cells[CONST_BEZ].Value = root_kriterium.getBezeichnung();
            dt.Rows[row].Cells[CONST_KOM].Value = root_kriterium.getNutzwert(db).getKommentar();

            if (erfuellung)
            {
                if (root_kriterium.getErfuellung(db) == true)
                {
                    dt.Rows[row].Cells[CONST_ERF].Value = "X";
                }
                else
                {
                    dt.Rows[row].Cells[CONST_ERF].Value = "-";
                }
            }
                 if (gewichtung)
            {
                dt.Rows[row].Cells[CONST_GEW].Value = root_kriterium.getGewichtung(db);
            }



                 addtorow(root_kriterium, erfuellung, gewichtung, nutzwert, prozent, ProjektID, ProduktID, db, "0");

          
        }

        private void addtorow(Kriterium temp_objekt, bool erfuellung, bool gewichtung, bool nutzwert, bool prozent, int ProjektID, int[] ProduktID, DatabaseAdapter db, string count)
        {
            int internal_count = 1;
            foreach (Kriterium temp_kriterium in temp_objekt.getUnterKriterium(db))
                {  
                    int row = dt.Rows.Add();
                    dt.Rows[row].Cells[CONST_NUM].Value = count + "." + internal_count;
                    dt.Rows[row].Cells[CONST_BEZ].Value = temp_kriterium.getBezeichnung();
                    dt.Rows[row].Cells[CONST_KOM].Value = temp_kriterium.getNutzwert(db).getKommentar();
                    if (erfuellung)
                    {
                        if (temp_kriterium.getErfuellung(db) == true)
                        {
                            dt.Rows[row].Cells[CONST_ERF].Value = "X";
                        }
                        else
                        {
                            dt.Rows[row].Cells[CONST_ERF].Value = "-";
                        }
                    }
                    if (gewichtung)
                    {
                        dt.Rows[row].Cells[CONST_GEW].Value = temp_kriterium.getGewichtung(db);
                    }
                    addtorow(temp_kriterium, erfuellung, gewichtung, nutzwert, prozent, ProjektID, ProduktID, db, count + "." + internal_count);
                    internal_count++;
                }
        }

        private void print()
        {
            Print();
        }
    }
}
