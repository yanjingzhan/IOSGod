namespace IOSGod
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
            this.components = new System.ComponentModel.Container();
            this.textBox_CurrentUrl = new System.Windows.Forms.TextBox();
            this.webBrowser_Main = new System.Windows.Forms.WebBrowser();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.textBox_Info = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.pictureBox_VerifyCode = new System.Windows.Forms.PictureBox();
            this.textBox_VerifyCode = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label_CurrentPassword = new System.Windows.Forms.Label();
            this.label_CurrentEduMail = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label_FailCount = new System.Windows.Forms.Label();
            this.label_SucCount = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.checkBox_AutoStart = new System.Windows.Forms.CheckBox();
            this.button_Do = new System.Windows.Forms.Button();
            this.checkBox_WriteLog = new System.Windows.Forms.CheckBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.button_MailCreator = new System.Windows.Forms.Button();
            this.panel2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_VerifyCode)).BeginInit();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox_CurrentUrl
            // 
            this.textBox_CurrentUrl.Dock = System.Windows.Forms.DockStyle.Top;
            this.textBox_CurrentUrl.Location = new System.Drawing.Point(0, 0);
            this.textBox_CurrentUrl.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox_CurrentUrl.Name = "textBox_CurrentUrl";
            this.textBox_CurrentUrl.ReadOnly = true;
            this.textBox_CurrentUrl.Size = new System.Drawing.Size(1204, 25);
            this.textBox_CurrentUrl.TabIndex = 0;
            // 
            // webBrowser_Main
            // 
            this.webBrowser_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowser_Main.Location = new System.Drawing.Point(0, 25);
            this.webBrowser_Main.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.webBrowser_Main.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser_Main.Name = "webBrowser_Main";
            this.webBrowser_Main.ScriptErrorsSuppressed = true;
            this.webBrowser_Main.Size = new System.Drawing.Size(1204, 418);
            this.webBrowser_Main.TabIndex = 1;
            // 
            // textBox_Info
            // 
            this.textBox_Info.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_Info.Location = new System.Drawing.Point(0, 0);
            this.textBox_Info.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox_Info.Multiline = true;
            this.textBox_Info.Name = "textBox_Info";
            this.textBox_Info.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox_Info.Size = new System.Drawing.Size(1204, 100);
            this.textBox_Info.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.textBox_Info);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 748);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1204, 100);
            this.panel2.TabIndex = 13;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "成功";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.groupBox3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label_CurrentPassword);
            this.groupBox2.Controls.Add(this.label_CurrentEduMail);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label_FailCount);
            this.groupBox2.Controls.Add(this.label_SucCount);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Size = new System.Drawing.Size(278, 305);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "信息";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.pictureBox_VerifyCode);
            this.groupBox3.Controls.Add(this.textBox_VerifyCode);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox3.Location = new System.Drawing.Point(3, 143);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(272, 160);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "验证码";
            // 
            // pictureBox_VerifyCode
            // 
            this.pictureBox_VerifyCode.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox_VerifyCode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox_VerifyCode.Location = new System.Drawing.Point(3, 21);
            this.pictureBox_VerifyCode.Name = "pictureBox_VerifyCode";
            this.pictureBox_VerifyCode.Size = new System.Drawing.Size(266, 111);
            this.pictureBox_VerifyCode.TabIndex = 0;
            this.pictureBox_VerifyCode.TabStop = false;
            // 
            // textBox_VerifyCode
            // 
            this.textBox_VerifyCode.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.textBox_VerifyCode.Location = new System.Drawing.Point(3, 132);
            this.textBox_VerifyCode.Name = "textBox_VerifyCode";
            this.textBox_VerifyCode.ReadOnly = true;
            this.textBox_VerifyCode.Size = new System.Drawing.Size(266, 25);
            this.textBox_VerifyCode.TabIndex = 1;
            this.textBox_VerifyCode.Text = "----";
            this.textBox_VerifyCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(171, 30);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 15);
            this.label4.TabIndex = 2;
            this.label4.Text = "失败";
            // 
            // label_CurrentPassword
            // 
            this.label_CurrentPassword.AutoSize = true;
            this.label_CurrentPassword.Font = new System.Drawing.Font("微软雅黑", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_CurrentPassword.Location = new System.Drawing.Point(72, 97);
            this.label_CurrentPassword.Name = "label_CurrentPassword";
            this.label_CurrentPassword.Size = new System.Drawing.Size(29, 31);
            this.label_CurrentPassword.TabIndex = 2;
            this.label_CurrentPassword.Text = "0";
            // 
            // label_CurrentEduMail
            // 
            this.label_CurrentEduMail.AutoSize = true;
            this.label_CurrentEduMail.Font = new System.Drawing.Font("微软雅黑", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_CurrentEduMail.Location = new System.Drawing.Point(72, 59);
            this.label_CurrentEduMail.Name = "label_CurrentEduMail";
            this.label_CurrentEduMail.Size = new System.Drawing.Size(29, 31);
            this.label_CurrentEduMail.TabIndex = 2;
            this.label_CurrentEduMail.Text = "0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 106);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 15);
            this.label5.TabIndex = 2;
            this.label5.Text = "密码";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 68);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(37, 15);
            this.label6.TabIndex = 2;
            this.label6.Text = "当前";
            // 
            // label_FailCount
            // 
            this.label_FailCount.AutoSize = true;
            this.label_FailCount.Font = new System.Drawing.Font("微软雅黑", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_FailCount.Location = new System.Drawing.Point(237, 21);
            this.label_FailCount.Name = "label_FailCount";
            this.label_FailCount.Size = new System.Drawing.Size(29, 31);
            this.label_FailCount.TabIndex = 2;
            this.label_FailCount.Text = "0";
            // 
            // label_SucCount
            // 
            this.label_SucCount.AutoSize = true;
            this.label_SucCount.Font = new System.Drawing.Font("微软雅黑", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_SucCount.Location = new System.Drawing.Point(72, 21);
            this.label_SucCount.Name = "label_SucCount";
            this.label_SucCount.Size = new System.Drawing.Size(29, 31);
            this.label_SucCount.TabIndex = 2;
            this.label_SucCount.Text = "0";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1204, 305);
            this.panel1.TabIndex = 12;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button_MailCreator);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.checkBox_AutoStart);
            this.groupBox1.Controls.Add(this.button_Do);
            this.groupBox1.Controls.Add(this.checkBox_WriteLog);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupBox1.Location = new System.Drawing.Point(850, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(354, 305);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "控制";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(126, 251);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 14;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // checkBox_AutoStart
            // 
            this.checkBox_AutoStart.AutoSize = true;
            this.checkBox_AutoStart.Location = new System.Drawing.Point(19, 143);
            this.checkBox_AutoStart.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.checkBox_AutoStart.Name = "checkBox_AutoStart";
            this.checkBox_AutoStart.Size = new System.Drawing.Size(89, 19);
            this.checkBox_AutoStart.TabIndex = 12;
            this.checkBox_AutoStart.Text = "自动重启";
            this.checkBox_AutoStart.UseVisualStyleBackColor = true;
            this.checkBox_AutoStart.CheckedChanged += new System.EventHandler(this.checkBox_AutoStart_CheckedChanged);
            // 
            // button_Do
            // 
            this.button_Do.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button_Do.Location = new System.Drawing.Point(243, 235);
            this.button_Do.Name = "button_Do";
            this.button_Do.Size = new System.Drawing.Size(99, 52);
            this.button_Do.TabIndex = 13;
            this.button_Do.Text = "开始";
            this.button_Do.UseVisualStyleBackColor = true;
            this.button_Do.Click += new System.EventHandler(this.button_Do_Click);
            // 
            // checkBox_WriteLog
            // 
            this.checkBox_WriteLog.AutoSize = true;
            this.checkBox_WriteLog.Checked = true;
            this.checkBox_WriteLog.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_WriteLog.Location = new System.Drawing.Point(126, 143);
            this.checkBox_WriteLog.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.checkBox_WriteLog.Name = "checkBox_WriteLog";
            this.checkBox_WriteLog.Size = new System.Drawing.Size(74, 19);
            this.checkBox_WriteLog.TabIndex = 12;
            this.checkBox_WriteLog.Text = "记日志";
            this.checkBox_WriteLog.UseVisualStyleBackColor = true;
            this.checkBox_WriteLog.CheckedChanged += new System.EventHandler(this.checkBox_WriteLog_CheckedChanged);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.webBrowser_Main);
            this.panel3.Controls.Add(this.textBox_CurrentUrl);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 305);
            this.panel3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1204, 443);
            this.panel3.TabIndex = 14;
            // 
            // button_MailCreator
            // 
            this.button_MailCreator.Location = new System.Drawing.Point(6, 235);
            this.button_MailCreator.Name = "button_MailCreator";
            this.button_MailCreator.Size = new System.Drawing.Size(75, 52);
            this.button_MailCreator.TabIndex = 15;
            this.button_MailCreator.Text = "生成邮箱到文件";
            this.button_MailCreator.UseVisualStyleBackColor = true;
            this.button_MailCreator.Click += new System.EventHandler(this.button_MailCreator_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1204, 848);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "MainForm";
            this.Text = "IOSAccount";
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_VerifyCode)).EndInit();
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_CurrentUrl;
        private System.Windows.Forms.WebBrowser webBrowser_Main;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TextBox textBox_Info;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label_CurrentPassword;
        private System.Windows.Forms.Label label_CurrentEduMail;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label_FailCount;
        private System.Windows.Forms.Label label_SucCount;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.PictureBox pictureBox_VerifyCode;
        private System.Windows.Forms.TextBox textBox_VerifyCode;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox checkBox_AutoStart;
        private System.Windows.Forms.Button button_Do;
        private System.Windows.Forms.CheckBox checkBox_WriteLog;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button_MailCreator;
    }
}

