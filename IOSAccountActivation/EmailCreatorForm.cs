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
using UtilityLib.Models;

namespace IOSAccountActivation
{
    public partial class EmailCreatorForm : Form
    {
        Random _rd = new Random();
        public EmailCreatorForm()
        {
            InitializeComponent();

            this.comboBox_Mails.SelectedIndex = 0;
        }

        private void button_Do_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();

            if (sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                using (StreamWriter sw = new StreamWriter(sfd.FileName, true))
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
            if (this.comboBox_Mails.SelectedIndex == 0)
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
            if (checkBox_randomPwd.Checked)
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

        private void button_SelectImportFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();

            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this.label_ImportFileName.Text = ofd.FileName;
            }
        }

        private async void button_Import_Click(object sender, EventArgs e)
        {
            if (this.label_ImportFileName.Text != "label4")
            {
                using (StreamReader sr = new StreamReader(this.label_ImportFileName.Text))
                {
                    string[] accountContents = sr.ReadToEnd().Split('\n');

                    if (accountContents.Length > 0)
                    {
                        foreach (var accountContent in accountContents)
                        {

                            string[] ss = accountContent.Trim().Replace("----", "|").Split('|');
                            if (ss.Length > 1)
                            {


                                ApplePersonInfo person = DataHelper.PersonInfoGet();

                                AppleAccountFullInfo shit = new AppleAccountFullInfo
                                {
                                    AppleAccount = ss[0].Trim(),
                                    ApplePassword = ApplePasswordCreator(),
                                    VerifyMail = ss[0].Trim(),
                                    VerifyPassword = ss[1].Trim(),
                                    FirstQuestion = "What is your favorite childrens book?",
                                    SecondQuestion = "What was the first thing you learned to cook?",
                                    ThirdQuestion = "What was the first album that you purchased?",
                                    FirstAnswer = RandomHelper.CreatorZiMu(6, 8),
                                    SecondAnswer = RandomHelper.CreatorZiMu(6, 8),
                                    ThirdAnswer = RandomHelper.CreatorZiMu(6, 8),
                                    FirstName = person.FirstName,
                                    SecondName = person.SecondName,
                                    Country = "USA",
                                    Birthday = RandomHelper.GetBirthday(),
                                };

                                try
                                {
                                    DataHelper.AddNewAppleAccountToDB(shit, person, "tobereg");
                                    await Task.Delay(TimeSpan.FromSeconds(0.1));

                                    SetInfo(shit.AppleAccount + "  ok");
                                }
                                catch (Exception ex)
                                {
                                    SetInfo(shit.AppleAccount + "  Fail," + ex.Message);
                                }
                            }
                        }
                    }
                }
            }
        }

        private string ApplePasswordCreator()
        {

            string[] first = {"Qq","Aa","Zz","Ww","Ss","Xx","Ee","Dd","Cc","Rr","Ff","Vv","Tt","Gg","Bb","Yy","Hh",
                                  "Nn","Uu","Jj","Mm","Ii","Kk","Oo","Ll","Pp"};

            string[] second = { "11", "22", "33", "44", "55", "66", "77", "88", "99", "00" };

            string firstStr = first[_rd.Next(first.Length)];
            string secondStr = second[_rd.Next(second.Length)];

            List<string> third = second.ToList();
            third.Remove(secondStr);

            string thirdStr = third[_rd.Next(third.Count)];
            third.Remove(thirdStr);

            string fourthStr = third[_rd.Next(third.Count)];


            return firstStr + secondStr + thirdStr + fourthStr;
        }

        private void SetInfo(string msg)
        {
            this.textBox_Info.AppendText(DateTime.Now.ToString() + "," + msg);
            this.textBox_Info.AppendText(Environment.NewLine);
        }


    }
}
