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
        //private Product product; 
        private TravelExpertsContext context = new TravelExpertsContext();
        public frmProducts()
        {
            InitializeComponent();
        }

        private void frmProducts_Load(object sender, EventArgs e)
        {
            using (TravelExpertsContext db = new TravelExpertsContext())
            {
                
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

            }
        }
        private void DisplayProduct()
        {

            dgvProducts.DataSource = null;
            dgvProducts.Columns.Clear();
            using (TravelExpertsContext db = new TravelExpertsContext())
            {
                var products = db.Products
                    .OrderBy(p => p.ProductId)
                    .Select(p => new { p.ProductId, p.ProdName })
                    .ToList();

                dgvProducts.DataSource = products.ToList();
                // enable Modify and Delete buttons
                btnModifyProd.Enabled = true;
                btnDeleteProd.Enabled = true;

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
        
        //user clicks the Add button
             
        private void btnAddProd_Click(object sender, EventArgs e)
        {
            frmProductsAddUpdate secondForm = new frmProductsAddUpdate();
            secondForm.isAdd = true;
            secondForm.Product = null;

            DialogResult result = secondForm.ShowDialog(); // display second form modal

            if (result == DialogResult.OK) // second form has product object with data
            {
                selectedProduct = secondForm.Product;

                // add it to the database table using EF
                try
                {
                    using (TravelExpertsContext db = new TravelExpertsContext())
                    {
                        db.Products.Add(selectedProduct);
                        db.SaveChanges();
                        MessageBox.Show("1 row was added to the Products table");
                        this.DisplayProduct();
                    }

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

        private void btnModifyProd_Click(object sender, EventArgs e)
        {
            //default first row selected, otherwise user can pick row from dgv
            var selectedProduct = context.Products.Find(dgvProducts.SelectedCells[0].Value);
            var modifysecondForm = new frmProductsAddUpdate
            {
                isAdd = false,
                Product = selectedProduct
            };
            modifysecondForm.isAdd = false; // it's Modify
            modifysecondForm.Product = selectedProduct;

            DialogResult result = modifysecondForm.ShowDialog();

            if (result == DialogResult.OK) // second form has customer with new data
            {
                try
                {
                    using (TravelExpertsContext db = new TravelExpertsContext())
                    {

                        db.Products.Update(selectedProduct);//selected row is updated
                        db.SaveChanges();
                        this.DisplayProduct();
                        // need to have object in the current  context
                        //selectedProduct= db.Products.Find(secondForm.product.ProductCode);
                        selectedProduct = db.Products.Find((string)dgvProducts.SelectedCells[0].Value);
                        // copy data from customer on the second form
                        selectedProduct.ProductId = modifysecondForm.Product.ProductId;
                        selectedProduct.ProdName = modifysecondForm.Product.ProdName;
                        db.Products.Remove(selectedProduct);
                        db.SaveChanges(true);

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
            var selectedProduct = context.Products.Find(dgvProducts.SelectedCells[0].Value);//user picks the row that will be deleted
            //DialogResult result = MessageBox.Show($"Are you sure you want to delete this entry?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            DialogResult result = MessageBox.Show("Delete " + selectedProduct.ProdName + "?",
                        "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {

                try
                {
                    context.Products.Remove(selectedProduct); // row deleted
                    context.SaveChanges(); // changes saved
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

        private void dgvProducts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DisplayProduct();
        }

        private void HandleDatabaseError(DbUpdateException ex)
        {
            string errorMessage = "";
            var sqlException = (SqlException)ex.InnerException;
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
            ex.Entries.Single().Reload();

            var state = context.Entry(selectedProduct).State;
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
