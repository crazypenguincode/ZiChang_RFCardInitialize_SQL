namespace ICCardInitialize
{
    partial class IC_PortSet
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IC_PortSet));
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtReadAndWrite = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtRfCardLen = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cbxRFBound = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cbxRFCom = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtICCardlen = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdbtn19200 = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.rdbtn9600 = new System.Windows.Forms.RadioButton();
            this.cbxIcCom = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.Transparent;
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.txtReadAndWrite);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.txtRfCardLen);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.cbxRFBound);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.cbxRFCom);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox3.ForeColor = System.Drawing.Color.White;
            this.groupBox3.Location = new System.Drawing.Point(13, 153);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(414, 104);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "电子标签设置";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.Location = new System.Drawing.Point(370, 76);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 12);
            this.label8.TabIndex = 15;
            this.label8.Text = "毫秒：";
            // 
            // txtReadAndWrite
            // 
            this.txtReadAndWrite.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold);
            this.txtReadAndWrite.Location = new System.Drawing.Point(288, 68);
            this.txtReadAndWrite.MaxLength = 5;
            this.txtReadAndWrite.Name = "txtReadAndWrite";
            this.txtReadAndWrite.Size = new System.Drawing.Size(78, 23);
            this.txtReadAndWrite.TabIndex = 14;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(229, 76);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 12);
            this.label7.TabIndex = 13;
            this.label7.Text = "读写频率：";
            // 
            // txtRfCardLen
            // 
            this.txtRfCardLen.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold);
            this.txtRfCardLen.Location = new System.Drawing.Point(99, 68);
            this.txtRfCardLen.MaxLength = 2;
            this.txtRfCardLen.Name = "txtRfCardLen";
            this.txtRfCardLen.Size = new System.Drawing.Size(104, 23);
            this.txtRfCardLen.TabIndex = 12;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(7, 75);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(89, 12);
            this.label6.TabIndex = 11;
            this.label6.Text = "电子标签长度：";
            // 
            // cbxRFBound
            // 
            this.cbxRFBound.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold);
            this.cbxRFBound.FormattingEnabled = true;
            this.cbxRFBound.Items.AddRange(new object[] {
            "9600bps",
            "115200bps"});
            this.cbxRFBound.Location = new System.Drawing.Point(276, 34);
            this.cbxRFBound.Name = "cbxRFBound";
            this.cbxRFBound.Size = new System.Drawing.Size(119, 21);
            this.cbxRFBound.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(229, 38);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 9;
            this.label5.Text = "波特率：";
            // 
            // cbxRFCom
            // 
            this.cbxRFCom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxRFCom.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold);
            this.cbxRFCom.FormattingEnabled = true;
            this.cbxRFCom.Items.AddRange(new object[] {
            "COM1",
            "COM2",
            "COM3",
            "COM4",
            "COM5",
            "COM6",
            "COM7",
            "COM8"});
            this.cbxRFCom.Location = new System.Drawing.Point(99, 34);
            this.cbxRFCom.Name = "cbxRFCom";
            this.cbxRFCom.Size = new System.Drawing.Size(104, 21);
            this.cbxRFCom.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(42, 41);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 7;
            this.label4.Text = "串口号：";
            // 
            // txtICCardlen
            // 
            this.txtICCardlen.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold);
            this.txtICCardlen.Location = new System.Drawing.Point(276, 25);
            this.txtICCardlen.MaxLength = 2;
            this.txtICCardlen.Name = "txtICCardlen";
            this.txtICCardlen.Size = new System.Drawing.Size(119, 23);
            this.txtICCardlen.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(217, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 5;
            this.label1.Text = "IC卡长度：";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.rdbtn19200);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.rdbtn9600);
            this.groupBox1.Controls.Add(this.txtICCardlen);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cbxIcCom);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(13, 22);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(414, 115);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "IC卡设置";
            // 
            // rdbtn19200
            // 
            this.rdbtn19200.AutoSize = true;
            this.rdbtn19200.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbtn19200.Location = new System.Drawing.Point(219, 69);
            this.rdbtn19200.Name = "rdbtn19200";
            this.rdbtn19200.Size = new System.Drawing.Size(98, 20);
            this.rdbtn19200.TabIndex = 4;
            this.rdbtn19200.Text = "19200 bps";
            this.rdbtn19200.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(42, 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 8;
            this.label3.Text = "波特率：";
            // 
            // rdbtn9600
            // 
            this.rdbtn9600.AutoSize = true;
            this.rdbtn9600.Checked = true;
            this.rdbtn9600.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbtn9600.Location = new System.Drawing.Point(99, 70);
            this.rdbtn9600.Name = "rdbtn9600";
            this.rdbtn9600.Size = new System.Drawing.Size(90, 20);
            this.rdbtn9600.TabIndex = 3;
            this.rdbtn9600.TabStop = true;
            this.rdbtn9600.Text = "9600 bps";
            this.rdbtn9600.UseVisualStyleBackColor = true;
            // 
            // cbxIcCom
            // 
            this.cbxIcCom.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold);
            this.cbxIcCom.FormattingEnabled = true;
            this.cbxIcCom.Items.AddRange(new object[] {
            "COM1",
            "COM2",
            "COM3",
            "COM4"});
            this.cbxIcCom.Location = new System.Drawing.Point(99, 27);
            this.cbxIcCom.Name = "cbxIcCom";
            this.cbxIcCom.Size = new System.Drawing.Size(104, 21);
            this.cbxIcCom.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(42, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 6;
            this.label2.Text = "串口号：";
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(137)))), ((int)(((byte)(163)))));
            this.btnSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(122, 263);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(80, 25);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "设 置";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(137)))), ((int)(((byte)(163)))));
            this.btnExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnExit.ForeColor = System.Drawing.Color.White;
            this.btnExit.Location = new System.Drawing.Point(250, 263);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(80, 25);
            this.btnExit.TabIndex = 4;
            this.btnExit.Text = "退 出";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // IC_PortSet
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImage = global::ICCardInitialize.Properties.Resources.bg;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(451, 311);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("宋体", 9.5F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "IC_PortSet";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "系统设置";
            this.Load += new System.EventHandler(this.IC_PortSet_Load);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.TextBox txtICCardlen;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton rdbtn9600;
        private System.Windows.Forms.RadioButton rdbtn19200;
        private System.Windows.Forms.ComboBox cbxIcCom;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbxRFCom;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbxRFBound;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtRfCardLen;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtReadAndWrite;
    }
}