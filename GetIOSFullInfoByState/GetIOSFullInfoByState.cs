using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GetIOSFullInfoByState
{
    public partial class GetIOSFullInfoByState : Form
    {
        public GetIOSFullInfoByState()
        {
            InitializeComponent();
        }

        private void button_CopyAccount_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(this.textBox_Account.Text))
            {
                try
                {
                    Clipboard.SetText(this.textBox_Account.Text);
                }
                catch { }
            }
        }

        private void button_CopyPassword_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(this.textBox_Password.Text))
            {
                try
                {
                    Clipboard.SetText(this.textBox_Password.Text);
                }
                catch { }
            }
        }

        private void button_CopyStreet_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(this.textBox_KeyWords.Text))
            {
                try
                {
                    Clipboard.SetText(this.textBox_KeyWords.Text);
                }
                catch { }
            }

        }

        private void button_Get_Click(object sender, EventArgs e)
        {
            try
            {
                string s = HttpDataHelpper.GetIOSFullInfoByStateStr();
                string[] shit_t = s.Split(',');

                this.textBox_Account.Text = shit_t[0];
                this.textBox_Password.Text = shit_t[1];
                this.textBox_KeyWords.Text = shit_t[10];

                HttpDataHelpper.DownloadGameLogo(shit_t[11]);

                SetInfo("获取成功," + shit_t[0]);
            }
            catch (Exception ex)
            {
                SetInfo("获取失败," + ex.Message);
            }
        }

        private void SetInfo(string msg)
        {
            this.label_info.Text = msg;
        }
    }
}
