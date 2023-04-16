using POS.Core.Orders;
using POS.Core.Sales;
using POS.Core.Settings;
using POS.Data.Orders;
using POS.Data.Settings;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS.Sales
{
    public partial class RetailInvoiceDetails : Form
    {
        #region Instantmember 
        private readonly BrandMap _brandMap;
        private readonly ProductMap _productMap;
        private readonly ItemMap _itemMap;
        public List<InvoiceDetails> _invoiceDetailsList;
        private readonly PurchaseMap _purchaseMap;
        private readonly MUnitMap _mUnitMap;
        public string modeT = "Add";
        public string dP = "";
        public string dA = "";
        #endregion

        #region Constructor
        public RetailInvoiceDetails()
        {
            InitializeComponent();
            _brandMap = new BrandMap();
            _productMap = new ProductMap();
            _itemMap = new ItemMap();
            _purchaseMap = new PurchaseMap();
            _mUnitMap = new MUnitMap();
            _invoiceDetailsList = new List<InvoiceDetails>();
        }
        #endregion

        #region ClickEvent
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnAddToList_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtItem.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("You must enter item Name !", Common.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtItem.Focus();
                    return;
                }
                if (listView.Items.Count == 0)
                {
                    MessageBox.Show("No  Batcha no for selecting Please Add Batch no !", Common.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtBatchNo.Focus();
                    return;
                }
                if (listView.CheckedItems.Count == 0)
                {
                    MessageBox.Show("Please Select Batch no !", Common.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtBatchNo.Focus();
                    return;
                }

                if (txtBatchNo.Text == string.Empty)
                {
                    MessageBox.Show("You must enter Batch No !", Common.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtBatchNo.Focus();
                    return;
                }
                //if(dtpItemExpiryDate.Value.Date<=DateTime.Now.Date)
                //{
                //    MessageBox.Show("You must enter greater date from today date !", Common.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                //    txtQuantity.Focus();
                //    return;
                //}
                if (txtQuantity.Text == string.Empty)
                {
                    MessageBox.Show("You must enter Quantity !", Common.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtQuantity.Focus();
                    return;
                }
                if (txtRate.Text == string.Empty)
                {
                    MessageBox.Show("You must enter Amount !", Common.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtRate.Focus();
                    return;
                }
                if (txtGstAmount.Text == string.Empty)
                {
                    MessageBox.Show("You must enter GST Amount !", Common.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtRate.Focus();
                    return;
                }

                if (txtNetAmount.Text == string.Empty)
                {
                    MessageBox.Show("You must enter Other Charge !", Common.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtNetAmount.Focus();
                    return;
                }

                var _invoiceDetails = new InvoiceDetails
                {
                    Id = 0,
                    RetailInvoiceId = 0,

                    ItemId = Common.IntConvert(txtItem.Tag),
                    ItemName = txtItem.Text,
                    BrandId = Common.IntConvert(cmbBrand.SelectedValue),
                    BrandName = cmbBrand.Text,
                    MUnitId = Common.IntConvert(cmbMunit.SelectedValue),
                    MUnitName = cmbMunit.Text,
                    BatchNo = txtBatchNo.Text,
                    ItemExpiryDate = dtpItemExpiryDate.Value.Date,
                    Quantity = Common.IntConvert(txtQuantity.Text),

                    Rate = Common.DecimalConvert(string.Format("{0:N2}", Common.DecimalConvert(txtRate.Text))),
                    Amount = Common.DecimalConvert(string.Format("{0:N2}", Common.DecimalConvert(txtAmount.Text))),

                    DiscountPercentage = Common.DecimalConvert(string.Format("{0:N2}", Common.DecimalConvert(txtDiscountPercentage.Text))),
                    DiscountAmount = Common.DecimalConvert(string.Format("{0:N2}", Common.DecimalConvert(txtDiscountAmount.Text))),

                    SaleAmount = Common.DecimalConvert(string.Format("{0:N2}", Common.DecimalConvert(txtSaleAmount.Text))),

                    GstPercentage = Common.DecimalConvert(string.Format("{0:N2}", Common.DecimalConvert(cmbGstPercentage.Text))),
                    GstAmount = Common.DecimalConvert(string.Format("{0:N2}", Common.DecimalConvert(txtGstAmount.Text))),

                    NetAmount = Common.DecimalConvert(string.Format("{0:N2}", Common.DecimalConvert(txtNetAmount.Text))),
                };
                _invoiceDetailsList.Add(_invoiceDetails);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
            this.Close();
        }

        #endregion

        #region Function
        public void GetAllBrandIdName(int brandId)
        {
            try
            {
                var _brand = _brandMap.GetAllBrand().Where(x => x.Id == brandId).ToList();
               cmbBrand.DataSource = _brand;
                cmbBrand.ValueMember = "Id";
                cmbBrand.DisplayMember = "BrandName";
            }
            catch (Exception exception)
            {

                MessageBox.Show(exception.Message);
            }
        }
        public void GetAllMUnitIdName()
        {
            try
            {
                var _mUnit = _mUnitMap.GetAllMUnit().ToList();
                cmbMunit.DataSource = _mUnit;
                cmbMunit.ValueMember = "Id";
                cmbMunit.DisplayMember = "MUnitName";
            }
            catch (Exception exception)
            {

                MessageBox.Show(exception.Message);
            }
        }
        void AddBatchList()
        {
            try
            {
                listView.Items.Clear();
                ListViewItem li;

                var lst = _purchaseMap.GetAllPurchaseDetails().Where(x => x.ItemId == Common.IntConvert(txtItem.Tag) && x.MUnitId == Common.IntConvert(cmbMunit.SelectedValue)).Select(y => new { y.BatchNo, y.ItemExpiryDate, y.GstPercentage, y.Mrp }).ToList();
                foreach (var batch in lst)
                {
                    li = listView.Items.Add(batch.BatchNo);
                    li.Tag = batch.ItemExpiryDate;
                    li.SubItems.Add(batch.Mrp.ToString());
                    li.SubItems.Add(batch.GstPercentage.ToString());
                }

            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }
        void calculateGst()
        {

            if (listView.Items.OfType<ListViewItem>().Where(i => i.Checked == true).ToList().Count() == 0 || listView.Items.Count == 0)
            {
                cmbGstPercentage.Text = "";
                Common.ClearControl(new Control[] { txtBatchNo,txtQuantity, txtRate,txtAmount,txtDiscountAmount,txtDiscountPercentage,
                        txtSaleAmount,txtGstAmt, txtGstAmount, txtCgstAmount, txtSgstAmount, txtNetAmount });
                dtpItemExpiryDate.Value = DateTime.Now;
                return;
            }

            txtAmount.Text = ((Common.DecimalConvert(txtRate.Text) * Common.IntConvert(txtQuantity.Text))).ToString();
            decimal dPercentage = 0;
            decimal dAmount = 0;
            if (txtDiscountPercentage.Text == "" && txtDiscountAmount.Text != "")
            {
                dPercentage = (100 * Common.DecimalConvert(txtDiscountAmount.Text)) / Common.DecimalConvert(txtAmount.Text);
                txtDiscountPercentage.Text = string.Format("{0:N2}", dPercentage);
            }
            else if (txtDiscountPercentage.Text != "" && txtDiscountAmount.Text == "")
            {
                dAmount = (Common.DecimalConvert(txtAmount.Text) * Common.DecimalConvert(txtDiscountPercentage.Text)) / 100;
                txtDiscountAmount.Text = string.Format("{0:N2}", dAmount);
            }

            txtSaleAmount.Text = (Common.DecimalConvert(txtAmount.Text) - Common.DecimalConvert(txtDiscountAmount.Text)).ToString();


            decimal gst = Common.DecimalConvert(cmbGstPercentage.Text);
            txtCgstPercentage.Text = (gst / 2).ToString() + "%";
            txtSgstPercentage.Text = (gst / 2).ToString() + "%";

            decimal gstAmount = (Common.DecimalConvert(txtSaleAmount.Text) * gst) / 100;
            txtGstAmount.Text = string.Format("{0:N2}", gstAmount);
            txtGstAmt.Text = txtGstAmount.Text;
            txtSgstAmount.Text = (gstAmount / 2).ToString();
            txtCgstAmount.Text = (gstAmount / 2).ToString();

            txtNetAmount.Text = (Common.DecimalConvert(txtSaleAmount.Text) + Common.DecimalConvert(txtGstAmount.Text)).ToString();
            //txtNetAmount.Text = string.Format("{0:N2}", Math.Round((Common.DecimalConvert(txtAmount.Text) + Common.DecimalConvert(txtGstAmount.Text))));

        }
        #endregion

        #region TextchangeEvent
        private void txtQuantity_TextChanged(object sender, EventArgs e)
        {
            calculateGst();
        }
        #endregion

        #region LoadEvent
        private void InvoiceDetails_Load(object sender, EventArgs e)
        {
            GetAllMUnitIdName();
            if (modeT == "Add")
            {
                cmbGstPercentage.SelectedIndex = 2;
            }
            else
            {
                cmbMunit.SelectedValue = cmbMunit.Tag;
               
           
                foreach (ListViewItem item in listView.Items)
                {
                   if( item.Text.ToUpper()==cmbBrand.Tag.ToString().ToUpper())
                    {
                        item.Checked = true;
                        
                        if (dP != "")
                            txtDiscountPercentage.Text = dP;
                        if (dA != "")
                            txtDiscountAmount.Text = dA;
                        calculateGst();

                    }
                }
               

            }
        }
        #endregion

        #region ItemCheckEvent
        private void listView_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            try
            {
                
                if (listView.Items.OfType<ListViewItem>().Where(i => i.Checked == true).ToList().Count() == 0 || listView.Items.Count==0)
                {
                    cmbGstPercentage.Text = "";
                    Common.ClearControl(new Control[] { txtBatchNo,txtQuantity, txtRate,txtAmount,txtDiscountAmount,txtDiscountPercentage,
                        txtSaleAmount,txtGstAmt, txtGstAmount, txtCgstAmount, txtSgstAmount, txtNetAmount });
                    dtpItemExpiryDate.Value = DateTime.Now;
                    return;
                }
                
                    int cnt = 0;

                foreach (ListViewItem item in listView.Items.OfType<ListViewItem>().Where(i => i.Checked == true).ToList())
                {
                    cnt += 1;
                    if (cnt > 1)
                    {
                        MessageBox.Show("Please select only one Batch no");
                        item.Checked = false;
                        return;
                    }
                    if (cnt == 1)
                    {
                        txtBatchNo.Text = item.Text;
                        dtpItemExpiryDate.Value = Convert.ToDateTime(item.Tag);
                        txtRate.Text = item.SubItems[1].Text;
                        txtQuantity.Text = "1";
                        cmbGstPercentage.Text= item.SubItems[2].Text;                        
                        txtQuantity.Focus();
                        calculateGst();
                    }
                    
                }
            }
            catch (Exception exception)
            {

                MessageBox.Show( exception.Message);
            }
        }
        #endregion

        #region SelectedIndexChanged Event
        private void cmbMunit_SelectedIndexChanged(object sender, EventArgs e)
        {
             AddBatchList();
            calculateGst();


        }
        #endregion

        #region LeaveEvent
        private void txtDiscountPercentage_Leave(object sender, EventArgs e)
        {
            
            calculateGst();
        }
        private void txtDiscountAmount_Leave(object sender, EventArgs e)
        {
            
            calculateGst();
        }
        #endregion

        #region KeyDownEvent
        private void txtItemName_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {

                IList<ListViewItem> listItems = new List<ListViewItem>();
                List<Item> _itemList = _itemMap.GetAllItem();
                int brandId = 0;

                if ((e.KeyCode == Keys.Enter) && Common.IsNumeric(txtItem.Text.Trim()))
                {
                    var itemNameId = from item in _itemList
                                     where item.Id == Common.IntConvert(txtItem.Text)
                                     select new { Id = item.Id, ItemName = item.ItemName, BrandId = item.BrandId };
                    if (itemNameId.Count() == 0)
                        MessageBox.Show("There is no Item. Please enter new Item !", Common.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                    {
                        foreach (var item in itemNameId)
                        {
                            txtItem.Tag = item.Id;
                            txtItem.Text = item.ItemName;
                            brandId = item.BrandId;
                        }
                        AddBatchList();
                        cmbMunit.Focus();
                    }
                }
                else if ((e.KeyCode == Keys.Enter) || e.KeyCode >= Keys.A && e.KeyCode <= Keys.Z)
                {
                    txtItem.Clear();
                    foreach (var item in _itemList)
                    {
                        ListViewItem listItem = new ListViewItem(item.Id.ToString());
                        listItem.SubItems.Add(item.ItemName);
                        listItems.Add(listItem);
                        brandId = item.BrandId;
                    }
                    ViewDialog frmView = new ViewDialog();
                    frmView.Text = "Item list";
                    frmView.SetDataSource(listItems, new string[] { "Item Code", "Item Name" }, new HorizontalAlignment[] { HorizontalAlignment.Center, HorizontalAlignment.Left }, new int[] { 80, 200 });
                    frmView.SearchInitial = Convert.ToChar(e.KeyValue).ToString();
                    frmView.ShowDialog();
                    if (frmView.lvwData.SelectedItems.Count <= 0)
                        return;
                    txtItem.Tag = Convert.ToInt32(frmView.lvwData.SelectedItems[0].Text);
                    txtItem.Text = frmView.lvwData.SelectedItems[0].SubItems[1].Text;

                    AddBatchList();
                    cmbMunit.Focus();
                }
                GetAllBrandIdName(brandId);

            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }
        private void txtQuantity_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtDiscountAmount.Focus();
            }
        }

        private void txtDiscountPercentage_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnAddToList.Focus();
                //btnAddToList_Click(sender, e);
            }
        }
        private void txtDiscountAmount_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnAddToList.Focus();
                //btnAddToList_Click(sender, e);
            }
        }
        #endregion

        #region EnterEvent
        private void txtDiscountPercentage_Enter(object sender, EventArgs e)
        {
            txtDiscountPercentage.Text = "";
            txtDiscountAmount.Text = "";
        }
        private void txtDiscountAmount_Enter(object sender, EventArgs e)
        {
            txtDiscountPercentage.Text = "";
            txtDiscountAmount.Text = "";
        }
        #endregion

        private void cmbMunit_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                listView.Focus();
        }
    }
}
