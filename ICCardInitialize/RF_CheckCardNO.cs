using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ICCardInitialize
{
    public partial class RF_CheckCardNO : Form
    {
        #region 变量
        //全局的电子标签值
        string strAllCardCode = "";
        public delegate void SetUIDelegate();
        RWini ini = new RWini(); 
        #endregion

        #region 对电子标签事件进行委托处理
        /// <summary>
        /// 对电子标签事件进行委托处理
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
                this.BeginInvoke(delgate, null);//将SetICCValue委托方法在窗体控件线程上执行
            }
            catch (Exception ex)
            {
                Log.WriteLog("电子标签委托", ex.ToString());
            }
        } 
        #endregion

        #region 将读取到的电子标签号设置到窗体控件中进行显示，并且给全局电子标签变量赋值。
        /// <summary>
        /// 将读取到的电子标签号设置到窗体控件中进行显示，并且给全局电子标签变量赋值。
        /// </summary>
        private void SetICCValue()
        {
            try
            {
                string[] arry = this.rfCard.CardCode.Split(',');
                this.txtCardCode.Clear();
                this.txtCardCode.Text = arry[arry.Length - 1];
                strAllCardCode = this.txtCardCode.Text;
            }
            catch (Exception ex)
            {
                Log.WriteLog("电子标签给控件赋值", ex.ToString());
            }
        } 
        #endregion

        #region 窗体构造函数
        /// <summary>
        /// 窗体构造函数
        /// </summary>
        public RF_CheckCardNO()
        {
            InitializeComponent();
        } 
        #endregion

        #region 窗体加载。。。
        /// <summary>
        /// 窗体加载。。。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RF_CheckCardNO_Load(object sender, EventArgs e)
        {
            //1、读取配置文件中关于电子标签的端口号和波特率
            string strCom = ini.IniReadValue("ReMote", "COM");
            string strBaud = ini.IniReadValue("ReMote", "Boud");
            //2、先关闭一次电子标签设备
            this.rfCard.Close();
            //3、对该电子标签设备进行初始化--传入：端口号、波特率
            short i = this.rfCard.Initialize(strCom, strBaud);
            if (i != 0)
            {
                this.lblTips.Text = "电子标签读卡器初始化失败";
                //this.btnSave.Enabled = false;
            }
            else
            {
                rfCard.SetUIValue += new EventHandler(SetUIICCard);
                this.lblTips.Text = "电子标签读卡器初始化成功";
            }

        } 
        #endregion

        #region 窗体关闭事件
        /// <summary>
        /// 窗体关闭事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RF_CheckCardNO_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.rfCard.Close();
        } 
        #endregion

        #region 退出

        /// <summary>
        /// 退出
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.rfCard.Close();
            this.Close();
        }

        #endregion

    }
}
