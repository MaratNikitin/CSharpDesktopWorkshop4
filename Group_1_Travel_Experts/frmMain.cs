using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Group_1_Travel_Experts.Models;

/*
 * This app helps doing CRUD operations with the select tables of the 'TravelExperts' database.
 * It is the main form of the application where a user selects which of the database's table to work with
 * Author: Marat Nikitin
 * SAIT, OOSD course, CPRG-207 - Threaded Project (Part 2), Workshop #4 - C#.NET, Group 1
 * When: January-February 2022
 */


namespace Group_1_Travel_Experts
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent(); // initializing the form's content
        }

        // when the 'Open' button is clicked:
        private void buttonOpen_Click(object sender, EventArgs e)
        {
            if (radioButtonPackages.Checked) // 'Packages' option is chosen
            {
                var packagesInstance = new frmPackages { }; // an instance of the 'Packages' form is created
                packagesInstance.Show(); // 'frmPackages' is opened
            }
            else if (radioButtonProducts.Checked) // 'Products' option is chosen
            {
                var productsInstance = new frmProducts { }; // an instance of the 'Products' form is created
                productsInstance.Show(); // 'frmProducts' is opened
            }
            else if (radioButtonSuppliers.Checked) // 'Suppliers' option is chosen
            {
                var suppliersInstance = new frmSuppliers { }; // an instance of the 'Suppliers' form is created
                suppliersInstance.Show(); // 'frmSuppliers' is opened
            }
            else if (radioButtonProductsSuppliers.Checked) // 'Products + Suppliers' option is chosen
            {
                var productsSuppliersInstance = new frmProductsSuppliers { }; // an instance of the 'Products + Suppliers' form is created
                productsSuppliersInstance.Show(); // 'frmProductsSuppliers' is opened
            }
        }

        // when the 'Exit' button is clicked
        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Close(); // it closes the Main window which leads to closing the app
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void frmMain_Load(object sender, EventArgs e)
        {

        }

        private void groupBoxTables_Enter(object sender, EventArgs e)
        {

        }

        private void labelWelcome_Click(object sender, EventArgs e)
        {

        }
    }
}
