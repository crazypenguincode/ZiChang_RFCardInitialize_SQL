using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net;

namespace ICCardInitialize
{
    public partial class IC_PortSet : Form
    {
        RWini ini=new RWini();

        public IC_PortSet()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string strMsg = "";
                if (this.txtICCardlen.Text.Trim() == "")
                    strMsg += "请输入IC卡号长度!\r\n";
                if (!DbHelperSQL.bolIsNumber(this.txtICCardlen.Text.Trim(), 2) && !DbHelperSQL.bolIsNumber(this.txtICCardlen.Text.Trim(), 1))
                    strMsg += "IC卡长度只能为数字!\r\n";
                else if (Convert.ToInt32(this.txtICCardlen.Text.Trim()) > 20)
                    strMsg += "IC卡长度不能大于20!\r\n";
                else
                    strMsg += "";

                if (this.txtRfCardLen.Text.Trim() == "")
                    strMsg += "请输入电子标签长度!\r\n";
                if (!DbHelperSQL.bolIsNumber(this.txtRfCardLen.Text.Trim(), 2))
                    strMsg += "电子标签长度只能为数字!\r\n";
                else if (Convert.ToInt32(this.txtRfCardLen.Text.Trim()) > 20)
                    strMsg += "电子标签长度不能大于20!";
                if (strMsg != "")
                {
                    MessageBox.Show(strMsg, "天科初始化系统", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return;
                }
                string strBps = "";
                if (this.rdbtn9600.Checked)
                    strBps = "9600";
                if (this.rdbtn19200.Checked)
                    strBps = "19200";
                int iCom = Convert.ToInt32(this.cbxIcCom.Text.Replace("COM", "")) - 1;
                ini.IniWriteValue("ICCard", "Port", iCom.ToString());
                ini.IniWriteValue("ICCard", "Baud", strBps);
                ini.IniWriteValue("ICCard", "CardNoLen", this.txtICCardlen.Text.Trim());

                ini.IniWriteValue("ReMote", "COM", this.cbxRFCom.Text);
                ini.IniWriteValue("ReMote", "Boud", this.cbxRFBound.Text.Replace("bps", ""));
                ini.IniWriteValue("ReMote", "CardNoLen", this.txtRfCardLen.Text.Trim());
                ini.IniWriteValue("ReMote", "Interval", this.txtReadAndWrite.Text.Trim());
                MessageBox.Show("读卡器串口初始化设置成功", "天科IC卡初始化系统", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
              
            }
            catch (Exception ex)
            {

                MessageBox.Show("串口失败初始化：" + ex.Message, "天科IC卡初始化系统", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void IC_PortSet_Load(object sender, EventArgs e)
        {
            this.txtICCardlen.Text=ini.IniReadValue("ICCard", "CardNoLen");
            this.txtRfCardLen.Text = ini.IniReadValue("RF", "CardNoLen");
            string strPort = ini.IniReadValue("ICCard", "Port");
            if (strPort != "")
                this.cbxIcCom.SelectedIndex = Convert.ToInt32(strPort);
            string strBaud = ini.IniReadValue("ICCard", "Baud");
            if (strBaud!="")
            {
                switch (strBaud)
                {
                    case "9600":
                        this.rdbtn9600.Select(); 
                        break;
                    case "19200":
                        this.rdbtn19200.Select(); 
                        break;
                    default:
                        break;
                }
            }
            strBaud = ini.IniReadValue("ReMote", "Baud");
            if(strPort!="")
                this.cbxRFBound.Text = strBaud+"bps";
            this.cbxRFCom.Text = ini.IniReadValue("ReMote", "COM");
            txtRfCardLen.Text = ini.IniReadValue("ReMote", "CardNoLen");
            txtReadAndWrite.Text = ini.IniReadValue("ReMote", "Interval");
        }
    }
}