using Group_1_Travel_Experts.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

/*
 * This app helps doing CRUD operations with the select tables of the 'TravelExperts' database.
 * It is the main form of the application where a user selects which of the database's table to work with
 * Author: Jacky Luong
 * SAIT, OOSD course, CPRG-207 - Threaded Project (Part 2), Workshop #4 - C#.NET, Group 1
 * When: January-February 2022
 */

namespace Group_1_Travel_Experts
{
    public partial class frmProductsSuppliersAddUpdate : Form
    {
        public string selectedProductName; // Product name from product_Supplier form
        public ProductsSuppliers newProductsSuppliers; // Create new product_Supplier link
        
        public frmProductsSuppliersAddUpdate()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Displays the selected product and all the suppliers that can be linked
        /// </summary>
        private void frmProductsSuppliersAddUpdate_Load(object sender, EventArgs e)
        {
            lblProdName.Text = selectedProductName;
            DisplaySuppliers();
            StyleDataGridView(dgvSuppliers);
        }

        /// <summary>
        /// Add new products_Supplier when add button is pressed
        /// </summary>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            newProductsSuppliers = new ProductsSuppliers(); // create a new product_supplier
            int supId = GetSelectedSupplierID();
            int prodId = GetSelectedProductID();

            if(supId == -1) //  If no supplier is selected
            {
                txtSearch.Clear();
                DisplaySuppliers(); // Reset the display
            }
            else // A supplier is selected
            {
                newProductsSuppliers.SupplierId = supId;
                newProductsSuppliers.ProductId = prodId;
                this.DialogResult = DialogResult.OK;
            }
        }

        /// <summary>
        /// Cancels the process and returns to main form
        /// </summary>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        /// <summary>
        /// Updates the data grid view to filter the suppliers
        /// </summary>
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtSearch.Text != null && txtSearch.Text != "")
                {
                    using (TravelExpertsContext db = new TravelExpertsContext())
                    {
                        //Get a list of all suppliers that are linked with the selected product
                        #region ProductSupplierQuery
                        var ProductSupplierQuery = (from supplier in db.Suppliers
                                                    join productSupplier in db.ProductsSuppliers //join product_Supplier
                                                        on supplier.SupplierId equals productSupplier.SupplierId

                                                    join product in db.Products //join products
                                                        on productSupplier.ProductId equals product.ProductId

                                                    where product.ProdName == selectedProductName
                                                    orderby supplier.SupName
                                                    select new { supplier.SupName }).ToList();
                        #endregion
                        //Get a list of all suppliers
                        #region AllSuppliers
                        var AllSuppliers = (from supplier in db.Suppliers
                                            orderby supplier.SupName
                                            select new { supplier.SupName }).ToList();
                        #endregion
                        // List of suppliers that are filtered based on search and suppliers that were already linked 
                        // to the selected product
                        List<object> suppliersToAdd = new List<object>();

                        //Filter out the suppliers that are already linked to the selected product
                        #region Filter suppliers
                        foreach (var supName in AllSuppliers)
                        {
                            // Counts how many matching supplier names from ProductSupplierQuery and AllSuppliers 
                            int counter = 0;

                            foreach (var prodSupName in ProductSupplierQuery)
                            {
                                if (prodSupName.SupName == supName.SupName)
                                {
                                    counter++;
                                }
                            }
                            // Add the supplier if there are no matches and filters the suppliers based on search
                            if (counter == 0 &&
                                supName.SupName.ToUpper().IndexOf(txtSearch.Text.ToUpper()) > -1 &&
                                txtSearch.Text.ToUpper().Substring(0, 1) == supName.SupName.ToUpper().Substring(0, 1)
                                )
                            {
                                suppliersToAdd.Add(supName); //Add supplier to the list
                            }
                        }
                        #endregion
                        dgvSuppliers.DataSource = suppliersToAdd; //Adds filtered suppliers list to the data grid view
                                                                  // Disable adding if there are no suppliers displayed
                        #region Disable/Enable Add Button
                        if (suppliersToAdd.Count == 0)
                        {
                            btnAdd.Enabled = false;
                        }
                        else
                        {
                            btnAdd.Enabled = true;
                        }
                        #endregion
                    } // Database connection closed
                }// If condition closed
                else // If there is nothing in the search text box
                {
                    DisplaySuppliers();
                }
            }
            catch (Exception ex) // dispay error message
            {
                MessageBox.Show("Error has occured when trying to display and filter the suppliers " 
                                + ex.Message, ex.GetType().ToString());
            }
        }

        /// <summary>
        /// Displays all the suppliers that have not yet linked to the selected product
        /// </summary>
        private void DisplaySuppliers()
        {
            try
            {
                using (TravelExpertsContext db = new TravelExpertsContext())
                {
                    //Get a list of all suppliers that are linked with the selected product
                    #region ProductSupplierQuery
                    var ProductSupplierQuery = (from supplier in db.Suppliers
                                                join productSupplier in db.ProductsSuppliers //join product_Supplier
                                                    on supplier.SupplierId equals productSupplier.SupplierId

                                                join product in db.Products //join products
                                                    on productSupplier.ProductId equals product.ProductId

                                                where product.ProdName == selectedProductName
                                                orderby supplier.SupName
                                                select new { supplier.SupName }).ToList();
                    #endregion
                    //Get a list of all suppliers
                    #region AllSuppliers
                    var AllSuppliers = (from supplier in db.Suppliers
                                        orderby supplier.SupName
                                        select new { supplier.SupName }).ToList();
                    #endregion
                    // List of suppliers that are filtered based on search and suppliers that were already linked 
                    // to the selected product
                    List<object> suppliersToAdd = new List<object>();
                    //Filter out the suppliers that are already linked to the selected product
                    #region Filter Suppliers
                    foreach (var supName in AllSuppliers)
                    {
                        // counts how many matching supplier names from ProductSupplierQuery and AllSuppliers 
                        int counter = 0;

                        foreach (var prodSupName in ProductSupplierQuery)
                        {
                            if (prodSupName.SupName == supName.SupName)
                            {
                                counter++;
                            }
                        }
                        // add the supplier if there are no matches
                        if (counter == 0)
                        {
                            suppliersToAdd.Add(supName);
                        }
                    }
                    #endregion
                    // displays all the supplier names that are not already displayed in frmProductsSupplier
                    dgvSuppliers.DataSource = suppliersToAdd;
                    // Disable adding if there are no suppliers displayed
                    #region Disable/Enable Add Button
                    if (suppliersToAdd.Count == 0)
                    {
                        btnAdd.Enabled = false;
                    }
                    else
                    {
                        btnAdd.Enabled = true;
                    }
                    #endregion
                }
            } 
            catch (Exception ex) // dispay error message
            {
                MessageBox.Show("Error has occured when trying to display the suppliers " + ex.Message, ex.GetType().ToString());
            }
        }
        
        /// <summary>
        /// Styles for the data grid view
        /// </summary>
        /// <param name="dgv"> Suppliers data grid view</param>
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
        
        /// <summary>
        /// Gets a supplier Id from the selected supplier name
        /// </summary>
        /// <returns>SupplierId</returns>
        private int GetSelectedSupplierID()
        {
            int? supplierId = -1; // null int if there is not supplier Id found
            try
            {
                using (TravelExpertsContext db = new TravelExpertsContext())
                {
                    string selecedSupplier= dgvSuppliers.SelectedCells[0].Value.ToString(); // get row index

                    // get supplierId based on what they selected in the data grid view
                    var supplierQuery = (from supplier in db.Suppliers
                                        where supplier.SupName == selecedSupplier
                                        select new { supplier.SupplierId }).Single();
                    supplierId = supplierQuery.SupplierId;
                }
            }
            catch (Exception ex) //write an exception message
            {
                MessageBox.Show("Error has occured when trying to get current product" + ex.Message, ex.GetType().ToString());
            }
            return (int)supplierId;
        }

        /// <summary>
        /// Gets productId from the selected product on the main form
        /// </summary>
        /// <returns>ProductId</returns>
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
