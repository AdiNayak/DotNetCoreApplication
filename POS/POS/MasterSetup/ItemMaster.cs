using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using POS.Core;
using POS.Data;
using POS.Core.Settings;
using POS.Data.Settings;

namespace POS.MasterSetup
{
    public partial class ItemMaster : formTemplate, IUserControl
    {
        #region InstantMember
        private FormModes modeType;        
        private Boolean ModeChk = false;
        IList<ListViewItem> dataList = new List<ListViewItem>();
        IList<string> newItems = new List<string>();
        private readonly BrandMap _brandMap;
        private readonly ProductMap _productMap;
        private readonly ItemMap _itemMap;
        #endregion

        #region Constructor
        public ItemMaster()
        {
            InitializeComponent();
            _brandMap = new BrandMap();
            _productMap = new ProductMap();
            _itemMap = new ItemMap();
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
                Common.EnableControl(new Control[] { txtItemId, txtItemName, cmbBrand,txtNarration, btnSave }, true);
                Common.ClearControl(new Control[] { txtItemId,txtItemName,txtNarration });
                ModeChk = false;
                GetAllBrandIdName();
                GetAllItem();
                txtItemName.Focus();
                modeType = FormModes.Add;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
            return modeType;
        }
        public FormModes Save()
        {
            int result = 0;
            try
            {
                if (txtItemName.Text.Trim() == "")
                {
                    MessageBox.Show("You must enter item Name", Common.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtItemName.Focus();
                    return modeType;
                }    
                if (MessageBox.Show("Are you sure to save the record !", Common.ApplicationName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    var item = new Item()
                    {
                        Id = Common.IntConvert(txtItemId.Text),
                        ItemName = txtItemName.Text,
                        BrandId = Common.IntConvert(cmbBrand.SelectedValue),
                        Date=DateTime.Now.Date,
                        Narration=txtNarration.Text,
                    };                  
                    if (ModeChk == false)
                    {
                        result = _itemMap.UpsertItem(item,SaveTypes.Insert);
                    }
                    if (ModeChk == true)
                    {
                        result = _itemMap.UpsertItem(item,SaveTypes.Update);
                    }
                    if (result > 0)
                    {
                        newItems.Add(txtItemName.Text.Trim());
                        Common.EnableControl(new Control[] { txtItemId, txtItemName, cmbBrand, txtNarration, btnSave }, true);
                        Common.ClearControl(new Control[] { txtItemId, txtItemName, txtNarration });
                        ModeChk = false;
                        txtItemName.Focus();
                        GetAllItem();
                        modeType = FormModes.View;                        
                    }
                    else
                    {
                        MessageBox.Show("Failed to Save !", Common.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
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
        public FormModes View()
        {
            throw new NotImplementedException();
        }
        public FormModes Print()
        {
            throw new NotImplementedException();
        }
        #endregion

        #region LoadEvent
        private void ItemMaster_Load(object sender, EventArgs e)
        {
            Add();
        }
        #endregion

        #region Function
        void GetAllBrandIdName()
        {
            try
            {
                var brand = _brandMap.GetAllBrand();
                cmbBrand.DataSource = brand;
                cmbBrand.ValueMember = "Id";
                cmbBrand.DisplayMember = "BrandName";
            }
            catch (Exception exception)
            {

                MessageBox.Show(exception.Message);
            }
        }
        void GetAllItem()
        {
            try
            {
                listView.Items.Clear();
                dataList.Clear();
                ListViewItem li;
                var itemsDetails = _itemMap.GetAllItem();
                foreach (var item in itemsDetails)
                {
                    li = new ListViewItem(item.Id.ToString());
                    li.SubItems.Add(item.ItemName);
                    li.SubItems.Add(item.BrandId.ToString());
                    li.SubItems.Add(item.BrandName.ToString());
                    li.SubItems.Add(item.Narration.ToString());
                    li.Name = li.SubItems[1].Text.ToUpper();
                    dataList.Add(li);
                }
                listView.Items.AddRange(dataList.ToArray());
                foreach (string item in newItems)
                {
                    li = listView.Items.Find(item, false)[0];
                    li.Remove();
                    listView.Items.Insert(0, li);
                    li.BackColor = Color.GreenYellow;
                    li.UseItemStyleForSubItems = true;
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }
        #endregion

        #region ClickEvent
        private void btnSave_Click(object sender, EventArgs e)
        {
            Save();
        }
        #endregion

        #region KeyDown
        private void txtItemName_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Enter)
            {
                if(txtItemName.Text.Trim()==string.Empty)
                {
                    MessageBox.Show("Enter Item Name", Common.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtItemName.Focus();
                    return;
                }
                else
                { cmbBrand.Focus(); }
            }
        }        
        private void cmbProduct_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Enter)
            {
                txtNarration.Focus();
            }
        }
        private void txtDescription_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Enter)
            { btnSave_Click(sender, e); }
        }
        #endregion

        #region DoubleClickEvent
        private void lvView_DoubleClick(object sender, EventArgs e)
        {
            ListViewItem li;
            try
            {
                if (listView.SelectedItems.Count > 0)
                    ModeChk = true;
                else ModeChk = false;
                li = listView.SelectedItems[0];
                txtItemId.Text = li.Text;
                txtItemName.Text = li.SubItems[1].Text;
                cmbBrand.SelectedValue = li.SubItems[2].Text;
                cmbBrand.Text = li.SubItems[3].Text;
                txtItemId.Tag = li.Name;
                txtNarration.Text = li.SubItems[4].Text;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }
        #endregion
    }
}
