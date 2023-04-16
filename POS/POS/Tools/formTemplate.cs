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
    public partial class formTemplate : Form
    {
      //  public string initialTab = "";
      //public  TabPage tp = new TabPage();
        
        public formTemplate()
        {
            InitializeComponent();
        }

        private void formTemplate_Load(object sender, EventArgs e)
        {
           this.WindowState = FormWindowState.Maximized;
        }

        public void formTemplate_FormClosed(object sender, FormClosedEventArgs e)
        {
        //    try
        //    {
        //        //((mdiDashBoard)this.MdiParent).kotTab.TabPages.RemoveAt(((mdiDashBoard)this.MdiParent).kotTab.SelectedIndex);
        //        if (initialTab != "")
        //        { ((DashBoard)this.MdiParent).kotTab.TabPages[initialTab].Dispose(); }
        //        //{ ((DashBoard)this.MdiParent).kotTab.TabPages[initialTab].Dispose(); }

                    
        //        else 
        //        {


        //            int ti = ((DashBoard)this.MdiParent).kotTab.SelectedIndex;
        //            ((DashBoard)this.MdiParent).kotTab.SelectedTab.Dispose();
        //            if (ti > 0)
        //                ((DashBoard)this.MdiParent).kotTab.SelectTab(ti - 1);

        //        }
                
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        }
    }
}
