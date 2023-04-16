using POS.Core.Orders;
using POS.Core.Settings;
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

namespace POS.Orders
{
    public partial class PurchaseOrderDetails : Form
    {
        #region InstantMember
        private readonly BrandMap _brandMap;
        private readonly ProductMap _productMap;
        private readonly ItemMap _itemMap;
        private readonly MUnitMap _mUnitMap;
        public List<PurchaseDetails> _purchaseDetailsList;
        public string modeT = "Add";
        #endregion

        #region Constructor
        public PurchaseOrderDetails()
        {
            InitializeComponent();
            _brandMap = new BrandMap();
            _productMap = new ProductMap();
            _itemMap = new ItemMap();
            _mUnitMap = new MUnitMap();
            _purchaseDetailsList = new List<PurchaseDetails>();
        }
        #endregion

        #region ClickEvent
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
                if (txtBatchNo.Text == string.Empty)
                {
                    MessageBox.Show("You must enter Batch No !", Common.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtBatchNo.Focus();
                    return;
                }
                if (dtpItemExpiryDate.Value.Date <= DateTime.Now.Date)
                {
                    MessageBox.Show("You must enter greater date from today date !", Common.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dtpItemExpiryDate.Focus();
                    return;
                }
                if (txtQuantity.Text == string.Empty)
                {
                    MessageBox.Show("You must enter Quantity !", Common.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtQuantity.Focus();
                    return;
                }
                if (txtAmount.Text == string.Empty)
                {
                    MessageBox.Show("You must enter Amount !", Common.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtAmount.Focus();
                    return;
                }
                if (txtGstAmount.Text == string.Empty)
                {
                    MessageBox.Show("You must enter GST Amount !", Common.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtAmount.Focus();
                    return;
                }

                if (txtNetAmount.Text == string.Empty)
                {
                    MessageBox.Show("You must enter Other Charge !", Common.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtNetAmount.Focus();
                    return;
                }
                if (txtRateperItem.Text == string.Empty)
                {
                    MessageBox.Show("You must enter Rate !", Common.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtNetAmount.Focus();
                    return;
                }
                if (txtMinSalePrice.Text == string.Empty)
                {
                    MessageBox.Show("You must enter min Sale Price", Common.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtMinSalePrice.Focus();
                    return;
                }
                if (txtMinSalePrice.Text == string.Empty)
                {
                    MessageBox.Show("You must enter min Sale Price", Common.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtMinSalePrice.Focus();
                    return;
                }

                //cmbProduct.SelectedValue =cmbProduct.Tag;

                var _purchaseDetails = new PurchaseDetails
                {
                    Id = 0,
                    PurchaseId = 0,
                    ItemId = Common.IntConvert(txtItem.Tag),
                    ItemName = txtItem.Text,
                    BrandId = Common.IntConvert(cmbBrand.SelectedValue),
                    BrandName = cmbBrand.Text,
                    MUnitId = Common.IntConvert(cmbMunit.SelectedValue),
                    MUnitName = cmbMunit.Text,
                    BatchNo = txtBatchNo.Text,
                    ItemExpiryDate = dtpItemExpiryDate.Value.Date,
                    Quantity = Common.IntConvert(txtQuantity.Text),
                    Amount = Common.DecimalConvert(string.Format("{0:N2}", Common.DecimalConvert(txtAmount.Text))),
                    GstPercentage = Common.DecimalConvert(string.Format("{0:N2}", Common.DecimalConvert(cmbGstPercentage.Text))),
                    GstAmount = Common.DecimalConvert(string.Format("{0:N2}", Common.DecimalConvert(txtGstAmount.Text))),
                    OtherCharge = Common.DecimalConvert(string.Format("{0:N2}", Common.DecimalConvert(txtOtherCharge.Text))),
                    NetAmount = Common.DecimalConvert(txtNetAmount.Text),
                    RateperItem = Common.DecimalConvert(string.Format("{0:N2}", Common.DecimalConvert(txtRateperItem.Text))),
                    MinSalePrice = Common.DecimalConvert(txtMinSalePrice.Text),
                    Mrp = Common.DecimalConvert(txtMrp.Text),
                };
                _purchaseDetailsList.Add(_purchaseDetails);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
            this.Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
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
        private void Calculate()
        {
            try
            {
                decimal totalAmount = 0, gstAmount = 0, minSaleAmount = 0, mrpAmount = 0;
                //totalAmount = Common.DecimalConvert(txtAmount.Text) * Common.IntConvert(txtQuantity.Text);
                totalAmount = Common.DecimalConvert(txtAmount.Text);
                gstAmount = (totalAmount * Common.DecimalConvert(cmbGstPercentage.Text)) / 100;
                txtGstAmount.Text = gstAmount.ToString();
                totalAmount += gstAmount;
                txtNetAmount.Text = string.Format("{0:N2}", Math.Round(Common.DecimalConvert(txtOtherCharge.Text) + totalAmount));
                if (Common.IntConvert(txtQuantity.Text) <= 0)
                    return;
                txtRateperItem.Text = (Common.DecimalConvert(txtNetAmount.Text) / Common.IntConvert(txtQuantity.Text)).ToString();

                minSaleAmount = (Common.DecimalConvert(txtRateperItem.Text) * Program.minSalePercentage) / 100;
                txtMinSalePrice.Text = string.Format("{0:N2}", Math.Round(Common.DecimalConvert(txtRateperItem.Text) + minSaleAmount));
                mrpAmount = (Common.DecimalConvert(txtMinSalePrice.Text) * Program.mrpPercentage) / 100;
                txtMrp.Text = (string.Format("{0:N2}", Math.Round(Common.DecimalConvert(txtMinSalePrice.Text) + mrpAmount)));
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }
        #endregion

        #region TextchangeEvent
        private void txtQuantity_TextChanged(object sender, EventArgs e)
        {
            Calculate();
        }
        private void txtAmount_TextChanged(object sender, EventArgs e)
        {
            Calculate();
        }
        private void txtOtherCharge_TextChanged(object sender, EventArgs e)
        {
            Calculate();
        }
        #endregion

        #region LoadEvent
        private void PurchaseOrderDetails_Load(object sender, EventArgs e)
        {
            GetAllMUnitIdName();
            if (modeT == "Add")
            {
                cmbGstPercentage.SelectedIndex = 2;

            }
            else
                cmbMunit.SelectedValue = cmbMunit.Tag;

        }
        #endregion

        #region SelectedIndexChangedEvent
        private void cmbGstPercentage_SelectedIndexChanged(object sender, EventArgs e)
        {
            Calculate();
        }
        #endregion

        #region KeydownEvent
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
                    cmbMunit.Focus();

                }
                GetAllBrandIdName(brandId);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }
        private void cmbBrand_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                cmbMunit.Focus();
        }
        private void cmbMunit_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtBatchNo.Focus();
        }

        private void txtBatchNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtBatchNo.Text == string.Empty)
                {
                    MessageBox.Show("You must enter Batch No !", Common.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtBatchNo.Focus();
                    return;
                }
                else
                    dtpItemExpiryDate.Focus();
            }
        }
        private void dtpItemExpiryDate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (dtpItemExpiryDate.Value.Date <= DateTime.Now.Date)
                {
                    MessageBox.Show("You must enter greater date from today date !", Common.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dtpItemExpiryDate.Focus();
                    return;
                }
                else
                    txtQuantity.Focus();

            }
        }
       

      
        private void txtQuantity_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Enter)
            {
                if (txtQuantity.Text == string.Empty)
                {
                    MessageBox.Show("You must enter Quantity !", Common.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtQuantity.Focus();
                    return;
                }
                else
                    txtAmount.Focus();
            }
        }
        private void txtAmount_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtAmount.Text == string.Empty)
                {
                    MessageBox.Show("You must enter Amount !", Common.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtAmount.Focus();
                    return;
                }
                else
                    cmbGstPercentage.Focus();
                
            }
        }
        private void cmbGstPercentage_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtOtherCharge.Focus();
            }
        }
        private void txtOtherCharge_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtMinSalePrice.Focus();
            }
        }
        private void txtMinSalePrice_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtMinSalePrice.Text == string.Empty)
                {
                    MessageBox.Show("You must enter min Sale Price", Common.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtMinSalePrice.Focus();
                    return;
                }
                else
                    txtMrp.Focus();
            }
           
        }       
        private void txtMrp_KeyDown(object sender, KeyEventArgs e)
        {
       if(e.KeyCode==Keys.Enter)
            {
                if (e.KeyCode == Keys.End)
                {
                    if (txtMinSalePrice.Text == string.Empty)
                    {
                        MessageBox.Show("You must enter min Sale Price", Common.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtMinSalePrice.Focus();
                        return;
                    }
                }
                else btnAddToList_Click(sender,e);
            }
        }
          #endregion

     }
}
