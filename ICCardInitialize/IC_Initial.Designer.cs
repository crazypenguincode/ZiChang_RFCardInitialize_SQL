namespace ICCardInitialize
{
    partial class IC_Initial
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IC_Initial));
            this.lblCardNO = new System.Windows.Forms.Label();
            this.txtCardNO = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdbTemp = new System.Windows.Forms.RadioButton();
            this.cbxCoalKind = new System.Windows.Forms.ComboBox();
            this.txtBeginCardNO = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.rdbAsc = new System.Windows.Forms.RadioButton();
            this.rdbHand = new System.Windows.Forms.RadioButton();
            this.rdbDesc = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCardID = new System.Windows.Forms.TextBox();
            this.rdbNavicet = new System.Windows.Forms.RadioButton();
            this.rdbMarkCard = new System.Windows.Forms.RadioButton();
            this.btnSave = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.lblCoalKind = new System.Windows.Forms.Label();
            this.lblBeginCardNO = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.status_IC = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblTips = new System.Windows.Forms.ToolStripStatusLabel();
            this.timer_start = new System.Windows.Forms.Timer(this.components);
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.status_IC.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblCardNO
            // 
            this.lblCardNO.AutoSize = true;
            this.lblCardNO.Location = new System.Drawing.Point(109, 240);
            this.lblCardNO.Name = "lblCardNO";
            this.lblCardNO.Size = new System.Drawing.Size(121, 15);
            this.lblCardNO.TabIndex = 1;
            this.lblCardNO.Text = "请输入IC卡号：";
            // 
            // txtCardNO
            // 
            this.txtCardNO.Font = new System.Drawing.Font("SimSun", 11F, System.Drawing.FontStyle.Bold);
            this.txtCardNO.Location = new System.Drawing.Point(231, 237);
            this.txtCardNO.Name = "txtCardNO";
            this.txtCardNO.Size = new System.Drawing.Size(200, 24);
            this.txtCardNO.TabIndex = 3;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.rdbTemp);
            this.groupBox1.Controls.Add(this.cbxCoalKind);
            this.groupBox1.Controls.Add(this.txtBeginCardNO);
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtCardID);
            this.groupBox1.Controls.Add(this.rdbNavicet);
            this.groupBox1.Controls.Add(this.rdbMarkCard);
            this.groupBox1.Controls.Add(this.btnSave);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtCardNO);
            this.groupBox1.Controls.Add(this.lblCoalKind);
            this.groupBox1.Controls.Add(this.lblBeginCardNO);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.lblCardNO);
            this.groupBox1.Font = new System.Drawing.Font("SimSun", 11F, System.Drawing.FontStyle.Bold);
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(13, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(532, 358);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "请填写以下信息后点击按钮";
            // 
            // rdbTemp
            // 
            this.rdbTemp.AutoSize = true;
            this.rdbTemp.Location = new System.Drawing.Point(379, 73);
            this.rdbTemp.Name = "rdbTemp";
            this.rdbTemp.Size = new System.Drawing.Size(73, 19);
            this.rdbTemp.TabIndex = 34;
            this.rdbTemp.Tag = "2";
            this.rdbTemp.Text = "临时卡";
            this.rdbTemp.UseVisualStyleBackColor = true;
            this.rdbTemp.CheckedChanged += new System.EventHandler(this.rdbTemp_CheckedChanged);
            // 
            // cbxCoalKind
            // 
            this.cbxCoalKind.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxCoalKind.FormattingEnabled = true;
            this.cbxCoalKind.Location = new System.Drawing.Point(231, 165);
            this.cbxCoalKind.Name = "cbxCoalKind";
            this.cbxCoalKind.Size = new System.Drawing.Size(200, 23);
            this.cbxCoalKind.TabIndex = 33;
            // 
            // txtBeginCardNO
            // 
            this.txtBeginCardNO.Font = new System.Drawing.Font("SimSun", 11F, System.Drawing.FontStyle.Bold);
            this.txtBeginCardNO.Location = new System.Drawing.Point(230, 275);
            this.txtBeginCardNO.Name = "txtBeginCardNO";
            this.txtBeginCardNO.Size = new System.Drawing.Size(200, 24);
            this.txtBeginCardNO.TabIndex = 31;
            this.txtBeginCardNO.TextChanged += new System.EventHandler(this.txtBeginCardNO_TextChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.rdbAsc);
            this.panel1.Controls.Add(this.rdbHand);
            this.panel1.Controls.Add(this.rdbDesc);
            this.panel1.Location = new System.Drawing.Point(214, 111);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(245, 40);
            this.panel1.TabIndex = 27;
            // 
            // rdbAsc
            // 
            this.rdbAsc.AutoSize = true;
            this.rdbAsc.Location = new System.Drawing.Point(92, 15);
            this.rdbAsc.Name = "rdbAsc";
            this.rdbAsc.Size = new System.Drawing.Size(57, 19);
            this.rdbAsc.TabIndex = 23;
            this.rdbAsc.Text = "升序";
            this.rdbAsc.UseVisualStyleBackColor = true;
            this.rdbAsc.CheckedChanged += new System.EventHandler(this.rdbAsc_CheckedChanged);
            // 
            // rdbHand
            // 
            this.rdbHand.AutoSize = true;
            this.rdbHand.Checked = true;
            this.rdbHand.Location = new System.Drawing.Point(16, 15);
            this.rdbHand.Name = "rdbHand";
            this.rdbHand.Size = new System.Drawing.Size(57, 19);
            this.rdbHand.TabIndex = 22;
            this.rdbHand.TabStop = true;
            this.rdbHand.Text = "手动";
            this.rdbHand.UseVisualStyleBackColor = true;
            this.rdbHand.CheckedChanged += new System.EventHandler(this.rdbHand_CheckedChanged);
            // 
            // rdbDesc
            // 
            this.rdbDesc.AutoSize = true;
            this.rdbDesc.Location = new System.Drawing.Point(162, 15);
            this.rdbDesc.Name = "rdbDesc";
            this.rdbDesc.Size = new System.Drawing.Size(57, 19);
            this.rdbDesc.TabIndex = 24;
            this.rdbDesc.Text = "降序";
            this.rdbDesc.UseVisualStyleBackColor = true;
            this.rdbDesc.CheckedChanged += new System.EventHandler(this.rdbDesc_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("SimSun", 11F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(74, 131);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(151, 15);
            this.label3.TabIndex = 26;
            this.label3.Text = "请选择初始化方式：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("SimSun", 11F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(74, 77);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(151, 15);
            this.label1.TabIndex = 25;
            this.label1.Text = "请选择初始化对象：";
            // 
            // txtCardID
            // 
            this.txtCardID.Font = new System.Drawing.Font("SimSun", 11F, System.Drawing.FontStyle.Bold);
            this.txtCardID.Location = new System.Drawing.Point(231, 198);
            this.txtCardID.MaxLength = 10;
            this.txtCardID.Name = "txtCardID";
            this.txtCardID.ReadOnly = true;
            this.txtCardID.Size = new System.Drawing.Size(199, 24);
            this.txtCardID.TabIndex = 20;
            // 
            // rdbNavicet
            // 
            this.rdbNavicet.AutoSize = true;
            this.rdbNavicet.Location = new System.Drawing.Point(306, 73);
            this.rdbNavicet.Name = "rdbNavicet";
            this.rdbNavicet.Size = new System.Drawing.Size(73, 19);
            this.rdbNavicet.TabIndex = 15;
            this.rdbNavicet.Tag = "2";
            this.rdbNavicet.Text = "准运卡";
            this.rdbNavicet.UseVisualStyleBackColor = true;
            this.rdbNavicet.CheckedChanged += new System.EventHandler(this.rdbNavicet_CheckedChanged);
            // 
            // rdbMarkCard
            // 
            this.rdbMarkCard.AutoSize = true;
            this.rdbMarkCard.Checked = true;
            this.rdbMarkCard.Location = new System.Drawing.Point(230, 73);
            this.rdbMarkCard.Name = "rdbMarkCard";
            this.rdbMarkCard.Size = new System.Drawing.Size(73, 19);
            this.rdbMarkCard.TabIndex = 14;
            this.rdbMarkCard.TabStop = true;
            this.rdbMarkCard.Tag = "1";
            this.rdbMarkCard.Text = "标识卡";
            this.rdbMarkCard.UseVisualStyleBackColor = true;
            this.rdbMarkCard.CheckedChanged += new System.EventHandler(this.rdbMarkCard_CheckedChanged);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(137)))), ((int)(((byte)(163)))));
            this.btnSave.Location = new System.Drawing.Point(213, 323);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 23);
            this.btnSave.TabIndex = 12;
            this.btnSave.Text = "保 存";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("SimSun", 11F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(62, 36);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(375, 15);
            this.label5.TabIndex = 8;
            this.label5.Text = "注：听到一声鸣叫表示保存成功，您可以刷另一张卡";
            // 
            // lblCoalKind
            // 
            this.lblCoalKind.AutoSize = true;
            this.lblCoalKind.Font = new System.Drawing.Font("SimSun", 11F, System.Drawing.FontStyle.Bold);
            this.lblCoalKind.Location = new System.Drawing.Point(127, 169);
            this.lblCoalKind.Name = "lblCoalKind";
            this.lblCoalKind.Size = new System.Drawing.Size(103, 15);
            this.lblCoalKind.TabIndex = 32;
            this.lblCoalKind.Text = "请选择煤种：";
            // 
            // lblBeginCardNO
            // 
            this.lblBeginCardNO.AutoSize = true;
            this.lblBeginCardNO.Location = new System.Drawing.Point(95, 278);
            this.lblBeginCardNO.Name = "lblBeginCardNO";
            this.lblBeginCardNO.Size = new System.Drawing.Size(135, 15);
            this.lblBeginCardNO.TabIndex = 30;
            this.lblBeginCardNO.Text = "请输入起始卡号：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("SimSun", 11F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(108, 203);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(121, 15);
            this.label4.TabIndex = 21;
            this.label4.Text = "IC卡内部编号：";
            // 
            // status_IC
            // 
            this.status_IC.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(137)))), ((int)(((byte)(163)))));
            this.status_IC.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.lblTips});
            this.status_IC.Location = new System.Drawing.Point(0, 373);
            this.status_IC.Name = "status_IC";
            this.status_IC.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.status_IC.Size = new System.Drawing.Size(557, 22);
            this.status_IC.TabIndex = 5;
            this.status_IC.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Font = new System.Drawing.Font("SimSun", 9F);
            this.toolStripStatusLabel1.ForeColor = System.Drawing.Color.White;
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(65, 17);
            this.toolStripStatusLabel1.Text = "操作提示：";
            // 
            // lblTips
            // 
            this.lblTips.ActiveLinkColor = System.Drawing.Color.Firebrick;
            this.lblTips.Font = new System.Drawing.Font("SimSun", 9F);
            this.lblTips.ForeColor = System.Drawing.Color.Red;
            this.lblTips.Name = "lblTips";
            this.lblTips.Size = new System.Drawing.Size(29, 17);
            this.lblTips.Text = "    ";
            // 
            // timer_start
            // 
            this.timer_start.Tick += new System.EventHandler(this.timer_start_Tick);
            // 
            // IC_Initial
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::ICCardInitialize.Properties.Resources.bg;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(557, 395);
            this.Controls.Add(this.status_IC);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("SimSun", 9.5F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "IC_Initial";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "IC卡初始化";
            this.Load += new System.EventHandler(this.IC_Initial_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.IC_Initial_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.status_IC.ResumeLayout(false);
            this.status_IC.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCardNO;
        private System.Windows.Forms.TextBox txtCardNO;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.StatusStrip status_IC;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel lblTips;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.RadioButton rdbNavicet;
        private System.Windows.Forms.RadioButton rdbMarkCard;
        private System.Windows.Forms.TextBox txtCardID;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Timer timer_start;
        private System.Windows.Forms.RadioButton rdbHand;
        private System.Windows.Forms.RadioButton rdbDesc;
        private System.Windows.Forms.RadioButton rdbAsc;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtBeginCardNO;
        private System.Windows.Forms.Label lblBeginCardNO;
        private System.Windows.Forms.ComboBox cbxCoalKind;
        private System.Windows.Forms.Label lblCoalKind;
        private System.Windows.Forms.RadioButton rdbTemp;
    }
}