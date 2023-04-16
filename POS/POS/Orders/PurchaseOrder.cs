using POS.Core;
using POS.Core.Orders;
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

namespace POS.Orders
{
    public partial class PurchaseOrder : formTemplate,IUserControl
    {
        #region InstantMember
        private FormModes modeType;
        private readonly PartyMap _partyMap;
        private readonly PurchaseMap _purchaseMap;
        #endregion

        #region Constructor
        public PurchaseOrder()
        {           
            InitializeComponent();
            _partyMap=new PartyMap();
            _purchaseMap = new PurchaseMap();          
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
            Common.EnableControl(new Control[] { txtParty,txtPartyVhNo,dtpVhDate, txtNarration,listView,btnCreate }, true);
            Common.ClearControl(new Control[] { txtInvcNo, txtParty, txtPartyVhNo,txtTotalQuantity,txtTotalAmount,txtTotalGstAmount,txtTotalOtherCharge,txtTotalNetAmount,txtNarration,listView });
            txtParty.Focus();
            modeType = FormModes.Add;
            return modeType;
        }
        public FormModes Delete()
        {
            throw new NotImplementedException();
        }
        public FormModes Print()
        {
            throw new NotImplementedException();
        }
        public FormModes Save()
        {
            int result = 0;
            try
            {
                if (txtParty.Text.Trim() == "")
                {
                    MessageBox.Show("You must enter Party Name", Common.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtParty.Focus();
                    return modeType;
                }
                if (txtPartyVhNo.Text.Trim() == "")
                {
                    MessageBox.Show("You must enter Party Voucher No", Common.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtPartyVhNo.Focus();
                    return modeType;
                }                
                if (listView.Items.Count <= 0)
                {
                    MessageBox.Show("No Item(s) for Purchase !", Common.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return modeType;
                }
                List<PurchaseDetails> _purchaseDetailsList = new List<PurchaseDetails>();

                if (MessageBox.Show("Are you sure to save this record ?", Common.ApplicationName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    foreach (ListViewItem lvItem in listView.Items)
                    {
                        var dt = Convert.ToDateTime(lvItem.SubItems[9].Text);
                       var _purchaseDetails = new PurchaseDetails()
                       {
                           Id = Common.IntConvert(lvItem.Text),
                           PurchaseId = Common.IntConvert(lvItem.SubItems[1].Text),
                           ItemId = Common.IntConvert(lvItem.SubItems[2].Text),
                           BrandId = Common.IntConvert(lvItem.SubItems[4].Text),
                           MUnitId = Common.IntConvert(lvItem.SubItems[6].Text),
                           BatchNo = lvItem.SubItems[8].Text,
                           ItemExpiryDate = Convert.ToDateTime(lvItem.SubItems[9].Text),
                           Quantity = Common.IntConvert(lvItem.SubItems[10].Text),
                           Amount = Common.DecimalConvert(lvItem.SubItems[11].Text),
                           GstPercentage = Common.DecimalConvert(lvItem.SubItems[12].Text),
                           GstAmount = Common.DecimalConvert(lvItem.SubItems[13].Text),
                           OtherCharge = Common.DecimalConvert(lvItem.SubItems[14].Text),
                           NetAmount = Common.DecimalConvert(lvItem.SubItems[15].Text),
                           RateperItem = Common.DecimalConvert(lvItem.SubItems[16].Text),
                           MinSalePrice = Common.DecimalConvert(lvItem.SubItems[17].Text),
                           Mrp = Common.DecimalConvert(lvItem.SubItems[18].Text),
                           Status=0,
                       };
                        _purchaseDetailsList.Add(_purchaseDetails);
                    }                   
                    var _purchase = new Purchase()
                    {
                        Id = Common.IntConvert(txtInvcNo.Tag),
                        FinacialId = Program.FinacialYearId,
                        InvoiceNo = txtInvcNo.Text,
                        Date = dtpDate.Value.Date,
                        PartyId = Common.IntConvert(txtParty.Tag),
                        PartyVoucherNo = txtPartyVhNo.Text,
                        PartyVoucherDate = dtpVhDate.Value.Date,
                        TotalQuantity = Common.IntConvert(txtTotalQuantity.Text),
                        TotalAmount = Common.DecimalConvert(txtTotalAmount.Text),
                        TotalGstAmount = Common.DecimalConvert(txtTotalGstAmount.Text),
                        TotalOtherCharge = Common.DecimalConvert(txtTotalOtherCharge.Text),
                        TotalNetAmount = Common.DecimalConvert(txtTotalNetAmount.Text),
                        Narration = txtNarration.Text,
                        Status=0,
                        _purchaseDetailsList = _purchaseDetailsList,
                    };

                    if (modeType == FormModes.Add)
                    {
                        result = _purchaseMap.UpsertPurchase(_purchase, SaveTypes.Insert);
                    }
                    else if (modeType == FormModes.View)
                    {
                        //_purchaseMap.DeletePurchaseDetails(Common.IntConvert(txtInvcNo.Tag));
                        result = _purchaseMap.UpsertPurchase(_purchase, SaveTypes.Update);
                    }
                    if (result > 0)
                    {
                        Common.EnableControl(new Control[] { txtParty, txtPartyVhNo, dtpVhDate, txtNarration, listView, btnCreate }, false);
                        if(modeType==FormModes.Add)
                        txtInvcNo.Text = _purchaseMap.GetAllPurchase().Where(x => x.Id == result).FirstOrDefault().InvoiceNo;
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
                Common.EnableControl(new Control[] { txtParty, txtPartyVhNo, dtpVhDate, txtNarration, listView, btnCreate }, true);
                Common.ClearControl(new Control[] { txtInvcNo, txtParty, txtPartyVhNo, txtTotalQuantity, txtTotalAmount, txtTotalGstAmount, txtTotalOtherCharge, txtTotalNetAmount, txtNarration, listView });

                IList<ListViewItem> listItems = new List<ListViewItem>();
                var _purchaseList = _purchaseMap.GetAllPurchase().Select(x => new Purchase { Id = x.Id, InvoiceNo = x.InvoiceNo,TotalNetAmount= x.TotalNetAmount });
                foreach (var purchase in _purchaseList)
                {
                    ListViewItem listItem = new ListViewItem(purchase.Id.ToString());
                    listItem.SubItems.Add(purchase.InvoiceNo);
                    listItem.SubItems.Add(purchase.TotalNetAmount.ToString());
                    listItems.Add(listItem);
                }
                ViewDialog frmView = new ViewDialog();
                frmView.Text = "Party list";
                frmView.SetDataSource(listItems, new string[] {"Id", "Invoice No", "Invoice Amount" }, new HorizontalAlignment[] { HorizontalAlignment.Left, HorizontalAlignment.Left, HorizontalAlignment.Right }, new int[] { 0, 100,150 });
              frmView.ShowDialog();
                if (frmView.lvwData.SelectedItems.Count <= 0)
                    return modeType;
                txtInvcNo.Tag = Convert.ToInt32(frmView.lvwData.SelectedItems[0].Text);
                txtInvcNo.Text = frmView.lvwData.SelectedItems[0].SubItems[1].Text;
                txtPartyVhNo.Focus();
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
            PurchaseOrderDetails purchaseOrderDetails = new PurchaseOrderDetails();            
            purchaseOrderDetails.ShowDialog();
            var _purchaseDetails = purchaseOrderDetails._purchaseDetailsList;            
            if (_purchaseDetails.Count>0)
            {
                foreach (var purchaseDetails in _purchaseDetails)
                {
                    ListViewItem li = new ListViewItem();
                    li = listView.Items.Add(purchaseDetails.Id.ToString());//0
                    li.SubItems.Add(purchaseDetails.PurchaseId.ToString());//1
                    li.SubItems.Add(purchaseDetails.ItemId.ToString());//2
                    li.SubItems.Add(purchaseDetails.ItemName.ToString());//3
                    li.SubItems.Add(purchaseDetails.BrandId.ToString());//4
                    li.SubItems.Add(purchaseDetails.BrandName.ToString());//5
                    li.SubItems.Add(purchaseDetails.MUnitId.ToString());//4
                    li.SubItems.Add(purchaseDetails.MUnitName.ToString());//5
                    li.SubItems.Add(purchaseDetails.BatchNo.ToString());//8
                    li.SubItems.Add(purchaseDetails.ItemExpiryDate.ToString());//9
                    li.SubItems.Add(purchaseDetails.Quantity.ToString());//10
                    li.SubItems.Add(purchaseDetails.Amount.ToString());//11
                    li.SubItems.Add(purchaseDetails.GstPercentage.ToString());//12
                    li.SubItems.Add(purchaseDetails.GstAmount.ToString());//13
                    li.SubItems.Add(purchaseDetails.OtherCharge.ToString());//14
                    li.SubItems.Add(purchaseDetails.NetAmount.ToString());//15
                    li.SubItems.Add(purchaseDetails.RateperItem.ToString());//16
                    li.SubItems.Add(purchaseDetails.MinSalePrice.ToString());//17
                    li.SubItems.Add(purchaseDetails.Mrp.ToString());//18
                }               
            }
            Calculate();
        }
        #endregion

        #region KeyDownEvent
        private void txtParty_KeyDown(object sender, KeyEventArgs e)
        {  
            try
            {
                
                IList<ListViewItem> listItems = new List<ListViewItem>();
                List<Party> _partyList = _partyMap.GetAllParty();
                if ((e.KeyCode == Keys.Enter) && Common.IsNumeric(txtParty.Text.Trim()))
                {
                var partyNameId=from party in _partyList
                                 where party.Id == Common.IntConvert(txtParty.Text)
                                 select new {Id= party.Id ,party.PartyName };                      
                    if (partyNameId.Count() == 0)
                        MessageBox.Show("There is no Party Registerd. Please register Party Details !", Common.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                    {
                        foreach (var item in partyNameId)
                        {
                            txtParty.Tag = item.Id;
                            txtParty.Text = item.PartyName;
                        }
                        
                        txtPartyVhNo.Focus();
                    }
                }
                else if ((e.KeyCode == Keys.Enter) || e.KeyCode >= Keys.A && e.KeyCode <= Keys.Z)
                {
                    txtParty.Clear();
                    foreach (var party in _partyList)
                    {
                        ListViewItem listItem = new ListViewItem(party.Id.ToString());
                        listItem.SubItems.Add(party.PartyName);
                        listItems.Add(listItem);
                    }
                    ViewDialog frmView = new ViewDialog();
                    frmView.Text = "Party list";
                    frmView.SetDataSource(listItems, new string[] { "Party Code", "Party Name" }, new HorizontalAlignment[] { HorizontalAlignment.Center, HorizontalAlignment.Left }, new int[] { 80, 200 });
                    frmView.SearchInitial = Convert.ToChar(e.KeyValue).ToString();
                    frmView.ShowDialog();
                    if (frmView.lvwData.SelectedItems.Count <= 0)
                        return;
                    txtParty.Tag = Convert.ToInt32(frmView.lvwData.SelectedItems[0].Text);
                    txtParty.Text = frmView.lvwData.SelectedItems[0].SubItems[1].Text;
                    txtPartyVhNo.Focus();
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }
        private void txtPartyVhNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtPartyVhNo.Text == string.Empty)
                {
                    MessageBox.Show("You must enter Party Voucher No !", Common.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtPartyVhNo.Focus();
                    return;
                }
                else
                    dtpVhDate.Focus();
            }
        }

        private void dtpVhDate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnCreate_Click(sender, e);
            }
        }
        #endregion

        #region LoadEvent
        private void PurchaseOrder_Load(object sender, EventArgs e)
        {
            Add();
        }
        #endregion

        #region UserDefined
        void Calculate()
        {
            Common.ClearControl(new  Control[]{txtTotalQuantity,txtTotalAmount,txtTotalGstAmount,txtTotalOtherCharge,txtTotalNetAmount });
            foreach (ListViewItem item in listView.Items)
            {
                txtTotalQuantity.Text = ((Common.IntConvert(txtTotalQuantity.Text) + Common.IntConvert(item.SubItems[10].Text))).ToString();
                txtTotalAmount.Text = ((Common.DecimalConvert(txtTotalAmount.Text) + Common.DecimalConvert(item.SubItems[11].Text))).ToString();
                txtTotalGstAmount.Text = ((Common.DecimalConvert(txtTotalGstAmount.Text) + Common.DecimalConvert(item.SubItems[13].Text))).ToString();
                txtTotalOtherCharge.Text = ((Common.DecimalConvert(txtTotalOtherCharge.Text) + Common.DecimalConvert(item.SubItems[14].Text))).ToString();
                txtTotalNetAmount.Text = ((Common.DecimalConvert(txtTotalNetAmount.Text) + Common.DecimalConvert(item.SubItems[15].Text))).ToString();
            }
        }
        void GetAll(Int32 PurchaseId)
        {
            try
            {
                var purchase = _purchaseMap.GetAllPurchase().Where(x => x.Id == Convert.ToInt32(PurchaseId)).FirstOrDefault();
                dtpDate.Value = (DateTime)purchase.Date;
                txtParty.Tag =purchase.PartyId;
                txtParty.Text = purchase.PartyName;
                txtPartyVhNo.Text = purchase.PartyVoucherNo;
                dtpVhDate.Value = (DateTime)purchase.PartyVoucherDate;    
                txtTotalQuantity.Text = purchase.TotalQuantity.ToString();
                txtTotalAmount.Text = purchase.TotalAmount.ToString();
                txtTotalGstAmount.Text = purchase.TotalGstAmount.ToString();
                txtTotalOtherCharge.Text = purchase.TotalOtherCharge.ToString() ;                
                txtTotalNetAmount.Text = purchase.TotalNetAmount.ToString();
                txtNarration.Text = purchase.Narration;                
            }
            catch (Exception exception)
            {
              MessageBox.Show(exception.Message);
            }
            GetAllDetails(PurchaseId);
        }
        void GetAllDetails(Int32 purchaseId)
        {
            try
            {
                var _purchaseDetails = _purchaseMap.GetAllPurchaseDetails().Where(x=>x.PurchaseId== purchaseId).ToList();
                if (_purchaseDetails.Count > 0)
                {
                    foreach (var purchaseDetails in _purchaseDetails)
                    {

                        ListViewItem li = new ListViewItem();
                        li = listView.Items.Add(purchaseDetails.Id.ToString());//0
                        li.SubItems.Add(purchaseDetails.PurchaseId.ToString());//1
                        li.SubItems.Add(purchaseDetails.ItemId.ToString());//2
                        li.SubItems.Add(purchaseDetails.ItemName.ToString());//3
                        li.SubItems.Add(purchaseDetails.BrandId.ToString());//4
                        li.SubItems.Add(purchaseDetails.BrandName.ToString());//5
                        li.SubItems.Add(purchaseDetails.MUnitId.ToString());//4
                        li.SubItems.Add(purchaseDetails.MUnitName.ToString());//5
                        li.SubItems.Add(purchaseDetails.BatchNo.ToString());//8
                        li.SubItems.Add(purchaseDetails.ItemExpiryDate.ToString());//9
                        li.SubItems.Add(purchaseDetails.Quantity.ToString());//10
                        li.SubItems.Add(purchaseDetails.Amount.ToString());//11
                        li.SubItems.Add(purchaseDetails.GstPercentage.ToString());//12
                        li.SubItems.Add(purchaseDetails.GstAmount.ToString());//13
                        li.SubItems.Add(purchaseDetails.OtherCharge.ToString());//14
                        li.SubItems.Add(purchaseDetails.NetAmount.ToString());//15
                        li.SubItems.Add(purchaseDetails.RateperItem.ToString());//16
                        li.SubItems.Add(purchaseDetails.MinSalePrice.ToString());//17
                        li.SubItems.Add(purchaseDetails.Mrp.ToString());//18
                    }
                }

            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion

        #region DoubleClick
        private void listView_DoubleClick(object sender, EventArgs e)
        {
            ListViewItem li=null;
            try
            {
                PurchaseOrderDetails purchaseOrderDetails = new PurchaseOrderDetails();
                li = listView.SelectedItems[0];
                purchaseOrderDetails.txtItem.Tag = li.SubItems[2].Text;
                purchaseOrderDetails.txtItem.Text = li.SubItems[3].Text;

                purchaseOrderDetails.GetAllBrandIdName(Common.IntConvert(li.SubItems[4].Text));

                purchaseOrderDetails.GetAllMUnitIdName();
                purchaseOrderDetails.cmbMunit.Tag=(Common.IntConvert(li.SubItems[6].Text));
                purchaseOrderDetails.cmbMunit.Text= li.SubItems[7].Text;

                purchaseOrderDetails.txtBatchNo.Text = li.SubItems[8].Text;
                purchaseOrderDetails.dtpItemExpiryDate.Value = Convert.ToDateTime(li.SubItems[9].Text);
                purchaseOrderDetails.txtQuantity.Text = li.SubItems[10].Text;
                purchaseOrderDetails.txtAmount.Text = li.SubItems[11].Text;
                purchaseOrderDetails.cmbGstPercentage.Text = li.SubItems[12].Text;
                purchaseOrderDetails.txtGstAmount.Text = li.SubItems[13].Text;
                purchaseOrderDetails.txtOtherCharge.Text = li.SubItems[14].Text;
                purchaseOrderDetails.txtNetAmount.Text = li.SubItems[15].Text;
                purchaseOrderDetails.txtRateperItem.Text = li.SubItems[16].Text;
                purchaseOrderDetails.txtMinSalePrice.Text = li.SubItems[17].Text;
                purchaseOrderDetails.txtMrp.Text = li.SubItems[18].Text;
                purchaseOrderDetails.modeT = "Edit";
                purchaseOrderDetails.ShowDialog();
                var _purchaseDetails = purchaseOrderDetails._purchaseDetailsList;
                if (_purchaseDetails.Count > 0)
                {
                    foreach (var purchaseDetails in _purchaseDetails)
                    {
                        
                        li.SubItems[2].Text=(purchaseDetails.ItemId.ToString());//2
                        li.SubItems[3].Text=(purchaseDetails.ItemName.ToString());//3
                        li.SubItems[4].Text=(purchaseDetails.BrandId.ToString());//4
                        li.SubItems[5].Text=(purchaseDetails.BrandName.ToString());//5

                        li.SubItems[6].Text = (purchaseDetails.MUnitId.ToString());//4
                        li.SubItems[7].Text = (purchaseDetails.MUnitName.ToString());//5

                        li.SubItems[8].Text=(purchaseDetails.BatchNo.ToString());//8
                        li.SubItems[9].Text=(Convert.ToDateTime(purchaseDetails.ItemExpiryDate).ToString());//9
                        li.SubItems[10].Text=(purchaseDetails.Quantity.ToString());//10
                        li.SubItems[11].Text=(purchaseDetails.Amount.ToString());//11
                        li.SubItems[12].Text=(purchaseDetails.GstPercentage.ToString());//12
                        li.SubItems[13].Text=(purchaseDetails.GstAmount.ToString());//13
                        li.SubItems[14].Text=(purchaseDetails.OtherCharge.ToString());//14
                        li.SubItems[15].Text=(purchaseDetails.NetAmount.ToString());//15
                        li.SubItems[16].Text=(purchaseDetails.RateperItem.ToString());//16
                        li.SubItems[17].Text=(purchaseDetails.MinSalePrice.ToString());//17
                        li.SubItems[18].Text=(purchaseDetails.Mrp.ToString());//18
                    }                 
                }
                Calculate();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        #endregion
    }
}
