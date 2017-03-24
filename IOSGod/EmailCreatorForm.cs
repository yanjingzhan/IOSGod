using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UtilityLib;

namespace IOSGod
{
    public partial class EmailCreatorForm : Form
    {
        public EmailCreatorForm()
        {
            InitializeComponent();

            this.comboBox_Mails.SelectedIndex = 0;
        }

        private void button_Do_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();

            if(sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                using(StreamWriter sw = new StreamWriter(sfd.FileName,true))
                {
                    using (StreamWriter sw2 = new StreamWriter(sfd.FileName + ".account.txt", true))
                    {
                        for (int i = 0; i < (int)this.numericUpDown_MailCount.Value; i++)
                        {
                            string account = RandomHelper.CreatorZiMu(4, 8);
                            string mailDomain = GetMailDomain();
                            string password = GetPassowrd();

                            sw.WriteLine(account + "@" + mailDomain + "----" + password);
                            sw2.WriteLine("User {0} {1} {2}", account, password, mailDomain);
                        }
                    }
                }
            }

            MessageBox.Show("done");
        }

        private string GetMailDomain()
        {
            if(this.comboBox_Mails .SelectedIndex == 0)
            {
                return comboBox_Mails.Items[new Random().Next(1, this.comboBox_Mails.Items.Count)].ToString();
            }
            else
            {
                return comboBox_Mails.Text;
            }
        }

        private string GetPassowrd()
        {
            if(checkBox_randomPwd.Checked)
            {
                return RandomHelper.PasswordCreator(4, 6);
            }
            else
            {
                return textBox_Password.Text;
            }
        }

        private void checkBox_randomPwd_CheckedChanged(object sender, EventArgs e)
        {
            this.textBox_Password.ReadOnly = checkBox_randomPwd.Checked;
        }
    }
}
