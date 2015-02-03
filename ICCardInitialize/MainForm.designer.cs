namespace ICCardInitialize
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.ms_IC = new System.Windows.Forms.MenuStrip();
            this.tsmi_SysSet = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_Initial = new System.Windows.Forms.ToolStripMenuItem();
            this.icInitial = new System.Windows.Forms.ToolStripMenuItem();
            this.rfInitial = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_CheckNO = new System.Windows.Forms.ToolStripMenuItem();
            this.icCheck = new System.Windows.Forms.ToolStripMenuItem();
            this.rfCheck = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_Psw = new System.Windows.Forms.ToolStripMenuItem();
            this.btnExit = new System.Windows.Forms.ToolStripMenuItem();
            this.ms_IC.SuspendLayout();
            this.SuspendLayout();
            // 
            // ms_IC
            // 
            this.ms_IC.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmi_SysSet,
            this.tsmi_Initial,
            this.tsmi_CheckNO,
            this.tsmi_Psw,
            this.btnExit});
            this.ms_IC.Location = new System.Drawing.Point(0, 0);
            this.ms_IC.Name = "ms_IC";
            this.ms_IC.Padding = new System.Windows.Forms.Padding(7, 2, 0, 2);
            this.ms_IC.Size = new System.Drawing.Size(593, 25);
            this.ms_IC.TabIndex = 0;
            this.ms_IC.Text = "menuStrip1";
            // 
            // tsmi_SysSet
            // 
            this.tsmi_SysSet.Image = ((System.Drawing.Image)(resources.GetObject("tsmi_SysSet.Image")));
            this.tsmi_SysSet.Name = "tsmi_SysSet";
            this.tsmi_SysSet.ShortcutKeyDisplayString = "";
            this.tsmi_SysSet.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.C)));
            this.tsmi_SysSet.Size = new System.Drawing.Size(100, 21);
            this.tsmi_SysSet.Text = "系统设置(C)";
            this.tsmi_SysSet.Click += new System.EventHandler(this.tsmi_SysSet_Click);
            // 
            // tsmi_Initial
            // 
            this.tsmi_Initial.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.icInitial,
            this.rfInitial});
            this.tsmi_Initial.Image = ((System.Drawing.Image)(resources.GetObject("tsmi_Initial.Image")));
            this.tsmi_Initial.Name = "tsmi_Initial";
            this.tsmi_Initial.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.I)));
            this.tsmi_Initial.ShowShortcutKeys = false;
            this.tsmi_Initial.Size = new System.Drawing.Size(96, 21);
            this.tsmi_Initial.Text = "卡初始化(I)";
            // 
            // icInitial
            // 
            this.icInitial.Name = "icInitial";
            this.icInitial.Size = new System.Drawing.Size(160, 22);
            this.icInitial.Text = "IC卡初始化";
            this.icInitial.Visible = false;
            this.icInitial.Click += new System.EventHandler(this.icInitial_Click);
            // 
            // rfInitial
            // 
            this.rfInitial.Name = "rfInitial";
            this.rfInitial.Size = new System.Drawing.Size(160, 22);
            this.rfInitial.Text = "电子标签初始化";
            this.rfInitial.Click += new System.EventHandler(this.rfInitial_Click);
            // 
            // tsmi_CheckNO
            // 
            this.tsmi_CheckNO.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.icCheck,
            this.rfCheck});
            this.tsmi_CheckNO.Image = ((System.Drawing.Image)(resources.GetObject("tsmi_CheckNO.Image")));
            this.tsmi_CheckNO.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tsmi_CheckNO.Name = "tsmi_CheckNO";
            this.tsmi_CheckNO.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.N)));
            this.tsmi_CheckNO.ShowShortcutKeys = false;
            this.tsmi_CheckNO.Size = new System.Drawing.Size(102, 21);
            this.tsmi_CheckNO.Text = "卡号检查(N)";
            // 
            // icCheck
            // 
            this.icCheck.Name = "icCheck";
            this.icCheck.Size = new System.Drawing.Size(148, 22);
            this.icCheck.Text = "IC卡检查";
            this.icCheck.Visible = false;
            this.icCheck.Click += new System.EventHandler(this.icCheck_Click);
            // 
            // rfCheck
            // 
            this.rfCheck.Name = "rfCheck";
            this.rfCheck.Size = new System.Drawing.Size(148, 22);
            this.rfCheck.Text = "电子标签检查";
            this.rfCheck.Click += new System.EventHandler(this.rfCheck_Click);
            // 
            // tsmi_Psw
            // 
            this.tsmi_Psw.Image = ((System.Drawing.Image)(resources.GetObject("tsmi_Psw.Image")));
            this.tsmi_Psw.Name = "tsmi_Psw";
            this.tsmi_Psw.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.P)));
            this.tsmi_Psw.ShowShortcutKeys = false;
            this.tsmi_Psw.Size = new System.Drawing.Size(135, 21);
            this.tsmi_Psw.Text = "初始化密码设置(P)";
            this.tsmi_Psw.Click += new System.EventHandler(this.tsmi_Psw_Click);
            // 
            // btnExit
            // 
            this.btnExit.Image = ((System.Drawing.Image)(resources.GetObject("btnExit.Image")));
            this.btnExit.Name = "btnExit";
            this.btnExit.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.X)));
            this.btnExit.ShowShortcutKeys = false;
            this.btnExit.Size = new System.Drawing.Size(60, 21);
            this.btnExit.Text = "退出";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::ICCardInitialize.Properties.Resources.Main;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(593, 304);
            this.Controls.Add(this.ms_IC);
            this.Font = new System.Drawing.Font("宋体", 9.5F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.ms_IC;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "北京天大天科电子标签初始化系统V2.02 Bate";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ms_IC.ResumeLayout(false);
            this.ms_IC.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip ms_IC;
        private System.Windows.Forms.ToolStripMenuItem tsmi_SysSet;
        private System.Windows.Forms.ToolStripMenuItem tsmi_Initial;
        private System.Windows.Forms.ToolStripMenuItem tsmi_Psw;
        private System.Windows.Forms.ToolStripMenuItem btnExit;
        private System.Windows.Forms.ToolStripMenuItem tsmi_CheckNO;
        private System.Windows.Forms.ToolStripMenuItem icInitial;
        private System.Windows.Forms.ToolStripMenuItem rfInitial;
        private System.Windows.Forms.ToolStripMenuItem icCheck;
        private System.Windows.Forms.ToolStripMenuItem rfCheck;
    }
}

