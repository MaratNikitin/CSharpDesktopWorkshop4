using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms; 
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Group_1_Travel_Experts.Models;

/*
 * This app helps doing CRUD operations with the select tables of the 'TravelExperts' database.
 * This form is used for displaying a list of packages in a list box and helps to add, modify or delete packages
 * Author: Marat Nikitin
 * SAIT, OOSD course, CPRG-207 - Threaded Project (Part 2), Workshop #4 - C#.NET, Group 1
 * When: January-February 2022
 */

namespace Group_1_Travel_Experts
{
    public partial class frmPackages : Form
    {
        public frmPackages()
        {
            InitializeComponent();
        }

        private TravelExpertsContext context = new TravelExpertsContext(); // creating an object of TravelExpertsContext class 
        private Packages selectedPackage; // represents a selected Packages class instance (which represents a row in the DB table)

        private void frmPackages_Load(object sender, EventArgs e)
        {
            RefreshDataGridViewPackages(); // 'dataGridViewPackages' is populated from the TravelExperts database
            RefreshDataGridViewProducts(); // 'dataGridViewProducts' is populated from the TravelExperts database
        }

        // when the 'Exit' button is pressed
        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Close(); // the form closes, but the app goes on
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            var addUpdateForm = new frmPackagesAddUpdate // an instance of the frmPackagesAddUpdate form is created
            {
                AddPackage = true // This is a public parameter from the frmPackagesAddUpdate form, true means that the "Add" button was pressed
            };
            DialogResult result = addUpdateForm.ShowDialog(); // the second form opens as modal form
            if (result == DialogResult.OK)
            {
                selectedPackage = addUpdateForm.Package; // information about the added product (entered in the second form) is saved as a Product class instance
                try
                {
                    context.Packages.Add(selectedPackage); // a new row is added
                    context.SaveChanges(); // the new row is saved in the DB
                    MessageBox.Show("1 row was successfuly added to the 'Packages' table of the 'TravelExperts' database.", "Success!"); // feedback to a user
                    RefreshDataGridViewPackages(); // using a custom-created method to refresh the listbox's contents
                }
                catch (DbUpdateException ex) // if saving data in the DB fails
                {
                    HandleDataError(ex); // this method is described below
                }
                catch (Exception ex) // if some other exception happens
                {
                    HandleGeneralError(ex); // this method is described below
                }
            }
        }

        // when the "Modify Package" button is clicked
        private void buttonModify_Click(object sender, EventArgs e)
        {            
            var selectedPackage = context.Packages.Find((int)dataGridViewPackages.SelectedCells[0].Value); // picking a selected row from DataGridView            
            var addUpdateForm = new frmPackagesAddUpdate // creating a new instance of the second form
            {
                AddPackage = false, // it means that the "Modify" button was pressed 
                Package = selectedPackage // saving the selected package to use it later in the frmPackagesAddUpdate form              
            };
            DialogResult result = addUpdateForm.ShowDialog(); // the second form opens as modal form
            if (result == DialogResult.OK)
            {
                addUpdateForm.Package = selectedPackage; // saving a selected package as a parameter for further manupulations
                try
                {
                    context.Packages.Update(selectedPackage); // updating the selected row
                    context.SaveChanges(); // the updated row is saved in the DB
                    MessageBox.Show("1 selected row was successfuly updated in the 'Packages' table of the 'TravelExperts' database.", "Success!"); // feedback to a user
                    RefreshDataGridViewPackages(); // using a custom-created method to refresh the listbox's contents
                }
                catch (DbUpdateException ex) // if saving data in the DB fails
                {
                    HandleDataError(ex); // this custom-made method is described below
                }
                catch (Exception ex) // if some other exception hapens
                {
                    HandleGeneralError(ex); // this custom-made method is described below
                }
            }
        }

        // when the "Remove Package" button is clicked
        private void buttonRemove_Click(object sender, EventArgs e)
        {
            var selectedPackage = context.Packages.Find((int)dataGridViewPackages.SelectedCells[0].Value); // picking the selected package
            DialogResult result =
                MessageBox.Show(
                $"Delete {selectedPackage.PkgName}?", "Confirm Delete", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question); // making sure that user wants to delete the selected row
            if (result == DialogResult.Yes) // it means that the Delete operation was manually confirmed by a user
            {
                try
                {
                    context.Packages.Remove(selectedPackage); // deleting the row
                    context.SaveChanges(); // the new row is deleted from the DB, the change is saved
                    MessageBox.Show("1 selected row was successfuly deleted from the 'Packages' table of the TravelExperts database", "Success!"); // feedback to a user
                    RefreshDataGridViewPackages(); // using a custom-created method to refresh the listbox's contents
                }
                catch (DbUpdateException ex) // if saving data in the DB fails
                {
                    HandleDataError(ex); // this custom-made method is described below
                }
                catch (Exception ex) // if some other exception hapens
                {
                    HandleGeneralError(ex); // this custom-made method is described below
                }
            }
        }

        // when any cell is clicked in the 'DataGridViewPackages' (i.e. a package is selected):
        private void dataGridViewPackages_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            RefreshDataGridViewProducts(); // products of the selected package are immediately displayed in the 'DataGridViewProducts'
        }

        /// <summary>
        /// Handling DB Update Exception error by displaying appropriate information about the error to a user
        /// </summary>
        /// <param name="ex"> Instance of an exception </param>
        private void HandleDataError(DbUpdateException ex)
        {
            string errorMessage = "";
            var sqlException = (SqlException)ex.InnerException;
            foreach (SqlError error in sqlException.Errors)
            {
                errorMessage += "ERROR CODE: " + error.Number + " " +
                error.Message + "\n";
            }
            MessageBox.Show(errorMessage); // displaying error code, number and message to a user in a message box
        }

        /// <summary>
        /// Handling al other unforeseen errors by displaying appropriate information about it in a message box
        /// </summary>
        /// <param name="ex"> Instance of an exception </param>
        private void HandleGeneralError(Exception ex)
        {
            MessageBox.Show(ex.Message, ex.GetType().ToString()); // displaying appropriate information about an error in a message box
        }

        /// <summary>
        /// Custom-made method allowing refreshing data in the 'dataGridViewPackages'  
        /// </summary>
        private void RefreshDataGridViewPackages()
        {
            dataGridViewPackages.DataSource = null; // setting DataSource as null helps to clear the listbox in the next line
            dataGridViewPackages.Rows.Clear(); // clearing the DataGridViewPackages
            using (TravelExpertsContext db = new TravelExpertsContext()) // creating a new DBContext instance
            {
                dataGridViewPackages.DataSource = db.Packages.ToList(); // displaying data from the 'Packages' table of the DB in the DataGridView
                // connection string is placed in the 'App.config' file inside this project             

                // hiding undesirable columns that shouldn't be displayed:
                dataGridViewPackages.Columns["PackageId"].Visible = false;
                dataGridViewPackages.Columns["Bookings"].Visible = false;
                dataGridViewPackages.Columns["PackagesProductsSuppliers"].Visible = false;

                // renaming the column headers properly:
                dataGridViewPackages.Columns["PackageId"].HeaderText = "Package ID";
                dataGridViewPackages.Columns["PkgName"].HeaderText = "Package Name";
                dataGridViewPackages.Columns["PkgStartDate"].HeaderText = "Package Start Date";
                dataGridViewPackages.Columns["PkgEndDate"].HeaderText = "Package End Date";
                dataGridViewPackages.Columns["PkgDesc"].HeaderText = "Description";
                dataGridViewPackages.Columns["PkgBasePrice"].HeaderText = "Base Price";
                dataGridViewPackages.Columns["PkgAgencyCommission"].HeaderText = "Agency Commission";

                // setting desired widths of the displayed columns:
                dataGridViewPackages.Columns["PkgName"].Width = 240; // width is set at 200px
                dataGridViewPackages.Columns["PkgStartDate"].Width = 120;
                dataGridViewPackages.Columns["PkgEndDate"].Width = 120;
                dataGridViewPackages.Columns["PkgDesc"].Width = 440;
                dataGridViewPackages.Columns["PkgBasePrice"].Width = 120;
                dataGridViewPackages.Columns["PkgAgencyCommission"].Width = 125;
                
                // setting displayed data formats:
                dataGridViewPackages.Columns["PkgStartDate"].DefaultCellStyle.Format = "MMM. dd, yyyy"; // setting desired package start date format
                dataGridViewPackages.Columns["PkgEndDate"].DefaultCellStyle.Format = "MMM. dd, yyyy"; // setting desired package end date format
                dataGridViewPackages.Columns["PkgBasePrice"].DefaultCellStyle.Format = "c"; // setting currency format to base price of a package
                dataGridViewPackages.Columns["PkgAgencyCommission"].DefaultCellStyle.Format = "c"; // setting currency format to commission value

                // styling the column headers row (i.e. the uppermost row)
                dataGridViewPackages.EnableHeadersVisualStyles = false; // enabling manual background color change in the next code row
                dataGridViewPackages.ColumnHeadersDefaultCellStyle.BackColor = Color.Bisque; // setting the desired background color
                dataGridViewPackages.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.Bisque; // to avoid highlighting selected columns
                dataGridViewPackages.ColumnHeadersDefaultCellStyle.ForeColor = Color.Maroon; // setting the same font color as for other rows
                dataGridViewPackages.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; // setting central text alignment

                // setting central text alignment for select columns:
                dataGridViewPackages.Columns["PkgStartDate"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridViewPackages.Columns["PkgEndDate"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridViewPackages.Columns["PkgBasePrice"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridViewPackages.Columns["PkgAgencyCommission"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
        }

        /// <summary>
        /// Custom-made method allowing refreshing data in the 'dataGridViewProducts'
        /// </summary>
        private void RefreshDataGridViewProducts()
        {
            dataGridViewProducts.DataSource = null; // setting DataSource as null helps to clear the listbox in the next line
            dataGridViewProducts.Rows.Clear(); // clearing the 'DataGridViewProducts'
            using (TravelExpertsContext db = new TravelExpertsContext()) // creating a new DBContext instance
            {
                //dataGridViewProducts.DataSource = db.Products.ToList(); // displaying data from the DB in the 'DataGridViewProducts'
                // connection string is placed in the 'App.config' file inside this project
                var selectedPackage = context.Packages.Find((int)dataGridViewPackages.SelectedCells[0].Value); // picking the selected package

                // creating a complex LINQ query to gather columns from two different tables joining four different tables
                var productsQuery = from somePackagesProductsSupplier in db.PackagesProductsSuppliers // packagesProductsSuppliers
                                    join somePackage in db.Packages // join packages
                                        on somePackagesProductsSupplier.PackageId equals somePackage.PackageId
                                    join someProductsSupplier in db.ProductsSuppliers // join ProductSuppliers
                                        on somePackagesProductsSupplier.ProductSupplierId equals someProductsSupplier.ProductSupplierId
                                    join someProduct in db.Products // join products
                                        on someProductsSupplier.ProductId equals someProduct.ProductId
                                    join someSupplier in db.Suppliers
                                        on someProductsSupplier.SupplierId equals someSupplier.SupplierId
                                    where somePackage.PackageId == selectedPackage.PackageId
                                    select new
                                    {
                                        somePackage.PkgName,
                                        someProduct.ProdName,
                                        someSupplier.SupName
                                    };
                dataGridViewProducts.DataSource = productsQuery.ToList();

                // renaming the column headers properly:
                dataGridViewProducts.Columns["PkgName"].HeaderText = "Packages";
                dataGridViewProducts.Columns["ProdName"].HeaderText = "Products";
                dataGridViewProducts.Columns["SupName"].HeaderText = "Suppliers";

                // setting desired widths of the displayed columns:
                dataGridViewProducts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill; // auto size the columns to fit all the cell's content

                // styling the column headers row (i.e. the uppermost row)
                dataGridViewProducts.EnableHeadersVisualStyles = false; // enabling manual background color change in the next code row
                dataGridViewProducts.ColumnHeadersDefaultCellStyle.BackColor = Color.Bisque; // setting the desired background color
                dataGridViewProducts.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.Bisque; // to avoid highlighting selected columns
                dataGridViewProducts.ColumnHeadersDefaultCellStyle.ForeColor = Color.Maroon; // setting the same font color as for other rows
                dataGridViewProducts.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; // setting central text alignment
            }
        }

        /// <summary>
        /// Add product to the package
        /// </summary>
        private void buttonAddProduct_Click(object sender, EventArgs e)
        {
            frmAddProductsToPackages secondfrm = new frmAddProductsToPackages(); // add product form
            
            var selectedPackage = context.Packages.Find((int)dataGridViewPackages.SelectedCells[0].Value); // get selected package
            secondfrm.selectedPackage = selectedPackage; // bring selected package to the second form
            DialogResult result = secondfrm.ShowDialog(); // display second form
            
            if(result == DialogResult.OK) // if user pressed add
            {
                PackagesProductsSuppliers newPPS = new PackagesProductsSuppliers(); // create new PPS link

                newPPS.PackageId = selectedPackage.PackageId; // assign packageId based on the product_SupplierID in second form
                newPPS.ProductSupplierId = secondfrm.addProductsSupplierID; // assign productSupplierID
                try
                {
                    using (TravelExpertsContext db = new TravelExpertsContext())
                    {
                        db.PackagesProductsSuppliers.Add(newPPS); // add new PPS link
                        db.SaveChanges(); // save changes
                    }
                }
                catch (Exception ex) //error message
                {
                    MessageBox.Show("Error occured when adding a new product to the package" + ex.Message, ex.GetType().ToString());
                }
                RefreshDataGridViewProducts(); // refresh product grid view
            }
        }
        /// <summary>
        /// Remove selected PackagesProductsSuppliers from the database and updates the display
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonRemoveProduct_Click(object sender, EventArgs e)
        {

            var selectedPackage = context.Packages.Find((int)dataGridViewPackages.SelectedCells[0].Value); // get selected package

            int selecedRowIndex = dataGridViewProducts.SelectedCells[0].RowIndex; // get row index
            DataGridViewRow selectedRow = dataGridViewProducts.Rows[selecedRowIndex]; // get row from selected cell

            //Confirm with the user to make sure they want to delete the supplier from the product
            DialogResult result = MessageBox.Show($"Delete {selectedRow.Cells["ProdName"].Value} supplied by {selectedRow.Cells["SupName"].Value}? ",
            "Confirm Delete", MessageBoxButtons.YesNo,
            MessageBoxIcon.Question);

            if(result == DialogResult.Yes)
            {
                try
                {
                    using (TravelExpertsContext db = new TravelExpertsContext())
                    {
                        // get selected packagesProductsSupplier object
                        var deleteQuery = (from pps in db.PackagesProductsSuppliers

                                           join prodSup in db.ProductsSuppliers // join product_suppliers
                                             on pps.ProductSupplierId equals prodSup.ProductSupplierId

                                           join prod in db.Products // join products
                                             on prodSup.ProductId equals prod.ProductId

                                           join sup in db.Suppliers // join suppliers
                                             on prodSup.SupplierId equals sup.SupplierId

                                           where pps.PackageId == selectedPackage.PackageId &&
                                                 prod.ProdName == selectedRow.Cells["ProdName"].Value.ToString() &&
                                                 sup.SupName == selectedRow.Cells["SupName"].Value.ToString()

                                           select new { pps }).Single();
                        db.Remove(deleteQuery.pps);
                        db.SaveChanges();
                    }
                }
                catch (Exception ex) //error message
                {
                    MessageBox.Show("Error occured when deleting a product from the package" + ex.Message, ex.GetType().ToString());
                }
                RefreshDataGridViewProducts(); // refresh product grid view
            }
        }
    }
}
