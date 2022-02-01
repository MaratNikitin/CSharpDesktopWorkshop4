using Group_1_Travel_Experts.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
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
    public partial class frmProductsSuppliers : Form
    {
        public frmProductsSuppliers()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Lists all the products into a combo box
        /// </summary>
        private void frmProductsSuppliers_Load(object sender, EventArgs e)
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
        /// Adds a supplier to the product
        /// </summary>
        private void btnAddSupplier_Click(object sender, EventArgs e)
        {
            frmProductsSuppliersAddUpdate secondFrm = new frmProductsSuppliersAddUpdate(); // create add form object
            secondFrm.selectedProductName = cboProducts.SelectedValue.ToString(); //gets current product name to second form

            DialogResult result = secondFrm.ShowDialog(); // display add/modify form
            
            // add product information from the second form to the database and display it in this form
            if (result == DialogResult.OK)
            {
                try
                {
                    using (TravelExpertsContext db = new TravelExpertsContext())
                    {
                        db.ProductsSuppliers.Add(secondFrm.newProductsSuppliers); // add new ProductsSupplier
                        db.SaveChanges(); // save changes
                    }
                    DisplaySuppliers(); // update display
                }
                catch (Exception ex)
                {
                    //error message
                    MessageBox.Show("Error has occured when trying to add the product." + ex.Message, ex.GetType().ToString());
                }
            }
        }

        /// <summary>
        /// Adds Delete buttons to each supplier row
        /// </summary>
        /// <param name="e"> Event listener that checks the location of the button and the method to execute</param>
        private void dgvSuppliers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            const int DeleteIndex = 1; // column index to delete supplier

            if (e.ColumnIndex == DeleteIndex && e.RowIndex >= 0) // delete button is pressed
            {
                string productName = cboProducts.SelectedValue.ToString(); // get product name from combo box
                string supplierName = dgvSuppliers.Rows[e.RowIndex].Cells[0].Value.ToString(); // get supplier from row
                DeleteProduct(e, productName, supplierName);
            }
        }

        /// <summary>
        /// Deletes the selected supplier from the product
        /// </summary>
        /// <param name="e"> Button event listener</param>
        /// <param name="productName"> product name from the combo box</param>
        /// <param name="supplierName"> supplier name from the selected row</param>
        private void DeleteProduct(DataGridViewCellEventArgs e, string productName, string supplierName)
        {
            //Confirm with the user to make sure they want to delete the supplier from the product
            DialogResult result = MessageBox.Show($"Delete {dgvSuppliers.Rows[e.RowIndex].Cells[0].Value}?",
            "Confirm Delete", MessageBoxButtons.YesNo,
            MessageBoxIcon.Question);

            if(result == DialogResult.Yes) // user confirms yes
            {
                try
                {
                    using (TravelExpertsContext db = new TravelExpertsContext())
                    {
                        //Query to get the selected productSupplierID based on the product name and supplier name selected
                        var selectedSupplier = (from productsSuppliers in db.ProductsSuppliers
                                                join suppliers in db.Suppliers on productsSuppliers.SupplierId equals suppliers.SupplierId
                                                join products in db.Products on productsSuppliers.ProductId equals products.ProductId
                                                where products.ProdName == productName && suppliers.SupName == supplierName
                                                select new { productsSuppliers.ProductSupplierId }).Single();

                        //get selected productSupplier 
                        ProductsSuppliers deleteProductSupplier = db.ProductsSuppliers.Find(selectedSupplier.ProductSupplierId);

                        db.Remove(deleteProductSupplier);//remove ProductsSupplier
                        db.SaveChanges(); // save changes
                    }
                    DisplaySuppliers(); // update display
                }
                catch (Exception ex) // display error message
                {
                    MessageBox.Show("Error has occured when trying to delete a supplier " + ex.Message, ex.GetType().ToString());
                }
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
                    dgvSuppliers.DataSource = db.ProductsSuppliers
                                             .Join(db.Suppliers, // join suppliers table
                                                   productSupplier => productSupplier.SupplierId, // Product_Supplier SupplierId
                                                   supplier => supplier.SupplierId, // Supplier SupplierId

                                                   // get all data from suppliers and Product_Supplier table
                                                   (productSupplier, supplier) => new { supplier, productSupplier })

                                             .Join(db.Products, // join products table
                                                   newProductSupplier => newProductSupplier.productSupplier.ProductId, // Product_Supplier ProductId
                                                   product => product.ProductId, // Product ProductId

                                                   //get all data from Product_Suppliers and Products table
                                                   (newProductSupplier, product) => new { product, newProductSupplier })

                                             //get all the suppliers that supplies the product with the same productName in the combo box
                                             .Where(m => m.product.ProdName == cboProducts.SelectedValue.ToString())

                                             .Select(m => new { m.newProductSupplier.supplier.SupName }).ToList(); // get supplier name
                }
                    // add column for delete buttons
                    var deleteColumn = new DataGridViewButtonColumn()
                    {
                        UseColumnTextForButtonValue = true,
                        HeaderText = " ",
                        Text = "Delete"
                    };
                    dgvSuppliers.Columns.Add(deleteColumn);
                    StyleDataGridView.Style(dgvSuppliers);
                    // shrink delete buttons to fit to size
                    dgvSuppliers.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }
            catch (Exception ex)
            {
                //error message
                MessageBox.Show("Error occured when trying to display suppliers" + ex.Message, ex.GetType().ToString());
            }
        }

        /// <summary>
        /// Closes the form
        /// </summary>
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
