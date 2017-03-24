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

namespace WindowsItunesRegister
{
    public partial class MainForm : Form
    {
        private AppleAccountFullInfo _appleAccountFullInfo;
        public MainForm()
        {
            InitializeComponent();
            SetButtonBeginState();
            InitConfig();

            try
            {
                NetHelper.TryDeleteVPN(_VPNName);
            }
            catch (Exception ex)
            {

                SetInfo("删除vpn失败," + ex.Message);
            }
        }

        private string _VPNName = string.Empty;
        private string _VPNAccount = string.Empty;
        private string _VPNPassword = string.Empty;
        private bool _isL2tp = false;

        private string _connectionWay = string.Empty;

        private string _adslName;
        private string _adslAccount;
        private string _adslPassword;


        private void InitConfig()
        {
            _VPNName = INIHelper.ReadIniData("conf", "VPNName", string.Empty, Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "conf.ini"));
            _VPNAccount = INIHelper.ReadIniData("conf", "VPNAccount", string.Empty, Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "conf.ini"));
            _VPNPassword = INIHelper.ReadIniData("conf", "VPNPassword", string.Empty, Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "conf.ini"));
            _isL2tp = INIHelper.ReadIniData("conf", "IsL2tp", "0", Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "conf.ini")) == "1";
            _connectionWay = INIHelper.ReadIniData("conf", "ConnectionWay", "VPN", Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "conf.ini"));

            comboBox_Country.Text = INIHelper.ReadIniData("conf", "Country", "US", Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "conf.ini"));

            _adslName = INIHelper.ReadIniData("Conf", "AdslName", "宽带连接", Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "conf.ini"));
            _adslAccount = INIHelper.ReadIniData("Conf", "AdslAccount", "0", Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "conf.ini"));
            _adslPassword = INIHelper.ReadIniData("Conf", "AdslPassword", "0", Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "conf.ini"));
        }

        private void button_GetAccount_Click(object sender, EventArgs e)
        {
            try
            {
                //163邮箱时候的代码
                /*  
                _appleAccountFullInfo = HttpDataHelper.GetAppleAccountFullInfo();
                this.textBox_Email.Text = _appleAccountFullInfo.AppleAccount;
                this.textBox_Password.Text = _appleAccountFullInfo.ApplePassword;
                this.textBox_SecondAnswer.Text = _appleAccountFullInfo.SecondAnswer;
                this.textBox_FirstAnswer.Text = _appleAccountFullInfo.FirstAnswer;
                this.textBox_ThirdAnswer.Text = _appleAccountFullInfo.ThirdAnswer;

                DateTime dt = DateTime.Parse(_appleAccountFullInfo.Birthday);
                this.textBox_Month.Text = dt.Month.ToString();
                this.textBox_Day.Text = dt.Day.ToString();
                this.textBox_Year.Text = dt.Year.ToString();

                this.textBox_FirstName.Text = _appleAccountFullInfo.FirstName;
                this.textBox_LastName.Text = _appleAccountFullInfo.SecondName;
                this.textBox_Street.Text = _appleAccountFullInfo.Address;
                this.textBox_City.Text = _appleAccountFullInfo.City;
                this.textBox_State.Text = _appleAccountFullInfo.Province;
                this.textBox_Zip.Text = _appleAccountFullInfo.ZipCode;
                this.textBox_AreaCode.Text = _appleAccountFullInfo.PhoneNumber1;
                this.textBox_Phone.Text = _appleAccountFullInfo.PhoneNumber2;
                */

                ApplePersonInfo personInfo = HttpDataHelper.GetApplePersonInfoAndRefreshState("tobebinding", "binding", comboBox_Country.Text);
                AccountInfo outLookAccountInfo = HttpDataHelper.GetAccountListByIOSStateAndRefreshState("outlooked", "binding");

                if (personInfo == null)
                {
                    throw new Exception("获取人物信息失败");
                }

                if (outLookAccountInfo == null)
                {
                    throw new Exception("获取账号信息失败");

                }

                if (comboBox_Country.Text.ToLower() == "china")
                {
                    _appleAccountFullInfo = new AppleAccountFullInfo
                    {
                        AppleAccount = outLookAccountInfo.Account,
                        ApplePassword = RandomHelper.ApplePasswordCreator2(),
                        VerifyMail = outLookAccountInfo.Account,
                        VerifyPassword = outLookAccountInfo.Password,
                        FirstQuestion = "你学会做的第一道菜是什么？",
                        SecondQuestion = "你小时候最喜欢的一本书？",
                        ThirdQuestion = "你购买的第一张专辑是什么？",
                        FirstAnswer = RandomHelper.CreatorZiMu(6, 8),
                        SecondAnswer = RandomHelper.CreatorZiMu(6, 8),
                        ThirdAnswer = RandomHelper.CreatorZiMu(6, 8),
                        FirstName = personInfo.FirstName,
                        SecondName = personInfo.SecondName,
                        Country = "China",
                        Birthday = RandomHelper.GetBirthday(),
                        ApplePersonInfoID = personInfo.ID,
                    };
                }
                else
                {
                    _appleAccountFullInfo = new AppleAccountFullInfo
                    {
                        AppleAccount = outLookAccountInfo.Account,
                        ApplePassword = RandomHelper.ApplePasswordCreator2(),
                        VerifyMail = outLookAccountInfo.Account,
                        VerifyPassword = outLookAccountInfo.Password,
                        FirstQuestion = "What is your favorite childrens book?",
                        SecondQuestion = "What was the first thing you learned to cook?",
                        ThirdQuestion = "What was the first album that you purchased?",
                        FirstAnswer = RandomHelper.CreatorZiMu(6, 8),
                        SecondAnswer = RandomHelper.CreatorZiMu(6, 8),
                        ThirdAnswer = RandomHelper.CreatorZiMu(6, 8),
                        FirstName = personInfo.FirstName,
                        SecondName = personInfo.SecondName,
                        Country = "USA",
                        Birthday = RandomHelper.GetBirthday(),
                        ApplePersonInfoID = personInfo.ID,
                    };
                }

                this.textBox_Email.Text = _appleAccountFullInfo.AppleAccount;
                this.textBox_Password.Text = _appleAccountFullInfo.ApplePassword;
                this.textBox_SecondAnswer.Text = _appleAccountFullInfo.SecondAnswer;
                this.textBox_FirstAnswer.Text = _appleAccountFullInfo.FirstAnswer;
                this.textBox_ThirdAnswer.Text = _appleAccountFullInfo.ThirdAnswer;

                DateTime dt = DateTime.Parse(_appleAccountFullInfo.Birthday);
                this.textBox_Month.Text = dt.Month.ToString();
                this.textBox_Day.Text = dt.Day.ToString();
                this.textBox_Year.Text = dt.Year.ToString();

                this.textBox_FirstName.Text = _appleAccountFullInfo.FirstName;
                this.textBox_LastName.Text = _appleAccountFullInfo.SecondName;
                this.textBox_Street.Text = personInfo.Address;
                this.textBox_City.Text = personInfo.City;
                this.textBox_State.Text = personInfo.Province;
                this.textBox_Zip.Text = personInfo.ZipCode;
                this.textBox_AreaCode.Text = personInfo.PhoneNumber1;
                this.textBox_Phone.Text = personInfo.PhoneNumber2;

                SetButtonWorkingState();
                SetInfo("获取成功");
            }
            catch (Exception ex)
            {
                SetInfo(ex.Message);
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

        private void button_SecondAnswer_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(this.textBox_SecondAnswer.Text))
            {
                try
                {
                    Clipboard.SetText(this.textBox_SecondAnswer.Text);
                }
                catch { }
            }

        }

        private void button_FirstAnswer_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(this.textBox_FirstAnswer.Text))
            {
                try
                {
                    Clipboard.SetText(this.textBox_FirstAnswer.Text);
                }
                catch { }
            }
        }

        private void button_ThirdAnswer_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(this.textBox_ThirdAnswer.Text))
            {
                try
                {

                    Clipboard.SetText(this.textBox_ThirdAnswer.Text);
                }
                catch { }
            }
        }

        private void button_Year_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(this.textBox_Year.Text))
            {
                try
                {
                    Clipboard.SetText(this.textBox_Year.Text);
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

        private void button_DoneOk_Click(object sender, EventArgs e)
        {
            try
            {
                //163邮箱时候的代码
                /*
                HttpDataHelper.UpdateAccountState(_appleAccountFullInfo.AppleAccount, "binding");
                 */

                HttpDataHelper.AddNewAppleAccountToDB(_appleAccountFullInfo, "ok");

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
                if (MessageBox.Show("确定这个账号已经作废了吗？", "提示", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
                {
                    //163邮箱时候的代码
                    /*
                    HttpDataHelper.UpdateAccountState(_appleAccountFullInfo.AppleAccount, "die");
                      */

                    //HttpDataHelper.UpdateApplePersonInfoStateByID("tobebinding", _appleAccountFullInfo.ApplePersonInfoID);

                    SetInfo("提交成功,请获取下一个");

                    SetButtonBeginState();
                }
            }
            catch
            {
                SetInfo("提交失败，请重试");
            }
        }

        private async void button_ConnectVPN_Click(object sender, EventArgs e)
        {
            if (_connectionWay.ToLower() == "adsl")
            {
                int totalCount = 0;
                while (totalCount++ < 5)
                {
                    SetInfo(string.Format("重连ADSL,{0}...", _adslName));
                    NetHelper.ReConnectADSL(_adslName, _adslAccount, _adslPassword);

                    if (NetHelper.IsVpnConnected(_adslName))
                    {
                        SetInfo(string.Format("重播完成"));
                        return;
                    }
                    else
                    {
                        await Task.Delay(TimeSpan.FromSeconds(1));
                        SetInfo(string.Format("重连ADSL失败,准备重试"));

                    }
                }

                SetInfo(string.Format("ADSL重播失败"));
            }
            else
            {
                int totalCount = 0;
                while (totalCount++ < 5)
                {
                    SetInfo(string.Format("断开,{0}...", _VPNName));
                    NetHelper.DisConnectVPN(_VPNName);
                    //NetHelper.TryDeleteVPN(_VPNName);

                    await Task.Delay(TimeSpan.FromSeconds(3));
                    NetHelper.CreateOrUpdateVPN(_VPNName, _VPNName, _isL2tp);

                    SetInfo(string.Format("链接VPN,{0}...", _VPNName));
                    NetHelper.ConnectVPN(_VPNName, _VPNAccount, _VPNPassword);

                    int count = 0;
                    while (count++ < 10)
                    {
                        await Task.Delay(TimeSpan.FromSeconds(1));

                        if (NetHelper.IsVpnConnected(_VPNName))
                        {
                            int mCount = 0;

                            while (mCount++ < 3)
                            {
                                await Task.Delay(TimeSpan.FromSeconds(1));

                                if (NetHelper.PingIpOrDomainName())
                                {
                                    SetInfo("VPN连接成功");
                                    return;
                                }
                                else
                                {
                                    SetInfo("VPN已连接但是不能上网...准备重试");
                                }
                            }

                            SetInfo("VPN已连接但是不能上网...重试5次仍然不行，准备重连VPN");
                        }

                        await Task.Delay(TimeSpan.FromSeconds(2));
                    }
                }

                SetInfo(string.Format("VPN连接失败"));
            }

        }

        private async void button_DisConnect_Click(object sender, EventArgs e)
        {
            NetHelper.DisConnectVPN(_VPNName);
            //NetHelper.TryDeleteVPN(_VPNName);

            int count = 0;
            while (count++ < 10)
            {
                await Task.Delay(TimeSpan.FromSeconds(3));

                if (!NetHelper.IsVpnConnected(_VPNName))
                {
                    SetInfo("VPN断开成功");
                    return;
                }
            }

            SetInfo(string.Format("VPN断开失败"));
        }

        private void button_ZipError_Click(object sender, EventArgs e)
        {
            try
            {
                HttpDataHelper.UpdateApplePersonInfoStateByID("zipdie", _appleAccountFullInfo.ApplePersonInfoID);
                //HttpDataHelper.UpdateApplePersonInfoStateByID("shit", "1");

                SetInfo("邮编状态提交成功");

                //SetButtonBeginState();
            }
            catch
            {
                SetInfo("邮编状态提交失败，请重试");
            }
        }

        private void button_ResetRouter_Click(object sender, EventArgs e)
        {
            try
            {
                HttpDataHelper.CreatePostHttpResponseNew("http://192.168.0.1/userRpm/SysRebootRpm.htm?Reboot=%D6%D8%C6%F4%C2%B7%D3%C9%C6%F7");
                SetInfo("重启请求发送完成");
            }
            catch (Exception ex)
            {
                SetInfo("重启路由器失败," + ex.Message);
            }
        }

        private void comboBox_Country_SelectedIndexChanged(object sender, EventArgs e)
        {
            INIHelper.WriteIniData("conf", "Country", comboBox_Country.Text, Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "conf.ini"));
        }
    }
}

