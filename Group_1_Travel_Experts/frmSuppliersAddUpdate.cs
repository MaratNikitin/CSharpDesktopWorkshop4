using Group_1_Travel_Experts.Models;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

/*
 * This app allows users to perform CRUD operations on select tables in the TravelExperts database
 * This form allow users to add a new supplier name, or modify an existing supplier name
 * Author: Scott Holmes
 * SAIT, OOSD course, CPRG-207 - Threaded Project (Part 2), Workshop #4 - C#.NET, Group 1
 * When: January-February 2022
 */

namespace Group_1_Travel_Experts
{
    public partial class frmSuppliersAddUpdate : Form
    {
        public bool isAdd; // for the Add and modify buttons where true = Add, false = Modify 
        public Suppliers supplier; // the product to be modified
        public List<string> supplierNames; // list of suppliers that are already in the database
        private string initialSupName; // initial supplier that is being modified
        public frmSuppliersAddUpdate()
        {
            InitializeComponent();
        }

        // When the form opens
        private void frmSuppliersAddUpdate_Load(object sender, EventArgs e)
        {
            if (isAdd) // Clicked add
            {
                this.Text = "Add Supplier"; // change the form title
            }
            else // Clicked modify
            {
                this.Text = "Modify Supplier"; // change the form title

                // get the supplier data
                try
                {
                    using (TravelExpertsContext db = new TravelExpertsContext())
                    {
                        // Display the data of the selected product
                        textBoxSupplierName.Text = supplier.SupName;
                        initialSupName = supplier.SupName;
                    }
                }
                // catch any exceptions
                catch (Exception ex)
                {
                    MessageBox.Show("Error while retrieving product data: " + ex.Message, e.GetType().ToString());
                }
            }
        }

        // when the user clicks the accept button
        private void buttonAccept_Click(object sender, EventArgs e)
        {
            // need to validate the form data
            if (Validator.IsTextPresent(textBoxSupplierName))
            {
                if(isAdd && Validator.isUnique(supplierNames, textBoxSupplierName.Text)) // if Adding, create an new supplier instance 
                {
                    supplier = new Suppliers();
                    // set the product object values to the form data values
                    supplier.SupName = textBoxSupplierName.Text.ToUpper();
                    this.DialogResult = DialogResult.OK; // close the form
                }
                else if(isAdd == false && Validator.isUnique(supplierNames, textBoxSupplierName.Text)) // modifying
                {
                    supplier.SupName = textBoxSupplierName.Text.ToUpper();
                    this.DialogResult = DialogResult.OK; // close the form
                }
                // The supplier already exists when trying to add
                else if (isAdd)
                {
                    MessageBox.Show("Supplier already exists");
                    textBoxSupplierName.Clear();
                }
                // The supplier already exists when trying to add
                else if (isAdd == false && textBoxSupplierName.Text.ToUpper() != initialSupName)
                {
                    MessageBox.Show("Supplier already exists");
                    textBoxSupplierName.Text = initialSupName;
                }
                // No changes were made when modifying
                else
                {
                    MessageBox.Show("No changes to the selected supplier");
                    this.DialogResult = DialogResult.OK; // close the form
                }
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
