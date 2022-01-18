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
                   cboProducts.DataSource = db.Products.OrderBy(p => p.ProductId).ToList();
                   cboProducts.DisplayMember = "ProdName";
                   cboProducts.ValueMember = "ProductId";
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
                lstSuppliers.DataSource = db.ProductsSuppliers.Where(ps => ps.ProductId == cboProducts.SelectedIndex + 1)
                                     .Join(db.Suppliers, 
                                           ps => ps.SupplierId,
                                           s => s.SupplierId,
                                           (ps, s) => new { s.SupName }).ToList();
                lstSuppliers.DisplayMember = "SupName";
            }
        }
    }
}
