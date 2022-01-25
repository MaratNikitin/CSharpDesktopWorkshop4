
namespace Group_1_Travel_Experts
{
    partial class frmAddProductsToPackages
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            this.labelPackages = new System.Windows.Forms.Label();
            this.cboProducts = new System.Windows.Forms.ComboBox();
            this.dgvSuppliers = new System.Windows.Forms.DataGridView();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSuppliers)).BeginInit();
            this.SuspendLayout();
            // 
            // labelPackages
            // 
            this.labelPackages.AutoSize = true;
            this.labelPackages.BackColor = System.Drawing.Color.Transparent;
            this.labelPackages.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelPackages.Location = new System.Drawing.Point(67, 15);
            this.labelPackages.Name = "labelPackages";
            this.labelPackages.Size = new System.Drawing.Size(68, 21);
            this.labelPackages.TabIndex = 15;
            this.labelPackages.Text = "Product";
            // 
            // cboProducts
            // 
            this.cboProducts.BackColor = System.Drawing.Color.Linen;
            this.cboProducts.ForeColor = System.Drawing.Color.Maroon;
            this.cboProducts.FormattingEnabled = true;
            this.cboProducts.Location = new System.Drawing.Point(165, 12);
            this.cboProducts.Name = "cboProducts";
            this.cboProducts.Size = new System.Drawing.Size(235, 29);
            this.cboProducts.TabIndex = 16;
            this.cboProducts.SelectedIndexChanged += new System.EventHandler(this.cboProducts_SelectedIndexChanged);
            // 
            // dgvSuppliers
            // 
            this.dgvSuppliers.AllowUserToOrderColumns = true;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.Bisque;
            this.dgvSuppliers.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvSuppliers.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvSuppliers.BackgroundColor = System.Drawing.Color.Linen;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.Bisque;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSuppliers.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dgvSuppliers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.Linen;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.Maroon;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvSuppliers.DefaultCellStyle = dataGridViewCellStyle8;
            this.dgvSuppliers.Location = new System.Drawing.Point(48, 47);
            this.dgvSuppliers.Name = "dgvSuppliers";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.Bisque;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSuppliers.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.dgvSuppliers.RowHeadersVisible = false;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.Color.PowderBlue;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.Color.Maroon;
            this.dgvSuppliers.RowsDefaultCellStyle = dataGridViewCellStyle10;
            this.dgvSuppliers.RowTemplate.Height = 25;
            this.dgvSuppliers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSuppliers.Size = new System.Drawing.Size(405, 478);
            this.dgvSuppliers.TabIndex = 17;
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.BurlyWood;
            this.btnAdd.Location = new System.Drawing.Point(48, 547);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(136, 37);
            this.btnAdd.TabIndex = 18;
            this.btnAdd.Text = "&Add Product";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.BurlyWood;
            this.btnCancel.Location = new System.Drawing.Point(317, 547);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(136, 37);
            this.btnCancel.TabIndex = 19;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // frmAddProductsToPackages
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Group_1_Travel_Experts.Properties.Resources.MyBackground_;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(497, 630);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.dgvSuppliers);
            this.Controls.Add(this.cboProducts);
            this.Controls.Add(this.labelPackages);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.ForeColor = System.Drawing.Color.Maroon;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmAddProductsToPackages";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmAddProductsToPackages";
            this.Load += new System.EventHandler(this.frmAddProductsToPackages_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSuppliers)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelPackages;
        private System.Windows.Forms.ComboBox cboProducts;
        private System.Windows.Forms.DataGridView dgvSuppliers;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnCancel;
    }
}