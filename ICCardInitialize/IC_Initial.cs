using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

/// <summary>
/// IC卡初始化(公司自已使用)
/// </summary>
/// author:黄春梅
/// 2008-9-1
namespace ICCardInitialize
{
    public partial class IC_Initial : Form
    {
        bool bolW=true; //初始化数据是否成功
        bool bolSave = true;//保存到数据库是否成功
        IntPtr ptr;
        RWini ini = new RWini();
        string strKeyA = string.Empty;
        string strKeyB = string.Empty;
        int Count = 0;
        int iLen = 0;

        ulong ulCardIDAll = 1;

        string strType = "1";//初始化卡类型
        string strOperateType = "";//操作方式 人工,升序,降序

        public IC_Initial()
        {
            InitializeComponent();

            try
            {
                strKeyA = CryptDes.DecryptDES(ini.IniReadValue("Key", "KeyA"), "EncryDes");
                strKeyB = CryptDes.DecryptDES(ini.IniReadValue("Key", "KeyB"), "EncryDes");
                DbHelperSQL.ComboxBind(this.cbxCoalKind, "TT_CoalKind", "CoalKindName", "CoalKindCode", "1=1", "CoalKindName");
                this.lblBeginCardNO.Visible = false;
                this.txtBeginCardNO.Visible = false;
            }
            catch
            {
                MessageBox.Show("请确认App.config文件中数据库设置是否正确!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void IC_Initial_Load(object sender, EventArgs e)
        {
            iLen = Convert.ToInt32(ini.IniReadValue("ICCard", "CardNoLen"));
            this.txtBeginCardNO.MaxLength = iLen;
            this.txtCardNO.MaxLength = iLen;
            int port = Convert.ToInt32(ini.IniReadValue("ICCard", "Port"));
            long baud = Convert.ToInt64(ini.IniReadValue("ICCard", "Baud"));
            ptr = RWCard.rf_init(port, baud);
            if ((int)ptr == -130)
            {
                this.lblTips.Text = "读卡器初始化失败";
                this.btnSave.Enabled = false;
            }
            else
            {
                this.lblTips.Text = "读卡器初始化成功";
                this.btnSave.Enabled = true;
            }

            timer_start.Interval = 500;
            if(this.strOperateType=="")
                timer_start.Enabled = true;
        }
        private void timer_start_Tick(object sender, EventArgs e)
        {
            ulong ulCardID = 0;
            int iLen = 0;
            bool bolExist = false;
            if ((int)ptr > 0)
            {
                int i = RWCard.rf_card(ptr, 1, ref ulCardID);
                if (i != 0)
                {
                    lblTips.Text = "请检查读写器上是否有卡!";
                    return;
                }
                else
                {
                    if (ulCardIDAll == ulCardID)
                    {
                        return;
                    }
                    
                    this.txtCardID.Text = ulCardID.ToString();
                    if (strOperateType == "")
                    {
                        if (this.txtCardNO.Text.Trim().Length == 0)
                        {
                            this.lblTips.Text = "请输入IC卡号";
                            return;
                        }
                        return;
                    }
                    bolExist = DbHelperSQL.isExistCardID(ulCardID.ToString(), strType);

                    if (this.txtCardNO.Text.Trim().Length == 0)
                    {
                        this.lblTips.Text = "请输入IC卡号";
                        return;
                    }
                    else
                    {
                        
                        if (!DbHelperSQL.bolIsNumber(this.txtCardNO.Text.Trim(), iLen))
                        {
                            this.lblTips.Text = "输入的IC卡号只能为" + iLen.ToString() + "位的数字";
                            return;
                        }
                    }

                    bool bolExistCardNO = false;

                    if (bolExist)
                    {
                        bolExistCardNO = DbHelperSQL.isExistCardNO(this.txtCardNO.Text.Trim(), ulCardID.ToString(), strType);
                    }
                    else
                    {
                        bolExistCardNO = DbHelperSQL.isExistCardNO(this.txtCardNO.Text.Trim(), "", strType);
                    }

                    if (bolExistCardNO)
                    {
                        lblTips.Text = "您输入的卡号已经存在!";
                        return;
                    }
                }

                if (bolExist)
                {
                    int iChangePsw = -1;

                    i = RWCard.rf_load_key_hex(ptr, 0, 0, "ffffffffffff");
                    i = RWCard.rf_load_key_hex(ptr, 4, 0, "ffffffffffff");
                    i = RWCard.rf_authentication(ptr, 0, 0);

                    if (i != 0)
                    {
                        //加载已存在密码
                        i = RWCard.rf_card(ptr, 1, ref ulCardID);
                        i = RWCard.rf_load_key_hex(ptr, 0, 0, strKeyA);
                        i = RWCard.rf_load_key_hex(ptr, 4, 0, strKeyB);
                        i = RWCard.rf_authentication(ptr, 0, 0);

                        if (i != 0)
                        {
                            lblTips.Text = "初始化密码验证失败!";

                            return;
                        }
                    }
                    else
                    {
                        iChangePsw = RWCard.rf_changeb3(ptr, 0, CryptDes.UnHex(strKeyA, "gb2312"), 0, 0, 0, 1, 0, CryptDes.UnHex(strKeyB, "gb2312"));
                    }
                }
                else
                {
                    //DialogResult result = MessageBox.Show("该卡已经初始化过，是否再初始化一遍", "天大天科IC卡初始化系统", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                    //if (result == DialogResult.Yes)
                    //{
                    i = RWCard.rf_load_key_hex(ptr, 0, 0, strKeyA);
                    i = RWCard.rf_load_key_hex(ptr, 4, 0, strKeyB);
                    i = RWCard.rf_authentication(ptr, 0, 0);

                    if (i != 0)
                    {
                        lblTips.Text = "密码验证失败!";
                        return;
                    }
                    //}
                    
                }

                ///往第二块写入卡号+卡类型标识(1：标识卡 2：准运卡)+状态(1:正常)+煤种(4位)
                string str = ""; //要写入第一块的数据
                str = this.txtCardNO.Text.Trim() + strType + "1";
                if (strType == "1")
                    str += this.cbxCoalKind.SelectedValue.ToString().PadLeft(4, '0');
                str = str.PadRight(32, '0');
                i = RWCard.rf_write_hex(ptr, 1, str);
                if (i != 0)
                {
                    lblTips.Text = "IC卡初始化写失败！";
                    bolW = false;
                    return;
                }
                if (bolW)
                    bolSave = DbHelperSQL.bolInsertInitialCard(this.txtCardNO.Text.Trim(), ulCardID.ToString(), strType);
                if (bolW && bolSave)
                {
                    RWCard.rf_beep(ptr, 20);
                    lblTips.Text = "IC卡初始化成功,请刷另一张卡！";
                    if (strOperateType == "asc")
                    {
                        this.txtCardNO.Text = (Convert.ToDecimal(this.txtCardNO.Text.Trim()) + 1).ToString();
                    }
                    else if (strOperateType == "desc")
                        this.txtCardNO.Text = (Convert.ToDecimal(this.txtCardNO.Text.Trim()) - 1).ToString();
                    else if(strOperateType == "")
                        this.txtCardNO.Text = "";
                    ulCardIDAll = ulCardID;
                }
                else
                    lblTips.Text = "IC卡初始化失败,请刷另一张卡！";
                bolW = true;
                bolSave = true;
                txtCardNO.Focus();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (this.strOperateType != "")
            {
                if (this.btnSave.Text == "开始初始化")
                {
                    if (this.txtBeginCardNO.Text.Trim() == "")
                    {
                        MessageBox.Show("请输入起始卡号!");
                        return;
                    }
                    int iLen0 = Convert.ToInt32(ini.IniReadValue("ICCard", "CardNoLen"));
                    if (!DbHelperSQL.bolIsNumber(this.txtCardNO.Text.Trim(), iLen0))
                    {
                        this.lblTips.Text = "起始卡号只能为" + iLen0.ToString() + "位的数字!";
                        return;
                    }
                    bool bolExistCardNO = DbHelperSQL.isExistCardNO(this.txtBeginCardNO.Text.Trim(), "", strType);
                    if (bolExistCardNO)
                    {
                        MessageBox.Show("您输入的起始卡号已经存在，请重新输入!");
                        return;
                    }
                    timer_start.Enabled = true;
                    this.btnSave.Text = "结束初始化";
                    this.txtBeginCardNO.Enabled = false;
                    this.txtCardNO.Enabled = false;
                }
                else if (this.btnSave.Text == "结束初始化")
                {
                    timer_start.Enabled = false;
                    this.btnSave.Text = "开始初始化";
                    this.txtBeginCardNO.Enabled = true;
                    this.txtCardNO.Enabled = false;
                }
                return;
            }
            
            ulong ulCardID = 0;
            int iLen = 0;
            bool bolExist=false;
           
            if ((int)ptr > 0)
            {
                int i = RWCard.rf_card(ptr, 1, ref ulCardID);

                if (i != 0)
                {
                    lblTips.Text = "请检查读写器上是否有卡!";
                    return;
                }
                else
                {
                    bolExist = DbHelperSQL.isExistCardID(ulCardID.ToString(), strType);

                    if (this.txtCardNO.Text.Trim().Length == 0)
                    {
                        this.lblTips.Text = "请输入IC卡号";
                        return;
                    }
                    else
                    {
                        iLen = Convert.ToInt32(ini.IniReadValue("ICCard", "CardNoLen"));
                        if (!DbHelperSQL.bolIsNumber(this.txtCardNO.Text.Trim(), iLen))
                        {
                            this.lblTips.Text = "输入的IC卡号只能为" + iLen.ToString() + "位的数字";
                            return;
                        }
                    }

                    bool bolExistCardNO = false;

                    if (bolExist)
                    {
                        bolExistCardNO = DbHelperSQL.isExistCardNO(this.txtCardNO.Text.Trim(), ulCardID.ToString(), strType);
                    }
                    else
                    {
                        bolExistCardNO = DbHelperSQL.isExistCardNO(this.txtCardNO.Text.Trim(), "", strType);
                    }

                    if (bolExistCardNO)
                    {
                        lblTips.Text = "您输入的卡号已经存在,请重新输入卡号!";
                        return;
                    }
                }

                if (!bolExist)
                {
                    int iChangePsw=-1;

                    i = RWCard.rf_load_key_hex(ptr, 0, 0, "ffffffffffff");
                    i = RWCard.rf_load_key_hex(ptr, 4, 0, "ffffffffffff");
                    i = RWCard.rf_authentication(ptr, 0, 0);

                    if (i != 0)
                    {
                        //加载已存在密码
                        i = RWCard.rf_card(ptr, 1, ref ulCardID);
                        i = RWCard.rf_load_key_hex(ptr, 0, 0, strKeyA);
                        i = RWCard.rf_load_key_hex(ptr, 4, 0, strKeyB);
                        i = RWCard.rf_authentication(ptr, 0, 0);

                        if (i != 0)
                        {
                            lblTips.Text = "初始化密码验证失败!";
                            return;
                        }
                    }
                    else
                    {
                        iChangePsw = RWCard.rf_changeb3(ptr, 0, CryptDes.UnHex(strKeyA, "gb2312"), 0, 0, 0, 1, 0, CryptDes.UnHex(strKeyB, "gb2312"));
                    }
                }
                else
                {
                    DialogResult result=MessageBox.Show("该卡已经初始化过，是否再初始化一遍", "天大天科卡初始化系统", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                    if (result == DialogResult.Yes)
                    {
                        i = RWCard.rf_load_key_hex(ptr, 0, 0, strKeyA);
                        i = RWCard.rf_load_key_hex(ptr, 4, 0, strKeyA);
                        i = RWCard.rf_authentication(ptr, 0, 0);

                        if (i != 0)
                        {
                            lblTips.Text = "密码验证失败!";
                            return;
                        }
                    }
                    else
                        return;
                }
               
                //往第二块写入卡号+卡类型标识(1：标识卡 2：准运卡)+状态(1:正常)
                string str=""; //要写入第一块的数据
                str = this.txtCardNO.Text.Trim() + strType + "1";
                if (strType == "1")
                    str += this.cbxCoalKind.SelectedValue.ToString().PadLeft(4, '0');
                str = str.PadRight(32, '0');
                i = RWCard.rf_write_hex(ptr, 1, str);
                if (i != 0)
                    bolW = false;
                if (bolW)
                    bolSave = DbHelperSQL.bolInsertInitialCard(this.txtCardNO.Text.Trim(), ulCardID.ToString(),strType);
                if (bolW && bolSave)
                {
                    RWCard.rf_beep(ptr, 20);
                    lblTips.Text = "IC卡初始化成功,请刷另一张卡！";
                    this.txtCardNO.Text = "";
                }
                else
                    lblTips.Text = "IC卡初始化失败,请刷另一张卡！";
                bolSave = true;
                bolSave = true;

                txtCardNO.Focus();
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void rdbMarkCard_CheckedChanged(object sender, EventArgs e)
        {
            strType = "1";
            timer_start.Enabled = false;
            if (strOperateType == "")
            {
                this.txtBeginCardNO.Visible = false;
                this.lblBeginCardNO.Visible = false;
            }
            else
            {
                this.txtBeginCardNO.Visible = true;
                this.lblBeginCardNO.Visible = true;
            }
            this.lblCoalKind.Visible = true;
            this.cbxCoalKind.Visible = true;
        }

        private void rdbNavicet_CheckedChanged(object sender, EventArgs e)
        {
            strType = "2";
            timer_start.Enabled = false;
            this.lblCoalKind.Visible = false;
            this.cbxCoalKind.Visible = false;
        }

        private void rdbTemp_CheckedChanged(object sender, EventArgs e)
        {
            strType = "3";
            timer_start.Enabled = false;
            this.lblCoalKind.Visible = false;
            this.cbxCoalKind.Visible = false;
        }

       
        private void IC_Initial_FormClosing(object sender, FormClosingEventArgs e)
        {
            RWCard.rf_exit(ptr);
            timer_start.Enabled = false;
            timer_start.Stop();
            timer_start.Dispose();
        }

        private void rdbHand_CheckedChanged(object sender, EventArgs e)
        {
            strOperateType = "";
            this.btnSave.Text = "保存";
            this.lblBeginCardNO.Visible = false;
            this.txtBeginCardNO.Visible = false;
            timer_start.Enabled = true;
            this.lblCardNO.Text = "请输入卡号：";
            this.txtCardNO.Enabled = true;
            this.lblTips.Text = "";
        }

        private void rdbAsc_CheckedChanged(object sender, EventArgs e)
        {
            timer_start.Enabled = false;
            strOperateType = "asc";
            this.btnSave.Text = "开始初始化";
            this.lblBeginCardNO.Visible = true;
            this.txtBeginCardNO.Visible = true;
            this.lblCardNO.Text = "初始化的卡号：";
            this.txtCardNO.Enabled = false;
            this.txtBeginCardNO.Enabled = true;
            this.txtBeginCardNO.Text = "";
            this.txtCardNO.Text = "";
            this.txtCardID.Text = "";
            this.lblTips.Text = "";

            if (strType == "2" || strType=="3")
            {
                this.lblCoalKind.Visible = false;
                this.cbxCoalKind.Visible = false;
            }
            else
            {
                this.lblCoalKind.Visible = true;
                this.cbxCoalKind.Visible = true;
            }
        }

        private void rdbDesc_CheckedChanged(object sender, EventArgs e)
        {
            timer_start.Enabled = false;
            strOperateType = "desc";
            this.btnSave.Text = "开始初始化";
            this.lblBeginCardNO.Visible = true;
            this.txtBeginCardNO.Visible = true;
            this.lblCardNO.Text = "初始化的卡号：";
            this.txtCardNO.Enabled = false;
            this.txtBeginCardNO.Enabled = true;
            this.txtBeginCardNO.Text = "";
            this.txtCardNO.Text = "";
            this.txtCardID.Text = "";
            this.lblTips.Text = "";

            if (strType == "2" || strType == "3")
            {
                this.lblCoalKind.Visible = false;
                this.cbxCoalKind.Visible = false;
            }
            else
            {
                this.lblCoalKind.Visible = true;
                this.cbxCoalKind.Visible = true;
            }
        }


        private void txtBeginCardNO_TextChanged(object sender, EventArgs e)
        {
            this.txtCardNO.Text = this.txtBeginCardNO.Text;
        }
    }
}