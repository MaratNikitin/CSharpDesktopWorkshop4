using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Group_1_Travel_Experts
{
    public static class StyleDataGridView
    {
        /// <summary>
        /// Styles for the data grid view
        /// </summary>
        /// <param name="dgv"> Suppliers data grid view</param>
        public static void Style(DataGridView dgv)
        {
            //Set header Style
            if (dgv.Columns["SupName"] != null)
            {
                dgv.Columns["SupName"].HeaderText = "Suppliers";
            }
            dgv.EnableHeadersVisualStyles = false; // enabling manual background color change in the next code row
            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.Bisque; // setting the desired background color
            dgv.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.Bisque; // to avoid highlighting selected columns
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.Maroon; // setting the same font color as for other rows
            dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill; // first cell fills the empty space
        }
    }
}
