using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

/// <summary>
/// 电子标签(公司自已使用)
/// </summary>
namespace ICCardInitialize
{
    public partial class RF_Initial : Form
    {
        #region 全局变量
        RWini ini = new RWini();
        /// <summary>
        /// 操作方式 人工,升序,降序
        /// </summary>
        string strOperateType = "";
        /// <summary>
        /// 获取到的电子标签
        /// </summary>
        string strAllCode = "";

        string REFCODE = "";

        short i = -1;
        /// <summary>
        /// 电子标签长度
        /// </summary>
        int iRfLen = 0;

        #endregion

        #region 窗体构造函数
        public RF_Initial()
        {
            InitializeComponent();
        } 
        #endregion

        public delegate void SetUIDelegate();

        #region -对电子标签事件进行委托处理
        /// <summary>
        /// -被调用的事件委托
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        public void SetUIICCard(object sender, EventArgs args)
        {

            try
            {
                SetUIDelegate delgate = null;
                delgate += new SetUIDelegate(SetICCValue);
                while (!this.IsHandleCreated) { ;}
                this.BeginInvoke(delgate, null);
            }
            catch (Exception ex)
            {
                Log.WriteLog("电子标签委托", ex.ToString());
            }
        }
        #endregion

        #region -电子标签给控件赋值?
        /// <summary>
        /// -电子标签给控件赋值
        /// </summary>
        private void SetICCValue()
        {
            try
            {
                string[] arry = this.rfCard.CardCode.Split(',');
                this.txtCardCode.Clear();
                this.txtCardCode.Text = arry[arry.Length - 1];
            }
            catch (Exception ex)
            {
                Log.WriteLog("电子标签给控件赋值", ex.ToString());
            }
            //try
            //{
            //    txtCardCode.Clear();
            //    this.txtCardCode.Text = this.rfCard.CardCode;
            //    this.rfCard.CardCode = "";

            //}
            //catch (Exception ex)
            //{
            //    Log.WriteLog("电子标签给控件赋值", ex.ToString());
            //}
        }
        #endregion

        #region 窗体初始化...
        /// <summary>
        /// 窗体初始化...
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RF_Initial_Load(object sender, EventArgs e)
        {
            #region 电子标签器初始化
            string strCom = ini.IniReadValue("ReMote", "COM");
            string strBaud = ini.IniReadValue("ReMote", "Boud");
            iRfLen = int.Parse(ini.IniReadValue("ReMote", "CardNoLen"));
            this.txtCardCode.MaxLength = iRfLen;//设置电子标签文本框数据长度
            this.rfCard.Close();
            i = this.rfCard.Initialize(strCom, strBaud);
            if (i != 0)
            {
                this.lblTips.Text = "电子标签读卡器初始化失败";
                MessageBox.Show("电子标签读卡器初始化失败!", "天大天科", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //this.btnSave.Enabled = false;
            }
            else
            {
                this.lblTips.Text = "电子标签读卡器初始化成功";
                this.btnSave.Enabled = true;
                this.rfCard.SetUIValue += new EventHandler(SetUIICCard);//
            }
            #endregion

            string TimeInterval = ini.IniReadValue("ReMote", "Interval");
            timer_start.Interval = int.Parse(TimeInterval);//设置读写频率

            //if (this.strOperateType == "")
            //{
            //    timer_start.Enabled = true;
            //}
        }
        #endregion

        #region 时钟进行重复读写，对电子标签进行读取和写入，并存入数据库中
        /// <summary>
        /// 时钟进行重复读写，对电子标签进行读取和写入，并存入数据库中
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer_start_Tick(object sender, EventArgs e)
        {
            if (i == 0)//i=0表示电子标签初始化成功！
            {
                string strCardCode = this.rfCard.CardCode;

                //txtCardCode.Text = this.rfCard.CardCode;

                byte iCount = this.rfCard.CardCount;

                this.rfCard.CardCode = "";

                if (iCount == 0)
                {
                    lblTips.Text = "请检查电子标签读写器上是否有卡!";
                    txtCardCode.Clear();
                    return;
                }
                else if (iCount > 1)
                {
                    lblTips.Text = "请检查电子标签读写器上是否只有一张卡!";
                    txtCardCode.Clear();
                    return;
                }
                else if (iCount == 1)//读到了一张电子标签
                {
                    timer_start.Stop();

                    int iExist = Convert.ToInt32(DbHelperSQL.GetSingle("Select Count(0) from TT_RFCard where CardCode='" + this.txtREFCode.Text + "'"));
                    if (iExist == 0)
                    {
                        strCardCode = this.rfCard.CardCode;
                        //int iIsInit = Convert.ToInt32(DbHelperSQL.GetSingle("Select Count(0) from TT_RFCard where CardCode='" + strCardCode + "'"));
                        int iIsInit = Convert.ToInt32(DbHelperSQL.GetSingle("Select Count(0) from TT_RFCard where CardCode='" + txtCardCode.Text.Trim() + "'"));
                        if (iIsInit > 0)
                        {
                            DialogResult result = MessageBox.Show("该卡已经初始化过，是否再初始化一遍", "天大天科卡初始化系统", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                            if (result == DialogResult.No)
                            {
                                this.lblTips.Text = "该电子标签已初始化过";
                                txtCardCode.Clear();
                                return;
                            }
                        }


                        short iSuccess = -1;
                        while (iSuccess != 0)
                        {
                            iSuccess = this.rfCard.RfWrite(txtREFCode.Text.Trim());//写入电子标签信息
                        }
                        if (iSuccess == 0)
                        {
                            if (iIsInit == 0)
                            {
                                DbHelperSQL.ExecuteSql("Insert into TT_RFCard Values('" + this.txtREFCode.Text + "',getdate(),'" + ini.IniReadValue("UserInfo", "UserCode") + "')");
                            }
                            else
                            {
                                DbHelperSQL.ExecuteSql("Update TT_RFCard Set CardCode='" + this.txtREFCode.Text + "' where CardCode='" + txtCardCode.Text.Trim() + "'");
                            }
                            RWini.Beep(2047, 150);
                            this.lblTips.Text = "初始化成功,请刷另一张电子标签";
                            //if (strOperateType == "asc")
                            //    this.txtCardCode.Text = (Convert.ToInt64(this.txtCardCode.Text) + 1).ToString();
                            //else if (strOperateType == "desc")
                            //    this.txtCardCode.Text = (Convert.ToInt64(this.txtCardCode.Text) - 1).ToString();
                            string rfcode = txtREFCode.Text;
                            txtREFCode.Clear();
                            txtREFCode.Text = (int.Parse(rfcode) + 1).ToString();
                            txtCardCode.Clear();
                            this.rfCard.CardCode = "";
                        }
                    }
                    else
                    {
                        this.lblTips.Text = "该卡号已经被使用过，不能继续初始化";

                        txtCardCode.Clear();
                        this.rfCard.CardCode = "";
                    }
                }
                txtCardCode.Clear();
                this.rfCard.CardCode = "";
                timer_start.Start();
            }
        }
        
        #endregion

        #region  开始初始化
        /// <summary>
        /// 开始初始化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (this.btnSave.Text == "结束初始化")
            {
                timer_start.Enabled = false;
                this.btnSave.Text = "开始初始化";
                return;
            }

            int iExist = Convert.ToInt32(DbHelperSQL.GetSingle("Select Count(0) from TT_RFCard where CardCode='" + this.txtREFCode.Text + "'"));

            if (this.txtREFCode.Text.Trim() == "")
            {
                MessageBox.Show("请点击获取电子标签起始号!");
                return;
            }

            if (!DbHelperSQL.bolIsNumber(txtREFCode.Text.Trim(), iRfLen))//判断卡号是否是10位数字
            {
                this.lblTips.Text = "起始卡号只能为" + iRfLen + "位的数字!";
                return;
            }
            if (iExist > 0)
            {
                this.lblTips.Text = "获取到的电子标签起始号已经存在，请联系开发人员!";

                txtCardCode.Clear();
                return;
            }


            if (txtCardCode.Text.Trim() == "")
            {
                this.lblTips.Text = "没有读取到电子标签号";

                return;
            }

            if (iExist == 0)
            {
                string strCardCode = this.rfCard.CardCode;
                //int iIsInit = Convert.ToInt32(DbHelperSQL.GetSingle("Select Count(0) from TT_RFCard where CardCode='" + strCardCode + "'"));
                int iIsInit = Convert.ToInt32(DbHelperSQL.GetSingle("Select Count(0) from TT_RFCard where CardCode='" + txtCardCode.Text.Trim() + "'"));
                if (iIsInit != 0)
                {
                    DialogResult result = MessageBox.Show("该卡已经初始化过，是否再初始化一遍", "天大天科卡初始化系统", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (result == DialogResult.No)
                    {
                        return;
                    }
                }
                short iSuccess = -1;
                while (iSuccess != 0)
                {
                    iSuccess = this.rfCard.RfWrite(this.txtREFCode.Text.Trim());

                }
                if (iSuccess == 0)//电子标签内部写入成功
                {
                    DateTime nowTime = DateTime.Now;
                    string sqlInsert = string.Empty;
                    if (iIsInit == 0)
                    {
                        DbHelperSQL.ExecuteSql("Insert into TT_RFCard Values('" + this.txtREFCode.Text + "',"+nowTime+",'" + ini.IniReadValue("UserInfo", "UserCode") + "')");

                        #region 插入sql语句到同步表中
                        sqlInsert = "insert [NetWorkDisconnectionLog] (ID, SQLcontext, datetime, IP) values (@ID,@SQLcontext,@datetime,@IP)";
                        SqlParameter[] sqlpars = new SqlParameter[]
                        {
                            new SqlParameter("@ID",DateTime.Now.ToString()), 
                            new SqlParameter("@SQLcontext","Insert into TT_RFCard Values('" + this.txtREFCode.Text + "',"+nowTime+",'" + ini.IniReadValue("UserInfo", "UserCode") + "')"), 
                            new SqlParameter("@datetime",DateTime.Now.ToString()), 
                            new SqlParameter("@IP","172.10.14.1")
                        };
                        DbHelperSQL.ExecuteSql(sqlInsert); 
                        #endregion
                    }
                    else
                    {
                        DbHelperSQL.ExecuteSql("Update TT_RFCard Set CardCode='" + this.txtREFCode.Text + "',InitialTime='"+nowTime+"' where CardCode='" + txtCardCode.Text.Trim() + "'");

                        #region 插入sql语句到同步表中
                        sqlInsert = "insert [NetWorkDisconnectionLog] (ID, SQLcontext, datetime, IP) values (@ID,@SQLcontext,@datetime,@IP)";
                        SqlParameter[] sqlpars = new SqlParameter[]
                        {
                            new SqlParameter("@ID",DateTime.Now.ToString()), 
                            new SqlParameter("@SQLcontext","Update TT_RFCard Set CardCode='" + this.txtREFCode.Text + "',InitialTime='"+nowTime+"' where CardCode='" + txtCardCode.Text.Trim() + "'"), 
                            new SqlParameter("@datetime",DateTime.Now.ToString()), 
                            new SqlParameter("@IP","172.10.14.1")
                        };
                        DbHelperSQL.ExecuteSql(sqlInsert);
                        #endregion
                    }

                    //this.txtCardCode.Text = (Convert.ToInt64(this.txtCardCode.Text) + 1).ToString();
                    this.lblTips.Text = "初始化成功,请刷另一张电子标签";
                    RWini.Beep(2047, 150);//鸣叫

                    string rfcode = txtREFCode.Text;
                    txtREFCode.Clear();
                    txtREFCode.Text = (int.Parse(rfcode) + 1).ToString();
                    txtCardCode.Clear();
                    this.rfCard.CardCode = "";
                    timer_start.Enabled = true;
                    this.btnSave.Text = "结束初始化";
                }
            }
            else
            {
                this.lblTips.Text = "获取到的电子标签起始号已经存在，请联系开发人员!";
                this.rfCard.CardCode = "";
                txtCardCode.Clear();
                return;
            }

        } 
        #endregion

        #region 退出
        private void btnExit_Click(object sender, EventArgs e)
        {
            rfCard.Close();
            this.Close();
        } 
        #endregion

        #region 关闭事件
        private void IC_Initial_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.rfCard.Close();
            timer_start.Enabled = false;
            timer_start.Stop();
            timer_start.Dispose();
        } 
        #endregion

        private void rdbHand_CheckedChanged(object sender, EventArgs e)
        {
            strOperateType = "";
            this.btnSave.Text = "保存";
            timer_start.Enabled = true;
            this.lblCode.Text = "请输入电子标签号：";
            this.txtCardCode.Enabled = true;
            this.lblTips.Text = "";
        }

        private void rdbAsc_CheckedChanged(object sender, EventArgs e)
        {
            timer_start.Enabled = false;
            strOperateType = "asc";
            this.btnSave.Text = "开始初始化";
            this.lblCode.Text = "电子标签起始卡号：";
            this.txtCardCode.Enabled = true;
            this.txtCardCode.Text = "";
            this.lblTips.Text = "";
        }

        private void rdbDesc_CheckedChanged(object sender, EventArgs e)
        {
            timer_start.Enabled = false;
            this.txtCardCode.Enabled = true;
            strOperateType = "desc";
            this.btnSave.Text = "开始初始化";
            this.lblCode.Text = "电子标签起始卡号：";
            this.txtCardCode.Text = "";
            this.lblTips.Text = "";
        }

        #region 获取电子标签最大编号
        /// <summary>
        /// 获取电子标签最大编号
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            string writeCode = (string)DbHelperSQL.GetSingle("select MAX(CardCode) from(select top 100 * from TT_RFCard  order by InitialTime desc) as rf  ");
            int REFmaxCode = int.Parse(writeCode) + 1;
            txtREFCode.Clear();
            txtREFCode.Text = REFmaxCode.ToString();
        } 
        #endregion

    }
}