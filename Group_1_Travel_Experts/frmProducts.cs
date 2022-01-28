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
       
        //private TravelExpertsContext context = new TravelExpertsContext();
        public frmProducts()
        {
            InitializeComponent();
        }

        private void frmProducts_Load(object sender, EventArgs e)
        {
            //using (TravelExpertsContext db = new TravelExpertsContext())
            //{
                
                //var products = db.Products.Select(p => new
                //{
                //    p.ProductId,
                //    p.ProdName
                   
                //}).ToList();
                //dgvProducts.DataSource = products;
                DisplayProduct(); // DRY - all code with DGV styling should be there
                // format headers
                

                // format alternating rows
                

                // format the columns
                //dgvProducts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

                //dgvProducts.Columns[0].HeaderText = "Product ID";

                //dgvProducts.Columns[1].Width = 200;
                //dgvProducts.Columns[1].HeaderText = "Product Name";

           //}
        }
        private void DisplayProduct()
        {

            dgvProducts.DataSource = null;
            dgvProducts.Columns.Clear();
            try
            {

                using (TravelExpertsContext db = new TravelExpertsContext())
                {
                    var products = db.Products
                        .OrderBy(p => p.ProdName)
                        .Select(p => new { p.ProductId, p.ProdName })
                        .ToList();

                    dgvProducts.DataSource = products;
                    // enable Modify and Delete buttons


                    //var products = db.Products.Select(p => new
                    //{
                    //    p.ProductId,
                    //    p.ProdName

                    //}).ToList();
                    //dgvProducts.DataSource = products;
                    btnModifyProd.Enabled = true;
                    btnDeleteProd.Enabled = true;
                    btnAddProd.Enabled = true;





                    // styling the DataGridView object:
                    dgvProducts.EnableHeadersVisualStyles = false;
                    dgvProducts.ColumnHeadersDefaultCellStyle.BackColor = Color.Bisque; // setting the desired background color
                    dgvProducts.Columns[0].Width = 200;
                    //dgvPructs.Coodlumns[1].Width = 400;
                    dgvProducts.Columns[0].HeaderText = "Product ID";
                    dgvProducts.Columns[1].HeaderText = "Product Name";
                    dgvProducts.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
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

            if (result == DialogResult.OK) // second form has product object with data
            {
                selectedProduct = secondForm.Product;

                using (TravelExpertsContext db = new TravelExpertsContext())
                {
                    try
                    {
                        int newProductId = db.Products.Max(s => s.ProductId) + 1;
                        selectedProduct.ProductId = newProductId;

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
            frmProductsAddUpdate secondForm = new frmProductsAddUpdate();
            secondForm.isAdd = false;
            //default first row selected, otherwise user can pick row from dgv
            
            //secondForm.Product = selectedProduct;
            try
            {
                using (TravelExpertsContext db = new TravelExpertsContext())
                {
                    selectedProduct = db.Products.Find(dgvProducts.SelectedCells[0].Value);
                    secondForm.Product = selectedProduct;
                }
            }
            catch (Exception ex)
            {
                HandleGeneralError(ex);
            }

            DialogResult result = secondForm.ShowDialog();

            if (result == DialogResult.OK) // second form has customer with new data
            {
                try
                {
                    using (TravelExpertsContext db = new TravelExpertsContext())
                    {
                        
                        db.Update(selectedProduct);//selected row is updated
                        db.SaveChanges();
                        DisplayProduct();
                        // need to have object in the current  context
                        //selectedProduct= db.Products.Find(secondForm.product.ProductCode);
                        //selectedProduct = db.Products.Find((string)dgvProducts.SelectedCells[0].Value);
                        
                        // copy data from customer on the second form
                        //selectedProduct.ProductId = secondForm.Product.ProductId;
                        //selectedProduct.ProdName = secondForm.Product.ProdName;
                        //db.Products.Remove(selectedProduct);
                        //db.SaveChanges(true);
                        //selectedSupplier = db.Suppliers.Find(dataGridViewSuppliers.SelectedCells[0].Value); // the selected row from DataGridView is found in the DB
                        //secondForm.supplier = selectedSupplier;

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
            using TravelExpertsContext db = new TravelExpertsContext();
            selectedProduct = db.Products.Find(dgvProducts.SelectedCells[0].Value);//user picks the row that will be deleted
            //DialogResult result = MessageBox.Show($"Are you sure you want to delete this entry?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
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

        private void btnCancelProd_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //private void dgvProducts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        //{
        //    DisplayProduct();
        //}

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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ex"></param>
        private void HandleGeneralError(Exception ex)
        {
            MessageBox.Show(ex.Message, ex.GetType().ToString());
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ex"></param>
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
