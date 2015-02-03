namespace ICCardInitialize
{
    partial class RF_Initial
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RF_Initial));
            this.lblCode = new System.Windows.Forms.Label();
            this.txtCardCode = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnMaxID = new System.Windows.Forms.Button();
            this.txtREFCode = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.status_IC = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblTips = new System.Windows.Forms.ToolStripStatusLabel();
            this.timer_start = new System.Windows.Forms.Timer(this.components);
            this.rfCard = new ThirdLibrary.RFCard(this.components);
            this.groupBox1.SuspendLayout();
            this.status_IC.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblCode
            // 
            this.lblCode.AutoSize = true;
            this.lblCode.Location = new System.Drawing.Point(23, 155);
            this.lblCode.Name = "lblCode";
            this.lblCode.Size = new System.Drawing.Size(135, 15);
            this.lblCode.TabIndex = 1;
            this.lblCode.Text = "获取电子标签号：";
            // 
            // txtCardCode
            // 
            this.txtCardCode.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Bold);
            this.txtCardCode.Location = new System.Drawing.Point(175, 155);
            this.txtCardCode.MaxLength = 10;
            this.txtCardCode.Name = "txtCardCode";
            this.txtCardCode.Size = new System.Drawing.Size(200, 24);
            this.txtCardCode.TabIndex = 3;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnMaxID);
            this.groupBox1.Controls.Add(this.txtREFCode);
            this.groupBox1.Controls.Add(this.btnSave);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtCardCode);
            this.groupBox1.Controls.Add(this.lblCode);
            this.groupBox1.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Bold);
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(19, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(450, 275);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "请填写以下信息后点击按钮";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 102);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(135, 15);
            this.label1.TabIndex = 30;
            this.label1.Text = "电子标签起始号：";
            // 
            // btnMaxID
            // 
            this.btnMaxID.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(137)))), ((int)(((byte)(163)))));
            this.btnMaxID.Location = new System.Drawing.Point(380, 97);
            this.btnMaxID.Name = "btnMaxID";
            this.btnMaxID.Size = new System.Drawing.Size(59, 23);
            this.btnMaxID.TabIndex = 29;
            this.btnMaxID.Text = "获取";
            this.btnMaxID.UseVisualStyleBackColor = false;
            this.btnMaxID.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtREFCode
            // 
            this.txtREFCode.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Bold);
            this.txtREFCode.Location = new System.Drawing.Point(175, 97);
            this.txtREFCode.MaxLength = 10;
            this.txtREFCode.Name = "txtREFCode";
            this.txtREFCode.Size = new System.Drawing.Size(200, 24);
            this.txtREFCode.TabIndex = 28;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(137)))), ((int)(((byte)(163)))));
            this.btnSave.Location = new System.Drawing.Point(175, 210);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 23);
            this.btnSave.TabIndex = 12;
            this.btnSave.Text = "开始初始化";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Location = new System.Drawing.Point(28, 42);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(391, 15);
            this.label5.TabIndex = 8;
            this.label5.Text = "注：听到一声鸣叫表示初始化成功，您可以刷另一张卡";
            // 
            // status_IC
            // 
            this.status_IC.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(137)))), ((int)(((byte)(163)))));
            this.status_IC.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.lblTips});
            this.status_IC.Location = new System.Drawing.Point(0, 307);
            this.status_IC.Name = "status_IC";
            this.status_IC.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.status_IC.Size = new System.Drawing.Size(483, 22);
            this.status_IC.TabIndex = 5;
            this.status_IC.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Font = new System.Drawing.Font("宋体", 9F);
            this.toolStripStatusLabel1.ForeColor = System.Drawing.Color.White;
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(65, 17);
            this.toolStripStatusLabel1.Text = "操作提示：";
            // 
            // lblTips
            // 
            this.lblTips.ActiveLinkColor = System.Drawing.Color.Firebrick;
            this.lblTips.Font = new System.Drawing.Font("宋体", 9F);
            this.lblTips.ForeColor = System.Drawing.Color.Red;
            this.lblTips.Name = "lblTips";
            this.lblTips.Size = new System.Drawing.Size(29, 17);
            this.lblTips.Text = "    ";
            // 
            // timer_start
            // 
            this.timer_start.Interval = 3000;
            this.timer_start.Tick += new System.EventHandler(this.timer_start_Tick);
            // 
            // rfCard
            // 
            this.rfCard.CardCode = "";
            // 
            // RF_Initial
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::ICCardInitialize.Properties.Resources.bg;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(483, 329);
            this.Controls.Add(this.status_IC);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("宋体", 9.5F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RF_Initial";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "远程卡初始化";
            this.Load += new System.EventHandler(this.RF_Initial_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.IC_Initial_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.status_IC.ResumeLayout(false);
            this.status_IC.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCode;
        private System.Windows.Forms.TextBox txtCardCode;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.StatusStrip status_IC;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel lblTips;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Timer timer_start;
        private ThirdLibrary.RFCard rfCard;
        private System.Windows.Forms.Button btnMaxID;
        private System.Windows.Forms.TextBox txtREFCode;
        private System.Windows.Forms.Label label1;
    }
}