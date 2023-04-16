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
    public partial class MUnitMaster : formTemplate, IUserControl
    {
        #region InstantMember
        private FormModes modeType;
        private Boolean ModeChk = false;
        IList<ListViewItem> dataList = new List<ListViewItem>();
        IList<string> newItems = new List<string>();
        private readonly MUnitMap _mUnitMap;
        #endregion

        #region Constructor
        public MUnitMaster()
        {
            InitializeComponent();
            _mUnitMap = new MUnitMap();
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
                Common.EnableControl(new Control[] { txtMUnitId, txtMUnitName, txtNarration, btnSave }, true);
                Common.ClearControl(new Control[] { txtMUnitId, txtMUnitName, txtNarration });
                ModeChk = false;
                GetAllUnit();
                txtMUnitName.Focus();
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
                if (txtMUnitName.Text.Trim() == "")
                {
                    MessageBox.Show("You must enter Unit Name", Common.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtMUnitName.Focus();
                    return modeType;
                }
                if (MessageBox.Show("Are you sure to save the record !", Common.ApplicationName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    var mUnit = new MUnit()
                    {
                        Id = Common.IntConvert(txtMUnitId.Text),
                        MUnitName = txtMUnitName.Text,
                        Date = DateTime.Now.Date,
                        Narration = txtNarration.Text,
                    };
                    if (ModeChk == false)
                    {
                         result = _mUnitMap.UpsertMUnit(mUnit,SaveTypes.Insert);
                    }
                    if (ModeChk == true)
                    {
                        result = _mUnitMap.UpsertMUnit(mUnit, SaveTypes.Update);
                    }
                    if (result > 0)
                    {
                        newItems.Add(txtMUnitName.Text.Trim());
                        Common.EnableControl(new Control[] { txtMUnitId, txtMUnitName, txtNarration, btnSave }, true);
                        Common.ClearControl(new Control[] { txtMUnitId, txtMUnitName, txtNarration });
                        ModeChk = false;
                        txtMUnitName.Focus();
                        GetAllUnit();
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
        void GetAllUnit()
        {
            try
            {
                listView.Items.Clear();
                dataList.Clear();
                ListViewItem li;
                var _mUnitList = _mUnitMap.GetAllMUnit();
                foreach (var brand in _mUnitList)
                {
                    li = new ListViewItem(brand.Id.ToString());
                    li.SubItems.Add(brand.MUnitName);
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
        private void txtMUnitName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtMUnitName.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("Enter Unit Name", Common.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtMUnitName.Focus();
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
                txtMUnitId.Text = li.Text;
                txtMUnitName.Text = li.SubItems[1].Text;
                txtMUnitId.Tag = li.Name;
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