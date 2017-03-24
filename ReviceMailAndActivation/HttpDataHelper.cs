using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using UtilityLib;
using UtilityLib.Models;

namespace ReviceMailAndActivation
{
    public class HttpDataHelper
    {
        public static AppleAccountFullInfo GetAppleAccountFullInfoAndRefreshStateByState(string state, string newState)
        {
            WebClient wc = new WebClient();

            try
            {
                string dataString = Encoding.GetEncoding("utf-8").GetString(
                    wc.DownloadData(string.Format(
                    "http://ios.pettostudio.net/AccountInfo.aspx?action=GetAppleAccountFullInfoAndRefreshStateByState&state={0}&newstate={1}",
                    state, newState)));

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

    }
}
