using Group_1_Travel_Experts.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Group_1_Travel_Experts
{
    public partial class frmProductsAddUpdate : Form
    {
        // public data - main form needs access to it
        public bool isAdd { get; set; } // true - Add, false - Modify
        public Products Product { get; set; } // current product
        public frmProductsAddUpdate()
        {
            InitializeComponent();
        }

        private void frmProductsAddUpdate_Load(object sender, EventArgs e)
        {
            using (TravelExpertsContext db = new TravelExpertsContext())
                if (this.isAdd)
                {
                    this.Text = "Add Product";
                    txtProductId.ReadOnly = false;
                }
                else
                {
                    this.Text = "Modify Product";
                    txtProductId.ReadOnly = true;
                    DisplayProduct();

                }
        }

        private void btnOKProduct_Click(object sender, EventArgs e)
        {
            if (IsValidData()) 
            {
            if (isAdd) // need to create product object
            {
                this.Product = new Products();//instantiated product object from class project
            }

            LoadProductData();
            this.DialogResult = DialogResult.OK; // closes the form
            }
        }

        private void btnCancelProduct_Click(object sender, EventArgs e)
        {
            this.Close(); //closes the current form
        }

        private void DisplayProduct()
        {


            txtProductId.Text = Product.ProductId.ToString();
            txtProdName.Text = Product.ProdName;
            
        }

        private void LoadProductData()
        {
            Product.ProductId = Convert.ToInt32(txtProductId.Text);
            Product.ProdName = txtProdName.Text;
            

        }

        private bool IsValidData()
        {
            bool success = true;
            string errorMessage = "";

            errorMessage += Validator.IsPresent(txtProductId.Text.ToString(), txtProductId.Tag.ToString());
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
