namespace POS.MasterSetup
{
    partial class BrandMaster
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
            this.UserMasterSplitContainer = new System.Windows.Forms.SplitContainer();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtNarration = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtBrandId = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.txtBrandName = new System.Windows.Forms.TextBox();
            this.listView = new System.Windows.Forms.ListView();
            this.Id = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.BrandName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Narration = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.BrandId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Brand = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ProductId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Product = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            ((System.ComponentModel.ISupportInitialize)(this.UserMasterSplitContainer)).BeginInit();
            this.UserMasterSplitContainer.Panel1.SuspendLayout();
            this.UserMasterSplitContainer.Panel2.SuspendLayout();
            this.UserMasterSplitContainer.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // UserMasterSplitContainer
            // 
            this.UserMasterSplitContainer.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.UserMasterSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.UserMasterSplitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.UserMasterSplitContainer.Location = new System.Drawing.Point(0, 0);
            this.UserMasterSplitContainer.Name = "UserMasterSplitContainer";
            // 
            // UserMasterSplitContainer.Panel1
            // 
            this.UserMasterSplitContainer.Panel1.BackColor = System.Drawing.Color.White;
            this.UserMasterSplitContainer.Panel1.Controls.Add(this.panel1);
            this.UserMasterSplitContainer.Panel1MinSize = 0;
            // 
            // UserMasterSplitContainer.Panel2
            // 
            this.UserMasterSplitContainer.Panel2.BackColor = System.Drawing.Color.White;
            this.UserMasterSplitContainer.Panel2.Controls.Add(this.listView);
            this.UserMasterSplitContainer.Panel2MinSize = 0;
            this.UserMasterSplitContainer.Size = new System.Drawing.Size(863, 396);
            this.UserMasterSplitContainer.SplitterDistance = 573;
            this.UserMasterSplitContainer.TabIndex = 31;
            // 
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.txtNarration);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Controls.Add(this.txtBrandId);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label16);
            this.panel1.Controls.Add(this.txtBrandName);
            this.panel1.Location = new System.Drawing.Point(34, 75);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(513, 177);
            this.panel1.TabIndex = 0;
            // 
            // txtNarration
            // 
            this.txtNarration.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNarration.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower;
            this.txtNarration.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNarration.Location = new System.Drawing.Point(201, 75);
            this.txtNarration.Multiline = true;
            this.txtNarration.Name = "txtNarration";
            this.txtNarration.Size = new System.Drawing.Size(213, 29);
            this.txtNarration.TabIndex = 4;
            this.txtNarration.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtNarration_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(96, 83);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 381;
            this.label1.Text = "Narration";
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(361, 115);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(53, 23);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtBrandId
            // 
            this.txtBrandId.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBrandId.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBrandId.Location = new System.Drawing.Point(201, 22);
            this.txtBrandId.Name = "txtBrandId";
            this.txtBrandId.Size = new System.Drawing.Size(163, 21);
            this.txtBrandId.TabIndex = 0;
            this.txtBrandId.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(96, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 13);
            this.label2.TabIndex = 377;
            this.label2.Text = "Brand Id";
            this.label2.Visible = false;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label16.Location = new System.Drawing.Point(96, 52);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(78, 13);
            this.label16.TabIndex = 372;
            this.label16.Text = "Brand Name";
            // 
            // txtBrandName
            // 
            this.txtBrandName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBrandName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtBrandName.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBrandName.Location = new System.Drawing.Point(201, 48);
            this.txtBrandName.Name = "txtBrandName";
            this.txtBrandName.Size = new System.Drawing.Size(163, 21);
            this.txtBrandName.TabIndex = 1;
            this.txtBrandName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBrandName_KeyDown);
            // 
            // listView
            // 
            this.listView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Id,
            this.BrandName,
            this.Narration});
            this.listView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listView.FullRowSelect = true;
            this.listView.GridLines = true;
            this.listView.Location = new System.Drawing.Point(0, 0);
            this.listView.Name = "listView";
            this.listView.Size = new System.Drawing.Size(286, 396);
            this.listView.TabIndex = 6;
            this.listView.UseCompatibleStateImageBehavior = false;
            this.listView.View = System.Windows.Forms.View.Details;
            this.listView.DoubleClick += new System.EventHandler(this.listView_DoubleClick);
            // 
            // Id
            // 
            this.Id.Text = "Brand Id";
            this.Id.Width = 0;
            // 
            // BrandName
            // 
            this.BrandName.Text = "Brand Name";
            this.BrandName.Width = 192;
            // 
            // Narration
            // 
            this.Narration.Text = "Narration";
            this.Narration.Width = 120;
            // 
            // BrandId
            // 
            this.BrandId.Text = "Brand Id";
            this.BrandId.Width = 120;
            // 
            // Brand
            // 
            this.Brand.Text = "Brand";
            this.Brand.Width = 0;
            // 
            // ProductId
            // 
            this.ProductId.Text = "Product Id";
            this.ProductId.Width = 120;
            // 
            // Product
            // 
            this.Product.Text = "Product";
            this.Product.Width = 120;
            // 
            // BrandMaster
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(863, 396);
            this.Controls.Add(this.UserMasterSplitContainer);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "BrandMaster";
            this.Text = "Brand Setup";
            this.Load += new System.EventHandler(this.BrandMaster_Load);
            this.UserMasterSplitContainer.Panel1.ResumeLayout(false);
            this.UserMasterSplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.UserMasterSplitContainer)).EndInit();
            this.UserMasterSplitContainer.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer UserMasterSplitContainer;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtBrandId;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txtBrandName;
        private System.Windows.Forms.ListView listView;
        private System.Windows.Forms.ColumnHeader Id;
        private System.Windows.Forms.TextBox txtNarration;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.ColumnHeader BrandName;
        private System.Windows.Forms.ColumnHeader BrandId;
        private System.Windows.Forms.ColumnHeader Brand;
        private System.Windows.Forms.ColumnHeader ProductId;
        private System.Windows.Forms.ColumnHeader Product;
        private System.Windows.Forms.ColumnHeader Narration;

    }
}