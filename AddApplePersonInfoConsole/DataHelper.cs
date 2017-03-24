
using DataBaseLib;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using UtilityLib;
using UtilityLib.Models;

namespace AddApplePersonInfoConsole
{
    public class DataHelper
    {

        public static ApplePersonInfo PersonInfoGet(string country = "USA")
        {
            try
            {
                ApplePersonInfo result = new ApplePersonInfo();
                HtmlAgilityPack.HtmlWeb web = new HtmlAgilityPack.HtmlWeb();
                web.OverrideEncoding = Encoding.GetEncoding("gb2312");

                if (country.ToLower() == "china")
                {
                    Random rd = new Random();

                    HtmlAgilityPack.HtmlDocument doc = web.Load("http://alexa.ip138.com/post/");

                    HtmlAgilityPack.HtmlNode node = doc.DocumentNode.SelectSingleNode(@"//div[@id='newAlexa']");
                    HtmlAgilityPack.HtmlNodeCollection provincesNodes = node.SelectNodes(@".//tr/td/a[@target='_blank']");

                    int index_t = rd.Next(provincesNodes.Count);
                    string provinceUrl = "http://alexa.ip138.com/" + provincesNodes[index_t].Attributes["href"].Value.TrimStart('/');

                    result.Province = provincesNodes[index_t].InnerText.Replace("省", "").Replace("市", "").Replace("自治区", "");
                    if (result.Province != "内蒙古" && result.Province != "黑龙江" && result.Province.Length > 2)
                    {
                        result.Province = result.Province.Substring(0, 2);
                    }


                    doc = web.Load(provinceUrl);
                    node = doc.DocumentNode.SelectSingleNode(@"//table[@class='t12']");
                    HtmlAgilityPack.HtmlNodeCollection citiesNodes = node.SelectNodes(@".//td/a/b");

                    index_t = rd.Next(citiesNodes.Count);
                    string regionUrl = provinceUrl.TrimEnd('/') + "/" + citiesNodes[index_t].ParentNode.Attributes["href"].Value.TrimStart('/');

                    result.City = citiesNodes[index_t].InnerText;

                    doc = web.Load(regionUrl);
                    node = doc.DocumentNode.SelectSingleNode(@"//table[@class='t5']");
                    int pageCount = int.Parse(node.SelectSingleNode(@".//span").InnerText.Replace("1/", ""));

                    index_t = (rd.Next(pageCount) + 1);
                    string detailedUrl = (regionUrl.TrimEnd('/') + "/" + index_t.ToString() + ".htm").Replace("1.htm", "");
                    doc = web.Load(detailedUrl);
                    HtmlAgilityPack.HtmlNodeCollection detailedNodes = doc.DocumentNode.SelectNodes(@".//tr[@bgcolor='#ffffff']");

                    index_t = rd.Next(detailedNodes.Count);
                    HtmlAgilityPack.HtmlNode detailedNode = detailedNodes[index_t];

                    result.FirstName = RandomHelper.LastNameGetter();
                    //result.SecondName = RandomHelper.CreateGBChar(1, 2);

                    string nameJsonStr = new WebClient().DownloadString("http://www.jjdzc.com/xm.php?type=1&nid=801&sex=2&hs=&tuijian=1");
                    var t = JsonHelper.DeserializeObjectFromJson<List<NamesJson>>(nameJsonStr);
                    result.SecondName = t[0].name;

                    result.Address = (detailedNode.ChildNodes[0].InnerText + detailedNode.ChildNodes[1].InnerText).Replace(result.City, "") + rd.Next(10, 999).ToString() + "号";
                    result.ZipCode = detailedNode.ChildNodes[2].InnerText;
                    result.Country = "China";
                    result.PhoneNumber1 = detailedNode.ChildNodes[3].InnerText;
                    result.PhoneNumber2 = RandomHelper.GetRandomPhoneNum();

                    if (result.Address.Contains("城市："))
                    {
                        return null;
                    }

                    return result;
                }
                else
                {
                    HtmlAgilityPack.HtmlDocument doc = web.Load("http://us.2kz.net/");

                    HtmlAgilityPack.HtmlNode node = doc.DocumentNode.SelectSingleNode(@"//tr/td");

                    if (node != null)
                    {
                        string[] shits = System.Web.HttpUtility.HtmlDecode(node.InnerHtml.Replace("<br>", "|").Trim()).Split('|');
                        result.FirstName = shits[0].Split('：')[1].Split(' ')[0].Trim();
                        result.SecondName = shits[0].Split('：')[1].Split(' ')[1].Trim();
                        result.Address = shits[1].Split('：')[1].Trim();
                        result.City = shits[2].Split('：')[1].Trim();
                        result.Province = shits[3].Split('：')[1].Trim();
                        result.Country = shits[4].Split('：')[1].Trim();
                        result.ZipCode = shits[5].Split('：')[1].Trim();


                        result.PhoneNumber1 = shits[6].Substring(shits[6].Length - 10, 3);
                        result.PhoneNumber2 = shits[6].Substring(shits[6].Length - 7);

                        return result;
                    }
                    else
                    {
                        throw new Exception("获取美国地址失败");
                    }
                }

                //return null;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static void AddPersonInfoToDB(ApplePersonInfo person)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(SqlHelper.Instance.ConnectionString))
                {
                    conn.Open();
                    string updatetime = DateTime.Now.ToString();
                    string sqlCmd = string.Format("INSERT INTO [dbo].[ApplePersonInfo] ([FirstName],[SecondName],[Address],[City],[Province],[Country],[ZipCode],[PhoneNumber1],[PhoneNumber2],[State],[AddTime],[UpdateTime]) VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}')",
                        person.FirstName, person.SecondName, person.Address, person.City, person.Province, person.Country, person.ZipCode, person.PhoneNumber1, person.PhoneNumber2, "tobebinding", updatetime, updatetime);

                    SqlCommand cmd = new SqlCommand(sqlCmd, conn);
                    cmd.ExecuteNonQuery();

                    cmd.Dispose();
                    conn.Close();
                }
            }
            catch (Exception ex)
            {

            }
        }

        public static List<string> GetDieZipCodeList()
        {
            try
            {
                string sqlCmd = string.Format("SELECT DISTINCT([ZipCode]) FROM [PettoStudio.AppServices].[dbo].[ApplePersonInfo] WHERE [State] = 'zipdie'");

                DataTable infoTable = SqlHelper.Instance.ExecuteDataTable(sqlCmd);

                if (infoTable == null || infoTable.Rows.Count == 0)
                {
                    return null;
                }

                List<string> result = new List<string>();
                for (int i = 0; i < infoTable.Rows.Count; i++)
                {
                    result.Add(infoTable.Rows[i][0].ToString());
                }

                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }

    public class NamesJson
    {
        public string name;
        public double Score;
    }

}
