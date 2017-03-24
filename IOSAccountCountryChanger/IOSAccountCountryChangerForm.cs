using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using UtilityLib;
using UtilityLib.Models;

namespace IOSAccountCountryChanger
{
    public partial class IOSAccountCountryChangerForm : Form
    {
        private string _country;
        private string _newCountry;

        private AppleAccountFullInfo _appleAccountFullInfo;
        public IOSAccountCountryChangerForm()
        {
            InitializeComponent();

            SetButtonBeginState();
            InitConfig();
        }

        private void InitConfig()
        {
            _country = INIHelper.ReadIniData("conf", "Country", "USA", Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "conf.ini"));
            _newCountry = INIHelper.ReadIniData("conf", "NewCountry", "China", Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "conf.ini"));
        }

        private void button_GetAccount_Click(object sender, EventArgs e)
        {
            try
            {
                _appleAccountFullInfo = HttpDataHelper.GetAppAccountByChangeCountryState(_country, _newCountry);

                this.textBox_Email.Text = _appleAccountFullInfo.AppleAccount;
                this.textBox_Password.Text = _appleAccountFullInfo.ApplePassword;


                this.textBox_FirstName.Text = _appleAccountFullInfo.FirstName;
                this.textBox_LastName.Text = _appleAccountFullInfo.SecondName;
                this.textBox_Street.Text = _appleAccountFullInfo.Address;
                this.textBox_City.Text = _appleAccountFullInfo.City;
                this.textBox_State.Text = _appleAccountFullInfo.Province;
                this.textBox_Zip.Text = _appleAccountFullInfo.ZipCode;
                this.textBox_AreaCode.Text = _appleAccountFullInfo.PhoneNumber1;
                this.textBox_Phone.Text = _appleAccountFullInfo.PhoneNumber2;

                SetButtonWorkingState();
                SetInfo("获取成功");
            }
            catch (Exception ex)
            {
                SetInfo(ex.Message);
            }
        }

        private void button_DoneOk_Click(object sender, EventArgs e)
        {
            try
            {

                HttpDataHelper.UpdateCountryAndChangeCountryStateByID(_newCountry, "changed", _appleAccountFullInfo.ApplePersonInfoID, _appleAccountFullInfo.ID);

                SetInfo("提交成功,请获取下一个");
                SetButtonBeginState();
            }
            catch
            {
                SetInfo("提交失败，请重试");
            }
        }

        private void button_Die_Click(object sender, EventArgs e)
        {
            try
            {

                HttpDataHelper.UpdateCountryAndChangeCountryStateByID(_country, "changeFail", "null", _appleAccountFullInfo.ID);

                SetInfo("提交完毕,请获取下一个");
                SetButtonBeginState();
            }
            catch
            {
                SetInfo("提交失败，请重试");
            }
        }

        private void SetInfo(string msg)
        {
            this.label_info.Text = msg;
        }

        private void SetButtonBeginState()
        {
            this.button_GetAccount.Enabled = true;
            this.button_DoneOk.Enabled = false;
            this.button_Die.Enabled = false;


            foreach (var textBox in groupBox2.Controls)
            {
                if (textBox is TextBox)
                {
                    (textBox as TextBox).Clear();
                }
            }

            foreach (var textBox in groupBox3.Controls)
            {
                if (textBox is TextBox)
                {
                    (textBox as TextBox).Clear();
                }
            }
        }

        private void SetButtonWorkingState()
        {
            this.button_GetAccount.Enabled = false;
            this.button_DoneOk.Enabled = true;
            this.button_Die.Enabled = true;
        }

        #region 剪切板


        private void button_Email_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(this.textBox_Email.Text))
            {
                try
                {
                    Clipboard.SetText(this.textBox_Email.Text);
                }
                catch { }
            }
        }

        private void button_Password_Click(object sender, EventArgs e)
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

       
        private void button_FirstName_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(this.textBox_FirstName.Text))
            {
                try
                {
                    Clipboard.SetText(this.textBox_FirstName.Text);
                }
                catch { }
            }
        }

        private void button_LastName_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(this.textBox_LastName.Text))
            {
                try
                {
                    Clipboard.SetText(this.textBox_LastName.Text);
                }
                catch { }
            }
        }

        private void button_Street_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(this.textBox_Street.Text))
            {
                try
                {
                    Clipboard.SetText(this.textBox_Street.Text);
                }
                catch { }
            }
        }

        private void button_Apt_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(this.textBox_Apt.Text))
            {
                try
                {
                    Clipboard.SetText(this.textBox_Apt.Text);
                }
                catch { }
            }
            else
            {
                try
                {
                    Clipboard.SetText(" ");
                }
                catch { }
            }
        }

        private void button_City_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(this.textBox_City.Text))
            {
                try
                {
                    Clipboard.SetText(this.textBox_City.Text);
                }
                catch { }
            }
        }

        private void button_State_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(this.textBox_State.Text))
            {
                try
                {
                    Clipboard.SetText(this.textBox_State.Text);
                }
                catch { }
            }

        }

        private void button_Zip_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(this.textBox_Zip.Text))
            {
                try
                {
                    Clipboard.SetText(this.textBox_Zip.Text);

                }
                catch { }
            }
        }

        private void button_AreaCode_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(this.textBox_AreaCode.Text))
            {
                try
                {
                    Clipboard.SetText(this.textBox_AreaCode.Text);
                }
                catch { }
            }
        }

        private void button__Phone_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(this.textBox_Phone.Text))
            {
                try
                {
                    Clipboard.SetText(this.textBox_Phone.Text);
                }
                catch { }
            }
        }

        #endregion

    }
}
