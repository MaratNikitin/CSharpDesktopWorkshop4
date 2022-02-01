using Group_1_Travel_Experts.Models;
using System;
using System.Windows.Forms;
using System.Globalization;

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

        //form is loaded
        private void frmProductsAddUpdate_Load(object sender, EventArgs e)
        {

            if (isAdd)
            {
                this.Text = "Add Product"; //form is labelled add product if add button is pressed

            }
            else
            {
                this.Text = "Modify Product"; //form is labelled modify if modify button in main form is pressed




                try
                {
                    using (TravelExpertsContext db = new TravelExpertsContext()) //access the database to get the data
                    {
                        txtProdName.Text = Product.ProdName; //selected data is displayed
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error while retrieving product data: " + ex.Message, e.GetType().ToString());
                }

            }
        }
        //ok button is pressed
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

                // set the product name to title case
                TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;
                Product.ProdName = textInfo.ToTitleCase(txtProdName.Text.ToString().ToLower());

                this.DialogResult = DialogResult.OK; // closes the form
            }
        }

        //cancel button is pressed
        private void btnCancelProduct_Click(object sender, EventArgs e)
        {
            this.Close(); //closes the current form
        }

        //data is loaded into the product object to be inserted into the main form
        private void LoadProductData()
        {

            Product.ProdName = txtProdName.Text; //loads data to be put into the main data grid view

        }

        //method using validator
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
