namespace ICCardInitialize
{
    partial class IC_CheckCardNO
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IC_CheckCardNO));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtCardCode = new System.Windows.Forms.TextBox();
            this.txtCardKind = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnExit = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.txtCardNO = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.status_CheckCardNO = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblTips = new System.Windows.Forms.ToolStripStatusLabel();
            this.timer_CheckCardNO = new System.Windows.Forms.Timer(this.components);
            this.txtCoalKind = new System.Windows.Forms.TextBox();
            this.lblCoalKind = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.status_CheckCardNO.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.txtCoalKind);
            this.groupBox1.Controls.Add(this.lblCoalKind);
            this.groupBox1.Controls.Add(this.txtCardCode);
            this.groupBox1.Controls.Add(this.txtCardKind);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.btnExit);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtCardNO);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Font = new System.Drawing.Font("SimSun", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(11, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(435, 296);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "卡号检测";
            // 
            // txtCardCode
            // 
            this.txtCardCode.Font = new System.Drawing.Font("SimSun", 10.5F, System.Drawing.FontStyle.Bold);
            this.txtCardCode.Location = new System.Drawing.Point(178, 101);
            this.txtCardCode.MaxLength = 10;
            this.txtCardCode.Name = "txtCardCode";
            this.txtCardCode.ReadOnly = true;
            this.txtCardCode.Size = new System.Drawing.Size(199, 23);
            this.txtCardCode.TabIndex = 18;
            // 
            // txtCardKind
            // 
            this.txtCardKind.Font = new System.Drawing.Font("SimSun", 10.5F, System.Drawing.FontStyle.Bold);
            this.txtCardKind.Location = new System.Drawing.Point(178, 175);
            this.txtCardKind.MaxLength = 10;
            this.txtCardKind.Name = "txtCardKind";
            this.txtCardKind.ReadOnly = true;
            this.txtCardKind.Size = new System.Drawing.Size(199, 23);
            this.txtCardKind.TabIndex = 17;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("SimSun", 11F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(60, 179);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(116, 15);
            this.label3.TabIndex = 16;
            this.label3.Text = "IC 卡 类 型：";
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(137)))), ((int)(((byte)(163)))));
            this.btnExit.Location = new System.Drawing.Point(185, 243);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 13;
            this.btnExit.Text = "退 出";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("SimSun", 11F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(17, 34);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(412, 38);
            this.label5.TabIndex = 8;
            this.label5.Text = "注：听到一声鸣叫表示读卡成功，您可以检测卡号是否正确，检查完毕请刷另一张卡。";
            // 
            // txtCardNO
            // 
            this.txtCardNO.Font = new System.Drawing.Font("SimSun", 10.5F, System.Drawing.FontStyle.Bold);
            this.txtCardNO.Location = new System.Drawing.Point(178, 137);
            this.txtCardNO.MaxLength = 10;
            this.txtCardNO.Name = "txtCardNO";
            this.txtCardNO.ReadOnly = true;
            this.txtCardNO.Size = new System.Drawing.Size(199, 23);
            this.txtCardNO.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("SimSun", 11F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(54, 141);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(121, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "IC卡写入卡号：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("SimSun", 11F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(54, 104);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(121, 15);
            this.label4.TabIndex = 19;
            this.label4.Text = "IC卡内部编号：";
            // 
            // status_CheckCardNO
            // 
            this.status_CheckCardNO.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(137)))), ((int)(((byte)(163)))));
            this.status_CheckCardNO.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.lblTips});
            this.status_CheckCardNO.Location = new System.Drawing.Point(0, 326);
            this.status_CheckCardNO.Name = "status_CheckCardNO";
            this.status_CheckCardNO.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.status_CheckCardNO.Size = new System.Drawing.Size(457, 22);
            this.status_CheckCardNO.TabIndex = 6;
            this.status_CheckCardNO.Text = "操作提示：";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.ForeColor = System.Drawing.Color.White;
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(65, 17);
            this.toolStripStatusLabel1.Text = "操作提示：";
            // 
            // lblTips
            // 
            this.lblTips.ForeColor = System.Drawing.Color.Firebrick;
            this.lblTips.Name = "lblTips";
            this.lblTips.Size = new System.Drawing.Size(23, 17);
            this.lblTips.Text = "   ";
            // 
            // timer_CheckCardNO
            // 
            this.timer_CheckCardNO.Enabled = true;
            this.timer_CheckCardNO.Interval = 500;
            this.timer_CheckCardNO.Tick += new System.EventHandler(this.timer_CheckCardNO_Tick);
            // 
            // txtCoalKind
            // 
            this.txtCoalKind.Font = new System.Drawing.Font("SimSun", 10.5F, System.Drawing.FontStyle.Bold);
            this.txtCoalKind.Location = new System.Drawing.Point(178, 208);
            this.txtCoalKind.MaxLength = 10;
            this.txtCoalKind.Name = "txtCoalKind";
            this.txtCoalKind.ReadOnly = true;
            this.txtCoalKind.Size = new System.Drawing.Size(199, 23);
            this.txtCoalKind.TabIndex = 21;
            // 
            // lblCoalKind
            // 
            this.lblCoalKind.AutoSize = true;
            this.lblCoalKind.Font = new System.Drawing.Font("SimSun", 11F, System.Drawing.FontStyle.Bold);
            this.lblCoalKind.Location = new System.Drawing.Point(54, 210);
            this.lblCoalKind.Name = "lblCoalKind";
            this.lblCoalKind.Size = new System.Drawing.Size(121, 15);
            this.lblCoalKind.TabIndex = 20;
            this.lblCoalKind.Text = "IC卡标示煤种：";
            // 
            // IC_CheckCardNO
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::ICCardInitialize.Properties.Resources.bg;
            this.ClientSize = new System.Drawing.Size(457, 348);
            this.Controls.Add(this.status_CheckCardNO);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "IC_CheckCardNO";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "IC卡号检测";
            this.Load += new System.EventHandler(this.IC_CheckCardNO_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.IC_CheckCardNO_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.status_CheckCardNO.ResumeLayout(false);
            this.status_CheckCardNO.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtCardNO;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Timer timer_CheckCardNO;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel lblTips;
        private System.Windows.Forms.TextBox txtCardKind;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtCardCode;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.StatusStrip status_CheckCardNO;
        private System.Windows.Forms.TextBox txtCoalKind;
        private System.Windows.Forms.Label lblCoalKind;
    }
}