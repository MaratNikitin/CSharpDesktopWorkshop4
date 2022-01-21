using Group_1_Travel_Experts.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Group_1_Travel_Experts
{
    public partial class frmSuppliers : Form
    {
        public frmSuppliers()
        {
            InitializeComponent();
        }

        private void frmSuppliers_Load(object sender, EventArgs e)
        {
            RefreshDataGridViewSuppliers(); // displays the newest Supplier data
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Close(); // closes the form
        }

        public void RefreshDataGridViewSuppliers()
        {
            dataGridViewSuppliers.DataSource = null; // setting DataSource as null helps to clear the listbox in the next line
            dataGridViewSuppliers.Rows.Clear(); // clearing the DataGridViewSuppliers

            try
            {
                using (TravelExpertsContext db = new TravelExpertsContext()) // creating a new DBContext instance
                {
                    var suppliers = db.Suppliers.Select(s => new
                    {
                        s.SupplierId,
                        s.SupName
                    }).OrderBy(s => s.SupName).ToList();

                    dataGridViewSuppliers.DataSource = suppliers; // displays the data from the Suppliers table in the data grid

                    // Rename the column
                    dataGridViewSuppliers.Columns["SupplierId"].HeaderText = "Supplier ID";
                    dataGridViewSuppliers.Columns["SupName"].HeaderText = "Supplier Name";

                    // format alternating rows
                    dataGridViewSuppliers.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray;

                    // Resize the columns
                    dataGridViewSuppliers.Columns[0].Width = 100;
                    dataGridViewSuppliers.Columns[1].Width = 525;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while getting the suppliers's data: " + ex.Message, ex.GetType().ToString());
            }
        }
    }
}
