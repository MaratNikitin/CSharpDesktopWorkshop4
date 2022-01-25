
namespace Group_1_Travel_Experts
{
    partial class frmMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.labelChooseOption = new System.Windows.Forms.Label();
            this.groupBoxTables = new System.Windows.Forms.GroupBox();
            this.radioButtonProductsSuppliers = new System.Windows.Forms.RadioButton();
            this.radioButtonSuppliers = new System.Windows.Forms.RadioButton();
            this.radioButtonProducts = new System.Windows.Forms.RadioButton();
            this.radioButtonPackages = new System.Windows.Forms.RadioButton();
            this.pictureBoxMainForm = new System.Windows.Forms.PictureBox();
            this.labelWelcome = new System.Windows.Forms.Label();
            this.buttonOpen = new System.Windows.Forms.Button();
            this.buttonExit = new System.Windows.Forms.Button();
            this.groupBoxTables.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMainForm)).BeginInit();
            this.SuspendLayout();
            // 
            // labelChooseOption
            // 
            this.labelChooseOption.AutoSize = true;
            this.labelChooseOption.BackColor = System.Drawing.Color.Transparent;
            this.labelChooseOption.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelChooseOption.ForeColor = System.Drawing.Color.Maroon;
            this.labelChooseOption.Location = new System.Drawing.Point(27, 77);
            this.labelChooseOption.Name = "labelChooseOption";
            this.labelChooseOption.Size = new System.Drawing.Size(246, 21);
            this.labelChooseOption.TabIndex = 0;
            this.labelChooseOption.Text = "Choose a table and then open it:";
            // 
            // groupBoxTables
            // 
            this.groupBoxTables.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxTables.BackColor = System.Drawing.Color.Transparent;
            this.groupBoxTables.Controls.Add(this.radioButtonProductsSuppliers);
            this.groupBoxTables.Controls.Add(this.radioButtonSuppliers);
            this.groupBoxTables.Controls.Add(this.radioButtonProducts);
            this.groupBoxTables.Controls.Add(this.radioButtonPackages);
            this.groupBoxTables.Location = new System.Drawing.Point(23, 101);
            this.groupBoxTables.Name = "groupBoxTables";
            this.groupBoxTables.Size = new System.Drawing.Size(292, 166);
            this.groupBoxTables.TabIndex = 1;
            this.groupBoxTables.TabStop = false;
            this.groupBoxTables.Enter += new System.EventHandler(this.groupBoxTables_Enter);
            // 
            // radioButtonProductsSuppliers
            // 
            this.radioButtonProductsSuppliers.AutoSize = true;
            this.radioButtonProductsSuppliers.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.radioButtonProductsSuppliers.ForeColor = System.Drawing.Color.Maroon;
            this.radioButtonProductsSuppliers.Location = new System.Drawing.Point(19, 103);
            this.radioButtonProductsSuppliers.Name = "radioButtonProductsSuppliers";
            this.radioButtonProductsSuppliers.Size = new System.Drawing.Size(180, 25);
            this.radioButtonProductsSuppliers.TabIndex = 5;
            this.radioButtonProductsSuppliers.TabStop = true;
            this.radioButtonProductsSuppliers.Text = "Products + Suppliers";
            this.radioButtonProductsSuppliers.UseVisualStyleBackColor = true;
            // 
            // radioButtonSuppliers
            // 
            this.radioButtonSuppliers.AutoSize = true;
            this.radioButtonSuppliers.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.radioButtonSuppliers.ForeColor = System.Drawing.Color.Maroon;
            this.radioButtonSuppliers.Location = new System.Drawing.Point(19, 72);
            this.radioButtonSuppliers.Name = "radioButtonSuppliers";
            this.radioButtonSuppliers.Size = new System.Drawing.Size(96, 25);
            this.radioButtonSuppliers.TabIndex = 4;
            this.radioButtonSuppliers.TabStop = true;
            this.radioButtonSuppliers.Text = "Suppliers";
            this.radioButtonSuppliers.UseVisualStyleBackColor = true;
            // 
            // radioButtonProducts
            // 
            this.radioButtonProducts.AutoSize = true;
            this.radioButtonProducts.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.radioButtonProducts.ForeColor = System.Drawing.Color.Maroon;
            this.radioButtonProducts.Location = new System.Drawing.Point(19, 41);
            this.radioButtonProducts.Name = "radioButtonProducts";
            this.radioButtonProducts.Size = new System.Drawing.Size(93, 25);
            this.radioButtonProducts.TabIndex = 3;
            this.radioButtonProducts.TabStop = true;
            this.radioButtonProducts.Text = "Products";
            this.radioButtonProducts.UseVisualStyleBackColor = true;
            // 
            // radioButtonPackages
            // 
            this.radioButtonPackages.AutoSize = true;
            this.radioButtonPackages.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.radioButtonPackages.ForeColor = System.Drawing.Color.Maroon;
            this.radioButtonPackages.Location = new System.Drawing.Point(19, 10);
            this.radioButtonPackages.Name = "radioButtonPackages";
            this.radioButtonPackages.Size = new System.Drawing.Size(95, 25);
            this.radioButtonPackages.TabIndex = 0;
            this.radioButtonPackages.TabStop = true;
            this.radioButtonPackages.Text = "Packages";
            this.radioButtonPackages.UseVisualStyleBackColor = true;
            // 
            // pictureBoxMainForm
            // 
            this.pictureBoxMainForm.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxMainForm.Image = global::Group_1_Travel_Experts.Properties.Resources.sunset;
            this.pictureBoxMainForm.InitialImage = null;
            this.pictureBoxMainForm.Location = new System.Drawing.Point(281, 6);
            this.pictureBoxMainForm.Name = "pictureBoxMainForm";
            this.pictureBoxMainForm.Size = new System.Drawing.Size(101, 120);
            this.pictureBoxMainForm.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxMainForm.TabIndex = 7;
            this.pictureBoxMainForm.TabStop = false;
            this.pictureBoxMainForm.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // labelWelcome
            // 
            this.labelWelcome.AutoSize = true;
            this.labelWelcome.BackColor = System.Drawing.Color.Transparent;
            this.labelWelcome.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.labelWelcome.ForeColor = System.Drawing.Color.Maroon;
            this.labelWelcome.Location = new System.Drawing.Point(12, 24);
            this.labelWelcome.Name = "labelWelcome";
            this.labelWelcome.Size = new System.Drawing.Size(252, 25);
            this.labelWelcome.TabIndex = 2;
            this.labelWelcome.Text = "Welcome To Travel Experts!";
            this.labelWelcome.Click += new System.EventHandler(this.labelWelcome_Click);
            // 
            // buttonOpen
            // 
            this.buttonOpen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonOpen.BackColor = System.Drawing.Color.BurlyWood;
            this.buttonOpen.ForeColor = System.Drawing.Color.Maroon;
            this.buttonOpen.Location = new System.Drawing.Point(42, 283);
            this.buttonOpen.Name = "buttonOpen";
            this.buttonOpen.Size = new System.Drawing.Size(75, 37);
            this.buttonOpen.TabIndex = 3;
            this.buttonOpen.Text = "Open";
            this.buttonOpen.UseVisualStyleBackColor = false;
            this.buttonOpen.Click += new System.EventHandler(this.buttonOpen_Click);
            // 
            // buttonExit
            // 
            this.buttonExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonExit.BackColor = System.Drawing.Color.BurlyWood;
            this.buttonExit.ForeColor = System.Drawing.Color.Maroon;
            this.buttonExit.Location = new System.Drawing.Point(283, 283);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(75, 37);
            this.buttonExit.TabIndex = 4;
            this.buttonExit.Text = "Exit";
            this.buttonExit.UseVisualStyleBackColor = false;
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            // 
            // frmMain
            // 
            this.AcceptButton = this.buttonOpen;
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Group_1_Travel_Experts.Properties.Resources.MyBackground_;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(390, 343);
            this.Controls.Add(this.pictureBoxMainForm);
            this.Controls.Add(this.buttonExit);
            this.Controls.Add(this.buttonOpen);
            this.Controls.Add(this.labelWelcome);
            this.Controls.Add(this.groupBoxTables);
            this.Controls.Add(this.labelChooseOption);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Travel Experts - Main Window";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.groupBoxTables.ResumeLayout(false);
            this.groupBoxTables.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMainForm)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelChooseOption;
        private System.Windows.Forms.RadioButton radioButtonSuppliers;
        private System.Windows.Forms.RadioButton radioButtonProducts;
        private System.Windows.Forms.RadioButton radioButtonPackages;
        private System.Windows.Forms.Label labelWelcome;
        private System.Windows.Forms.RadioButton radioButtonProductsSuppliers;
        private System.Windows.Forms.Button buttonOpen;
        // private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button buttonExit;
        internal System.Windows.Forms.GroupBox groupBoxTables;
        private System.Windows.Forms.PictureBox pictureBoxMainForm;
    }
}

