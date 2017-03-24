using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using UtilityLib;
using UtilityLib.Models;

namespace WindowsItunesRegister
{
    public class HttpDataHelper
    {
        public static AppleAccountFullInfo GetAppleAccountFullInfo()
        {
            WebClient wc = new WebClient();

            try
            {
                string dataString = Encoding.GetEncoding("utf-8").GetString(
                    wc.DownloadData(string.Format(
                    "http://ios.pettostudio.net/AccountInfo.aspx?action=getiosfullinfobystate&state={0}",
                    "tobereg")));

                AppleAccountFullInfo result = JsonHelper.DeserializeObjectFromJson<AppleAccountFullInfo>(dataString);
                if (result == null)
                {
                    throw new Exception("没有获取到账号信息");
                }
                else
                {
                    return result;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static void UpdateAccountState(string account, string state)
        {

            WebClient wc = new WebClient();
            try
            {
                string dataString = Encoding.GetEncoding("utf-8").GetString(
                         wc.DownloadData(string.Format(
                         "http://ios.pettostudio.net/AccountInfo.aspx?action=UpdateAccountState&account={0}&state={1}",
                                                            account, state)));

                if (!dataString.Contains("ok"))
                {
                    throw new Exception(dataString);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static AccountInfo GetAccountListByIOSStateAndRefreshState(string iosState, string newIOSState)
        {
            try
            {

                WebClient wc = new WebClient();
                byte[] bResult = wc.DownloadData(
                   string.Format("http://as.pettostudio.net/account.aspx?action=GetAccountListByIOSStateAndRefreshState&count=1&iosstate={0}&newiosstate={1}",
                                 iosState, newIOSState));

                string aiStr = Encoding.UTF8.GetString(bResult);

                List<AccountInfo> accountInfo = JsonHelper.DeserializeObjectFromJson<List<AccountInfo>>(aiStr);

                if (accountInfo == null || accountInfo.Count == 0)
                {
                    throw new Exception("获取账号信息失败," + aiStr);
                }
                else
                {
                    return accountInfo[0];
                }
            }
            catch
            {
                throw;
            }
        }

        public static ApplePersonInfo GetApplePersonInfoAndRefreshState(string state, string newState, string country)
        {
            try
            {

                WebClient wc = new WebClient();
                byte[] bResult = wc.DownloadData(
                   string.Format("http://ios.pettostudio.net/AccountInfo.aspx?action=GetApplePersonInfoAndRefreshState&count=1&state={0}&newState={1}&country={2}",
                                 state, newState, country));

                string aiStr = Encoding.UTF8.GetString(bResult);

                ApplePersonInfo t = JsonHelper.DeserializeObjectFromJson<ApplePersonInfo>(aiStr);

                if (t == null)
                {
                    throw new Exception("获取人物信息失败," + aiStr);
                }
                else
                {
                    return t;
                }
            }
            catch
            {
                throw;
            }
        }

        public static void AddNewAppleAccountToDB(AppleAccountFullInfo appleAccountFullInfo, string state)
        {
            try
            {
                WebClient wc = new WebClient();
                string dataString = Encoding.GetEncoding("utf-8").GetString(
                             wc.DownloadData(string.Format("http://ios.pettostudio.net/AccountInfo.aspx?action=AddNewAppleAccountToDB&jsonstr={0}&state={1}",
                                            JsonHelper.SerializerToJson(appleAccountFullInfo), state)));

                if (!dataString.Contains("ok"))
                {
                    throw new Exception(dataString);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void UpdateApplePersonInfoStateByID(string state, string id)
        {
            try
            {
                WebClient wc = new WebClient();
                string dataString = Encoding.GetEncoding("utf-8").GetString(
                             wc.DownloadData(string.Format("http://ios.pettostudio.net/AccountInfo.aspx?action=UpdateApplePersonInfoStateByID&state={0}&id={1}",
                                            state, id)));

                if (!dataString.Contains("ok"))
                {
                    throw new Exception(dataString);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static string CreatePostHttpResponseNew(string url)
        {
            HttpWebRequest request3 = null;
            //HTTPSQ请求  
            request3 = WebRequest.Create(url) as HttpWebRequest;

            request3.Method = "GET";
            request3.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8";
            request3.UserAgent = "Mozilla/5.0 (Windows NT 6.3; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/49.0.2623.22 Safari/537.36 SE 2.X MetaSr 1.0";
            request3.Referer = "http://192.168.0.1/userRpm/SysRebootRpm.htm";
            request3.Headers.Add("Upgrade-Insecure-Requests", "1");
            request3.Headers.Add("Accept-Encoding", "gzip, deflate, sdch");
            request3.Headers.Add("Accept-Language", "zh-CN,zh;q=0.8");

            request3.KeepAlive = true;

            request3.CookieContainer = new CookieContainer();
            request3.CookieContainer.Add(new Uri("http://192.168.0.1"), new Cookie("Authorization", "Basic%20YWRtaW46dGFuamlhZnU%3D"));
            request3.CookieContainer.Add(new Uri("http://192.168.0.1"), new Cookie("ChgPwdSubTag", ""));

            try
            {
                //return new StreamReader((request.GetResponse() as HttpWebResponse).GetResponseStream(),Encoding.ASCII).ReadToEnd();

                HttpWebResponse response = request3.GetResponse() as HttpWebResponse;
                using (Stream stream2 = response.GetResponseStream())
                {
                    using (StreamReader sr = new StreamReader(stream2))
                    {
                        return sr.ReadToEnd();
                    }
                }
            }
            catch
            {
                return string.Empty;
            }
        }

    }
}
