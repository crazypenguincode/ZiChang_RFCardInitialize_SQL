using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

/// <summary>
/// 检测初始化卡号与卡上的号是否一致(公司自已使用)
/// </summary>
/// author:huangcm
/// 2008-8-20
namespace ICCardInitialize
{
    public partial class IC_CheckCardNO : Form
    {
        IntPtr ptr;
        RWini ini = new RWini();
        ulong ulCardNoSelfG = 1;
        string strKeyA = string.Empty;
        string strKeyB = string.Empty;
        int port;
        long baud;

        public IC_CheckCardNO()
        {
            InitializeComponent();

            port = Convert.ToInt32(ini.IniReadValue("ICCard", "Port"));
            baud = Convert.ToInt64(ini.IniReadValue("ICCard", "Baud"));

            strKeyA = CryptDes.DecryptDES(ini.IniReadValue("Key", "KeyA"), "EncryDes");
            strKeyB = CryptDes.DecryptDES(ini.IniReadValue("Key", "KeyB"), "EncryDes");
        }
        private void timer_CheckCardNO_Tick(object sender, EventArgs e)
        {
            ulong ulCardNoSelf = 0;
            int i = -1;
            if ((int)ptr > 0)
            {
                i = RWCard.rf_card(ptr, 1, ref ulCardNoSelf);

                if (i != 0)
                {
                    lblTips.Text = "请检查读写器上是否有卡!";
                    return;
                }
                else
                {
                    if (ulCardNoSelfG == ulCardNoSelf)
                        return;
                    bool bolExist = DbHelperSQL.isExistCardID(ulCardNoSelf.ToString());
                    if (bolExist)
                    {
                        ulong card = 0;
                        RWCard.rf_card(ptr, 1, ref card); //读取卡号 
                        
                        i = RWCard.rf_load_key_hex(ptr, 0, 0, strKeyA);
                        i = RWCard.rf_load_key_hex(ptr, 4, 0, strKeyA);
                        i = RWCard.rf_authentication(ptr, 0, 0);
                        int iLen = Convert.ToInt32(ini.IniReadValue("ICCard", "CardNoLen"));
                        txtCardCode.Text = card.ToString();
                        string strBlockOne = RWCard.ReadICCardData(ptr, 1, 0, 32);
                        this.txtCardNO.Text = strBlockOne.Substring(0,iLen);
                        ulCardNoSelfG = ulCardNoSelf;
                        string strCardKind = strBlockOne.Substring(iLen,1);
                        switch (strCardKind)
                        {
                            case "1":
                                this.txtCardKind.Text = "标识卡";
                                string strCoalKindCode = strBlockOne.Substring(iLen + 2, 4).Trim('0');
                                if (strCoalKindCode != "0000")
                                {
                                    this.txtCoalKind.Text = DbHelperSQL.strGetCoalKindByCode(strCoalKindCode);
                                    this.lblCoalKind.Visible = true;
                                    this.txtCoalKind.Visible = true;
                                }
                                break;
                            case "2":
                                this.txtCardKind.Text = "准运卡";
                                this.lblCoalKind.Visible = false;
                                this.txtCoalKind.Visible = false;
                                break;
                            //case "3":
                            //    this.txtCardKind.Text = "二次转运卡";
                            //    this.lblCoalKind.Visible = false;
                            //    this.txtCoalKind.Visible = false;
                            //    break;
                            case "3":
                                this.txtCardKind.Text = "临时卡";
                                this.lblCoalKind.Visible = false;
                                this.txtCoalKind.Visible = false;
                                break;
                            default:
                                break;
                        }
                        
                        RWCard.rf_beep(ptr, 20);
                        this.lblTips.Text = "卡号读取成功！";
                    }
                    else
                    {
                        this.lblTips.Text = "该卡没有被初始化，请初始化该卡";
                    }
                }
            }
            else
            {
                this.lblTips.Text = "读卡器初始化失败";
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void IC_CheckCardNO_Load(object sender, EventArgs e)
        {
            int port = Convert.ToInt32(ini.IniReadValue("ICCard", "Port"));
            long baud = Convert.ToInt64(ini.IniReadValue("ICCard", "Baud"));
            ptr = RWCard.rf_init(port, baud);
            if ((int)ptr == -130)
                this.lblTips.Text = "读卡器初始化失败";
            else
                this.lblTips.Text = "读卡器初始化成功";
        }

        private void IC_CheckCardNO_FormClosing(object sender, FormClosingEventArgs e)
        {
            RWCard.rf_exit(ptr);
            this.timer_CheckCardNO.Enabled = false;
            this.timer_CheckCardNO.Stop();
            this.timer_CheckCardNO.Dispose();
        }
    }
}