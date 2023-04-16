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
    public partial class BrandMaster : formTemplate, IUserControl
    {
        #region InstantMember
        private FormModes modeType;
        private Boolean ModeChk = false;
        IList<ListViewItem> dataList = new List<ListViewItem>();
        IList<string> newItems = new List<string>();
        private readonly BrandMap _brandMap;
        #endregion

        #region Constructor
        public BrandMaster()
        {
            InitializeComponent();
            _brandMap = new BrandMap();
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
                Common.EnableControl(new Control[] { txtBrandId, txtBrandName, txtNarration, btnSave }, true);
                Common.ClearControl(new Control[] { txtBrandId, txtBrandName, txtNarration });
                ModeChk = false;
                GetAllBrand();
                txtBrandName.Focus();
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
                if (txtBrandName.Text.Trim() == "")
                {
                    MessageBox.Show("You must enter Brand Name", Common.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtBrandName.Focus();
                    return modeType;
                }
                if (MessageBox.Show("Are you sure to save the record !", Common.ApplicationName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    var brand = new Brand()
                    {
                        Id = Common.IntConvert(txtBrandId.Text),
                        BrandName = txtBrandName.Text,
                        Date = DateTime.Now.Date,
                        Narration = txtNarration.Text,
                    };
                    if (ModeChk == false)
                    {
                         result = _brandMap.UpsertBrand(brand,SaveTypes.Insert);
                    }
                    if (ModeChk == true)
                    {
                        result = _brandMap.UpsertBrand(brand, SaveTypes.Update);
                    }
                    if (result > 0)
                    {
                        newItems.Add(txtBrandName.Text.Trim());
                        Common.EnableControl(new Control[] { txtBrandId, txtBrandName, txtNarration, btnSave }, true);
                        Common.ClearControl(new Control[] { txtBrandId, txtBrandName, txtNarration });
                        ModeChk = false;
                        txtBrandName.Focus();
                        GetAllBrand();
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
        void GetAllBrand()
        {
            try
            {
                listView.Items.Clear();
                dataList.Clear();
                ListViewItem li;
                var _brandList = _brandMap.GetAllBrand();
                foreach (var brand in _brandList)
                {
                    li = new ListViewItem(brand.Id.ToString());
                    li.SubItems.Add(brand.BrandName);
                    li.SubItems.Add(brand.Narration.ToString());
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
        private void txtBrandName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtBrandName.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("Enter Brand Name", Common.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtBrandName.Focus();
                    return;
                }
                else
                { txtNarration.Focus(); }
            }
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
                txtBrandId.Text = li.Text;
                txtBrandName.Text = li.SubItems[1].Text;
                txtBrandId.Tag = li.Name;
                txtNarration.Text = li.SubItems[2].Text;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }
        #endregion

        #region LoadEvent
        private void BrandMaster_Load(object sender, EventArgs e)
        {
            Add();
        }
        #endregion
    }
}