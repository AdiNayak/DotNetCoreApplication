using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using POS.Core.Settings;
using POS.Data.Settings;
using POS.Core;

namespace POS.MasterSetup
{
    public partial class ProductMaster : formTemplate,IUserControl
    {
        #region InstantMember
        private FormModes modeType;
        private Boolean ModeChk = false;
        IList<ListViewItem> dataList = new List<ListViewItem>();
        IList<string> newItems = new List<string>();
        private readonly BrandMap _brandMap;
        private readonly ProductMap _productMap;
        #endregion

        #region Constructor
        public ProductMaster()
        {
            InitializeComponent();
            _brandMap = new BrandMap();
            _productMap = new ProductMap();
           
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
                Common.EnableControl(new Control[] { txtProductId, txtProductName, txtNarration, btnSave }, true);
                Common.ClearControl(new Control[] { txtProductId, txtProductName, txtNarration,listView });
                ModeChk = false;
                GetAllBrandIdName();
                GetAllProduct();
                 txtProductName.Focus();
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
                if (txtProductName.Text.Trim() == "")
                {
                    MessageBox.Show("You must enter Product Name", Common.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtProductName.Focus();
                    return modeType;
                }
                if (MessageBox.Show("Are you sure to save the record !", Common.ApplicationName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    var product = new Product()
                    {
                        Id = Common.IntConvert(txtProductId.Text),
                        ProductName = txtProductName.Text,
                        BrandId = Common.IntConvert(cmbBrand.SelectedValue),
                        Date = DateTime.Now.Date,
                        Narration = txtNarration.Text,
                    };
                    if (ModeChk == false)
                    {
                        result = _productMap.UpsertProduct(product,SaveTypes.Insert);
                    }
                    if (ModeChk == true)
                    {
                        result = _productMap.UpsertProduct(product, SaveTypes.Update);
                    }
                    if (result > 0)
                    {
                        newItems.Add(txtProductName.Text.Trim());
                        Common.EnableControl(new Control[] { txtProductId, txtProductName, txtNarration, btnSave }, true);
                        Common.ClearControl(new Control[] { txtProductId, txtProductName, txtNarration ,listView});
                        ModeChk = false;
                        txtProductName.Focus();
                        GetAllProduct();
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

        #region ClickEvent
        private void btnSave_Click(object sender, EventArgs e)
        {
            Save();
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
        void GetAllProduct()
        {
            try
            {
                listView.Items.Clear();
                dataList.Clear();
                ListViewItem li;
                var _productList = _productMap.GetAllProduct();
                foreach (var product in _productList)
                {
                    li = new ListViewItem(product.Id.ToString());                    
                    li.SubItems.Add(product.ProductName.ToString());
                    li.SubItems.Add(product.BrandId.ToString());
                    li.SubItems.Add(product.BrandName.ToString());
                    li.SubItems.Add(product.Narration.ToString());
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

        #region KeyDownEvent
        private void txtProductName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtProductName.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("Enter Item Name", Common.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtProductName.Focus();
                    return;
                }
                else
                { cmbBrand.Focus(); }
            }
        }
        private void cmbBrand_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            { txtNarration.Focus(); }
        }
        private void txtNarration_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            { btnSave_Click(sender, e); }
        }
        #endregion

        #region DoubleClickEvent
        private void listView_DoubleClick(object sender, EventArgs e)
        {
            ListViewItem li;
            try
            {
                if (listView.SelectedItems.Count > 0)
                    ModeChk = true;
                else ModeChk = false;
                li = listView.SelectedItems[0];
                txtProductId.Text = li.Text;
                txtProductName.Text = li.SubItems[1].Text;
                cmbBrand.SelectedValue =Common.IntConvert(li.SubItems[2].Text);
                cmbBrand.Text = li.SubItems[3].Text;               
                txtProductId.Tag = li.Name;
                txtNarration.Text = li.SubItems[4].Text;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }
        #endregion

        #region LoadEvent
        private void ProductMaster_Load(object sender, EventArgs e)
        {
            Add();
        }
        #endregion
    }
}
