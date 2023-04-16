using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace POS
{
    public partial class ViewDialog : Form
    {
        public IList<ListViewItem> _data;
        int column;

        string _SearchInitial = null;
        public string SearchInitial
        {
            get { return _SearchInitial; }
            set { _SearchInitial = value; 
            
            }
        }

        public ViewDialog()
        {
            InitializeComponent();   
        }

        public void SetDataSource(IList<ListViewItem> data, string[] columnNames, HorizontalAlignment[] directions, int[] columnWidths)
        {
            if ((columnNames.Length != directions.Length) || (directions.Length != columnWidths.Length))
                throw new ApplicationException("Number of parameters for each group should be equal.");

            for (int i = 0; i < columnNames.Length; i++)
                lvwData.Columns.Add(new ColumnHeader { Text = columnNames[i], TextAlign = directions[i], Width = columnWidths[i] });

            lvwData.Items.AddRange(data.ToArray());
            if (lvwData.Items.Count != 0)
                lvwData.Items[0].Selected=true;
               // cmbColumns.DataSource = columnNames.Skip(1).ToArray();
            _data = data;
            column = lvwData.Columns[1].Index;
            lblSearch.Text = lvwData.Columns[column].Text.Insert(0, "Search On ");
        }

        private void txtSearchKey_TextChanged(object sender, EventArgs e)
        {
            lvwData.Items.Clear();
            var data = from lstItems in _data
                       //where lstItems.SubItems[column].Text.ToUpper().StartsWith(txtSearchKey.Text.ToUpper())
                       //select lstItems;
                       where lstItems.SubItems[column].Text.ToUpper().Contains(txtSearchKey.Text.ToUpper())
                       select lstItems;
            lvwData.Items.AddRange(data.ToArray());
            if (lvwData.Items.Count > 0)
                lvwData.Items[0].Selected = true;
        }
     
        private void lvwData_DoubleClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lvwData_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.Close();
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in lvwData.Items)
            {
                item.Selected = false;
            }
              this.Close();
        }

        private void lvwData_ColumnClick(object sender, ColumnClickEventArgs e)
        {
          column = e.Column;
          lblSearch.Text = lvwData.Columns[e.Column].Text.Insert(0, "Search On ");
          if (txtSearchKey.Text != "")
          {
              lvwData.Items.Clear();
              var data = from lstItems in _data
                         where lstItems.SubItems[e.Column].Text.ToUpper().StartsWith(txtSearchKey.Text.ToUpper())
                         select lstItems;
              lvwData.Items.AddRange(data.ToArray());
          }
        }

        private void frmViewDialog_Load(object sender, EventArgs e)
        {
            //txtSearchKey.Focus();
        }

        private void txtSearchKey_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                lvwData.Focus();
                lvwData.Items[0].Selected = true;
            }
        }

        private void ViewDialog_Activated(object sender, EventArgs e)
        {
            txtSearchKey.Focus();
            if (_SearchInitial != "\r")
                txtSearchKey.Paste(_SearchInitial);
            
        }

    }
}
