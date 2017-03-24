using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using UtilityLib;
using UtilityLib.Models;

namespace IOSAccountCountryChanger
{
    public class HttpDataHelper
    {

        public static AppleAccountFullInfo GetAppAccountByChangeCountryState(string country, string newcountry)
        {
            WebClient wc = new WebClient();

            try
            {
                string dataString = Encoding.GetEncoding("utf-8").GetString(
                    wc.DownloadData(string.Format(
                    "http://ios.pettostudio.net/AccountInfo.aspx?action=getappaccountbychangecountrystate&country={0}&newcountry={1}&state=success&oldchangecountrystate=null&newchangecountrystate=changing",
                    country,newcountry)));

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

        public static void UpdateCountryAndChangeCountryStateByID(string newCountry,string changecountrystate, string applePersonInfoID, string id)
        {

            WebClient wc = new WebClient();
            try
            {
                string dataString = Encoding.GetEncoding("utf-8").GetString(
                         wc.DownloadData(string.Format(
                         "http://ios.pettostudio.net/AccountInfo.aspx?action=updatecountryandchangecountrystatebyid&country={0}&changecountrystate={1}&applepersoninfoid={2}&id={3}",
                                                            newCountry, changecountrystate, applePersonInfoID, id)));

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
