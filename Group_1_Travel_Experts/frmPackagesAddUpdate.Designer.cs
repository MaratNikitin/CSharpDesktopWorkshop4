
namespace Group_1_Travel_Experts
{
    partial class frmPackagesAddUpdate
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPackagesAddUpdate));
            this.buttonOk = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.labelPackageName = new System.Windows.Forms.Label();
            this.labelStartDate = new System.Windows.Forms.Label();
            this.labelEndDate = new System.Windows.Forms.Label();
            this.labeDescription = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxAgencyCommission = new System.Windows.Forms.TextBox();
            this.textBoxBasePrice = new System.Windows.Forms.TextBox();
            this.textBoxDescription = new System.Windows.Forms.TextBox();
            this.textBoxPackageName = new System.Windows.Forms.TextBox();
            this.textBoxPackageStartDate = new System.Windows.Forms.TextBox();
            this.textBoxPackageEndDate = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // buttonOk
            // 
            this.buttonOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonOk.BackColor = System.Drawing.Color.BurlyWood;
            this.buttonOk.ForeColor = System.Drawing.Color.Maroon;
            this.buttonOk.Location = new System.Drawing.Point(247, 364);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(85, 37);
            this.buttonOk.TabIndex = 5;
            this.buttonOk.Text = "&Ok";
            this.buttonOk.UseVisualStyleBackColor = false;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonCancel.BackColor = System.Drawing.Color.BurlyWood;
            this.buttonCancel.ForeColor = System.Drawing.Color.Maroon;
            this.buttonCancel.Location = new System.Drawing.Point(493, 364);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(85, 37);
            this.buttonCancel.TabIndex = 6;
            this.buttonCancel.Text = "&Cancel";
            this.buttonCancel.UseVisualStyleBackColor = false;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click_1);
            // 
            // labelPackageName
            // 
            this.labelPackageName.AutoSize = true;
            this.labelPackageName.BackColor = System.Drawing.Color.Transparent;
            this.labelPackageName.Location = new System.Drawing.Point(35, 50);
            this.labelPackageName.Name = "labelPackageName";
            this.labelPackageName.Size = new System.Drawing.Size(157, 28);
            this.labelPackageName.TabIndex = 7;
            this.labelPackageName.Text = "Package Name:";
            // 
            // labelStartDate
            // 
            this.labelStartDate.AutoSize = true;
            this.labelStartDate.BackColor = System.Drawing.Color.Transparent;
            this.labelStartDate.Location = new System.Drawing.Point(35, 105);
            this.labelStartDate.Name = "labelStartDate";
            this.labelStartDate.Size = new System.Drawing.Size(199, 28);
            this.labelStartDate.TabIndex = 8;
            this.labelStartDate.Text = "Package Start Date:";
            // 
            // labelEndDate
            // 
            this.labelEndDate.AutoSize = true;
            this.labelEndDate.BackColor = System.Drawing.Color.Transparent;
            this.labelEndDate.Location = new System.Drawing.Point(35, 156);
            this.labelEndDate.Name = "labelEndDate";
            this.labelEndDate.Size = new System.Drawing.Size(187, 28);
            this.labelEndDate.TabIndex = 9;
            this.labelEndDate.Text = "Package End Date:";
            // 
            // labeDescription
            // 
            this.labeDescription.AutoSize = true;
            this.labeDescription.BackColor = System.Drawing.Color.Transparent;
            this.labeDescription.Location = new System.Drawing.Point(35, 208);
            this.labeDescription.Name = "labeDescription";
            this.labeDescription.Size = new System.Drawing.Size(126, 28);
            this.labeDescription.TabIndex = 10;
            this.labeDescription.Text = "Description:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(35, 260);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(158, 28);
            this.label1.TabIndex = 11;
            this.label1.Text = "Base Price (C$):";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(37, 314);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(251, 28);
            this.label2.TabIndex = 12;
            this.label2.Text = "Agency Commission (C$):";
            // 
            // textBoxAgencyCommission
            // 
            this.textBoxAgencyCommission.BackColor = System.Drawing.Color.Linen;
            this.textBoxAgencyCommission.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.textBoxAgencyCommission.ForeColor = System.Drawing.Color.Maroon;
            this.textBoxAgencyCommission.Location = new System.Drawing.Point(294, 311);
            this.textBoxAgencyCommission.Name = "textBoxAgencyCommission";
            this.textBoxAgencyCommission.Size = new System.Drawing.Size(284, 34);
            this.textBoxAgencyCommission.TabIndex = 6;
            this.textBoxAgencyCommission.Tag = "Agency Commission";
            // 
            // textBoxBasePrice
            // 
            this.textBoxBasePrice.BackColor = System.Drawing.Color.Linen;
            this.textBoxBasePrice.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.textBoxBasePrice.ForeColor = System.Drawing.Color.Maroon;
            this.textBoxBasePrice.Location = new System.Drawing.Point(294, 257);
            this.textBoxBasePrice.Name = "textBoxBasePrice";
            this.textBoxBasePrice.Size = new System.Drawing.Size(284, 34);
            this.textBoxBasePrice.TabIndex = 5;
            this.textBoxBasePrice.Tag = "Base Price";
            // 
            // textBoxDescription
            // 
            this.textBoxDescription.BackColor = System.Drawing.Color.Linen;
            this.textBoxDescription.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.textBoxDescription.ForeColor = System.Drawing.Color.Maroon;
            this.textBoxDescription.Location = new System.Drawing.Point(294, 205);
            this.textBoxDescription.Name = "textBoxDescription";
            this.textBoxDescription.Size = new System.Drawing.Size(284, 34);
            this.textBoxDescription.TabIndex = 4;
            this.textBoxDescription.Tag = "Description";
            // 
            // textBoxPackageName
            // 
            this.textBoxPackageName.BackColor = System.Drawing.Color.Linen;
            this.textBoxPackageName.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.textBoxPackageName.ForeColor = System.Drawing.Color.Maroon;
            this.textBoxPackageName.Location = new System.Drawing.Point(294, 47);
            this.textBoxPackageName.Name = "textBoxPackageName";
            this.textBoxPackageName.Size = new System.Drawing.Size(284, 34);
            this.textBoxPackageName.TabIndex = 1;
            this.textBoxPackageName.Tag = "Package Name";
            // 
            // textBoxPackageStartDate
            // 
            this.textBoxPackageStartDate.BackColor = System.Drawing.Color.Linen;
            this.textBoxPackageStartDate.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.textBoxPackageStartDate.ForeColor = System.Drawing.Color.Maroon;
            this.textBoxPackageStartDate.Location = new System.Drawing.Point(294, 102);
            this.textBoxPackageStartDate.Name = "textBoxPackageStartDate";
            this.textBoxPackageStartDate.Size = new System.Drawing.Size(284, 34);
            this.textBoxPackageStartDate.TabIndex = 2;
            this.textBoxPackageStartDate.Tag = "Package Start Date";
            // 
            // textBoxPackageEndDate
            // 
            this.textBoxPackageEndDate.BackColor = System.Drawing.Color.Linen;
            this.textBoxPackageEndDate.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.textBoxPackageEndDate.ForeColor = System.Drawing.Color.Maroon;
            this.textBoxPackageEndDate.Location = new System.Drawing.Point(294, 153);
            this.textBoxPackageEndDate.Name = "textBoxPackageEndDate";
            this.textBoxPackageEndDate.Size = new System.Drawing.Size(284, 34);
            this.textBoxPackageEndDate.TabIndex = 3;
            this.textBoxPackageEndDate.Tag = "Package End Date";
            // 
            // frmPackagesAddUpdate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 28F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Group_1_Travel_Experts.Properties.Resources.MyBackground_;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(658, 425);
            this.Controls.Add(this.textBoxPackageEndDate);
            this.Controls.Add(this.textBoxPackageStartDate);
            this.Controls.Add(this.textBoxPackageName);
            this.Controls.Add(this.textBoxDescription);
            this.Controls.Add(this.textBoxBasePrice);
            this.Controls.Add(this.textBoxAgencyCommission);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labeDescription);
            this.Controls.Add(this.labelEndDate);
            this.Controls.Add(this.labelStartDate);
            this.Controls.Add(this.labelPackageName);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOk);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.ForeColor = System.Drawing.Color.Maroon;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmPackagesAddUpdate";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add / Update Packages";
            this.Load += new System.EventHandler(this.frmPackagesAddUpdate_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Label labelPackageName;
        private System.Windows.Forms.Label labelStartDate;
        private System.Windows.Forms.Label labelEndDate;
        private System.Windows.Forms.Label labeDescription;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxAgencyCommission;
        private System.Windows.Forms.TextBox textBoxBasePrice;
        private System.Windows.Forms.TextBox textBoxDescription;
        private System.Windows.Forms.TextBox textBoxPackageName;
        private System.Windows.Forms.TextBox textBoxPackageStartDate;
        private System.Windows.Forms.TextBox textBoxPackageEndDate;
    }
}