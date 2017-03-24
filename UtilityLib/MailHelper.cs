using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace UtilityLib
{
    /// <summary>
    /// 邮件发送类
    /// </summary>
    public class MailHelper
    {
        private static MailHelper _mail;
        public static MailHelper Instance
        {
            get
            {
                if (_mail == null)
                {
                    _mail = new MailHelper();
                }

                return _mail;
            }
        }

        MailMessage mailMessage = new MailMessage();
        /// <summary>
        /// 邮件
        /// </summary>
        /// <param name="mailTo">收件人Email地址</param>
        /// <param name="mailSubject">邮件标题</param>
        /// <param name="mailBody">邮件内容</param>
        public MailHelper(ArrayList mailTo, string mailSubject, string mailBody)
        {
            mailMessage.From = new MailAddress("ekautzm@126.com", "Good Man;");
            for (int i = 0; i < mailTo.Count; i++)
            {
                mailMessage.To.Add(mailTo[i].ToString());
            }
            mailMessage.IsBodyHtml = true;
            mailMessage.BodyEncoding = System.Text.Encoding.Default;
            mailMessage.Subject = mailSubject;
            mailMessage.Body = mailBody;
        }
        /// <summary>
        /// 邮件
        /// </summary>
        /// <param name="mailTo">收件人Email地址</param>
        /// <param name="mailSubject">邮件标题</param>
        /// <param name="mailBody">邮件内容</param>
        public MailHelper(string mailTo, string mailSubject, string mailBody)
        {
            mailMessage.From = new MailAddress("ekautzm@126.com", "Good Man");
            mailMessage.To.Add(mailTo);
            mailMessage.IsBodyHtml = true;
            mailMessage.BodyEncoding = System.Text.Encoding.Default;
            mailMessage.Subject = mailSubject;
            mailMessage.Body = mailBody;
        }

        public MailHelper()
        {
            mailMessage.From = new MailAddress("ekautzm@126.com", "Good Man");

            string mailFile = AppDomain.CurrentDomain.BaseDirectory + "mail.txt";
            if (File.Exists(mailFile))
            {
                using (StreamReader sr = new StreamReader(mailFile))
                {
                    string[] mailToList = sr.ReadToEnd().Split(';');

                    if (mailFile.Length > 0)
                    {
                        foreach (var m in mailToList)
                        {
                            if (m.Contains("@"))
                            {
                                mailMessage.To.Add(m);
                            }
                        }
                    }
                }
            }

            if (mailMessage.To.Count == 0)
            {
                mailMessage.To.Add("ekautzm@126.com");
            }

            mailMessage.IsBodyHtml = false;
            mailMessage.BodyEncoding = System.Text.Encoding.Default;
        }

        /// <summary>
        /// 发送邮件
        /// </summary>
        /// <returns></returns>
        public bool Send(string subject, string mainBody)
        {
            mailMessage.Subject = subject;
            mailMessage.Body = mainBody;

            SmtpClient smtpClient = new SmtpClient();
            smtpClient.Host = "smtp.126.com";
            smtpClient.Credentials = new System.Net.NetworkCredential("ekautzm", "heieish31d;");

            try
            {
                smtpClient.Send(this.mailMessage);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
