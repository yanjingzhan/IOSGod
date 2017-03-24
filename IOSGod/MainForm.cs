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
using System.Runtime.InteropServices;
using UtilityLib;

namespace IOSGod
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
            Success
        }

        private string _regUrl = "https://appleid.apple.com/account#!&page=create";

        public MainForm()
        {
            InitializeComponent();

            //UserAgentHelper.ChangeUserAgent("Mozilla/5.0 (Linux; Android 4.1.1; Nexus 7 Build/JRO03D) AppleWebKit/535.19 (KHTML, like Gecko) Chrome/18.0.1025.166 Safari/535.19");

            this.Load += MainForm_Load;
            this.webBrowser_Main.DocumentCompleted += webBrowser_Main_DocumentCompleted;
        }

        void webBrowser_Main_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            this.textBox_CurrentUrl.Text = e.Url.ToString();
            UrlState state = VerfyUrl();

        }

        private UrlState VerfyUrl()
        {
            return UrlState.NotComplate;
        }


        void MainForm_Load(object sender, EventArgs e)
        {
            Init();
        }



        private void button_Do_Click(object sender, EventArgs e)
        {
            SetInfo("开始");
            Start();
        }

        private void Start()
        {
            this.webBrowser_Main.Navigate(_regUrl);
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

        private async void button1_Click(object sender, EventArgs e)
        {
            HtmlElement email = GetElementByTagAndType("input", "email");
            HtmlElement password = GetElementByTagAndType("input", "password");
            HtmlElement password2 = GetElementByTagAndType("input", "password", 1);

            HtmlElement lastName = GetElementByClassName("generic-input-field form-cell form-textbox form-textbox-text form-field last-name form-control field ");
            HtmlElement firstName = GetElementByClassName("generic-input-field form-cell form-textbox form-textbox-text form-field first-name form-control field ");

            HtmlElement date = this.webBrowser_Main.Document.All["date"];

            HtmlElement firstQuestion = GetElementByClassName("generic-input-field form-cell form-dropdown content-input content-dropdown noarrow-dropdown form-control", 0);
            HtmlElement SecondQuestion = GetElementByClassName("generic-input-field form-cell form-dropdown content-input content-dropdown noarrow-dropdown form-control", 1);
            HtmlElement thirdQuestion = GetElementByClassName("generic-input-field form-cell form-dropdown content-input content-dropdown noarrow-dropdown form-control", 2);

            email.Focus();
            //email.InvokeMember("click");
            email.InnerText = "pettosryg1@126.com";
            //email.SetAttribute("value", "pettosryg1@126.com");

            password.Focus();
            //password.InvokeMember("click");
            password.InnerText = "Alibabasb123";
            //password.SetAttribute("value", "Alibabasb123");

            password2.Focus();
            //password2.InvokeMember("click");
            password2.InnerText = "Alibabasb123";
            //password2.SetAttribute("value", "Alibabasb123");


            lastName.Focus();
            lastName.SetAttribute("value", "shit");


            firstName.Focus();
            firstName.SetAttribute("value", "shit");


            date.Focus();
            Clipboard.SetText("19910101");

            keybd_event(Convert.ToInt32(System.Windows.Forms.Keys.ControlKey), 0, 0, 0);
            keybd_event(Convert.ToInt32(System.Windows.Forms.Keys.V), 0, 0, 0);
            await Task.Delay(TimeSpan.FromSeconds(0.5));
            keybd_event(Convert.ToInt32(System.Windows.Forms.Keys.V), 0, 0, 0);
            await Task.Delay(TimeSpan.FromSeconds(0.5));
            keybd_event(Convert.ToInt32(System.Windows.Forms.Keys.V), 0, 0, 0);
            await Task.Delay(TimeSpan.FromSeconds(0.5));
            keybd_event(Convert.ToInt32(System.Windows.Forms.Keys.ControlKey), 0, KEYEVENTF_KEYUP, 0);
            //SendKeys.SendWait("{Ctrl}+{V}");

            //await Task.Delay(TimeSpan.FromSeconds(0.5));

            //SendKeys.SendWait("1998");
            //await Task.Delay(TimeSpan.FromSeconds(0.1));

            ////SendKeys.SendWait("9");
            ////await Task.Delay(TimeSpan.FromSeconds(0.1));

            ////SendKeys.SendWait("8");
            ////await Task.Delay(TimeSpan.FromSeconds(0.1));

            ////SendKeys.SendWait("8");
            //await Task.Delay(TimeSpan.FromSeconds(1.5));

            //SendKeys.SendWait("01");
            //await Task.Delay(TimeSpan.FromSeconds(0.5));

            ////SendKeys.SendWait("1");
            //await Task.Delay(TimeSpan.FromSeconds(1.5));

            //SendKeys.SendWait("01");
            //await Task.Delay(TimeSpan.FromSeconds(0.5));

            ////SendKeys.SendWait("1");
            //await Task.Delay(TimeSpan.FromSeconds(0.5));

            //date.InnerText = "1988-01-2";

            //this.webBrowser_Main.Document.InvokeScript("execScript", new object[] { string.Format("document.all.date.innerText='19911122';") });
            //this.webBrowser_Main.Document.InvokeScript("execScript", new object[] { "document.all.date.fireEvent('onkeydown')" });
            //date.SetAttribute("value", "1988/11/10");

            //HtmlElement shit = date.Parent;
            //shit.SetAttribute("value", "2016-01-04");

            await Task.Delay(TimeSpan.FromSeconds(0.5));
            //firstName.Focus();

            //firstQuestion.Focus();
            //firstQuestion.SetAttribute("value", "137");

        }

        private HtmlElement GetElementByTagAndType(string tag, string type, int index = 0)
        {
            HtmlElementCollection alls = this.webBrowser_Main.Document.GetElementsByTagName(tag);

            int i = 0;
            foreach (HtmlElement a in alls)
            {
                System.Diagnostics.Debug.WriteLine(a.Id + ":" + a.GetAttribute("type"));
                if (a.GetAttribute("type") == type)
                {
                    if (i == index)
                    {
                        return a;
                    }
                    i++;
                }
            }

            return null;
        }

        private HtmlElement GetElementByClassName(string className, int index = 0)
        {
            int i = 0;
            foreach (HtmlElement item in this.webBrowser_Main.Document.All)
            {
                if (item.GetAttribute("className") == className)
                {
                    if (i == index)
                    {
                        return item;
                    }
                    i++;
                }
            }
            return null;
        }

        public static int KEYEVENTF_KEYUP = 0x2;
        [DllImport("user32.dll")]
        public static extern void keybd_event(int bVk, byte bScan, int dwFlags, int dwExtraInfo);

        private void button_MailCreator_Click(object sender, EventArgs e)
        {
            new EmailCreatorForm().ShowDialog();
        }

        //static void Main(string[] args)
        //{

        //    keybd_event(Convert.ToInt32(System.Windows.Forms.Keys.ControlKey), 0, 0, 0);
        //    keybd_event(Convert.ToInt32(System.Windows.Forms.Keys.C), 0, 0, 0);

        //}
    }
}
