namespace POS.Orders
{
    partial class PurchaseOrder
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
            this.listView = new System.Windows.Forms.ListView();
            this.Id = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.PurchaseId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ItemId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ItemName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.BrandId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Brand = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.BatchNo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ItemExpiryDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Quantity = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Amount = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.GstPercentage = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.GstAmount = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.OtherCharge = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.NetAmount = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.RatePerItem = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.MinSaleAmount = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.MRP = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel2 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.txtTotalOtherCharge = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtTotalNetAmount = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtTotalAmount = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtTotalGstAmount = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtTotalQuantity = new System.Windows.Forms.TextBox();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label11 = new System.Windows.Forms.Label();
            this.txtNarration = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnCreate = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtParty = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.dtpVhDate = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPartyVhNo = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.txtInvcNo = new System.Windows.Forms.TextBox();
            this.MUnitId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.MUnitName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel2.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // listView
            // 
            this.listView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Id,
            this.PurchaseId,
            this.ItemId,
            this.ItemName,
            this.BrandId,
            this.Brand,
            this.MUnitId,
            this.MUnitName,
            this.BatchNo,
            this.ItemExpiryDate,
            this.Quantity,
            this.Amount,
            this.GstPercentage,
            this.GstAmount,
            this.OtherCharge,
            this.NetAmount,
            this.RatePerItem,
            this.MinSaleAmount,
            this.MRP});
            this.listView.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.listView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listView.FullRowSelect = true;
            this.listView.GridLines = true;
            this.listView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listView.LabelEdit = true;
            this.listView.Location = new System.Drawing.Point(0, 153);
            this.listView.Name = "listView";
            this.listView.Size = new System.Drawing.Size(968, 230);
            this.listView.TabIndex = 12;
            this.listView.UseCompatibleStateImageBehavior = false;
            this.listView.View = System.Windows.Forms.View.Details;
            this.listView.DoubleClick += new System.EventHandler(this.listView_DoubleClick);
            // 
            // Id
            // 
            this.Id.Text = "Id";
            this.Id.Width = 0;
            // 
            // PurchaseId
            // 
            this.PurchaseId.Text = "PurchaseId";
            this.PurchaseId.Width = 0;
            // 
            // ItemId
            // 
            this.ItemId.Text = "Item Id";
            this.ItemId.Width = 0;
            // 
            // ItemName
            // 
            this.ItemName.Text = "Item Name";
            this.ItemName.Width = 150;
            // 
            // BrandId
            // 
            this.BrandId.Text = "Brand Id";
            this.BrandId.Width = 0;
            // 
            // Brand
            // 
            this.Brand.Text = "Brand";
            this.Brand.Width = 150;
            // 
            // BatchNo
            // 
            this.BatchNo.Text = "Batch #";
            this.BatchNo.Width = 80;
            // 
            // ItemExpiryDate
            // 
            this.ItemExpiryDate.Text = "Expire Date";
            this.ItemExpiryDate.Width = 100;
            // 
            // Quantity
            // 
            this.Quantity.Text = "Quantity";
            this.Quantity.Width = 80;
            // 
            // Amount
            // 
            this.Amount.Text = "Amount";
            this.Amount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.Amount.Width = 100;
            // 
            // GstPercentage
            // 
            this.GstPercentage.Text = "Gst(%)";
            this.GstPercentage.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.GstPercentage.Width = 80;
            // 
            // GstAmount
            // 
            this.GstAmount.Text = "Gst Amount";
            this.GstAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.GstAmount.Width = 100;
            // 
            // OtherCharge
            // 
            this.OtherCharge.Text = "Other Charge";
            this.OtherCharge.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.OtherCharge.Width = 100;
            // 
            // NetAmount
            // 
            this.NetAmount.Text = "Net Amount";
            this.NetAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.NetAmount.Width = 100;
            // 
            // RatePerItem
            // 
            this.RatePerItem.Text = "Rate / Item";
            this.RatePerItem.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.RatePerItem.Width = 100;
            // 
            // MinSaleAmount
            // 
            this.MinSaleAmount.Text = "Min Sale Amount";
            this.MinSaleAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.MinSaleAmount.Width = 120;
            // 
            // MRP
            // 
            this.MRP.Text = "MRP";
            this.MRP.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.MRP.Width = 100;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.txtTotalOtherCharge);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.txtTotalNetAmount);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Controls.Add(this.txtTotalAmount);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.txtTotalGstAmount);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.txtTotalQuantity);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 383);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(968, 28);
            this.panel2.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Location = new System.Drawing.Point(590, 8);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(116, 13);
            this.label5.TabIndex = 387;
            this.label5.Text = "Total Other Charge";
            // 
            // txtTotalOtherCharge
            // 
            this.txtTotalOtherCharge.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTotalOtherCharge.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTotalOtherCharge.Enabled = false;
            this.txtTotalOtherCharge.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalOtherCharge.ForeColor = System.Drawing.Color.Red;
            this.txtTotalOtherCharge.Location = new System.Drawing.Point(711, 4);
            this.txtTotalOtherCharge.Name = "txtTotalOtherCharge";
            this.txtTotalOtherCharge.Size = new System.Drawing.Size(70, 21);
            this.txtTotalOtherCharge.TabIndex = 386;
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Red;
            this.label9.Location = new System.Drawing.Point(783, 8);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(105, 13);
            this.label9.TabIndex = 383;
            this.label9.Text = "Total Net Amount";
            // 
            // txtTotalNetAmount
            // 
            this.txtTotalNetAmount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTotalNetAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTotalNetAmount.Enabled = false;
            this.txtTotalNetAmount.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalNetAmount.ForeColor = System.Drawing.Color.Red;
            this.txtTotalNetAmount.Location = new System.Drawing.Point(892, 4);
            this.txtTotalNetAmount.Name = "txtTotalNetAmount";
            this.txtTotalNetAmount.Size = new System.Drawing.Size(70, 21);
            this.txtTotalNetAmount.TabIndex = 10;
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Red;
            this.label10.Location = new System.Drawing.Point(243, 8);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(82, 13);
            this.label10.TabIndex = 381;
            this.label10.Text = "Total Amount";
            // 
            // txtTotalAmount
            // 
            this.txtTotalAmount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTotalAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTotalAmount.Enabled = false;
            this.txtTotalAmount.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalAmount.ForeColor = System.Drawing.Color.Red;
            this.txtTotalAmount.Location = new System.Drawing.Point(331, 4);
            this.txtTotalAmount.Name = "txtTotalAmount";
            this.txtTotalAmount.Size = new System.Drawing.Size(70, 21);
            this.txtTotalAmount.TabIndex = 7;
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Red;
            this.label8.Location = new System.Drawing.Point(406, 8);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(105, 13);
            this.label8.TabIndex = 379;
            this.label8.Text = "Total Gst Amount";
            // 
            // txtTotalGstAmount
            // 
            this.txtTotalGstAmount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTotalGstAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTotalGstAmount.Enabled = false;
            this.txtTotalGstAmount.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalGstAmount.ForeColor = System.Drawing.Color.Red;
            this.txtTotalGstAmount.Location = new System.Drawing.Point(516, 4);
            this.txtTotalGstAmount.Name = "txtTotalGstAmount";
            this.txtTotalGstAmount.Size = new System.Drawing.Size(70, 21);
            this.txtTotalGstAmount.TabIndex = 9;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Red;
            this.label7.Location = new System.Drawing.Point(122, 8);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(58, 13);
            this.label7.TabIndex = 377;
            this.label7.Text = "Total Qty";
            // 
            // txtTotalQuantity
            // 
            this.txtTotalQuantity.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTotalQuantity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTotalQuantity.Enabled = false;
            this.txtTotalQuantity.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalQuantity.ForeColor = System.Drawing.Color.Red;
            this.txtTotalQuantity.Location = new System.Drawing.Point(188, 4);
            this.txtTotalQuantity.Name = "txtTotalQuantity";
            this.txtTotalQuantity.Size = new System.Drawing.Size(47, 21);
            this.txtTotalQuantity.TabIndex = 6;
            // 
            // panel5
            // 
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel5.Controls.Add(this.label11);
            this.panel5.Controls.Add(this.txtNarration);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel5.Location = new System.Drawing.Point(0, 411);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(968, 51);
            this.panel5.TabIndex = 11;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(3, 3);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(60, 13);
            this.label11.TabIndex = 94;
            this.label11.Text = "Narration";
            // 
            // txtNarration
            // 
            this.txtNarration.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNarration.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.txtNarration.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNarration.Location = new System.Drawing.Point(0, 19);
            this.txtNarration.Multiline = true;
            this.txtNarration.Name = "txtNarration";
            this.txtNarration.Size = new System.Drawing.Size(966, 30);
            this.txtNarration.TabIndex = 11;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btnCreate);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 114);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(968, 39);
            this.panel1.TabIndex = 5;
            // 
            // btnCreate
            // 
            this.btnCreate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCreate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnCreate.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCreate.ForeColor = System.Drawing.Color.Blue;
            this.btnCreate.Location = new System.Drawing.Point(878, 5);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(85, 29);
            this.btnCreate.TabIndex = 5;
            this.btnCreate.Text = "Create";
            this.btnCreate.UseCompatibleTextRendering = true;
            this.btnCreate.UseVisualStyleBackColor = false;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtParty);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.dtpVhDate);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtPartyVhNo);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.dtpDate);
            this.groupBox1.Controls.Add(this.txtInvcNo);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(968, 114);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Purchase Order";
            // 
            // txtParty
            // 
            this.txtParty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtParty.Location = new System.Drawing.Point(138, 24);
            this.txtParty.Name = "txtParty";
            this.txtParty.Size = new System.Drawing.Size(198, 21);
            this.txtParty.TabIndex = 2;
            this.txtParty.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtParty_KeyDown);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Red;
            this.label6.Location = new System.Drawing.Point(118, 55);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(14, 13);
            this.label6.TabIndex = 488;
            this.label6.Text = "*";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.Red;
            this.label14.Location = new System.Drawing.Point(118, 28);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(14, 13);
            this.label14.TabIndex = 487;
            this.label14.Text = "*";
            // 
            // dtpVhDate
            // 
            this.dtpVhDate.CustomFormat = "dd-MMM-yyyy";
            this.dtpVhDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpVhDate.Location = new System.Drawing.Point(138, 79);
            this.dtpVhDate.Name = "dtpVhDate";
            this.dtpVhDate.Size = new System.Drawing.Size(198, 21);
            this.dtpVhDate.TabIndex = 4;
            this.dtpVhDate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dtpVhDate_KeyDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(19, 83);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 13);
            this.label3.TabIndex = 374;
            this.label3.Text = "Vhr Date";
            // 
            // txtPartyVhNo
            // 
            this.txtPartyVhNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPartyVhNo.Location = new System.Drawing.Point(138, 53);
            this.txtPartyVhNo.Name = "txtPartyVhNo";
            this.txtPartyVhNo.Size = new System.Drawing.Size(198, 21);
            this.txtPartyVhNo.TabIndex = 3;
            this.txtPartyVhNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPartyVhNo_KeyDown);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(19, 54);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 13);
            this.label4.TabIndex = 373;
            this.label4.Text = "Party Vhr #";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(19, 28);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(74, 13);
            this.label13.TabIndex = 372;
            this.label13.Text = "Party Name";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(828, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Date";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(680, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Invc #";
            // 
            // dtpDate
            // 
            this.dtpDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpDate.CustomFormat = "dd-MMM-yyyy";
            this.dtpDate.Enabled = false;
            this.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDate.Location = new System.Drawing.Point(865, 24);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(100, 21);
            this.dtpDate.TabIndex = 1;
            // 
            // txtInvcNo
            // 
            this.txtInvcNo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtInvcNo.Enabled = false;
            this.txtInvcNo.Location = new System.Drawing.Point(728, 24);
            this.txtInvcNo.Name = "txtInvcNo";
            this.txtInvcNo.Size = new System.Drawing.Size(100, 21);
            this.txtInvcNo.TabIndex = 0;
            // 
            // MUnitId
            // 
            this.MUnitId.Text = "MUnitId";
            this.MUnitId.Width = 0;
            // 
            // MUnitName
            // 
            this.MUnitName.Text = "MUnit";
            this.MUnitName.Width = 80;
            // 
            // PurchaseOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(968, 462);
            this.Controls.Add(this.listView);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox1);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "PurchaseOrder";
            this.Text = "Purchase";
            this.Load += new System.EventHandler(this.PurchaseOrder_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.TextBox txtInvcNo;
        private System.Windows.Forms.DateTimePicker dtpVhDate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtPartyVhNo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ListView listView;
        private System.Windows.Forms.ColumnHeader Id;
        private System.Windows.Forms.ColumnHeader ItemId;
        private System.Windows.Forms.ColumnHeader ItemName;
        private System.Windows.Forms.ColumnHeader BrandId;
        private System.Windows.Forms.ColumnHeader Brand;
        private System.Windows.Forms.ColumnHeader BatchNo;
        private System.Windows.Forms.ColumnHeader ItemExpiryDate;
        private System.Windows.Forms.ColumnHeader Quantity;
        private System.Windows.Forms.ColumnHeader Amount;
        private System.Windows.Forms.ColumnHeader GstPercentage;
        private System.Windows.Forms.ColumnHeader GstAmount;
        private System.Windows.Forms.ColumnHeader OtherCharge;
        private System.Windows.Forms.ColumnHeader NetAmount;
        private System.Windows.Forms.ColumnHeader RatePerItem;
        private System.Windows.Forms.ColumnHeader MinSaleAmount;
        private System.Windows.Forms.ColumnHeader MRP;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtNarration;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtTotalNetAmount;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtTotalAmount;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtTotalGstAmount;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtTotalQuantity;
        private System.Windows.Forms.TextBox txtParty;
        private System.Windows.Forms.ColumnHeader PurchaseId;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtTotalOtherCharge;
        private System.Windows.Forms.ColumnHeader MUnitId;
        private System.Windows.Forms.ColumnHeader MUnitName;
    }
}