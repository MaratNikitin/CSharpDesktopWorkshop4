
namespace Group_1_Travel_Experts
{
    partial class frmSuppliers
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSuppliers));
            this.dataGridViewSuppliers = new System.Windows.Forms.DataGridView();
            this.labelSuppliers = new System.Windows.Forms.Label();
            this.buttonModify = new System.Windows.Forms.Button();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.buttonRemove = new System.Windows.Forms.Button();
            this.buttonExit = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSuppliers)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewSuppliers
            // 
            this.dataGridViewSuppliers.BackgroundColor = System.Drawing.Color.Linen;
            this.dataGridViewSuppliers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewSuppliers.Location = new System.Drawing.Point(44, 35);
            this.dataGridViewSuppliers.MultiSelect = false;
            this.dataGridViewSuppliers.Name = "dataGridViewSuppliers";
            this.dataGridViewSuppliers.RowTemplate.Height = 25;
            this.dataGridViewSuppliers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewSuppliers.Size = new System.Drawing.Size(693, 510);
            this.dataGridViewSuppliers.TabIndex = 0;
            // 
            // labelSuppliers
            // 
            this.labelSuppliers.AutoSize = true;
            this.labelSuppliers.BackColor = System.Drawing.Color.Transparent;
            this.labelSuppliers.Location = new System.Drawing.Point(44, 11);
            this.labelSuppliers.Name = "labelSuppliers";
            this.labelSuppliers.Size = new System.Drawing.Size(228, 21);
            this.labelSuppliers.TabIndex = 1;
            this.labelSuppliers.Text = "Suppliers (select by clicking)";
            // 
            // buttonModify
            // 
            this.buttonModify.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonModify.BackColor = System.Drawing.Color.BurlyWood;
            this.buttonModify.ForeColor = System.Drawing.Color.Maroon;
            this.buttonModify.Location = new System.Drawing.Point(300, 569);
            this.buttonModify.Name = "buttonModify";
            this.buttonModify.Size = new System.Drawing.Size(166, 39);
            this.buttonModify.TabIndex = 8;
            this.buttonModify.Text = "&Modify Supplier";
            this.buttonModify.UseVisualStyleBackColor = false;
            // 
            // buttonAdd
            // 
            this.buttonAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonAdd.BackColor = System.Drawing.Color.BurlyWood;
            this.buttonAdd.ForeColor = System.Drawing.Color.Maroon;
            this.buttonAdd.Location = new System.Drawing.Point(44, 570);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(139, 37);
            this.buttonAdd.TabIndex = 7;
            this.buttonAdd.Text = "&Add Supplier";
            this.buttonAdd.UseVisualStyleBackColor = false;
            // 
            // buttonRemove
            // 
            this.buttonRemove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonRemove.BackColor = System.Drawing.Color.BurlyWood;
            this.buttonRemove.ForeColor = System.Drawing.Color.Maroon;
            this.buttonRemove.Location = new System.Drawing.Point(583, 569);
            this.buttonRemove.Name = "buttonRemove";
            this.buttonRemove.Size = new System.Drawing.Size(154, 39);
            this.buttonRemove.TabIndex = 9;
            this.buttonRemove.Text = "&Remove Supplier";
            this.buttonRemove.UseVisualStyleBackColor = false;
            // 
            // buttonExit
            // 
            this.buttonExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonExit.BackColor = System.Drawing.Color.BurlyWood;
            this.buttonExit.ForeColor = System.Drawing.Color.Maroon;
            this.buttonExit.Location = new System.Drawing.Point(583, 642);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(154, 39);
            this.buttonExit.TabIndex = 10;
            this.buttonExit.Text = "&Exit";
            this.buttonExit.UseVisualStyleBackColor = false;
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            // 
            // frmSuppliers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Group_1_Travel_Experts.Properties.Resources.MyBackground_;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.CancelButton = this.buttonExit;
            this.ClientSize = new System.Drawing.Size(785, 693);
            this.Controls.Add(this.buttonExit);
            this.Controls.Add(this.buttonRemove);
            this.Controls.Add(this.buttonModify);
            this.Controls.Add(this.buttonAdd);
            this.Controls.Add(this.labelSuppliers);
            this.Controls.Add(this.dataGridViewSuppliers);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.ForeColor = System.Drawing.Color.Maroon;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmSuppliers";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Suppliers";
            this.Load += new System.EventHandler(this.frmSuppliers_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSuppliers)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewSuppliers;
        private System.Windows.Forms.Label labelSuppliers;
        private System.Windows.Forms.Button buttonRemove;
        private System.Windows.Forms.Button buttonModify;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Button buttonExit;
        private System.Windows.Forms.Button buttonModifyProduct;
        private System.Windows.Forms.Button buttonRemoveContact;
        private System.Windows.Forms.Button buttonAddContact;
        private System.Windows.Forms.DataGridView dataGridViewSupplierContacts;
        private System.Windows.Forms.Label labelSupplierContacts;
    }
}