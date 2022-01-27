using Group_1_Travel_Experts.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

/*
 * This app helps doing CRUD operations with the select tables of the 'TravelExperts' database.
 * This form is used for displaying a list of packages in a list box and helps to add, modify or delete packages
 * Author: Richard Cook
 * SAIT, OOSD course, CPRG-207 - Threaded Project (Part 2), Workshop #4 - C#.NET, Group 1
 * When: January-February 2022
 */

namespace Group_1_Travel_Experts
{
    public partial class frmProductsAddUpdate : Form
    {
        // public data - main form needs access to it
        public bool isAdd; // true - Add, false - Modify
        public Products Product; // current product
        public frmProductsAddUpdate()
        {
            InitializeComponent();
        }

        private void frmProductsAddUpdate_Load(object sender, EventArgs e)
        {

            if (isAdd)
            {
                this.Text = "Add Product";

            }
            else
            {
                this.Text = "Modify Product";




                try
                {
                    using (TravelExpertsContext db = new TravelExpertsContext())
                    {
                        txtProdName.Text = Product.ProdName;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error while retrieving product data: " + ex.Message, e.GetType().ToString());
                }

            }
        }

        private void btnOKProduct_Click(object sender, EventArgs e)
        {
            if (IsValidData()) 
            {
                if (isAdd) // need to create product object
                {
                Product = new Products();//instantiated product object from class project
                }
                LoadProductData();
                //LoadProductData();
                this.DialogResult = DialogResult.OK; // closes the form
            }
        }

        private void btnCancelProduct_Click(object sender, EventArgs e)
        {
            this.Close(); //closes the current form
        }

        //private void DisplayProduct()
        //{

            
        //    // txtProductId.Text = Product.ProductId.ToString();
        //    txtProdName.Text = Product.ProdName;

        //}

        private void LoadProductData()
        {


            //Product.ProductId = Convert.ToInt32(txtProductId.Text);
            Product.ProdName = txtProdName.Text.ToUpper();

        }

        private bool IsValidData()
        {
            bool success = true;
            string errorMessage = "";

            //errorMessage += Validator.IsPresent(txtProductId.Text.ToString(), txtProductId.Tag.ToString());
            errorMessage += Validator.IsPresent(txtProdName.Text, txtProdName.Tag.ToString());
            errorMessage += Validator.IsWithinAllowedRangeOfCharacters(txtProdName.Text, txtProdName.Tag.ToString(), 50);
            


            if (errorMessage != "")
            {
                success = false;
                MessageBox.Show(errorMessage, "Entry Error");
            }
            return success;
        }
    }
}
