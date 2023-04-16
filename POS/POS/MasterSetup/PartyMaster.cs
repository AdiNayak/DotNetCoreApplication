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
    public partial class PartyMaster : formTemplate, IUserControl
    {
        #region InstantMember
        private FormModes modeType;        
        private Boolean ModeChk = false;
        IList<ListViewItem> dataList = new List<ListViewItem>();
        IList<string> newItems = new List<string>();
        private readonly PartyMap _partyMap;
        #endregion

        #region Constructor
        public PartyMaster()
        {
            InitializeComponent();
            
            _partyMap = new PartyMap();
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
                Common.EnableControl(new Control[] { txtPartyId, txtPartyName, txtGstinNo, txtContactNo, txtEmail, txtWebsite, txtAddress, txtNarration, btnSave }, true);
                Common.ClearControl(new Control[] { txtPartyId, txtPartyName, txtGstinNo, txtContactNo, txtEmail, txtWebsite, txtAddress, txtNarration });
                ModeChk = false;
                 GetAllParty();
                txtPartyName.Focus();
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
                if (txtPartyName.Text.Trim() == "")
                {
                    MessageBox.Show("You must enter Party Name", Common.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtPartyName.Focus();
                    return modeType;
                }    
                if (MessageBox.Show("Are you sure to save the record !", Common.ApplicationName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    var party = new Party()
                    {
                        Id = Common.IntConvert(txtPartyId.Text),
                        PartyName = txtPartyName.Text,
                        GstinNo = txtGstinNo.Text,
                        ContactNo=txtContactNo.Text,
                        Email = txtEmail.Text,
                        WebSite = txtWebsite.Text,
                        Address = txtAddress.Text,
                        Date =DateTime.Now.Date,
                        Narration=txtNarration.Text,
                    };                  
                    if (ModeChk == false)
                    {
                        result = _partyMap.UpsertParty(party,SaveTypes.Insert);
                    }
                    if (ModeChk == true)
                    {
                        result = _partyMap.UpsertParty(party,SaveTypes.Update);
                    }
                    if (result > 0)
                    {
                        newItems.Add(txtPartyName.Text.Trim());
                        Common.EnableControl(new Control[] { txtPartyId, txtPartyName, txtGstinNo,txtContactNo, txtEmail, txtWebsite, txtAddress, txtNarration, btnSave }, true);
                        Common.ClearControl(new Control[] { txtPartyId, txtPartyName, txtGstinNo,txtContactNo, txtEmail, txtWebsite, txtAddress, txtNarration });
                        ModeChk = false;
                        txtPartyName.Focus();
                        GetAllParty();
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
        void GetAllParty()
        {
            try
            {
                listView.Items.Clear();
                dataList.Clear();
                ListViewItem li;
                var _partylist = _partyMap.GetAllParty();
                foreach (var item in _partylist)
                {
                    li = new ListViewItem(item.Id.ToString());
                    li.SubItems.Add(item.PartyName);
                    li.SubItems.Add(item.GstinNo.ToString());
                    li.SubItems.Add(item.ContactNo.ToString());
                    li.SubItems.Add(item.Email);
                    li.SubItems.Add(item.WebSite.ToString());
                    li.SubItems.Add(item.Address.ToString());
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
        private void txtPartyName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtPartyName.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("Enter Party Name", Common.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtPartyName.Focus();
                    return;
                }
                else
                { txtGstinNo.Focus(); }
            }
        }

        private void txtGstinNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtContactNo.Focus();
            }
        }

        private void txtContactNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtEmail.Focus();
            }
        }

        private void txtEmail_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtWebsite.Focus();
            }
        }

        private void txtWebsite_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtAddress.Focus();
            }
        }

        private void txtAddress_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtNarration.Focus();
            }
        }

        private void txtNarration_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
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
                txtPartyId.Text = li.Text;
                txtPartyName.Text = li.SubItems[1].Text;
                txtGstinNo.Text = li.SubItems[2].Text;
                txtContactNo.Text = li.SubItems[3].Text;
                txtEmail.Text = li.SubItems[4].Text;
                txtWebsite.Text = li.SubItems[5].Text;
                txtAddress.Text = li.SubItems[6].Text;
                txtPartyId.Tag = li.Name;
                txtNarration.Text = li.SubItems[7].Text;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }
        #endregion

    
    }
}
