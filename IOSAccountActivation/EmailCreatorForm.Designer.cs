namespace IOSAccountActivation
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkBox_randomPwd = new System.Windows.Forms.CheckBox();
            this.textBox_Password = new System.Windows.Forms.TextBox();
            this.numericUpDown_MailCount = new System.Windows.Forms.NumericUpDown();
            this.comboBox_Mails = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button_Do = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button_SelectImportFile = new System.Windows.Forms.Button();
            this.button_Import = new System.Windows.Forms.Button();
            this.label_ImportFileName = new System.Windows.Forms.Label();
            this.textBox_Info = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_MailCount)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1083, 211);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.textBox_Info);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 211);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1083, 435);
            this.panel2.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.checkBox_randomPwd);
            this.groupBox1.Controls.Add(this.textBox_Password);
            this.groupBox1.Controls.Add(this.numericUpDown_MailCount);
            this.groupBox1.Controls.Add(this.comboBox_Mails);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.button_Do);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(421, 179);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "导出账号";
            // 
            // checkBox_randomPwd
            // 
            this.checkBox_randomPwd.AutoSize = true;
            this.checkBox_randomPwd.Location = new System.Drawing.Point(187, 131);
            this.checkBox_randomPwd.Name = "checkBox_randomPwd";
            this.checkBox_randomPwd.Size = new System.Drawing.Size(89, 19);
            this.checkBox_randomPwd.TabIndex = 13;
            this.checkBox_randomPwd.Text = "密码随机";
            this.checkBox_randomPwd.UseVisualStyleBackColor = true;
            // 
            // textBox_Password
            // 
            this.textBox_Password.Location = new System.Drawing.Point(58, 128);
            this.textBox_Password.Name = "textBox_Password";
            this.textBox_Password.Size = new System.Drawing.Size(123, 25);
            this.textBox_Password.TabIndex = 12;
            this.textBox_Password.Text = "Alibabasb123";
            // 
            // numericUpDown_MailCount
            // 
            this.numericUpDown_MailCount.Location = new System.Drawing.Point(58, 74);
            this.numericUpDown_MailCount.Name = "numericUpDown_MailCount";
            this.numericUpDown_MailCount.Size = new System.Drawing.Size(218, 25);
            this.numericUpDown_MailCount.TabIndex = 11;
            this.numericUpDown_MailCount.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // comboBox_Mails
            // 
            this.comboBox_Mails.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Mails.FormattingEnabled = true;
            this.comboBox_Mails.Items.AddRange(new object[] {
            "全部随机",
            "suningguoji.com"});
            this.comboBox_Mails.Location = new System.Drawing.Point(58, 24);
            this.comboBox_Mails.Name = "comboBox_Mails";
            this.comboBox_Mails.Size = new System.Drawing.Size(218, 23);
            this.comboBox_Mails.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 131);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 15);
            this.label3.TabIndex = 7;
            this.label3.Text = "密码";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 15);
            this.label2.TabIndex = 8;
            this.label2.Text = "个数";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 15);
            this.label1.TabIndex = 9;
            this.label1.Text = "后缀";
            // 
            // button_Do
            // 
            this.button_Do.Location = new System.Drawing.Point(305, 107);
            this.button_Do.Name = "button_Do";
            this.button_Do.Size = new System.Drawing.Size(110, 43);
            this.button_Do.TabIndex = 6;
            this.button_Do.Text = "导出";
            this.button_Do.UseVisualStyleBackColor = true;
            this.button_Do.Click += new System.EventHandler(this.button_Do_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label_ImportFileName);
            this.groupBox2.Controls.Add(this.button_SelectImportFile);
            this.groupBox2.Controls.Add(this.button_Import);
            this.groupBox2.Location = new System.Drawing.Point(458, 22);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(613, 169);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "导入账号到库中";
            // 
            // button_SelectImportFile
            // 
            this.button_SelectImportFile.Location = new System.Drawing.Point(6, 24);
            this.button_SelectImportFile.Name = "button_SelectImportFile";
            this.button_SelectImportFile.Size = new System.Drawing.Size(75, 23);
            this.button_SelectImportFile.TabIndex = 0;
            this.button_SelectImportFile.Text = "选择文件";
            this.button_SelectImportFile.UseVisualStyleBackColor = true;
            this.button_SelectImportFile.Click += new System.EventHandler(this.button_SelectImportFile_Click);
            // 
            // button_Import
            // 
            this.button_Import.Location = new System.Drawing.Point(6, 97);
            this.button_Import.Name = "button_Import";
            this.button_Import.Size = new System.Drawing.Size(110, 43);
            this.button_Import.TabIndex = 6;
            this.button_Import.Text = "导入";
            this.button_Import.UseVisualStyleBackColor = true;
            this.button_Import.Click += new System.EventHandler(this.button_Import_Click);
            // 
            // label_ImportFileName
            // 
            this.label_ImportFileName.AutoSize = true;
            this.label_ImportFileName.Location = new System.Drawing.Point(6, 64);
            this.label_ImportFileName.Name = "label_ImportFileName";
            this.label_ImportFileName.Size = new System.Drawing.Size(55, 15);
            this.label_ImportFileName.TabIndex = 7;
            this.label_ImportFileName.Text = "label4";
            // 
            // textBox_Info
            // 
            this.textBox_Info.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_Info.Location = new System.Drawing.Point(0, 0);
            this.textBox_Info.Multiline = true;
            this.textBox_Info.Name = "textBox_Info";
            this.textBox_Info.Size = new System.Drawing.Size(1083, 435);
            this.textBox_Info.TabIndex = 0;
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
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_MailCount)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox checkBox_randomPwd;
        private System.Windows.Forms.TextBox textBox_Password;
        private System.Windows.Forms.NumericUpDown numericUpDown_MailCount;
        private System.Windows.Forms.ComboBox comboBox_Mails;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_Do;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label_ImportFileName;
        private System.Windows.Forms.Button button_SelectImportFile;
        private System.Windows.Forms.Button button_Import;
        private System.Windows.Forms.TextBox textBox_Info;
    }
}