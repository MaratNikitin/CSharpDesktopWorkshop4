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
    public partial class frmProductsSuppliersAddUpdate : Form
    {
        public string selectedProductName;
        public ProductsSuppliers newProductsSuppliers;
        public frmProductsSuppliersAddUpdate()
        {
            InitializeComponent();
        }

        private void frmProductsSuppliersAddUpdate_Load(object sender, EventArgs e)
        {
            lblProdName.Text = selectedProductName;
            DisplaySuppliers();
            StyleDataGridView(dgvSuppliers);
        }
        private void StyleDataGridView(DataGridView dgv)
        {
            //Set header Style
            dgv.Columns["SupName"].HeaderText = "Suppliers";
            dgv.EnableHeadersVisualStyles = false; // enabling manual background color change in the next code row
            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.Bisque; // setting the desired background color
            dgv.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.Bisque; // to avoid highlighting selected columns
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.Maroon; // setting the same font color as for other rows
            dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill; // first cell fills the empty space
        }
        // Add new products_Supplier when add button is pressed
        private void btnAdd_Click(object sender, EventArgs e)
        {
            newProductsSuppliers = new ProductsSuppliers();
            newProductsSuppliers.SupplierId = GetSelectedSupplierID();
            newProductsSuppliers.ProductId = GetSelectedProductID();

            this.DialogResult = DialogResult.OK;
        }
        //Cancels the process and returns to main form
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        //Updates the data grid view to filter the suppliers
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if(txtSearch.Text != null && txtSearch.Text !="")
            {
                using (TravelExpertsContext db = new TravelExpertsContext())
                {
                    var SupplierQuery = (from productSupplier in db.ProductsSuppliers
                                         join supplier in db.Suppliers
                                             on productSupplier.SupplierId equals supplier.SupplierId
                                         join product in db.Products
                                             on productSupplier.ProductId equals product.ProductId
                                         where product.ProdName != selectedProductName &&
                                                // filters suppliers by characters in text box
                                                supplier.SupName.ToUpper().IndexOf(txtSearch.Text.ToUpper()) > -1 &&
                                                // filters suppliers by the first character in the text box
                                                txtSearch.Text.ToUpper().Substring(0,1) == supplier.SupName.ToUpper().Substring(0, 1)
                                         orderby supplier.SupName
                                         select new { supplier.SupName }).ToList();

                    // displays all the supplier names that are not already displayed in frmProductsSupplier
                    dgvSuppliers.DataSource = SupplierQuery;
                }
            }
            else
            {
                DisplaySuppliers();
            }
        }

        //Load all suppliers
        private void DisplaySuppliers()
        {
            using (TravelExpertsContext db = new TravelExpertsContext())
            {
                var SupplierQuery = (from productSupplier in db.ProductsSuppliers
                                     join supplier in db.Suppliers
                                         on productSupplier.SupplierId equals supplier.SupplierId
                                     join product in db.Products
                                         on productSupplier.ProductId equals product.ProductId
                                     where product.ProdName != selectedProductName
                                     orderby supplier.SupName
                                     select new { supplier.SupName }).ToList();

                // displays all the supplier names that are not already displayed in frmProductsSupplier
                dgvSuppliers.DataSource = SupplierQuery;
            }
        }

        //get selected product
        private int GetSelectedSupplierID()
        {
            int? supplierId = null; // null int if there is not supplier Id found
            try
            {
                using (TravelExpertsContext db = new TravelExpertsContext())
                {
                    if (dgvSuppliers.SelectedCells.Count > 0)
                    {
                        int selecedRowIndex = dgvSuppliers.SelectedCells[0].RowIndex; // get row index
                        DataGridViewRow selectedRow = dgvSuppliers.Rows[selecedRowIndex]; // get row from selected cell

                        // get supplierId based on what they selected in the data grid view
                        var supplierQuery = (from supplier in db.Suppliers
                                            where supplier.SupName == selectedRow.Cells["SupName"].Value.ToString()
                                            select new { supplier.SupplierId }).Single();
                        supplierId = supplierQuery.SupplierId;
                    }
                }
            }
            catch (Exception ex) //write an exception message
            {
                MessageBox.Show("Error has occured when trying to get current product" + ex.Message, ex.GetType().ToString());
            }
            return (int)supplierId;
        }

        //get selected product
        private int GetSelectedProductID()
        {
            int? productId = null; // null int if there is not supplier Id found
            try
            {
                using (TravelExpertsContext db = new TravelExpertsContext())
                {

                    // get productID based on what they selected in the main form
                    var productQuery = (from product in db.Products
                                             where product.ProdName == selectedProductName
                                             select new { product.ProductId }).Single();
                    productId = productQuery.ProductId;
                    
                }
            }
            catch (Exception ex) //write an exception message
            {
                MessageBox.Show("Error has occured when trying to get current product" + ex.Message, ex.GetType().ToString());
            }
            return (int)productId;
        }
    }
}
