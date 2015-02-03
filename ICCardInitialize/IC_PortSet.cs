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
                    strMsg += "������IC���ų���!\r\n";
                if (!DbHelperSQL.bolIsNumber(this.txtICCardlen.Text.Trim(), 2) && !DbHelperSQL.bolIsNumber(this.txtICCardlen.Text.Trim(), 1))
                    strMsg += "IC������ֻ��Ϊ����!\r\n";
                else if (Convert.ToInt32(this.txtICCardlen.Text.Trim()) > 20)
                    strMsg += "IC�����Ȳ��ܴ���20!\r\n";
                else
                    strMsg += "";

                if (this.txtRfCardLen.Text.Trim() == "")
                    strMsg += "��������ӱ�ǩ����!\r\n";
                if (!DbHelperSQL.bolIsNumber(this.txtRfCardLen.Text.Trim(), 2))
                    strMsg += "���ӱ�ǩ����ֻ��Ϊ����!\r\n";
                else if (Convert.ToInt32(this.txtRfCardLen.Text.Trim()) > 20)
                    strMsg += "���ӱ�ǩ���Ȳ��ܴ���20!";
                if (strMsg != "")
                {
                    MessageBox.Show(strMsg, "��Ƴ�ʼ��ϵͳ", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
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
                MessageBox.Show("���������ڳ�ʼ�����óɹ�", "���IC����ʼ��ϵͳ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
              
            }
            catch (Exception ex)
            {

                MessageBox.Show("����ʧ�ܳ�ʼ����" + ex.Message, "���IC����ʼ��ϵͳ", MessageBoxButtons.OK, MessageBoxIcon.Error);
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