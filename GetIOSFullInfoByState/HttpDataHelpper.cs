using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace GetIOSFullInfoByState
{
    public class HttpDataHelpper
    {
        public static string GetIOSFullInfoByStateStr()
        {
            WebClient wc = new WebClient();

            try
            {
                string dataString = Encoding.GetEncoding("utf-8").GetString(
                    wc.DownloadData(string.Format(
                    "http://ios.pettostudio.net/AccountInfo.aspx?action=GetIOSFullInfoByStateStr&state={0}",
                    "success")));


                if (string.IsNullOrWhiteSpace(dataString) || dataString.Split(',').Length < 20)
                {
                    throw new Exception("没有获取到账号信息");
                }
                else
                {
                    return dataString;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static void DownloadGameLogo(string url)
        {
            WebClient wc = new WebClient();

            try
            {
                wc.DownloadFile(url, AppDomain.CurrentDomain.BaseDirectory + "gamelogo.bmp");

            }
            catch (Exception ex)
            {
                throw new Exception("下载gamelogo失败," + ex.Message);
            }
        }
    }
}
