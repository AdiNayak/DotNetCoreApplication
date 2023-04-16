using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using POS.MasterSetup;
using POS.Orders;
using POS.Sales;
using POS.Report;

namespace POS
{
    public partial class DashBoard : Form
    {
       
        public DashBoard()
        {
            InitializeComponent();
        }

        FormModes formMode;

        public FormModes FormMode
        {
            set { formMode = value; }
            get { return formMode; }
        }
        #region Function
        private void SetFormStatus()
        {
            jsTools.Enabled = true;
            switch (formMode)
            {
                case FormModes.Save:
                    saveToolStripButton.Enabled = true; 
                    closeToolStripButton.Enabled = true; 
                    newToolStripButton.Enabled = true; 
                    openToolStripButton.Enabled = true; 
                    printToolStripButton.Enabled = true; 
                    break;
              
                case FormModes.View:
                    closeToolStripButton.Enabled = true; 
                    printToolStripButton.Enabled = true;
                    saveToolStripButton.Enabled = true;
                    openToolStripButton.Enabled = true;
                    newToolStripButton.Enabled = true; 
                    break;
                
                default:
                    newToolStripButton.Enabled = true; 
                    openToolStripButton.Enabled = true; 
                    closeToolStripButton.Enabled = true;
                    saveToolStripButton.Enabled = true; 
                    printToolStripButton.Enabled = false; 
                    break;
            }
        }

        
        #endregion
    
        #region Command Button Click_Event
        private void newToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                IUserControl frmControl = (IUserControl)this.ActiveMdiChild;
                formMode = frmControl.Add();
                SetFormStatus();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, Common.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void openToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                IUserControl frmControl = (IUserControl)this.ActiveMdiChild;
                formMode = frmControl.View();
                SetFormStatus();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, Common.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
       

        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                IUserControl frmControl = (IUserControl)this.ActiveMdiChild;
                formMode = frmControl.Save();
                SetFormStatus();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, Common.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void printToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                IUserControl frmControl = (IUserControl)this.ActiveMdiChild;
                formMode = frmControl.Print();
                SetFormStatus();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, Common.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void closeToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.ActiveMdiChild != null)
                {
                    this.ActiveMdiChild.Close();
                    lblMdlName.Text = "";
                }
                if (this.ActiveMdiChild != null)
                {
                    lblMdlName.Text = this.ActiveMdiChild.Text;

                    formMode = ((IUserControl)this.ActiveMdiChild).CurrentMode;
                }
                SetFormStatus();
            }
            catch (Exception exception)
            {

                MessageBox.Show(exception.Message);
            }
        }

        #endregion


        #region Constructor
        #endregion


        #region Tool Menu Click_Event     



        #endregion

        private void mdiDashBoard_Load(object sender, EventArgs e)
        {
            toolStripStatusCompanyName.Text = Program.companyName;
            toolStripStatusUserName.Text = Program.userName;
            tslCounterName.Text = Program.counterNo;
            //jsTools.Enabled = false;
            //label2.Text = DateTime.Now.ToString("dd-MMM-yyyy   hh:mm tt");
            //Program.FYRId = 3;
            //Program.FYRName = "2016-17";
            timer1.Start();

            //=======================Financial Year==========================================
            //DataSet DsFyr = Program.RemoteFacade.GetDefaultFYRExit();
            //foreach (DataRow dr in DsFyr.Tables[0].Rows)
            //{
            //    Common.FinancialYearId = Common.IntConvert(dr["FYR_ID"].ToString());
            //    Common.StartFinancialYear = Convert.ToDateTime(dr["FYR_START_DATE"].ToString());
            //    Common.EndFinancialYear = Convert.ToDateTime(dr["FYR_END_DATE"].ToString());

            //}

            //fyrToolStripSplitButton.Text = Program.FYRName;
            fyrToolStripSplitButton.ForeColor = Color.Black;
           
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            toolStripStatusTime.Text = DateTime.Now.ToString("dd-MMM-yyyy hh:mm tt");
        }
        private void itemSetupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                ItemMaster frmObject = new ItemMaster();
                frmObject.MdiParent = this;
                frmObject.Show();
                this.lblMdlName.Text = frmObject.Text;
                SetFormStatus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,Common.ApplicationName);
            }
        }

        private void itemPurchaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                PurchaseOrder frmObject = new PurchaseOrder();
                frmObject.MdiParent = this;
                frmObject.Show();
                this.lblMdlName.Text = frmObject.Text;
                //formMode = FormModes.Load;
                SetFormStatus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Common.ApplicationName);
            }
        }

        private void invoiceToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                RetailInvoice frmObject = new RetailInvoice();
                frmObject.MdiParent = this;
                frmObject.Show();
                this.lblMdlName.Text = frmObject.Text;
                //formMode = FormModes.Load;
                SetFormStatus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Common.ApplicationName);
            }
        }

        private void brandSetupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                BrandMaster frmObject = new BrandMaster();
                frmObject.MdiParent = this;
                frmObject.Show();
                this.lblMdlName.Text = frmObject.Text;
                //formMode = FormModes.Load;
                SetFormStatus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Common.ApplicationName);
            }
        }

        private void productSetupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                ProductMaster frmObject = new ProductMaster();
                frmObject.MdiParent = this;
                frmObject.Show();
                this.lblMdlName.Text = frmObject.Text;
                //formMode = FormModes.Load;
                SetFormStatus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Common.ApplicationName);
            }
        }

        private void saleRegisterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                SaleRegister frmObject = new SaleRegister();
                frmObject.MdiParent = this;
                frmObject.Show();
                this.lblMdlName.Text = frmObject.Text;
                //formMode = FormModes.Load;
                SetFormStatus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Common.ApplicationName);
            }
        }

        private void purchaseRegisterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                PurchaseRegister frmObject = new PurchaseRegister();
                frmObject.MdiParent = this;
                frmObject.Show();
                this.lblMdlName.Text = frmObject.Text;
                //formMode = FormModes.Load;
                SetFormStatus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Common.ApplicationName);
            }
        }

        private void mUnitSetupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                MUnitMaster frmObject = new MUnitMaster();
                frmObject.MdiParent = this;
                frmObject.Show();
                this.lblMdlName.Text = frmObject.Text;
                //formMode = FormModes.Load;
                SetFormStatus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Common.ApplicationName);
            }
        }

        private void partySetupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                PartyMaster frmObject = new PartyMaster();
                frmObject.MdiParent = this;
                frmObject.Show();
                this.lblMdlName.Text = frmObject.Text;
                //formMode = FormModes.Load;
                SetFormStatus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Common.ApplicationName);
            }
        }
    }
    
}
