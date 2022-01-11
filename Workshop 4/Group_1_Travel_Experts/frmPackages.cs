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
                dataGridViewPackages.Columns["PkgAgencyCommission"].Width = 120;

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
                var productsQuery = from somePackage in db.Packages
                                    where somePackage.PackageId == selectedPackage.PackageId
                                    join somePackagesProductsSupplier in db.PackagesProductsSuppliers
                                        on somePackage.PackageId equals somePackagesProductsSupplier.PackageId
                                    join someProductsSupplier in db.ProductsSuppliers
                                        on somePackagesProductsSupplier.ProductSupplierId equals someProductsSupplier.ProductSupplierId
                                    join someProduct in db.Products
                                        on someProductsSupplier.ProductId equals someProduct.ProductId
                                    select new
                                    {
                                        somePackage.PackageId,
                                        somePackage.PkgName,
                                        someProduct.ProductId,
                                        someProduct.ProdName,                                       
                                        someProductsSupplier.ProductSupplierId,
                                        someProductsSupplier.SupplierId
                                    };
                dataGridViewProducts.DataSource = productsQuery.ToList();

                // renaming the column headers properly:
                dataGridViewProducts.Columns["PackageId"].HeaderText = "Package ID";
                dataGridViewProducts.Columns["PkgName"].HeaderText = "Package Name";
                dataGridViewProducts.Columns["ProductId"].HeaderText = "Product ID";
                dataGridViewProducts.Columns["ProdName"].HeaderText = "Product Name";
                dataGridViewProducts.Columns["ProductSupplierId"].HeaderText = "Product Supplier ID";
                dataGridViewProducts.Columns["SupplierId"].HeaderText = "Supplier ID";

                // setting desired widths of the displayed columns:
                dataGridViewProducts.Columns["PackageId"].Width = 120; // width is set at 120px
                dataGridViewProducts.Columns["PkgName"].Width = 200;
                dataGridViewProducts.Columns["ProductId"].Width = 120;
                dataGridViewProducts.Columns["ProdName"].Width = 200;
                dataGridViewProducts.Columns["ProductSupplierId"].Width = 120;
                dataGridViewProducts.Columns["SupplierId"].Width = 120;

                // styling the column headers row (i.e. the uppermost row)
                dataGridViewProducts.EnableHeadersVisualStyles = false; // enabling manual background color change in the next code row
                dataGridViewProducts.ColumnHeadersDefaultCellStyle.BackColor = Color.Bisque; // setting the desired background color
                dataGridViewProducts.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.Bisque; // to avoid highlighting selected columns
                dataGridViewProducts.ColumnHeadersDefaultCellStyle.ForeColor = Color.Maroon; // setting the same font color as for other rows
                dataGridViewProducts.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; // setting central text alignment

                // setting central text alignment for select columns:
                dataGridViewProducts.Columns["PackageId"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridViewProducts.Columns["ProductId"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridViewProducts.Columns["ProductSupplierId"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridViewProducts.Columns["SupplierId"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
        }

        private void buttonAddProduct_Click(object sender, EventArgs e)
        {

        }

        private void buttonRemoveProduct_Click(object sender, EventArgs e)
        {

        }

        private void buttonModifyProduct_Click(object sender, EventArgs e)
        {

        }
    }
}
