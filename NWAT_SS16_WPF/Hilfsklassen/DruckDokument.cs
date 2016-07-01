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
        }

        public void druck(object sender, PrintPageEventArgs e)
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
                            100, row.Height);

                        if (row.Cells[row.Index].Value != null)
                        {
                            row.Cells[row.Index].Value.ToString();
                            e.Graphics.DrawString(row.Cells[row.Index].Value.ToString(),
                                dt.Font, Brushes.Black, new RectangleF(offset_column, offset_row,
                                dt.Columns[row.Index].Width, row.Height), new StringFormat());
                        }
                        temp_row = row;
                        offset_column += dt.Columns[row.Index].Width;
                    }
                    offset_row += temp_row.Height;
                    offset_column = 0;
                }
        }
       
        public void BuildDataTable()
        {
            dt.ColumnCount = 5;
            dt.Columns[0].Name = "Spalte 1";
            dt.Columns[1].Name = "Spalte 2";
            dt.Columns[2].Name = "Spalte 3";
            dt.Columns[3].Name = "Spalte 4";
            dt.Columns[4].Name = "Spalte 5";

            // Populate the table 
            dt.Rows.Add("bla", "blubb", "da", "da", "da");
        }

        private void print()
        {
            Print();
        }
    }
}
