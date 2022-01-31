using Group_1_Travel_Experts.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;

/*
 * This app helps doing CRUD operations with the select tables of the 'TravelExperts' database.
 * This form is used for displaying a list of packages in a list box and helps to add, modify or delete packages
 * Author: Richard Cook
 * SAIT, OOSD course, CPRG-207 - Threaded Project (Part 2), Workshop #4 - C#.NET, Group 1
 * When: January-February 2022
 */

namespace Group_1_Travel_Experts
{
    public partial class frmProducts : Form
    {

        Products selectedProduct = null; // current customer
       
        
        public frmProducts()
        {
            InitializeComponent();
        }

        private void frmProducts_Load(object sender, EventArgs e)
        {
            
                DisplayProduct(); //using this method to generate the data for the data grid view
        }
        //method queries the data from the travel experts database and displays it.
        private void DisplayProduct()
        {
            //code below clears the data grid view data 
            dgvProducts.DataSource = null;
            dgvProducts.Columns.Clear();
            try
            {
                //accessing the travel experts database
                using (TravelExpertsContext db = new TravelExpertsContext())
                {
                    //linq query to produce the data
                    var products = db.Products
                        .OrderBy(p => p.ProdName)
                        .Select(p => new { p.ProdName })
                        .ToList();
                    //p.ProductId,
                    //linq query data gets assigned
                    dgvProducts.DataSource = products;
                    // enable Modify and Delete buttons

                    btnModifyProd.Enabled = true;
                    btnDeleteProd.Enabled = true;
                    btnAddProd.Enabled = true;

                    // styling the DataGridView object:
                    dgvProducts.EnableHeadersVisualStyles = false;
                    dgvProducts.ColumnHeadersDefaultCellStyle.BackColor = Color.Bisque; // setting the desired background color
                    
                    dgvProducts.Columns[0].HeaderText = "Product Name";
                    dgvProducts.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
            }
            catch (Exception ex)
            {
                HandleGeneralError(ex);
            }

        }
        
        //user clicks the Add button
        private void btnAddProd_Click(object sender, EventArgs e)
        {
            frmProductsAddUpdate secondForm = new frmProductsAddUpdate();//creating the instance of the product form
            secondForm.isAdd = true;//secondform instance is true when user adds a product
            secondForm.Product = null;//otherwise no change

            
            DialogResult result = secondForm.ShowDialog(); // display second form modal

            if (result == DialogResult.OK) 
            {
                
                selectedProduct = secondForm.Product; //product data is loaded into the form
                
                //accessing the travel experts database
                using (TravelExpertsContext db = new TravelExpertsContext())
                {
                    try
                    {
                        
                        
                        //This code updates the database with the new entry
                        db.Products.Add(selectedProduct);
                        db.SaveChanges();
                        dgvProducts.Columns.Clear();
                        MessageBox.Show("1 row was added to the Products table");
                        DisplayProduct();
                    }



                    catch (DbUpdateException ex)
                    {
                        this.HandleDatabaseError(ex);
                    }
                    catch (Exception ex)
                    {
                        HandleGeneralError(ex);
                    }
                }

            }   
            
        }

        private void btnModifyProd_Click(object sender, EventArgs e)
        {
            frmProductsAddUpdate secondForm = new frmProductsAddUpdate();  //new instance of the frm is created
            secondForm.isAdd = false; //not adding data, modifying it
            
           
            try
            {
                //accessing the travel experts database
                using (TravelExpertsContext db = new TravelExpertsContext())
                {
                    selectedProduct = db.Products.Find(dgvProducts.SelectedCells[0].Value);//select the value to be modified
                    secondForm.Product = selectedProduct;//assign selected value to the form
                }
            }
            catch (Exception ex)
            {
                HandleGeneralError(ex);
            }

            DialogResult result = secondForm.ShowDialog();//form is generated

            if (result == DialogResult.OK) // second form has customer with new data
            {
                try
                {
                    //accessing the travel experts database
                    using (TravelExpertsContext db = new TravelExpertsContext())
                    {
                        
                        db.Update(selectedProduct);//selected row is updated
                        db.SaveChanges();
                        DisplayProduct();
                        
                    }
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    HandleConcurrencyError(ex);
                }
                catch (DbUpdateException ex)
                {
                    this.HandleDatabaseError(ex);
                }
                catch (Exception ex)
                {
                    HandleGeneralError(ex);
                }
            }
        }

        private void btnDeleteProd_Click(object sender, EventArgs e)
        {
            //accessing the travel experts database
            using TravelExpertsContext db = new TravelExpertsContext();
            selectedProduct = db.Products.Find(dgvProducts.SelectedCells[0].Value);//user picks the row that will be deleted
            
            DialogResult result = MessageBox.Show("Delete " + selectedProduct.ProdName + "?",
                        "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {

                try
                {
                    db.Products.Remove(selectedProduct); // row deleted
                    db.SaveChanges(); // changes saved
                    MessageBox.Show("1 row was deleted", "Good Job!");
                    DisplayProduct();
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    HandleConcurrencyError(ex);
                }
                catch (DbUpdateException ex)
                {
                    this.HandleDatabaseError(ex);
                }
                catch (Exception ex)
                {
                    HandleGeneralError(ex);

                }
            }
        }
        //User selects Cancel
        private void btnCancelProd_Click(object sender, EventArgs e)
        {
            this.Close();
        }

      
        /// <summary>
        /// Below are handling error methods for the catch exceptions
        /// </summary>
        /// <param name="ex"></param>

        private void HandleDatabaseError(DbUpdateException ex)
        {
            string errorMessage = "";
            SqlException sqlException = (SqlException)ex.InnerException;
            foreach (SqlError error in sqlException.Errors)
            {
                errorMessage += "ERROR CODE:  " + error.Number + " " +
                                error.Message + "\n";
            }
            MessageBox.Show(errorMessage);
        }
      
        private void HandleGeneralError(Exception ex)
        {
            MessageBox.Show(ex.Message, ex.GetType().ToString());
        }
       
        private void HandleConcurrencyError(DbUpdateConcurrencyException ex)
        {
            using TravelExpertsContext db = new TravelExpertsContext();
            ex.Entries.Single().Reload();

            var state = db.Entry(selectedProduct).State;
            if (state == EntityState.Detached)
            {
                MessageBox.Show("Another user has deleted that product.",
                    "Concurrency Error");
            }
            else
            {
                string message = "Another user has updated that product.\n" +
                    "The current database values will be displayed.";
                MessageBox.Show(message, "Concurrency Error");
            }

        }
    }
}
