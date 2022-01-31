
namespace Group_1_Travel_Experts
{
    partial class frmProductsAddUpdate
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmProductsAddUpdate));
            this.label2 = new System.Windows.Forms.Label();
            this.txtProdName = new System.Windows.Forms.TextBox();
            this.btnOKProduct = new System.Windows.Forms.Button();
            this.btnCancelProduct = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(41, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(120, 21);
            this.label2.TabIndex = 1;
            this.label2.Text = "Product Name";
            // 
            // txtProdName
            // 
            this.txtProdName.BackColor = System.Drawing.Color.Linen;
            this.txtProdName.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.txtProdName.ForeColor = System.Drawing.Color.Maroon;
            this.txtProdName.Location = new System.Drawing.Point(195, 59);
            this.txtProdName.MaxLength = 50;
            this.txtProdName.Name = "txtProdName";
            this.txtProdName.PlaceholderText = "50 characters maximum";
            this.txtProdName.Size = new System.Drawing.Size(353, 29);
            this.txtProdName.TabIndex = 3;
            this.txtProdName.Tag = "Product Name";
            // 
            // btnOKProduct
            // 
            this.btnOKProduct.BackColor = System.Drawing.Color.BurlyWood;
            this.btnOKProduct.Location = new System.Drawing.Point(41, 119);
            this.btnOKProduct.Name = "btnOKProduct";
            this.btnOKProduct.Size = new System.Drawing.Size(113, 42);
            this.btnOKProduct.TabIndex = 4;
            this.btnOKProduct.Text = "&Ok";
            this.btnOKProduct.UseVisualStyleBackColor = false;
            this.btnOKProduct.Click += new System.EventHandler(this.btnOKProduct_Click);
            // 
            // btnCancelProduct
            // 
            this.btnCancelProduct.BackColor = System.Drawing.Color.BurlyWood;
            this.btnCancelProduct.Location = new System.Drawing.Point(435, 119);
            this.btnCancelProduct.Name = "btnCancelProduct";
            this.btnCancelProduct.Size = new System.Drawing.Size(113, 43);
            this.btnCancelProduct.TabIndex = 5;
            this.btnCancelProduct.Text = "&Cancel";
            this.btnCancelProduct.UseVisualStyleBackColor = false;
            this.btnCancelProduct.Click += new System.EventHandler(this.btnCancelProduct_Click);
            // 
            // frmProductsAddUpdate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Group_1_Travel_Experts.Properties.Resources.MyBackground_;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(598, 196);
            this.Controls.Add(this.btnCancelProduct);
            this.Controls.Add(this.btnOKProduct);
            this.Controls.Add(this.txtProdName);
            this.Controls.Add(this.label2);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.ForeColor = System.Drawing.Color.Maroon;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmProductsAddUpdate";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add / Update Products";
            this.Load += new System.EventHandler(this.frmProductsAddUpdate_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtProdName;
        private System.Windows.Forms.Button btnOKProduct;
        private System.Windows.Forms.Button btnCancelProduct;
    }
}