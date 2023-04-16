namespace POS.Report
{
    partial class PurchaseRegister
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
            this.DtpFromdate = new System.Windows.Forms.DateTimePicker();
            this.btnPrint = new System.Windows.Forms.Button();
            this.BtnView = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.DtptoDate = new System.Windows.Forms.DateTimePicker();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.NetAmount = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.GSTAmount = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.OC = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Amount = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.PtyVhDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.PtyVhNo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Party = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.InvoiceNo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Date = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Sl = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Qty = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.listview = new System.Windows.Forms.ListView();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // DtpFromdate
            // 
            this.DtpFromdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.DtpFromdate.CustomFormat = "dd/MMM/yyy";
            this.DtpFromdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DtpFromdate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DtpFromdate.Location = new System.Drawing.Point(501, 23);
            this.DtpFromdate.Name = "DtpFromdate";
            this.DtpFromdate.Size = new System.Drawing.Size(119, 20);
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
            this.label1.Location = new System.Drawing.Point(461, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 396;
            this.label1.Text = "From";
            // 
            // DtptoDate
            // 
            this.DtptoDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.DtptoDate.CustomFormat = "dd/MMM/yyy";
            this.DtptoDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DtptoDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DtptoDate.Location = new System.Drawing.Point(652, 23);
            this.DtptoDate.Name = "DtptoDate";
            this.DtptoDate.Size = new System.Drawing.Size(119, 20);
            this.DtptoDate.TabIndex = 395;
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
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(884, 77);
            this.panel1.TabIndex = 391;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(626, 27);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(20, 13);
            this.label4.TabIndex = 397;
            this.label4.Text = "To";
            // 
            // NetAmount
            // 
            this.NetAmount.Text = "Net Amount";
            this.NetAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.NetAmount.Width = 100;
            // 
            // GSTAmount
            // 
            this.GSTAmount.Text = "GST Amount";
            this.GSTAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.GSTAmount.Width = 100;
            // 
            // OC
            // 
            this.OC.Text = "OC";
            this.OC.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.OC.Width = 100;
            // 
            // Amount
            // 
            this.Amount.Text = "Amount";
            this.Amount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.Amount.Width = 100;
            // 
            // PtyVhDate
            // 
            this.PtyVhDate.Text = "Pty Vh Date";
            this.PtyVhDate.Width = 120;
            // 
            // PtyVhNo
            // 
            this.PtyVhNo.Text = "Pty Vh No";
            this.PtyVhNo.Width = 100;
            // 
            // Party
            // 
            this.Party.Text = "Party";
            this.Party.Width = 200;
            // 
            // InvoiceNo
            // 
            this.InvoiceNo.Text = "Invoice No";
            this.InvoiceNo.Width = 120;
            // 
            // Date
            // 
            this.Date.Text = "Date";
            this.Date.Width = 120;
            // 
            // Sl
            // 
            this.Sl.Text = "Sl";
            this.Sl.Width = 40;
            // 
            // Qty
            // 
            this.Qty.Text = "Qty";
            this.Qty.Width = 80;
            // 
            // listview
            // 
            this.listview.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Sl,
            this.Date,
            this.InvoiceNo,
            this.Party,
            this.PtyVhNo,
            this.PtyVhDate,
            this.Qty,
            this.Amount,
            this.GSTAmount,
            this.OC,
            this.NetAmount});
            this.listview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listview.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listview.FullRowSelect = true;
            this.listview.GridLines = true;
            this.listview.Location = new System.Drawing.Point(0, 77);
            this.listview.Name = "listview";
            this.listview.Size = new System.Drawing.Size(884, 385);
            this.listview.TabIndex = 390;
            this.listview.UseCompatibleStateImageBehavior = false;
            this.listview.View = System.Windows.Forms.View.Details;
            // 
            // PurchaseRegister
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 462);
            this.Controls.Add(this.listview);
            this.Controls.Add(this.panel1);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "PurchaseRegister";
            this.Text = "Purchase Register";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.DateTimePicker DtpFromdate;
        public System.Windows.Forms.Button btnPrint;
        public System.Windows.Forms.Button BtnView;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.DateTimePicker DtptoDate;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ColumnHeader NetAmount;
        private System.Windows.Forms.ColumnHeader GSTAmount;
        private System.Windows.Forms.ColumnHeader OC;
        private System.Windows.Forms.ColumnHeader Amount;
        private System.Windows.Forms.ColumnHeader PtyVhDate;
        private System.Windows.Forms.ColumnHeader PtyVhNo;
        private System.Windows.Forms.ColumnHeader Party;
        private System.Windows.Forms.ColumnHeader InvoiceNo;
        private System.Windows.Forms.ColumnHeader Date;
        private System.Windows.Forms.ColumnHeader Sl;
        private System.Windows.Forms.ColumnHeader Qty;
        public System.Windows.Forms.ListView listview;
    }
}