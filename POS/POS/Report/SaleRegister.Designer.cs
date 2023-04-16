namespace POS.Report
{
    partial class SaleRegister
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
            this.listview = new System.Windows.Forms.ListView();
            this.Sl = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Date = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.InvoiceNo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SoldBy = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Customer = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Address = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.MobNo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.GSTINNo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Qty = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Amount = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Discount = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.GSTAmount = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.NetAmount = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel1 = new System.Windows.Forms.Panel();
            this.DtpFromdate = new System.Windows.Forms.DateTimePicker();
            this.btnPrint = new System.Windows.Forms.Button();
            this.BtnView = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.DtptoDate = new System.Windows.Forms.DateTimePicker();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // listview
            // 
            this.listview.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Sl,
            this.Date,
            this.InvoiceNo,
            this.SoldBy,
            this.Customer,
            this.Address,
            this.MobNo,
            this.GSTINNo,
            this.Qty,
            this.Amount,
            this.Discount,
            this.GSTAmount,
            this.NetAmount});
            this.listview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listview.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listview.FullRowSelect = true;
            this.listview.GridLines = true;
            this.listview.Location = new System.Drawing.Point(0, 77);
            this.listview.Name = "listview";
            this.listview.Size = new System.Drawing.Size(884, 385);
            this.listview.TabIndex = 388;
            this.listview.UseCompatibleStateImageBehavior = false;
            this.listview.View = System.Windows.Forms.View.Details;
            // 
            // Sl
            // 
            this.Sl.Text = "Sl";
            this.Sl.Width = 40;
            // 
            // Date
            // 
            this.Date.Text = "Date";
            this.Date.Width = 100;
            // 
            // InvoiceNo
            // 
            this.InvoiceNo.Text = "Invoice No";
            this.InvoiceNo.Width = 100;
            // 
            // SoldBy
            // 
            this.SoldBy.Text = "Sold By";
            this.SoldBy.Width = 150;
            // 
            // Customer
            // 
            this.Customer.Text = "Customer";
            this.Customer.Width = 150;
            // 
            // Address
            // 
            this.Address.Text = "Address";
            this.Address.Width = 200;
            // 
            // MobNo
            // 
            this.MobNo.Text = "Mob No";
            this.MobNo.Width = 100;
            // 
            // GSTINNo
            // 
            this.GSTINNo.Text = "GSTIN No";
            this.GSTINNo.Width = 150;
            // 
            // Qty
            // 
            this.Qty.Text = "Qty";
            this.Qty.Width = 80;
            // 
            // Amount
            // 
            this.Amount.Text = "Amount";
            this.Amount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.Amount.Width = 100;
            // 
            // Discount
            // 
            this.Discount.Text = "Discount";
            this.Discount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.Discount.Width = 100;
            // 
            // GSTAmount
            // 
            this.GSTAmount.Text = "GST Amount";
            this.GSTAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.GSTAmount.Width = 100;
            // 
            // NetAmount
            // 
            this.NetAmount.Text = "Net Amount";
            this.NetAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.NetAmount.Width = 100;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.DtpFromdate);
            this.panel1.Controls.Add(this.btnPrint);
            this.panel1.Controls.Add(this.BtnView);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.DtptoDate);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(884, 77);
            this.panel1.TabIndex = 389;
            // 
            // DtpFromdate
            // 
            this.DtpFromdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.DtpFromdate.CustomFormat = "dd/MMM/yyy";
            this.DtpFromdate.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DtpFromdate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DtpFromdate.Location = new System.Drawing.Point(501, 23);
            this.DtpFromdate.Name = "DtpFromdate";
            this.DtpFromdate.Size = new System.Drawing.Size(119, 22);
            this.DtpFromdate.TabIndex = 398;
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnPrint.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnPrint.Image = global::POS.Properties.Resources.Print;
            this.btnPrint.Location = new System.Drawing.Point(838, 20);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(37, 26);
            this.btnPrint.TabIndex = 400;
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Visible = false;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // BtnView
            // 
            this.BtnView.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnView.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.BtnView.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BtnView.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnView.Image = global::POS.Properties.Resources.Open;
            this.BtnView.Location = new System.Drawing.Point(787, 20);
            this.BtnView.Name = "BtnView";
            this.BtnView.Size = new System.Drawing.Size(45, 26);
            this.BtnView.TabIndex = 399;
            this.BtnView.UseVisualStyleBackColor = true;
            this.BtnView.Click += new System.EventHandler(this.BtnView_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(461, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 14);
            this.label1.TabIndex = 396;
            this.label1.Text = "From";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(626, 27);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(21, 14);
            this.label4.TabIndex = 397;
            this.label4.Text = "To";
            // 
            // DtptoDate
            // 
            this.DtptoDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.DtptoDate.CustomFormat = "dd/MMM/yyy";
            this.DtptoDate.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DtptoDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DtptoDate.Location = new System.Drawing.Point(652, 23);
            this.DtptoDate.Name = "DtptoDate";
            this.DtptoDate.Size = new System.Drawing.Size(119, 22);
            this.DtptoDate.TabIndex = 395;
            // 
            // SaleRegister
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 462);
            this.Controls.Add(this.listview);
            this.Controls.Add(this.panel1);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "SaleRegister";
            this.Text = "Sale Register";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        public System.Windows.Forms.ListView listview;
        private System.Windows.Forms.ColumnHeader Date;
        private System.Windows.Forms.ColumnHeader InvoiceNo;
        private System.Windows.Forms.ColumnHeader SoldBy;
        private System.Windows.Forms.ColumnHeader Customer;
        private System.Windows.Forms.ColumnHeader Address;
        private System.Windows.Forms.ColumnHeader MobNo;
        private System.Windows.Forms.ColumnHeader GSTINNo;
        private System.Windows.Forms.ColumnHeader Qty;
        private System.Windows.Forms.ColumnHeader Amount;
        private System.Windows.Forms.ColumnHeader Discount;
        private System.Windows.Forms.ColumnHeader GSTAmount;
        private System.Windows.Forms.ColumnHeader NetAmount;
        private System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.DateTimePicker DtpFromdate;
        public System.Windows.Forms.Button btnPrint;
        public System.Windows.Forms.Button BtnView;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.DateTimePicker DtptoDate;
        private System.Windows.Forms.ColumnHeader Sl;
    }
}