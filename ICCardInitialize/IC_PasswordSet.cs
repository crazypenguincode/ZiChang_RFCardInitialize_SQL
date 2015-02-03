using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;


/// <summary>
/// 给IC卡设置密码(天科公司自已使用)
/// </summary>
/// author:huangcm
/// 2008-8-6
namespace ICCardInitialize
{
    public partial class IC_PasswordSet : Form
    {
        RWini ini = new RWini();
        public IC_PasswordSet()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!Regex.IsMatch(this.txtKeyA.Text.Trim(), "[A-Za-z0-9]{6}"))
            {
                MessageBox.Show("A密码必须为六位的字母和数字的组合","天大天科IC卡初始化系统",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
            if (!Regex.IsMatch(this.txtKeyB.Text.Trim(), "[A-Za-z0-9]{6}"))
            {
                MessageBox.Show("B密码必须为六位的字母和数字的组合", "天大天科IC卡初始化系统", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (this.txtKeyA.Text.Trim() != this.txtKeyAAgain.Text.Trim())
            {
                MessageBox.Show("A密码与确认密码不一致", "天大天科IC卡初始化系统", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (this.txtKeyB.Text.Trim() != this.txtKeyBAgain.Text.Trim())
            {
                MessageBox.Show("B密码与确认密码不一致", "天大天科IC卡初始化系统", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string strKeyA = CryptDes.ToHex(this.txtKeyA.Text.Trim(), "gb2312", false); ;
            strKeyA=CryptDes.EncryptDES(strKeyA, "EncryDes");
            
            string strA = CryptDes.DecryptDES(strKeyA, "EncryDes");
            ini.IniWriteValue("Key", "KeyA", strKeyA);
            string strKeyB = CryptDes.ToHex(this.txtKeyB.Text.Trim(), "gb2312", false);
            strKeyB = CryptDes.EncryptDES(strKeyB, "EncryDes");
            ini.IniWriteValue("Key", "KeyB", strKeyB);
            MessageBox.Show("密码设置成功！", "天大天科IC卡初始化系统", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}