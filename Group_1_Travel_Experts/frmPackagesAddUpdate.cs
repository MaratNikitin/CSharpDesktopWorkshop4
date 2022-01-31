using System;
using System.Windows.Forms;
using Group_1_Travel_Experts.Models;

/*
 * This app helps doing CRUD operations with the select tables of the 'TravelExperts' database.
 * This form is used for adding or modifying packages in the 'Packages' table of the database
 * It is opened as a modal form from the frmPackages parent form by clicking 'Add' or 'Modify' buttons
 * Author: Marat Nikitin
 * SAIT, OOSD course, CPRG-207 - Threaded Project (Part 2), Workshop #4 - C#.NET, Group 1
 * When: January-February 2022
 */

namespace Group_1_Travel_Experts
{
    public partial class frmPackagesAddUpdate : Form
    {
        public Packages Package { get; set; } // represents an instance of a Packages class, used for transferring data here from the Packages form
        public bool AddPackage { get; set; } // this parameter saves the "true" value when the "Add" button is pressed in the
                                             // 'Packages' form; saves the "false" value when the "Modify" button was pressed there
        public frmPackagesAddUpdate()
        {
            InitializeComponent(); // initializing the form's content
        }

        // when the frmPackagesAddUpdate (modal) form loads (which happens after clicking "Add" or "Modify" button of the main form)
        private void frmPackagesAddUpdate_Load(object sender, EventArgs e)
        {
            if (this.AddPackage == true) // it means that the "Add" button of the main form was clicked
            {
                this.Text = "Add Package"; // that text is displayed at the top of the form
            }
            else // it means that the "Modify" button of the main form was clicked
            {
                this.Text = "Modify Package"; // that text is displayed at the top of this form
                DisplaySelectedPackage(); // contents of a row selected in the DataGridView before pressing
                                          //  the "Modify" button are displayed in this form               
            }
        }

        // when the "Ok" button was clicked
        private void buttonOk_Click(object sender, EventArgs e)
        {
            if (IsValidData()) // it means that all the data validation criteria are met
            {
                if (this.AddPackage == true) // It means that the "Add" option was chosen
                {
                    this.Package = new Packages(); // a new instance of the Packages class is created
                }
                LoadPackagesData(); // it's a custom-made function described below
                this.DialogResult = DialogResult.OK; // it's used in the 'Packages' form
            }
        }

        // when the cancel button is clicked
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close(); // the Second (modal) form closes
        }

        /// <summary>
        /// Custom-made method saving data from the textboxes inside the 'Package' instance of a 'Packages' class
        /// </summary>
        private void LoadPackagesData()
        {
            Package.PkgName = textBoxPackageName.Text; // 'Package Name' value is retrieved using data entered in the appropriate textbox
            Package.PkgStartDate = Convert.ToDateTime(textBoxPackageStartDate.Text); // 'Package Start Date' value is retrieved from the appropriate textbox
            Package.PkgEndDate = Convert.ToDateTime(textBoxPackageEndDate.Text); // 'Package End Date' value is retrieved from the appropriate textbox
            Package.PkgDesc = textBoxDescription.Text; // 'Package NameDescription' is retrieved using data entered in the appropriate textbox
            Package.PkgBasePrice = Convert.ToDecimal(textBoxBasePrice.Text); // 'Package Base Price' is retrieved using data entered in the appropriate textbox
            Package.PkgAgencyCommission = Convert.ToDecimal(textBoxAgencyCommission.Text); // 'Package Agency Commission' is retrieved using data entered in the appropriate textbox           
        }

        /// <summary>
        /// This custom-made method validates data entered in the textboxes of the Second (modal) form
        /// </summary>
        /// <returns>List of validation error messages</returns>
        private bool IsValidData()
        {
            bool success = true; // not guilty until proven otherwise - this parameter stays true when validation is successful
            string errorMessage = ""; // beginning from a blank slate

            // checking if all the textboxes contain at least some data:
            errorMessage += Validator.IsPresent(textBoxPackageName.Text, textBoxPackageName.Tag.ToString());
            errorMessage += Validator.IsPresent(textBoxPackageStartDate.Text, textBoxPackageStartDate.Tag.ToString());
            errorMessage += Validator.IsPresent(textBoxPackageEndDate.Text, textBoxPackageEndDate.Tag.ToString());
            errorMessage += Validator.IsPresent(textBoxDescription.Text, textBoxDescription.Tag.ToString());
            //errorMessage += Validator.IsPresent(textBoxBasePrice.Text, textBoxBasePrice.Tag.ToString());
            //errorMessage += Validator.IsPresent(textBoxAgencyCommission.Text, textBoxAgencyCommission.Tag.ToString());
                     
            // checking if the textboxes for base price and agency commission contain a decimal number:
            errorMessage += Validator.IsPositiveDecimal(textBoxBasePrice.Text, textBoxBasePrice.Tag.ToString());
            errorMessage += Validator.IsPositiveDecimal(textBoxAgencyCommission.Text, textBoxAgencyCommission.Tag.ToString());

            // checking if the textboxes for package start and end date contain valid date values:
            errorMessage += Validator.IsValidDate(textBoxPackageStartDate.Text, textBoxPackageStartDate.Tag.ToString());
            errorMessage += Validator.IsValidDate(textBoxPackageEndDate.Text, textBoxPackageEndDate.Tag.ToString());

            // checking if the numbers of characters in the textboxes do not exceed the maximum allowed values set in the database:
            errorMessage += Validator.IsWithinAllowedRangeOfCharacters(textBoxPackageName.Text, textBoxPackageName.Tag.ToString(), 50);
            errorMessage += Validator.IsWithinAllowedRangeOfCharacters(textBoxDescription.Text, textBoxDescription.Tag.ToString(), 50);

            // checking if the Package Agency Comission is less than Package Base Price:
            errorMessage += Validator.IsAdequateAgencyCommission(textBoxBasePrice.Text, textBoxAgencyCommission.Text);

            // checking if a Package End Date is later than Package End Date:
            errorMessage += Validator.PackageEndDateIsLaterThanStartDate(textBoxPackageStartDate.Text, textBoxPackageEndDate.Text);

            if (errorMessage != "") // it means that at least one validation criterion was not met
            {
                success = false; // it's a fail
                MessageBox.Show(errorMessage, "Entry Error", MessageBoxButtons.OK, MessageBoxIcon.Warning); // precious feedback to a user listing all the validation failures
            }
            return success; // "true" value of the "success" if validation passed and "false" if validation failed
        }

        /// <summary>
        /// Custom-made method populating textboxes of the Second form for their further update
        /// </summary>
        private void DisplaySelectedPackage()
        {
            textBoxPackageName.Text = Package.PkgName; // selected row's 'Package Name' value is displayed in the appropriate text box of this modal form
            textBoxPackageStartDate.Text = Package.PkgStartDate.Value.ToString("yyyy-MM-dd"); // selected row's 'Package Start Date' value is displayed in the appropriate text box of this modal form
            textBoxPackageEndDate.Text = Package.PkgEndDate.Value.ToString("yyyy-MM-dd"); // selected row's 'Package End Date' value is displayed in the appropriate text box of this modal form
            textBoxDescription.Text = Package.PkgDesc; // selected row's 'Package Description' value is displayed in the appropriate text box of this modal form 
            textBoxBasePrice.Text = Package.PkgBasePrice.ToString("n2"); // selected row's 'Package Base Price' value is displayed in the appropriate text box of this modal form
            textBoxAgencyCommission.Text = Package.PkgAgencyCommission.Value.ToString("n2"); // selected row's 'Agency Commission' value is displayed in the appropriate text box of this modal form            
        }

        // when the "Cancel" button is clicked
        private void buttonCancel_Click_1(object sender, EventArgs e)
        {
            this.Close(); // the modal form closes but the app goes on
        }
    }
}
