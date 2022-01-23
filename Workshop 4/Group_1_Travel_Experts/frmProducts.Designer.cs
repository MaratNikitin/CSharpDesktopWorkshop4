
namespace Group_1_Travel_Experts
{
    partial class frmProducts
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmProducts));
            this.dgvProducts = new System.Windows.Forms.DataGridView();
            this.btnDeleteProd = new System.Windows.Forms.Button();
            this.btnCancelProd = new System.Windows.Forms.Button();
            this.btnAddProd = new System.Windows.Forms.Button();
            this.btnModifyProd = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvProducts
            // 
            this.dgvProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProducts.Location = new System.Drawing.Point(40, 71);
            this.dgvProducts.Name = "dgvProducts";
            this.dgvProducts.RowHeadersWidth = 51;
            this.dgvProducts.RowTemplate.Height = 29;
            this.dgvProducts.Size = new System.Drawing.Size(422, 210);
            this.dgvProducts.TabIndex = 0;
            this.dgvProducts.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProducts_CellContentClick);
            // 
            // btnDeleteProd
            // 
            this.btnDeleteProd.Location = new System.Drawing.Point(484, 175);
            this.btnDeleteProd.Name = "btnDeleteProd";
            this.btnDeleteProd.Size = new System.Drawing.Size(92, 45);
            this.btnDeleteProd.TabIndex = 1;
            this.btnDeleteProd.Text = "&Delete";
            this.btnDeleteProd.UseVisualStyleBackColor = true;
            this.btnDeleteProd.Click += new System.EventHandler(this.btnDeleteProd_Click);
            // 
            // btnCancelProd
            // 
            this.btnCancelProd.Location = new System.Drawing.Point(484, 236);
            this.btnCancelProd.Name = "btnCancelProd";
            this.btnCancelProd.Size = new System.Drawing.Size(92, 45);
            this.btnCancelProd.TabIndex = 2;
            this.btnCancelProd.Text = "&Cancel";
            this.btnCancelProd.UseVisualStyleBackColor = true;
            this.btnCancelProd.Click += new System.EventHandler(this.btnCancelProd_Click);
            // 
            // btnAddProd
            // 
            this.btnAddProd.Location = new System.Drawing.Point(484, 71);
            this.btnAddProd.Name = "btnAddProd";
            this.btnAddProd.Size = new System.Drawing.Size(92, 46);
            this.btnAddProd.TabIndex = 3;
            this.btnAddProd.Text = "&Add";
            this.btnAddProd.UseVisualStyleBackColor = true;
            this.btnAddProd.Click += new System.EventHandler(this.btnAddProd_Click);
            // 
            // btnModifyProd
            // 
            this.btnModifyProd.Location = new System.Drawing.Point(484, 123);
            this.btnModifyProd.Name = "btnModifyProd";
            this.btnModifyProd.Size = new System.Drawing.Size(92, 46);
            this.btnModifyProd.TabIndex = 4;
            this.btnModifyProd.Text = "&Modify";
            this.btnModifyProd.UseVisualStyleBackColor = true;
            this.btnModifyProd.Click += new System.EventHandler(this.btnModifyProd_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(40, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(203, 28);
            this.label1.TabIndex = 5;
            this.label1.Text = "Click to Select Entry";
            // 
            // frmProducts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 28F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Group_1_Travel_Experts.Properties.Resources.MyBackground_;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(615, 322);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnModifyProd);
            this.Controls.Add(this.btnAddProd);
            this.Controls.Add(this.btnCancelProd);
            this.Controls.Add(this.btnDeleteProd);
            this.Controls.Add(this.dgvProducts);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.ForeColor = System.Drawing.Color.Maroon;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmProducts";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Products";
            this.Load += new System.EventHandler(this.frmProducts_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvProducts;
        private System.Windows.Forms.Button btnDeleteProd;
        private System.Windows.Forms.Button btnCancelProd;
        private System.Windows.Forms.Button btnAddProd;
        private System.Windows.Forms.Button btnModifyProd;
        private System.Windows.Forms.Label label1;
    }
}