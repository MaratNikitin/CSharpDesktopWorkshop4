﻿using Group_1_Travel_Experts.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Group_1_Travel_Experts
{
    public partial class frmAddProductsToPackages : Form
    {
        #region Class Variable
        public Packages selectedPackage; // get selected product
        public int addProductsSupplierID; // returns productsSupplierId to create / update PackagesSuppliers
        #endregion
        public frmAddProductsToPackages()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Lists all the products into a combo box
        /// </summary>
        private void frmAddProductsToPackages_Load(object sender, EventArgs e)
        {
            try
            {
                using (TravelExpertsContext db = new TravelExpertsContext())
                {
                    //puts all products in a combo box
                    cboProducts.DataSource = db.Products.OrderBy(p => p.ProdName).Select(p => p.ProdName).ToList();
                    cboProducts.DisplayMember = "ProdName";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error when displaying data. {ex.Message}, {ex.GetType()}"); // error message
            }
        }
        /// <summary>
        /// Updates the supplier grid everytime a product is selected in the combo box
        /// </summary>
        private void cboProducts_SelectedIndexChanged(object sender, EventArgs e)
        {
            DisplaySuppliers();
        }
        /// <summary>
        /// Add/Update products and suppliers in the selected package
        /// </summary>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                using (TravelExpertsContext db = new TravelExpertsContext())
                {
                    if (dgvSuppliers.SelectedCells.Count > 0)
                    {
                        int selecedRowIndex = dgvSuppliers.SelectedCells[0].RowIndex; // get row index
                        DataGridViewRow selectedRow = dgvSuppliers.Rows[selecedRowIndex]; // get row from selected cell

                        // get productID based on what they selected in the main form
                        var productSupplierQuery = (from productSupplier in db.ProductsSuppliers // products_supplier table
                                                join product in db.Products // join products table
                                                    on productSupplier.ProductId equals product.ProductId
                                                join supplier in db.Suppliers // join suppliers table
                                                    on productSupplier.SupplierId equals supplier.SupplierId
                                                where supplier.SupName == selectedRow.Cells["SupName"].Value.ToString() &&
                                                        product.ProdName == cboProducts.SelectedValue.ToString()
                                                    //get product_supplier Id based on selected product and 
                                                    // selected supplier
                                                    select new { productSupplier.ProductSupplierId }).Single(); 

                        addProductsSupplierID = productSupplierQuery.ProductSupplierId; // get product Supplier ID
                        this.DialogResult = DialogResult.OK; // return to main form
                    }
                }
            }
            catch (Exception ex) //write an exception message
            {
                MessageBox.Show("Error has occured when trying to get current product" + ex.Message, ex.GetType().ToString());
            }
        }

        /// <summary>
        /// Displays all the suppliers that correspond to the selected product
        /// </summary>
        private void DisplaySuppliers()
        {
            try
            {
                dgvSuppliers.Columns.Clear(); // clear display

                using (TravelExpertsContext db = new TravelExpertsContext())
                {
                    /* Get supplier names based on the select product
                     * It will only display supplier that supply the selected product
                     */
                    var prodSupQuery = (from prodSup in db.ProductsSuppliers
                                        join pps in db.PackagesProductsSuppliers // join packagesProductsSuppliers
                                             on prodSup.ProductSupplierId equals pps.ProductSupplierId into ps
                                             from subPPS in ps.DefaultIfEmpty()

                                        join supplier in db.Suppliers // join suppliers table
                                             on prodSup.SupplierId equals supplier.SupplierId

                                        join prod in db.Products // join products
                                            on prodSup.ProductId equals prod.ProductId
                                        // filter suppliers by selected product
                                        where prod.ProdName == cboProducts.SelectedValue.ToString()

                                                //filter suppliers based on the PackagesProductSuppliers that already exsits
                                                // Prevent duplicating data in PackagesProductSuppliers table
                                                && subPPS.PackageId != selectedPackage.PackageId

                                        select new { supplier.SupName }).ToList(); // get supplier names
                    dgvSuppliers.DataSource = prodSupQuery;
                }
                StyleDataGridView(dgvSuppliers);
            }
            catch (Exception ex)
            {
                //error message
                MessageBox.Show("Error occured when trying to display suppliers" + ex.Message, ex.GetType().ToString());
            }
        }

        /// <summary>
        /// Sizes and styles the data grid view
        /// </summary>
        /// <param name="dgv"> suppliers grid</param>
        private void StyleDataGridView(DataGridView dgv)
        {
            //Set header Style
            dgv.Columns["SupName"].HeaderText = "Suppliers";
            dgv.EnableHeadersVisualStyles = false; // enabling manual background color change in the next code row
            dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; // Align header to the middle center
            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.Bisque; // setting the desired background color
            dgv.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.Bisque; // to avoid highlighting selected columns
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.Maroon; // setting the same font color as for other rows

            //Size columns
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill; // auto size the columns to fit all the cell's content
            dgv.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; // first cell fills the empty space
        }

        /// <summary>
        /// Closes the form
        /// </summary>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}