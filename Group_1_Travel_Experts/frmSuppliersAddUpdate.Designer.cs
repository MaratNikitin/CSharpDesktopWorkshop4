
namespace Group_1_Travel_Experts
{
    partial class frmSuppliersAddUpdate
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSuppliersAddUpdate));
            this.textBoxSupplierName = new System.Windows.Forms.TextBox();
            this.labelName = new System.Windows.Forms.Label();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonAccept = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBoxSupplierName
            // 
            this.textBoxSupplierName.BackColor = System.Drawing.Color.Linen;
            this.textBoxSupplierName.ForeColor = System.Drawing.Color.Maroon;
            this.textBoxSupplierName.Location = new System.Drawing.Point(162, 51);
            this.textBoxSupplierName.MaxLength = 50;
            this.textBoxSupplierName.Name = "textBoxSupplierName";
            this.textBoxSupplierName.Size = new System.Drawing.Size(542, 29);
            this.textBoxSupplierName.TabIndex = 0;
            this.textBoxSupplierName.Tag = "Supplier Name";
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.BackColor = System.Drawing.Color.Transparent;
            this.labelName.Location = new System.Drawing.Point(28, 54);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(128, 21);
            this.labelName.TabIndex = 6;
            this.labelName.Text = "Supplier Name:";
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonCancel.BackColor = System.Drawing.Color.BurlyWood;
            this.buttonCancel.ForeColor = System.Drawing.Color.Maroon;
            this.buttonCancel.Location = new System.Drawing.Point(383, 120);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(166, 37);
            this.buttonCancel.TabIndex = 3;
            this.buttonCancel.Text = "&Cancel";
            this.buttonCancel.UseVisualStyleBackColor = false;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonAccept
            // 
            this.buttonAccept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonAccept.BackColor = System.Drawing.Color.BurlyWood;
            this.buttonAccept.ForeColor = System.Drawing.Color.Maroon;
            this.buttonAccept.Location = new System.Drawing.Point(162, 120);
            this.buttonAccept.Name = "buttonAccept";
            this.buttonAccept.Size = new System.Drawing.Size(139, 37);
            this.buttonAccept.TabIndex = 1;
            this.buttonAccept.Text = "&Accept";
            this.buttonAccept.UseVisualStyleBackColor = false;
            this.buttonAccept.Click += new System.EventHandler(this.buttonAccept_Click);
            // 
            // frmSuppliersAddUpdate
            // 
            this.AcceptButton = this.buttonAccept;
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Group_1_Travel_Experts.Properties.Resources.MyBackground_;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(735, 187);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonAccept);
            this.Controls.Add(this.textBoxSupplierName);
            this.Controls.Add(this.labelName);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.ForeColor = System.Drawing.Color.Maroon;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmSuppliersAddUpdate";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add / Update Suppliers";
            this.Load += new System.EventHandler(this.frmSuppliersAddUpdate_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxSupplierName;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonAccept;
    }
}