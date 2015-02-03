using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ICCardInitialize
{
    public partial class IC_UserLogin : Form
    {
        public IC_UserLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (this.txtUserCode.Text.Trim() == "")
            {
                MessageBox.Show("请输入用户名", "提示", MessageBoxButtons.OK);
                return;
            }
            RWini ini=new RWini();
            ini.IniWriteValue("UserInfo", "UserCode", this.txtUserCode.Text.Trim());
            this.DialogResult = DialogResult.OK;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}