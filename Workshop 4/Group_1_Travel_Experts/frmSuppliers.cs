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

        public void RefreshDataGridViewSuppliers()
        {
            dataGridViewSuppliers.DataSource = null; // setting DataSource as null helps to clear the listbox in the next line
            dataGridViewSuppliers.Rows.Clear(); // clearing the DataGridViewSuppliers

            using (TravelExpertsContext db = new TravelExpertsContext()) // creating a new DBContext instance
            {
                dataGridViewSuppliers.DataSource = db.Suppliers.ToList(); // displays the data from the Suppliers table in the data grid

                // Rename the columns
                dataGridViewSuppliers.Columns["SupplierId"].HeaderText = "Supplier ID";
                dataGridViewSuppliers.Columns["SupName"].HeaderText = "Supplier Name";

            }
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Close(); // closes this form but allows the application to continue running
        }
    }
}
