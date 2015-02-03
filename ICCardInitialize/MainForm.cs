using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ICCardInitialize
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

       

        private void tsmi_PortInitial_Click(object sender, EventArgs e)
        {
            new IC_PortSet().ShowDialog();

        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            
            if (new RWini().IniReadValue("UserInfo", "UserCode") != "admin")
                this.tsmi_Psw.Visible = false;
        }

        private void tsmi_Psw_Click(object sender, EventArgs e)
        {
            new IC_PasswordSet().ShowDialog();
        }


        private void tsmi_SysSet_Click(object sender, EventArgs e)
        {
            new IC_PortSet().ShowDialog();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("您确定要退出系统吗？", "天大天科IC卡初始化", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
                Application.Exit();
        }

        private void icInitial_Click(object sender, EventArgs e)
        {
            new IC_Initial().ShowDialog();
        }

        private void rfInitial_Click(object sender, EventArgs e)
        {
            new RF_Initial().ShowDialog();
        }

        private void icCheck_Click(object sender, EventArgs e)
        {
            new IC_CheckCardNO().ShowDialog();
        }

        private void rfCheck_Click(object sender, EventArgs e)
        {
            new RF_CheckCardNO().ShowDialog();
        }
    }
}