namespace GetIOSFullInfoByState
{
    partial class GetIOSFullInfoByState
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GetIOSFullInfoByState));
            this.button_CopyStreet = new System.Windows.Forms.Button();
            this.button_CopyPassword = new System.Windows.Forms.Button();
            this.button_CopyAccount = new System.Windows.Forms.Button();
            this.textBox_KeyWords = new System.Windows.Forms.TextBox();
            this.textBox_Password = new System.Windows.Forms.TextBox();
            this.textBox_Account = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.button_Get = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label_info = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button_CopyStreet
            // 
            this.button_CopyStreet.Location = new System.Drawing.Point(487, 88);
            this.button_CopyStreet.Name = "button_CopyStreet";
            this.button_CopyStreet.Size = new System.Drawing.Size(104, 23);
            this.button_CopyStreet.TabIndex = 1015;
            this.button_CopyStreet.Text = "复制";
            this.button_CopyStreet.UseVisualStyleBackColor = true;
            this.button_CopyStreet.Click += new System.EventHandler(this.button_CopyStreet_Click);
            // 
            // button_CopyPassword
            // 
            this.button_CopyPassword.Location = new System.Drawing.Point(487, 46);
            this.button_CopyPassword.Name = "button_CopyPassword";
            this.button_CopyPassword.Size = new System.Drawing.Size(104, 23);
            this.button_CopyPassword.TabIndex = 1014;
            this.button_CopyPassword.Text = "复制";
            this.button_CopyPassword.UseVisualStyleBackColor = true;
            this.button_CopyPassword.Click += new System.EventHandler(this.button_CopyPassword_Click);
            // 
            // button_CopyAccount
            // 
            this.button_CopyAccount.Location = new System.Drawing.Point(487, 5);
            this.button_CopyAccount.Name = "button_CopyAccount";
            this.button_CopyAccount.Size = new System.Drawing.Size(104, 23);
            this.button_CopyAccount.TabIndex = 1013;
            this.button_CopyAccount.Text = "复制";
            this.button_CopyAccount.UseVisualStyleBackColor = true;
            this.button_CopyAccount.Click += new System.EventHandler(this.button_CopyAccount_Click);
            // 
            // textBox_KeyWords
            // 
            this.textBox_KeyWords.Location = new System.Drawing.Point(63, 87);
            this.textBox_KeyWords.Name = "textBox_KeyWords";
            this.textBox_KeyWords.ReadOnly = true;
            this.textBox_KeyWords.Size = new System.Drawing.Size(418, 25);
            this.textBox_KeyWords.TabIndex = 1018;
            // 
            // textBox_Password
            // 
            this.textBox_Password.Location = new System.Drawing.Point(63, 45);
            this.textBox_Password.Name = "textBox_Password";
            this.textBox_Password.ReadOnly = true;
            this.textBox_Password.Size = new System.Drawing.Size(418, 25);
            this.textBox_Password.TabIndex = 1017;
            // 
            // textBox_Account
            // 
            this.textBox_Account.Location = new System.Drawing.Point(63, 4);
            this.textBox_Account.Name = "textBox_Account";
            this.textBox_Account.ReadOnly = true;
            this.textBox_Account.Size = new System.Drawing.Size(418, 25);
            this.textBox_Account.TabIndex = 1016;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(5, 91);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(52, 15);
            this.label9.TabIndex = 1010;
            this.label9.Text = "关键词";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(20, 49);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(37, 15);
            this.label8.TabIndex = 1011;
            this.label8.Text = "密码";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(20, 9);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(37, 15);
            this.label7.TabIndex = 1012;
            this.label7.Text = "账号";
            // 
            // button_Get
            // 
            this.button_Get.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button_Get.ForeColor = System.Drawing.Color.Red;
            this.button_Get.Location = new System.Drawing.Point(172, 127);
            this.button_Get.Name = "button_Get";
            this.button_Get.Size = new System.Drawing.Size(203, 73);
            this.button_Get.TabIndex = 1019;
            this.button_Get.Text = "获取";
            this.button_Get.UseVisualStyleBackColor = true;
            this.button_Get.Click += new System.EventHandler(this.button_Get_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 212);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(601, 100);
            this.panel1.TabIndex = 1020;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label_info);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(601, 100);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "信息";
            // 
            // label_info
            // 
            this.label_info.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_info.ForeColor = System.Drawing.Color.Blue;
            this.label_info.Location = new System.Drawing.Point(6, 21);
            this.label_info.Name = "label_info";
            this.label_info.Size = new System.Drawing.Size(948, 83);
            this.label_info.TabIndex = 1;
            this.label_info.Text = " ";
            // 
            // GetIOSFullInfoByState
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(601, 312);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.button_Get);
            this.Controls.Add(this.button_CopyStreet);
            this.Controls.Add(this.button_CopyPassword);
            this.Controls.Add(this.button_CopyAccount);
            this.Controls.Add(this.textBox_KeyWords);
            this.Controls.Add(this.textBox_Password);
            this.Controls.Add(this.textBox_Account);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "GetIOSFullInfoByState";
            this.Text = "IOS信息获取";
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_CopyStreet;
        private System.Windows.Forms.Button button_CopyPassword;
        private System.Windows.Forms.Button button_CopyAccount;
        private System.Windows.Forms.TextBox textBox_KeyWords;
        private System.Windows.Forms.TextBox textBox_Password;
        private System.Windows.Forms.TextBox textBox_Account;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button button_Get;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label_info;
    }
}

