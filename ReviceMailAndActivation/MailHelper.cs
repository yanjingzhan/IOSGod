using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReviceMailAndActivation
{
    public class MailHelper
    {
        public static string GetVerifyMailUrl(string account, string password,string country="USA")
        {
            string imapServer = "imap-mail.outlook.com";

            //account = "pettosryg@outlook.com";
            //password = "wanghuilan215";

            try
            {
                string result = string.Empty;

                AE.Net.Mail.ImapClient ic = new AE.Net.Mail.ImapClient(imapServer, account, password,
                    AE.Net.Mail.AuthMethods.Login, 993, true);
                // Select a mailbox. Case-insensitive
                //ic.SelectMailbox("INBOX");
                //ic.SelectMailbox("Junk");

                //int count = ic.GetMessageCount();
                // Get the first *11* messages. 0 is the first message;
                // and it also includes the 10th message, which is really the eleventh ;)
                // MailMessage represents, well, a message in your mailbox

                //var mm = ic.SearchMessages(AE.Net.Mail.SearchCondition.Undeleted().And(
                //                AE.Net.Mail.SearchCondition.From("Apple"),
                //                country.ToLower() == "china" ? AE.Net.Mail.SearchCondition.Subject("验证您的 Apple ID") : AE.Net.Mail.SearchCondition.Subject("Verify your Apple ID.")), false, false);


                 //using(var imap = new AE.Net.Mail.ImapClient(host, username, password, AE.Net.Mail.ImapClient.AuthMethods.Login, port, isSSL))
                 //{ var msgs = imap.SearchMessages(  SearchCondition.Undeleted().And( SearchCondition.From("david"), SearchCondition.SentSince(new DateTime(2000, 1, 1)) ).Or(SearchCondition.To("andy")) );

                var mm = ic.SearchMessages(AE.Net.Mail.SearchCondition.Undeleted().And(
                                AE.Net.Mail.SearchCondition.From("Apple")),false,false);

                if (mm.Count() > 0)
                {
                    string body = mm[0].Value.Body;
                    string indexStr_1 = country.ToLower() == "china" ? "立即验证" : "Verify now";
                    string indexStr_2 = country.ToLower() == "china" ? "您为何收到此电子邮件" : "Why you received this email";

                    int index_1 = body.IndexOf(indexStr_1);
                    int index_2 = body.IndexOf(indexStr_2);

                    if (index_2 > index_1 && index_1  > 0)
                    {
                        result = body.Substring(index_1 + indexStr_1.Length, index_2 - index_1 - indexStr_1.Length).Trim();
                    }
                }
                else
                {
                    ic.SelectMailbox("Junk");

                    mm = ic.SearchMessages(AE.Net.Mail.SearchCondition.Undeleted().And(
                               AE.Net.Mail.SearchCondition.From("Apple")), false, false);

                    if (mm.Count() > 0)
                    {
                        string body = mm[0].Value.Body;
                        string indexStr_1 = country.ToLower() == "china" ? "立即验证" : "Verify now";
                        string indexStr_2 = country.ToLower() == "china" ? "您为何收到此电子邮件" : "Why you received this email";

                        int index_1 = body.IndexOf(indexStr_1);
                        int index_2 = body.IndexOf(indexStr_2);

                        if (index_2 > index_1 && index_1 > 0)
                        {
                            result = body.Substring(index_1 + indexStr_1.Length, index_2 - index_1 - indexStr_1.Length).Trim();
                        }
                    }
                }

                ic.Dispose();

                return result;
            }
            catch (Exception ex)
            {
                return "ERROR:" + ex.Message;
            }
        }
    }
}
