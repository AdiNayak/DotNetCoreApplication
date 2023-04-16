using POS.Core.Sales;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using POS.Data.Settings;
using POS.Data.Sales;
using POS.Core;
using System.IO;

namespace POS.Sales
{
    /// <summary>
    /// Developed By:Adeita Kumar Nayak
    /// Date:18-08-2017
    /// </summary>
    public partial class RetailInvoice : formTemplate,IUserControl
    {
        #region InstantMember
        private FormModes modeType;
        private readonly UserMap _userMap;
        private readonly RetailInvoiceMap _retailInvoiceMap;
        #endregion

        #region Constructor
        public RetailInvoice()
        {
            InitializeComponent();
            _retailInvoiceMap = new RetailInvoiceMap();
            _userMap = new UserMap();
        }
        #endregion

        #region FormEvent
        public FormModes CurrentMode
        {
            get
            {
                return modeType;
            }
        }
        public FormModes Add()
        {
            try
            {
                Common.EnableControl(new Control[] {txtCustomerName,txtAddress, txtMobNo,txtGstinNo, txtNarration, listview, btnCreate }, true);
                Common.ClearControl(new Control[] { txtInvcNo, txtSaleBy, txtCustomerName,txtAddress,txtMobNo,txtGstinNo,txtTotalQuantity,txtTotalGstAmount, txtTotalAmount, txtTotalDiscountAmount, txtTotalNetAmount, txtNarration, listview });
                txtSaleBy.Text = Program.userName;
                txtSaleBy.Tag = Program.userId;
                txtCustomerName.Focus();
                modeType = FormModes.Add;
               
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }

            return modeType;
        }
        public FormModes Delete()
        {
            throw new NotImplementedException();
        }
        public FormModes Print()
        {
            BillPrint();
            modeType = FormModes.Print;
            return modeType;
        }
        public FormModes Save()
        {
            int result = 0;
            try
            {
                if (txtSaleBy.Text.Trim() == "")
                {
                    MessageBox.Show("You must enter Party Employee name", Common.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtSaleBy.Focus();
                    return modeType;
                }
                if (txtCustomerName.Text.Trim() == "")
                {
                    MessageBox.Show("You must enter Customer Name", Common.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtCustomerName.Focus();
                    return modeType;
                }
                if (listview.Items.Count <= 0)
                {
                    MessageBox.Show("No Item(s) for sale !", Common.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return modeType;
                }
                List<InvoiceDetails> _invoiceDetailsList = new List<InvoiceDetails>();

                if (MessageBox.Show("Are you sure to save this record ?", Common.ApplicationName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    foreach (ListViewItem lvItem in listview.Items)
                    {
                        var dt = Convert.ToDateTime(lvItem.SubItems[9].Text);
                        var _invoiceDetails = new InvoiceDetails()
                        {
                            Id = Common.IntConvert(lvItem.Text),
                            RetailInvoiceId = Common.IntConvert(lvItem.SubItems[1].Text),
                            ItemId = Common.IntConvert(lvItem.SubItems[2].Text),
                            BrandId = Common.IntConvert(lvItem.SubItems[4].Text),
                            MUnitId = Common.IntConvert(lvItem.SubItems[6].Text),
                            BatchNo = lvItem.SubItems[8].Text,
                            ItemExpiryDate = Convert.ToDateTime(lvItem.SubItems[9].Text),
                            Quantity = Common.IntConvert(lvItem.SubItems[10].Text),
                            Rate = Common.DecimalConvert(lvItem.SubItems[11].Text),
                            Amount = Common.DecimalConvert(lvItem.SubItems[12].Text),
                            DiscountPercentage = Common.DecimalConvert(lvItem.SubItems[13].Text),
                            DiscountAmount = Common.DecimalConvert(lvItem.SubItems[14].Text),
                            SaleAmount = Common.DecimalConvert(lvItem.SubItems[15].Text),
                            GstPercentage = Common.DecimalConvert(lvItem.SubItems[16].Text),
                            GstAmount = Common.DecimalConvert(lvItem.SubItems[17].Text),
                           NetAmount = Common.DecimalConvert(lvItem.SubItems[18].Text),                            
                            Status = 0,
                        };
                        _invoiceDetailsList.Add(_invoiceDetails);
                    }
                    var _invoice = new Invoice()
                    {
                        Id = Common.IntConvert(txtInvcNo.Tag),
                        FinacialId = Program.FinacialYearId,
                        InvoiceNo = txtInvcNo.Text,
                        Date = dtpDate.Value.Date,
                        SellerId = Common.IntConvert(txtSaleBy.Tag),
                        CustomerName = txtCustomerName.Text,
                        Address = txtAddress.Text,
                        MobileNo=txtMobNo.Text,
                        GstinNo=txtGstinNo.Text,
                        TotalQuantity = Common.IntConvert(txtTotalQuantity.Text),
                        TotalAmount = Common.DecimalConvert(txtTotalAmount.Text),
                        TotalDiscountAmount = Common.DecimalConvert(txtTotalDiscountAmount.Text),
                        TotalSaleAmount = Common.DecimalConvert(txtTotalSaleAmount.Text),
                        TotalGstAmount = Common.DecimalConvert(txtTotalGstAmount.Text),                       
                        TotalNetAmount = Common.DecimalConvert(txtTotalNetAmount.Text),
                        Narration = txtNarration.Text,
                        Status = 0,
                        _invoiceDetailsList = _invoiceDetailsList,
                    };

                    if (modeType == FormModes.Add)
                    {
                        result = _retailInvoiceMap.UpsertInvoice(_invoice, SaveTypes.Insert);
                    }
                    else if (modeType == FormModes.View)
                    {
                        result = _retailInvoiceMap.UpsertInvoice(_invoice, SaveTypes.Update);
                    }
                    if (result > 0)
                    {
                        Common.EnableControl(new Control[] { txtSaleBy, txtCustomerName, txtAddress, txtMobNo, txtGstinNo, txtNarration, listview, btnCreate }, false);
                        if (modeType == FormModes.Add)
                            txtInvcNo.Text = _retailInvoiceMap.GetAllInvoice().Where(x => x.Id == result).FirstOrDefault().InvoiceNo;
                    }
                    else
                        MessageBox.Show("!Failed to saved", Common.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Error);

                    modeType = FormModes.Save;
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }

            return modeType;
        }
        public FormModes View()
        {
            try
            {
                Common.EnableControl(new Control[] {txtCustomerName, txtAddress, txtMobNo, txtGstinNo, txtNarration, listview, btnCreate }, true);
                Common.ClearControl(new Control[] { txtInvcNo, txtSaleBy, txtCustomerName, txtAddress, txtMobNo, txtGstinNo, txtTotalQuantity, txtTotalAmount, txtTotalDiscountAmount, txtTotalSaleAmount,txtTotalDiscountAmount, txtTotalNetAmount, txtNarration, listview });

                IList<ListViewItem> listItems = new List<ListViewItem>();
                var _invoiceList = _retailInvoiceMap.GetAllInvoice().Select(x => new Invoice { Id = x.Id, InvoiceNo = x.InvoiceNo, TotalNetAmount = x.TotalNetAmount });
                foreach (var invoice in _invoiceList)
                {
                    ListViewItem listItem = new ListViewItem(invoice.Id.ToString());
                    listItem.SubItems.Add(invoice.InvoiceNo);
                    listItem.SubItems.Add(invoice.TotalNetAmount.ToString());
                    listItems.Add(listItem);
                }
                ViewDialog frmView = new ViewDialog();
                frmView.Text = "Party list";
                frmView.SetDataSource(listItems, new string[] { "Id", "Invoice No", "Invoice Amount" }, new HorizontalAlignment[] { HorizontalAlignment.Left, HorizontalAlignment.Left, HorizontalAlignment.Right }, new int[] { 0, 100, 150 });
                frmView.ShowDialog();
                if (frmView.lvwData.SelectedItems.Count <= 0)
                    return modeType;
                txtInvcNo.Tag = Convert.ToInt32(frmView.lvwData.SelectedItems[0].Text);
                txtInvcNo.Text = frmView.lvwData.SelectedItems[0].SubItems[1].Text;
                txtCustomerName.Focus();
               GetAll(Common.IntConvert(txtInvcNo.Tag));
                modeType = FormModes.View;


            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
            return modeType;
        }
        #endregion

        #region ClickEvent
        private void btnCreate_Click(object sender, EventArgs e)
        {
            RetailInvoiceDetails invoiceDetails = new RetailInvoiceDetails();
            invoiceDetails.ShowDialog();
            var _invoiceDetailsList = invoiceDetails._invoiceDetailsList;
            if (_invoiceDetailsList.Count > 0)
            {
                foreach (var invoiceDetail in _invoiceDetailsList)
                {
                    ListViewItem li = new ListViewItem();
                    li = listview.Items.Add(invoiceDetail.Id.ToString());//0
                    li.SubItems.Add(invoiceDetail.RetailInvoiceId.ToString());//1
                    li.SubItems.Add(invoiceDetail.ItemId.ToString());//2
                    li.SubItems.Add(invoiceDetail.ItemName.ToString());//3
                    li.SubItems.Add(invoiceDetail.BrandId.ToString());//4
                    li.SubItems.Add(invoiceDetail.BrandName.ToString());//5
                    li.SubItems.Add(invoiceDetail.MUnitId.ToString());//6
                    li.SubItems.Add(invoiceDetail.MUnitName.ToString());//7
                    li.SubItems.Add(invoiceDetail.BatchNo.ToString());//8
                    li.SubItems.Add(invoiceDetail.ItemExpiryDate.ToString());//9
                    li.SubItems.Add(invoiceDetail.Quantity.ToString());//10
                    li.SubItems.Add(invoiceDetail.Rate.ToString());//11
                    li.SubItems.Add(invoiceDetail.Amount.ToString());//12
                    li.SubItems.Add(invoiceDetail.DiscountPercentage.ToString());//13
                    li.SubItems.Add(invoiceDetail.DiscountAmount.ToString());//14
                    li.SubItems.Add(invoiceDetail.SaleAmount.ToString());//15
                    li.SubItems.Add(invoiceDetail.GstPercentage.ToString());//16
                    li.SubItems.Add(invoiceDetail.GstAmount.ToString());//17                         
                    li.SubItems.Add(invoiceDetail.NetAmount.ToString());//18                    
                }
                Calculate();
                txtNarration.Focus();
            }
        }
        #endregion

        #region TextChangeEvent
        private void txtTotalNetAmount_TextChanged(object sender, EventArgs e)
        {
             lblPaybleAmount.Text= txtTotalNetAmount.Text;
        }

        #endregion

        #region LoadEvent
        private void RetailInvoice_Load(object sender, EventArgs e)
        {
            
            Add();
           
        }
        #endregion

        #region Function
        void GetAll(Int32 InvoiceId)
        {
            try
            {
                var invoice = _retailInvoiceMap.GetAllInvoice().Where(x => x.Id == Convert.ToInt32(InvoiceId)).FirstOrDefault();
                dtpDate.Value = (DateTime)invoice.Date;
                txtSaleBy.Tag = invoice.SellerId;
                txtSaleBy.Text = invoice.UserName;
                txtCustomerName.Text = invoice.CustomerName;
                txtAddress.Text = invoice.Address;
                txtMobNo.Text = invoice.MobileNo;
                txtGstinNo.Text = invoice.GstinNo;
                txtTotalQuantity.Text = invoice.TotalQuantity.ToString();
                txtTotalAmount.Text = invoice.TotalDiscountAmount.ToString();
                txtTotalSaleAmount.Text = invoice.TotalSaleAmount.ToString();
                txtTotalGstAmount.Text = invoice.TotalGstAmount.ToString();
                txtTotalNetAmount.Text = invoice.TotalNetAmount.ToString();
                txtNarration.Text = invoice.Narration;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
            GetAllDetails(InvoiceId);
        }
        void GetAllDetails(Int32 InvoiceId)
        {
            try
            {
                var _invoiceDetails = _retailInvoiceMap.GetAllInvoiceDetails().Where(x => x.RetailInvoiceId == InvoiceId).ToList();
                if (_invoiceDetails.Count > 0)
                {
                    foreach (var invoiceDetail in _invoiceDetails)
                    {

                        ListViewItem li = new ListViewItem();
                        li = listview.Items.Add(invoiceDetail.Id.ToString());//0
                        li.SubItems.Add(invoiceDetail.RetailInvoiceId.ToString());//1
                        li.SubItems.Add(invoiceDetail.ItemId.ToString());//2
                        li.SubItems.Add(invoiceDetail.ItemName.ToString());//3
                        li.SubItems.Add(invoiceDetail.BrandId.ToString());//4
                        li.SubItems.Add(invoiceDetail.BrandName.ToString());//5
                        li.SubItems.Add(invoiceDetail.MUnitId.ToString());//6
                        li.SubItems.Add(invoiceDetail.MUnitName.ToString());//7
                        li.SubItems.Add(invoiceDetail.BatchNo.ToString());//8
                        li.SubItems.Add(invoiceDetail.ItemExpiryDate.ToString());//9
                        li.SubItems.Add(invoiceDetail.Quantity.ToString());//10
                        li.SubItems.Add(invoiceDetail.Rate.ToString());//11
                        li.SubItems.Add(invoiceDetail.Amount.ToString());//12
                        li.SubItems.Add(invoiceDetail.DiscountPercentage.ToString());//13
                        li.SubItems.Add(invoiceDetail.DiscountAmount.ToString());//14
                        li.SubItems.Add(invoiceDetail.SaleAmount.ToString());//15
                        li.SubItems.Add(invoiceDetail.GstPercentage.ToString());//16
                        li.SubItems.Add(invoiceDetail.GstAmount.ToString());//17                         
                        li.SubItems.Add(invoiceDetail.NetAmount.ToString());//18  
                    }
                    Calculate();
                }

            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }
        void Calculate()
        {
            try
            {
                Common.ClearControl(new Control[] { txtTotalQuantity, txtTotalAmount, txtTotalDiscountAmount, txtTotalSaleAmount, txtTotalGstAmount, txtTotalNetAmount });
                foreach (ListViewItem item in listview.Items)
                {
                    txtTotalQuantity.Text = ((Common.IntConvert(txtTotalQuantity.Text) + Common.IntConvert(item.SubItems[10].Text))).ToString();
                    txtTotalAmount.Text = string.Format("{0:N2}", Math.Round((Common.DecimalConvert(txtTotalAmount.Text) + Common.DecimalConvert(item.SubItems[12].Text))));
                    txtTotalDiscountAmount.Text = string.Format("{0:N2}", Math.Round((Common.DecimalConvert(txtTotalDiscountAmount.Text) + Common.DecimalConvert(item.SubItems[14].Text))));
                    txtTotalSaleAmount.Text = string.Format("{0:N2}", Math.Round((Common.DecimalConvert(txtTotalSaleAmount.Text) + Common.DecimalConvert(item.SubItems[15].Text))));
                    txtTotalGstAmount.Text = string.Format("{0:N2}", Math.Round((Common.DecimalConvert(txtTotalGstAmount.Text) + Common.DecimalConvert(item.SubItems[17].Text))));
                    txtTotalNetAmount.Text = string.Format("{0:N2}", Math.Round((Common.DecimalConvert(txtTotalNetAmount.Text) + Common.DecimalConvert(item.SubItems[18].Text))));
                }
            }
            catch (Exception exception)
            {

                MessageBox.Show(exception.Message);
            }
        }

        private void BillPrint()
        {
            try
            {
                if (!Directory.Exists(Application.StartupPath + @"\Print"))
                    Directory.CreateDirectory(Application.StartupPath + @"\Print");
                File.Delete(Application.StartupPath + @"\Print\BillPrint.html");
                FileStream fs = new FileStream(Application.StartupPath + @"\Print\BillPrint.html", FileMode.OpenOrCreate, FileAccess.ReadWrite);
                StreamWriter sr = new StreamWriter(fs);
                sr.BaseStream.Seek(0, SeekOrigin.Begin);
                sr.WriteLine("<html><head><title></title></head><body style='font-family: Verdana;'>");
                sr.WriteLine("<table style='width:100%; font-size: 15px;' ><tr align='center'><td><div><span style='font-size:25px;padding-bottom:10px;'>ANKIT ENTERPRISES</span><br /><span>BHUBANESWAR-751006.</span><br /><span style='font-size:20px;'><b>Reatil Invoice</b></span></div></td></tr></table>");
                sr.WriteLine("<table style='width:100%;font-size: 15px;'><tr><td align='left'><div><span>Name: " + txtCustomerName.Text + "</span><br /><span>Address: " + txtAddress.Text + "</span><br /><span>GSTIN: " + txtGstinNo.Text + "</span></div>");
                sr.WriteLine("</td><td align='right' style='font-style:italic'><div><span>INVC: " + txtInvcNo.Text+"</span><br /><span>Date: "+dtpDate.Value.Date.ToString("dd-MM-yyyy")+"</span></div></td></tr></table><br />");
               
                sr.WriteLine("<table style= 'width:100%;font-size:15px;'>");
                sr.WriteLine("<tr ><td align='left'style='border-bottom:1px solid;'>Sl.</td> ");
                sr.WriteLine("<td align='left'style='border-bottom:1px solid;'>Particulars</td>");
                sr.WriteLine("<td align='left'style='border-bottom:1px solid;'>Munit</td>");
                sr.WriteLine("<td align='left'style='border-bottom:1px solid;'>Qty</td>");
                sr.WriteLine("<td align='right'style='border-bottom:1px solid;'>Rate</td>");
                sr.WriteLine("<td align='right'style='border-bottom:1px solid;'>Dnt&nbsp;[&nbsp;%&nbsp;] </td>");
                sr.WriteLine("<td align='right'style='border-bottom:1px solid;'>Gst&nbsp;[&nbsp;%&nbsp;]</td>");
                sr.WriteLine("<td align='right'style='border-bottom:1px solid;'>Net Amt</td></tr>");
                int cnt = 0;
                foreach (ListViewItem li in listview.Items)
                {
                    cnt += 1;
                    sr.WriteLine("<tr><td align='left'>" + cnt + "</td> ");
                    sr.WriteLine("<td align='left'>" + li.SubItems[3].Text + "</td>");
                    sr.WriteLine("<td align='left'>" + li.SubItems[7].Text + "</td>");
                    sr.WriteLine("<td align='left'>" + li.SubItems[10].Text + "</td>");
                    sr.WriteLine("<td align='right'>" + li.SubItems[11].Text + "</td>");
                    sr.WriteLine("<td align='right'>" + li.SubItems[13].Text + "</td>");
                    sr.WriteLine("<td align='right'>" + li.SubItems[16].Text + "</td>");
                    sr.WriteLine("<td align='right'>" + li.SubItems[18].Text + "</td></tr>");
                }
                sr.WriteLine("<tr ><td align='left'style='border-top:1px solid;'></td> ");
                sr.WriteLine("<td align='left'style='border-top:1px solid;'><b>Total</b></td>");
                sr.WriteLine("<td align='left'style='border-top:1px solid;'></td>");
                sr.WriteLine("<td align='left'style='border-top:1px solid;'><b>"+txtTotalQuantity.Text+"</b></td>");
                sr.WriteLine("<td align='right'style='border-top:1px solid;'></td>");
                sr.WriteLine("<td align='right'style='border-top:1px solid;'></td>");
                sr.WriteLine("<td align='right'style='border-top:1px solid;'></td>");
                sr.WriteLine("<td align='right'style='border-top:1px solid;'><b>" + txtTotalNetAmount.Text + "</b></td></tr>");
                sr.WriteLine("</table>");
                sr.WriteLine("  <table style='position:fixed;left:0px;bottom:0px;padding:22px;width:100 %;font-size:12px;'><tr><td><b>Include</b><br />Discount  &nbsp;[Rs.]:&nbsp; &nbsp;"+txtTotalDiscountAmount.Text+"<br /><span>GST&nbsp;[Rs.]&nbsp;:" + txtTotalGstAmount.Text + "&nbsp;&nbsp;</span>,<span>CGST&nbsp;[Rs.]&nbsp;:" +Common.DecimalConvert(txtTotalGstAmount.Text )/2+ "&nbsp;&nbsp</span>,<span>&nbsp;SGST&nbsp;[Rs.]&nbsp;:" + Common.DecimalConvert(txtTotalGstAmount.Text) / 2 + "</span></td></tr>");
                sr.WriteLine("<tr><td><div><span style='text-align:left;font-size:12px;'><b>Adress:</b><br />" + Program.address+"<br />"+Program.city+"-"+Program.pin+"<br />Email Id:"+Program.email+"<br />Mob : "+Program.contactNo+", Ph : "+Program.phoneNo+"<br /><b sstyle='font - size:15px;'> GSTIN:"+Program.gstNo+ "</b></span></div></td><td align='right'>");
                sr.WriteLine(" <div style='position:fixed;right:0px;bottom:0px;padding:22px;width:100%;'><span style='text-align:left;font-size:13px;'>for " + Program.companyName + "</span></div></td></tr><tr> <td style='font-size:10px'><div><b>Term and condition:</b><br />1.The regstration certificate is valid on the date of issue of this Tax/Retail Invoice.<br />2.If Goods are once sold then there is no return.<br />3.All disputed arrising out of this Invoice are subjected jurisdiction.<br /></div></td></tr></table>");
                sr.WriteLine("</body></html>");
                sr.Flush();
                sr.Close();
                System.Diagnostics.Process.Start(Application.StartupPath + @"\Print\BillPrint.html");
                //PrintThroughBrowser();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
        private void PrintThroughBrowser()
        {

            // Create a WebBrowser instance. 
            WebBrowser webBrowserForPrinting = new WebBrowser();

            // Add an event handler that prints the document after it loads.
            webBrowserForPrinting.DocumentCompleted +=
                new WebBrowserDocumentCompletedEventHandler(PrintDocument);

            // Set the Url property to load the document.
            webBrowserForPrinting.Url = new Uri(Application.StartupPath + @"\Print\BillPrint.html");
        }

        private void PrintDocument(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            // Print the document now that it is fully loaded.
            ((WebBrowser)sender).Print();

            // Dispose the WebBrowser now that the task is complete. 
            ((WebBrowser)sender).Dispose();
        }


        #endregion

        #region DoubleClickEvent
        private void listview_DoubleClick(object sender, EventArgs e)
        {
            ListViewItem li = null;
            try
            {
                RetailInvoiceDetails retailInvoiceDetails = new RetailInvoiceDetails();
                li = listview.SelectedItems[0];
                retailInvoiceDetails.txtItem.Tag = li.SubItems[2].Text;
                retailInvoiceDetails.txtItem.Text = li.SubItems[3].Text;

                retailInvoiceDetails.GetAllBrandIdName(Common.IntConvert(li.SubItems[4].Text));

                retailInvoiceDetails.GetAllMUnitIdName();
                retailInvoiceDetails.cmbMunit.Tag = (Common.IntConvert(li.SubItems[6].Text));
                retailInvoiceDetails.cmbMunit.Text = li.SubItems[7].Text;

                retailInvoiceDetails.cmbBrand.Tag = li.SubItems[8].Text;
                retailInvoiceDetails.txtBatchNo.Text = li.SubItems[8].Text;
                retailInvoiceDetails.dtpItemExpiryDate.Value = Convert.ToDateTime(li.SubItems[9].Text);
                retailInvoiceDetails.txtQuantity.Text = li.SubItems[10].Text;
                retailInvoiceDetails.txtRate.Text = li.SubItems[11].Text;
                retailInvoiceDetails.txtAmount.Text = li.SubItems[12].Text;


                retailInvoiceDetails.txtDiscountPercentage.Text = li.SubItems[13].Text;
                retailInvoiceDetails.txtDiscountAmount.Text = li.SubItems[14].Text;
                retailInvoiceDetails.dP = li.SubItems[13].Text;
                retailInvoiceDetails.dA= li.SubItems[14].Text;


                retailInvoiceDetails.txtDiscountAmount.Text = li.SubItems[15].Text;
                retailInvoiceDetails.cmbGstPercentage.Text = li.SubItems[16].Text;
                retailInvoiceDetails.txtGstAmount.Text = li.SubItems[17].Text;
                retailInvoiceDetails.txtNetAmount.Text = li.SubItems[18].Text;
                retailInvoiceDetails.modeT = "Edit";
                retailInvoiceDetails.ShowDialog();

               
                var _invoiceDetailsList = retailInvoiceDetails._invoiceDetailsList;
                if (_invoiceDetailsList.Count > 0)
                {
                    foreach (var invoiceDetail in _invoiceDetailsList)
                    {
                        li.SubItems[2].Text=(invoiceDetail.ItemId.ToString());//2
                        li.SubItems[3].Text=(invoiceDetail.ItemName.ToString());//3
                        li.SubItems[4].Text=(invoiceDetail.BrandId.ToString());//4
                        li.SubItems[5].Text=(invoiceDetail.BrandName.ToString());//5
                        li.SubItems[6].Text=(invoiceDetail.MUnitId.ToString());//6
                        li.SubItems[7].Text=(invoiceDetail.MUnitName.ToString());//7
                        li.SubItems[8].Text=(invoiceDetail.BatchNo.ToString());//8
                        li.SubItems[9].Text=(invoiceDetail.ItemExpiryDate.ToString());//9
                        li.SubItems[10].Text=(invoiceDetail.Quantity.ToString());//10
                        li.SubItems[11].Text=(invoiceDetail.Rate.ToString());//11
                        li.SubItems[12].Text=(invoiceDetail.Amount.ToString());//12
                        li.SubItems[13].Text=(invoiceDetail.DiscountPercentage.ToString());//13
                        li.SubItems[14].Text=(invoiceDetail.DiscountAmount.ToString());//14
                        li.SubItems[15].Text=(invoiceDetail.SaleAmount.ToString());//15
                        li.SubItems[16].Text=(invoiceDetail.GstPercentage.ToString());//16
                        li.SubItems[17].Text=(invoiceDetail.GstAmount.ToString());//17                         
                        li.SubItems[18].Text=(invoiceDetail.NetAmount.ToString());//18                    
                    }
                    Calculate();
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }
        #endregion

        #region KeydownEvent
        private void txtCustomerName_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Enter)
            {
                if (txtCustomerName.Text.Trim() == "")
                {
                    MessageBox.Show("You must enter Customer Name", Common.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtCustomerName.Focus();
                    return;
                }
                else
                    txtAddress.Focus();
            }
        }

        private void txtAddress_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            { txtMobNo.Focus(); }
        }

        private void txtMobNo_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Enter)
            { txtGstinNo.Focus(); }
        }

        private void txtGstinNo_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Enter)
            btnCreate_Click(sender, e);
        }
        #endregion
    }
}
