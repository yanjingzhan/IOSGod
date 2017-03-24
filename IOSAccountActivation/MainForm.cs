using mshtml;
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
    public partial class MainForm : Form
    {
        private int _step = 0;

        private int _currentSucCount;

        public int CurrentSucCount
        {
            get { return _currentSucCount; }
            set
            {
                _currentSucCount = value;
                this.label_SucCount.Text = _currentSucCount.ToString();
            }
        }

        private int _currentFailCount;

        public int CurrentFailCount
        {
            get { return _currentFailCount; }
            set
            {
                _currentFailCount = value;
                this.label_FailCount.Text = _currentFailCount.ToString();
            }
        }

        private string _currentMail;

        public string CurrentMail
        {
            get { return _currentMail; }
            set
            {
                _currentMail = value;
                this.label_CurrentEduMail.Text = _currentMail;
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
            NeedLogin
        }

        private List<AppleAccountFullInfo> _appleAccountFullInfoList = null;

        private string _loginUrl = string.Format("https://appleid.apple.com/#!&page=signin");

        public MainForm()
        {
            InitializeComponent();
            this.Load += MainForm_Load;
            this.webBrowser_Main.DocumentCompleted += webBrowser_Main_DocumentCompleted;
            this.timer1.Tick += timer1_Tick;
        }

        void timer1_Tick(object sender, EventArgs e)
        {
            SetInfo("超时重启...");
            Application.Restart();
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
                if (_step == 2)
                {
                    Success();
                }
            }

        }


        private UrlState VerfyUrl()
        {
            if (_step == 0)
            {
                IHTMLDocument3 htmlDoc = CorssDomainHelper.GetDocumentFromWindow(webBrowser_Main.Document.Window.Frames[0].DomWindow
                        as IHTMLWindow2);

                IHTMLElementCollection all = ((HTMLDocument)(htmlDoc.documentElement.document)).all;

                mshtml.IHTMLElement appleId = null;
                mshtml.IHTMLElement pwd = null;
                mshtml.IHTMLElement signin = null;

                foreach (mshtml.IHTMLElement element in all)
                {
                    System.Diagnostics.Debug.WriteLine(element.id);
                    if (element.id == "appleId")
                    {
                        appleId = element;
                    }


                    if (element.id == "pwd")
                    {
                        pwd = element;
                    }

                    if (element.id == "sign-in")
                    {
                        signin = element;
                    }
                }

                if (appleId != null && pwd != null && signin != null)
                {
                    _step = 1;
                    return UrlState.NeedLogin;
                }
            }

            if (_step == 1)
            {
                HtmlElement account = this.webBrowser_Main.Document.All["account"];
                HtmlElement accountcontent = this.webBrowser_Main.Document.All["account-content"];

                if (account != null && accountcontent != null)
                {
                    _step = 2;
                    return UrlState.Success;
                }
            }

            return UrlState.NotComplate;
        }

        void MainForm_Load(object sender, EventArgs e)
        {
            Init();
        }

        private async void Login()
        {
            SetInfo("登陆");

            IHTMLDocument3 htmlDoc = CorssDomainHelper.GetDocumentFromWindow(webBrowser_Main.Document.Window.Frames[0].DomWindow
                                   as IHTMLWindow2);

            IHTMLElementCollection all = ((HTMLDocument)(htmlDoc.documentElement.document)).all;

            mshtml.IHTMLElement appleId = null;
            mshtml.IHTMLElement pwd = null;
            mshtml.IHTMLElement signin = null;

            foreach (mshtml.IHTMLElement element in all)
            {
                System.Diagnostics.Debug.WriteLine(element.id);
                if (element.id == "appleId")
                {
                    appleId = element;
                }


                if (element.id == "pwd")
                {
                    pwd = element;
                }

                if (element.id == "sign-in")
                {
                    signin = element;
                }
            }

            (appleId as IHTMLElement2).focus();
            appleId.innerText = _appleAccountFullInfoList[0].AppleAccount;

            (pwd as IHTMLElement2).focus();
            pwd.setAttribute("value", _appleAccountFullInfoList[0].ApplePassword);

            await Task.Delay(TimeSpan.FromSeconds(1));
            signin.click();
        }


        private void Success()
        {
            SetInfo("成功");
            try
            {
                ApplePersonInfo person = DataHelper.PersonInfoGet();
                DataHelper.AddNewAppleAccountToDB(_appleAccountFullInfoList[0], person);

                SetInfo("添加到数据库成功，移除本账号并序列化到文件");
                _appleAccountFullInfoList.RemoveAt(0);
                IOHelper.SaveAppleAccontToFile(_appleAccountFullInfoList);

                SetInfo("移除本账号并序列化到文件 成功...期待重启");
                Application.Restart();

            }
            catch (Exception ex)
            {
                SetInfo("添加到数据库失败了," + ex.Message);

                if (ex.Message.Contains("已经存在库中"))
                {
                    _appleAccountFullInfoList.RemoveAt(0);
                    IOHelper.SaveAppleAccontToFile(_appleAccountFullInfoList);

                    SetInfo("移除本账号并序列化到文件 成功...期待重启");
                    Application.Restart();
                }
            }
        }


        private async void CheckLogin()
        {
            while (_step == 0)
            {
                try
                {
                    if (webBrowser_Main.Document != null)
                    {
                        IHTMLDocument3 htmlDoc = CorssDomainHelper.GetDocumentFromWindow(webBrowser_Main.Document.Window.Frames[0].DomWindow
                                as IHTMLWindow2);

                        IHTMLElementCollection all = ((HTMLDocument)(htmlDoc.documentElement.document)).all;

                        mshtml.IHTMLElement appleId = null;
                        mshtml.IHTMLElement pwd = null;
                        mshtml.IHTMLElement signin = null;

                        foreach (mshtml.IHTMLElement element in all)
                        {
                            System.Diagnostics.Debug.WriteLine(element.id);
                            if (element.id == "appleId")
                            {
                                appleId = element;
                            }


                            if (element.id == "pwd")
                            {
                                pwd = element;
                            }

                            if (element.id == "sign-in")
                            {
                                signin = element;
                            }
                        }

                        if (appleId != null && pwd != null && signin != null)
                        {
                            SetInfo("检查到可以登陆了！");
                            _step = 1;

                            Login();
                            break;
                        }
                    }
                }
                catch { }

                await Task.Delay(TimeSpan.FromSeconds(3));
            }
        }

        private void button_Do_Click(object sender, EventArgs e)
        {
            SetInfo("开始");

            timer1.Stop();
            this.timer1.Interval = ((int)this.numericUpDown_Second.Value) * 1000;
            timer1.Start();

            Start();
        }

        private void Start()
        {
            SetInfo("从序列化文件中读取账号...");
            _appleAccountFullInfoList = IOHelper.LoadAppleAccount();

            if (_appleAccountFullInfoList == null || _appleAccountFullInfoList.Count == 0)
            {
                SetInfo("没有从序列化文件中读取到账号.从data文件夹下的 AccountSucFile.txt 读取..");
                string accountSucFileFullPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "data", "AccountSucFile.txt");
                if (!File.Exists(accountSucFileFullPath))
                {
                    SetInfo("data文件夹下没有 AccountSucFile.txt ，从外层目录移动.....");

                    IOHelper.MoveAccountSucFileToDataDir(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "注册保存文件[账号----密码----邮箱----邮箱密码----密保----详细信息].txt"));
                }

                _appleAccountFullInfoList = IOHelper.LoadAccountSucFile();
                if (_appleAccountFullInfoList == null || _appleAccountFullInfoList.Count == 0)
                {
                    SetInfo("始终无法读取到账号文件...等待超时后重启...");
                    return;
                }
            }

            SetInfo("读取到账号,序列化到文件中...");
            IOHelper.SaveAppleAccontToFile(_appleAccountFullInfoList);
            File.Delete(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "data", "AccountSucFile.txt"));

            SetInfo("导航到登陆页面...");
            this.webBrowser_Main.Navigate(string.Format(_loginUrl));

            CheckLogin();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            //foreach (HtmlElement item in this.webBrowser_Main.Document.All)
            //{
            //    System.Diagnostics.Debug.WriteLine(item.Id);
            //}

            //HtmlElement appleId = this.webBrowser_Main.Document.All["appleId"];
            //HtmlElement pwd = this.webBrowser_Main.Document.All["pwd"];
            //HtmlElement signin = this.webBrowser_Main.Document.All["sign-in"];

            //appleId.Focus();
            //appleId.InnerText = "a07ash@163.com";

            //pwd.Focus();
            //pwd.InnerText = "Alibabasb123";

            //signin.InvokeMember("click");

            IHTMLDocument3 htmlDoc = CorssDomainHelper.GetDocumentFromWindow(webBrowser_Main.Document.Window.Frames[0].DomWindow
                                    as IHTMLWindow2);

            IHTMLElementCollection all = ((HTMLDocument)(htmlDoc.documentElement.document)).all;

            mshtml.IHTMLElement appleId = null;
            mshtml.IHTMLElement pwd = null;
            mshtml.IHTMLElement signin = null;

            foreach (mshtml.IHTMLElement element in all)
            {
                System.Diagnostics.Debug.WriteLine(element.id);
                if (element.id == "appleId")
                {
                    appleId = element;
                }


                if (element.id == "pwd")
                {
                    pwd = element;
                }

                if (element.id == "sign-in")
                {
                    signin = element;
                }
            }

            //appleId.click();

            (appleId as IHTMLElement2).focus();

            appleId.innerText = "a07ash@163.com";
            //appleId.setAttribute("value", "a07ash@163.com");



            ////appleId.setAttribute("value", "a07ash@163.com");


            //pwd.click();
            (pwd as IHTMLElement2).focus();
            pwd.setAttribute("value", "Alibabasb123");
            //(pwd as IHTMLElement3).FireEvent("onchange");



            //this.webBrowser_Main.Document.InvokeScript("execScript", new object[] { string.Format("window.frames('aid-auth-widget-iFrame').contentWindow.document.all.appleId.innertext='shittt';") });

            //signin.className = "si-button btn  ";

            //System.Diagnostics.Debug.WriteLine(signin.outerHTML);
            //signin.setAttribute("className", "si-button btn  ");
            //signin.setAttribute("aria-disabled", "flase");
            //System.Diagnostics.Debug.WriteLine(signin.outerHTML);

            await Task.Delay(TimeSpan.FromSeconds(1));
            signin.click();
            //appleId.setAttribute("value", "a07ash@163.com");
        }

        public void Init()
        {
            if (INIHelper.ReadIniData("conf", "WriteLog", "1", Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "conf.ini")) == "1")
            {
                this.checkBox_WriteLog.Checked = true;
            }
            else
            {
                this.checkBox_WriteLog.Checked = false;
            }

            if (INIHelper.ReadIniData("conf", "AutoRestart", "0", Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "conf.ini")) == "1")
            {
                this.checkBox_AutoStart.Checked = true;
            }
            else
            {
                this.checkBox_AutoStart.Checked = false;
            }

            numericUpDown_Second.Value = int.Parse(INIHelper.ReadIniData("conf", "WholeTime", "300", Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "conf.ini")));
            
            if(checkBox_AutoStart.Checked)
            {
                button_Do_Click(new object(),new EventArgs());
            }
        }

        private void SetInfo(string msg)
        {
            this.textBox_Info.AppendText(DateTime.Now.ToString() + "," + msg);
            this.textBox_Info.AppendText(Environment.NewLine);

            if (checkBox_WriteLog.Checked)
            {
                Logger.Log(msg);
            }
        }

        private void checkBox_WriteLog_CheckedChanged(object sender, EventArgs e)
        {
            INIHelper.WriteIniData("Conf", "WriteLog", checkBox_WriteLog.Checked ? "1" : "0", Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "conf.ini"));
        }

        private void checkBox_AutoStart_CheckedChanged(object sender, EventArgs e)
        {
            INIHelper.WriteIniData("Conf", "AutoRestart", checkBox_AutoStart.Checked ? "1" : "0", Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "conf.ini"));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //IEHelper.IEclear2();

            DataHelper.PersonInfoGet();
        }

        private void numericUpDown_Second_ValueChanged(object sender, EventArgs e)
        {
            INIHelper.WriteIniData("Conf", "WholeTime", numericUpDown_Second.Value.ToString(), Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "conf.ini"));

        }

        private void button3_Click(object sender, EventArgs e)
        {
            new EmailCreatorForm().ShowDialog();
        }

    }
}
