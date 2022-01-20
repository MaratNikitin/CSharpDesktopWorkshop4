using Group_1_Travel_Experts.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Group_1_Travel_Experts
{
    public partial class frmProductsSuppliers : Form
    {
        public Products selectedProd = null;
        public frmProductsSuppliers()
        {
            InitializeComponent();
        }

        private void frmProductsSuppliers_Load(object sender, EventArgs e)
        {
            try
            {
                using (TravelExpertsContext db = new TravelExpertsContext())
                {
                   cboProducts.DataSource = db.Products.OrderBy(p => p.ProdName).Select(p => p.ProdName).ToList();
                   cboProducts.DisplayMember = "ProdName";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error when displaying data. {ex.Message}, {ex.GetType()}");
            }
        }

        private void cboProducts_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (TravelExpertsContext db = new TravelExpertsContext())
            {

                dgvSuppliers.DataSource = db.ProductsSuppliers
                                     .Join(db.Suppliers, // join suppliers table
                                           productSupplier => productSupplier.SupplierId, // Product_Supplier SupplierId
                                           supplier => supplier.SupplierId, // Supplier SupplierId

                                           // get all data from suppliers and Product_Supplier table
                                           (productSupplier, supplier) => new { supplier, productSupplier })

                                     .Join(db.Products, // join products table
                                           newProductSupplier => newProductSupplier.productSupplier.ProductId, // Product_Supplier ProductId
                                           product => product.ProductId, // Product ProductId

                                           //get all data from Product_Suppliers and Products table
                                           (newProductSupplier, product) => new { product, newProductSupplier })

                                     //get all the suppliers that supplies the product with the same productName in the combo box
                                     .Where(m => m.product.ProdName == cboProducts.SelectedValue.ToString())

                                     .Select(m => new {m.newProductSupplier.supplier.SupName }).ToList(); // get supplier name
            }
            dgvSuppliers.Columns["SupName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; // Fills the entire data grid view
            dgvSuppliers.Columns["SupName"].HeaderText = "Suppliers";
        }
    }
}
