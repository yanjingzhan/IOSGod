namespace IOSGod
{
    partial class EmailCreatorForm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button_Do = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox_Mails = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.numericUpDown_MailCount = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_Password = new System.Windows.Forms.TextBox();
            this.checkBox_randomPwd = new System.Windows.Forms.CheckBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_MailCount)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.checkBox_randomPwd);
            this.panel1.Controls.Add(this.textBox_Password);
            this.panel1.Controls.Add(this.numericUpDown_MailCount);
            this.panel1.Controls.Add(this.comboBox_Mails);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.button_Do);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1083, 175);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 175);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1083, 471);
            this.panel2.TabIndex = 1;
            // 
            // button_Do
            // 
            this.button_Do.Location = new System.Drawing.Point(952, 115);
            this.button_Do.Name = "button_Do";
            this.button_Do.Size = new System.Drawing.Size(110, 43);
            this.button_Do.TabIndex = 0;
            this.button_Do.Text = "Do";
            this.button_Do.UseVisualStyleBackColor = true;
            this.button_Do.Click += new System.EventHandler(this.button_Do_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "后缀";
            // 
            // comboBox_Mails
            // 
            this.comboBox_Mails.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Mails.FormattingEnabled = true;
            this.comboBox_Mails.Items.AddRange(new object[] {
            "全部随机",
            "suningguoji.com"});
            this.comboBox_Mails.Location = new System.Drawing.Point(56, 22);
            this.comboBox_Mails.Name = "comboBox_Mails";
            this.comboBox_Mails.Size = new System.Drawing.Size(218, 23);
            this.comboBox_Mails.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "个数";
            // 
            // numericUpDown_MailCount
            // 
            this.numericUpDown_MailCount.Location = new System.Drawing.Point(56, 72);
            this.numericUpDown_MailCount.Name = "numericUpDown_MailCount";
            this.numericUpDown_MailCount.Size = new System.Drawing.Size(218, 25);
            this.numericUpDown_MailCount.TabIndex = 3;
            this.numericUpDown_MailCount.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 129);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 15);
            this.label3.TabIndex = 1;
            this.label3.Text = "密码";
            // 
            // textBox_Password
            // 
            this.textBox_Password.Location = new System.Drawing.Point(56, 126);
            this.textBox_Password.Name = "textBox_Password";
            this.textBox_Password.Size = new System.Drawing.Size(123, 25);
            this.textBox_Password.TabIndex = 4;
            this.textBox_Password.Text = "Alibabasb123";
            // 
            // checkBox_randomPwd
            // 
            this.checkBox_randomPwd.AutoSize = true;
            this.checkBox_randomPwd.Location = new System.Drawing.Point(185, 129);
            this.checkBox_randomPwd.Name = "checkBox_randomPwd";
            this.checkBox_randomPwd.Size = new System.Drawing.Size(89, 19);
            this.checkBox_randomPwd.TabIndex = 5;
            this.checkBox_randomPwd.Text = "密码随机";
            this.checkBox_randomPwd.UseVisualStyleBackColor = true;
            this.checkBox_randomPwd.CheckedChanged += new System.EventHandler(this.checkBox_randomPwd_CheckedChanged);
            // 
            // EmailCreatorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1083, 646);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "EmailCreatorForm";
            this.Text = "EmailCreatorForm";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_MailCount)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox checkBox_randomPwd;
        private System.Windows.Forms.TextBox textBox_Password;
        private System.Windows.Forms.NumericUpDown numericUpDown_MailCount;
        private System.Windows.Forms.ComboBox comboBox_Mails;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_Do;
        private System.Windows.Forms.Panel panel2;
    }
}