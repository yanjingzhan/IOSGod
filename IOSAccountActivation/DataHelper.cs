using DataBaseLib;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UtilityLib.Models;

namespace IOSAccountActivation
{
    public class DataHelper
    {
        public static void AddNewAppleAccountToDB(AppleAccountFullInfo appleAccount, ApplePersonInfo person,string state = "normal")
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(SqlHelper.Instance.ConnectionString))
                {
                    conn.Open();

                    string sqlCmd = string.Format("SELECT [ID] FROM [dbo].[AppleAccountFullInfo] WHERE [AppleAccount] = '{0}'", appleAccount.AppleAccount);
                    SqlCommand cmd = new SqlCommand(sqlCmd, conn);

                    var t = cmd.ExecuteScalar();
                    if (t != null)
                    {
                        throw new Exception(string.Format("{0} 已经存在库中!", appleAccount.AppleAccount));
                    }

                    string updatetime = DateTime.Now.ToString();
                    sqlCmd = string.Format("INSERT INTO [dbo].[ApplePersonInfo] ([FirstName],[SecondName],[Address],[City],[Province],[Country],[ZipCode],[PhoneNumber1],[PhoneNumber2],[State],[AddTime],[UpdateTime]) VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}')",
                        person.FirstName, person.SecondName, person.Address, person.City, person.Province, person.Country, person.ZipCode, person.PhoneNumber1, person.PhoneNumber2, "normal", updatetime, updatetime);

                    cmd.CommandText = sqlCmd;
                    cmd.ExecuteNonQuery();

                    sqlCmd = string.Format("SELECT [ID] FROM [dbo].[ApplePersonInfo] WHERE [FirstName] = '{0}' AND [UpdateTime] = '{1}'",
                        person.FirstName, updatetime);

                    cmd.CommandText = sqlCmd;
                    string applePersonInfoID = cmd.ExecuteScalar().ToString();

                    sqlCmd = string.Format("INSERT INTO [dbo].[AppleAccountFullInfo] ([AppleAccount],[ApplePassword],[VPNAccount],[VPNPassword],[IP],[VerifyMail],[VerifyPassword],[FirstQuestion],[FirstAnswer],[SecondQuestion],[SecondAnswer],[ThirdQuestion],[ThirdAnswer],[FirstName],[SecondName],[Birthday],[Country],[ApplePersonInfoID],[State],[AddTime],[UpdateTime]) VALUES " +
                                            "('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}','{16}','{17}','{18}','{19}','{20}')",
                                            appleAccount.AppleAccount,appleAccount.ApplePassword,appleAccount.VPNAccount,appleAccount.VPNPassword,appleAccount.IP,appleAccount.VerifyMail,appleAccount.VerifyPassword,appleAccount.FirstQuestion,appleAccount.FirstAnswer,appleAccount.SecondQuestion,appleAccount.SecondAnswer,appleAccount.ThirdQuestion,appleAccount.ThirdAnswer,
                                            appleAccount.FirstName, appleAccount.SecondName, appleAccount.Birthday, appleAccount.Country, applePersonInfoID, state, updatetime, updatetime);

                    cmd.CommandText = sqlCmd;
                    cmd.ExecuteNonQuery();

                    cmd.Dispose();
                    conn.Close();
                }
            }
            catch
            {
                throw;
            }
        }

        public static ApplePersonInfo PersonInfoGet()
        {
            try
            {
                ApplePersonInfo result = new ApplePersonInfo();
                HtmlAgilityPack.HtmlWeb web = new HtmlAgilityPack.HtmlWeb();
                web.OverrideEncoding = Encoding.GetEncoding("gb2312");
                HtmlAgilityPack.HtmlDocument doc = web.Load("http://us.2kz.net/");

                HtmlAgilityPack.HtmlNode node = doc.DocumentNode.SelectSingleNode(@"//tr/td");

                if(node != null)
                {
                    string[] shits = System.Web.HttpUtility.HtmlDecode(node.InnerHtml.Replace("<br>","|").Trim()).Split('|');
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
                //return null;
            }
            catch (Exception)
            {
                
                throw;
            }
        }
    }
}
