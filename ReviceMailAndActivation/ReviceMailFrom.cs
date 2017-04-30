using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using S22.Imap;
using UtilityLib;
using System.IO;
using UtilityLib.Models;

namespace ReviceMailAndActivation
{
    public partial class ReviceMailFrom : Form
    {
        private string _currentMail;

        public string CurrentMail
        {
            get { return _currentMail; }
            set
            {
                _currentMail = value;
                this.label_CurrentCount.Text = _currentMail;
            }
        }

        private string _currentPassword;

        public string CurrentPassword
        {
            get { return _currentPassword; }
            set
            {
                _currentPassword = value;
                this.label_CurrentPassword.Text = _currentPassword;
            }
        }

        private enum UrlState
        {
            NotComplate,
            Success,
            NeedGoToReg,
            NeedReg,
            NeedGoToEditName,
            NeedEditName,
            NeedEditProf,
            NeedGotoEditProf,
            IPDie,
            NeedReStart,
            NeedGoToLogin,
            NeedLogin,
            AccountError,
            Shit,
            NeedHip
        }

        private int _step = 0;

        Timer _timer = new Timer();
        AppleAccountFullInfo _appleAccountFullInfo;

        private string _mainUrl = string.Empty;
        public ReviceMailFrom()
        {
            InitializeComponent();
            this.Load += ReviceMailFrom_Load;
            this.webBrowser_Main.DocumentCompleted += webBrowser_Main_DocumentCompleted;
        }

        void webBrowser_Main_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            this.textBox_CurrentUrl.Text = e.Url.ToString();
            UrlState state = VerfyUrl();

            if (state == UrlState.NeedLogin)
            {
                if (_step == 1)
                {
                    Login();
                }
            }

            if (state == UrlState.Success)
            {
                if (_step == 10)
                {
                    Success();
                }
            }
        }

        private UrlState VerfyUrl()
        {
            if (webBrowser_Main.Document.All["content"] != null &&
                    (webBrowser_Main.Document.All["content"].InnerText.Contains("has already been verified") ||
                    webBrowser_Main.Document.All["content"].InnerText.Contains("has been verified.")))
            {
                _step = 10;
                return UrlState.Success;
            }

            CheckSueecess();

            if (_step == 0)
            {
                if (webBrowser_Main.Document.All["accountpassword"] != null && webBrowser_Main.Document.All["accountname"] != null)
                {
                    _step = 1;
                    return UrlState.NeedLogin;
                }
            }

            return UrlState.NotComplate;
        }

        void ReviceMailFrom_Load(object sender, EventArgs e)
        {
            InitControls();

            _timer = new Timer();
            _timer.Interval = (int)numericUpDown_Second.Value * 1000;
            _timer.Tick += _timer_Tick;

            if (checkBox_AutoStart.Checked)
            {
                button_Start_Click(new object(), new EventArgs());
            }
        }

        private void InitControls()
        {
            if (INIHelper.ReadIniData("conf", "AutoRestart", "0", Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "conf.ini")) == "1")
            {
                this.checkBox_AutoStart.Checked = true;
            }

            numericUpDown_Second.Value = int.Parse(INIHelper.ReadIniData("conf", "WholeTime", "150", Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "conf.ini")));
        }

        bool _hasRestart = false;
        public void Restart()
        {
            if (!_hasRestart)
            {
                _hasRestart = true;
                Application.Restart();
            }
            else
            {
                Application.Exit();
            }
        }

        void _timer_Tick(object sender, EventArgs e)
        {
            _timer.Stop();
            SetInfo("超时，重启");

            try
            {
                SetInfo("修改为 ok 状态");

                HttpDataHelper.UpdateAccountState(_appleAccountFullInfo.AppleAccount, "ok");


            }
            catch (Exception ex)
            {
                SetInfo("Success时候上报数据库失败，" + ex.Message);
            }

            Restart();
        }

        private async void CheckSueecess()
        {
            while (_step != 10)
            {

                if (webBrowser_Main.Document.All["content"] != null &&
                    (webBrowser_Main.Document.All["content"].InnerText.Contains("has already been verified") ||
                    webBrowser_Main.Document.All["content"].InnerText.Contains("has been verified.")
                    || webBrowser_Main.Document.All["content"].InnerText.Contains("已验证")))
                {
                    _step = 10;
                    Success();
                }

                await Task.Delay(TimeSpan.FromSeconds(3));
            }
        }

        private void Login()
        {
            SetInfo("登陆");

            HtmlElement accountname = this.webBrowser_Main.Document.All["accountname"];
            HtmlElement accountpassword = this.webBrowser_Main.Document.All["accountpassword"];

            HtmlElement right = this.webBrowser_Main.Document.All["right"];

            //accountname.Focus();
            //accountname.InnerText = _appleAccountFullInfo.AppleAccount;

            accountpassword.Focus();
            accountpassword.InnerText = _appleAccountFullInfo.ApplePassword;

            right.InvokeMember("click");
        }

        private void Success()
        {
            SetInfo("成功");

            try
            {
                HttpDataHelper.UpdateAccountState(_appleAccountFullInfo.AppleAccount, "success");
                SetInfo("重启");
            }
            catch (Exception ex)
            {
                SetInfo("Success时候上报数据库失败，" + ex.Message);
            }

            Restart();
        }


        private void button_Start_Click(object sender, EventArgs e)
        {
            Start();
        }

        private async void Start()
        {
            try
            {
                SetInfo("开始");

                _timer.Stop();
                _timer.Interval = (int)numericUpDown_Second.Value * 1000;
                _timer.Start();

                _appleAccountFullInfo = HttpDataHelper.GetAppleAccountFullInfoAndRefreshStateByState("ok", "reviceing");

                //test
                //_appleAccountFullInfo = new AppleAccountFullInfo();
                //_appleAccountFullInfo.AppleAccount = "muerkdosstblciqu@outlook.com";
                //_appleAccountFullInfo.ApplePassword = "Kk662255";

                if (_appleAccountFullInfo != null)
                {
                    CurrentMail = _appleAccountFullInfo.AppleAccount;
                    CurrentPassword = _appleAccountFullInfo.ApplePassword;

                    //test
                    //CurrentMail = "muerkdosstblciqu@outlook.com";
                    //CurrentPassword = "b2y6h7w8v6";

                    SetInfo("获取到账号");

                    await Task.Delay(TimeSpan.FromSeconds(1));

                    _mainUrl = MailHelper.GetVerifyMailUrl(_appleAccountFullInfo.VerifyMail, _appleAccountFullInfo.VerifyPassword, _appleAccountFullInfo.Country);
                    if (string.IsNullOrWhiteSpace(_mainUrl))
                    {
                        SetInfo("没有获取到邮件,恢复账号状态...");
                        HttpDataHelper.UpdateAccountState(_appleAccountFullInfo.AppleAccount, "ok");

                        SetInfo("重启...");
                        Restart();
                        return;
                    }

                    if (_mainUrl.StartsWith("ERROR:"))
                    {
                        SetInfo("出错了," + _mainUrl);

                        if (_mainUrl.Contains("Invalid username or password.") || _mainUrl.Contains("Login to your account via a web browser."))
                        {
                            SetInfo("密码错误或账号废了,上报数据库");

                            HttpDataHelper.UpdateAccountState(_appleAccountFullInfo.AppleAccount, "die");
                        }
                        else
                        {
                            HttpDataHelper.UpdateAccountState(_appleAccountFullInfo.AppleAccount, "ok");
                        }

                        SetInfo("重启...");
                        Restart();
                        return;
                    }

                    SetInfo("去验证...");
                    webBrowser_Main.Navigate(_mainUrl);
                }
                else
                {
                    SetInfo("没有获取到账号，等待超时重启...");
                }
            }
            catch (Exception ex)
            {
                SetInfo("获取账号信息失败..." + ex.Message);
            }
        }




        private void SetInfo(string msg)
        {
            if (_appleAccountFullInfo != null)
            {
                msg = _appleAccountFullInfo.AppleAccount + "," + msg;
            }

            this.textBox_Info.AppendText(DateTime.Now.ToString() + "," + msg);
            this.textBox_Info.AppendText(Environment.NewLine);

            try
            {
                Logger.Log(msg);
            }
            catch { }
        }

        private void numericUpDown_Second_ValueChanged(object sender, EventArgs e)
        {
            INIHelper.WriteIniData("Conf", "WholeTime", numericUpDown_Second.Value.ToString(), Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "conf.ini"));
        }

        private void checkBox_AutoStart_CheckedChanged(object sender, EventArgs e)
        {
            INIHelper.WriteIniData("Conf", "AutoRestart", checkBox_AutoStart.Checked ? "1" : "0", Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "conf.ini"));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //MailHelper.GetVerifyMailUrl("muerkdosstblciqu@outlook.com", "b2y6h7w8v6");
            MailHelper.GetVerifyMailUrl("lwmlqbputsesekxmbiymwn1@outlook.com", "q2i8m3h3x1m1");
        }

    }
}
