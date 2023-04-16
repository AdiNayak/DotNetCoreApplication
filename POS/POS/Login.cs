using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;

namespace POS
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtLoginId.Text == "admin" && txtPassword.Text == "admin1$")
            {
                new DashBoard().Show();
                this.Hide();
            }
            else
                MessageBox.Show("Invalid User Id or Password", Common.ApplicationName);
            //try
            //{

            //    DataSet Ds = Program.RemoteFacade.dsLogin(txtLoginId.Text,Common.EncryptText( txtPassword.Text));

            //    foreach (DataRow dr in Ds.Tables[0].Rows)
            //    {
            //        Program.userID =Common.IntConvert( dr["USER_ID"]);
            //        Program.userName = dr["USER_NAME"].ToString();
            //        Program.loginId = dr["USER_LOG_ID"].ToString();
            //        Program.password = dr["USER_PWD"].ToString();
            //        Program.roleId =Common.IntConvert( dr["ROLE_ID"]);
            //        Program.roleName = dr["ROLE_NAME"].ToString();
            //        Program.companyId = Common.IntConvert(dr["CMP_ID"]);
            //        Program.CompanyName = dr["CMP_NAME"].ToString();
            //    }

            //    if (Ds.Tables[0].Rows.Count > 0)
            //    {
            //        mdiDashBoard mdiDashBoard = new mdiDashBoard();
            //        mdiDashBoard.Show();
            //        this.Hide();
            //    }
            //    else
            //    { lblMessage.Text = "Invalid Login id or Password"; txtLoginId.Focus(); return; }

            //}
            //catch (Exception exception)
            //{
            //    MessageBox.Show(exception.Message);
            //}

        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void btnMinmize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtLoginId_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Enter)
            //{ txtPassword.Focus(); }
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            { btnLogin_Click(sender, e); }
        }
    }
}
