using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UtilityLib;
using UtilityLib.Models;

namespace IOSAccountActivation
{
    public class IOHelper
    {
        public static List<AppleAccountFullInfo> LoadAppleAccount()
        {
            return JsonHelper.DeserializeObjectFromJsonFile<List<AppleAccountFullInfo>>(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "data", "AppleAccount.json"));
        }

        public static void MoveAccountSucFileToDataDir(string accountSucFile)
        {
            try
            {
                string dir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "data");
                if (!Directory.Exists(dir))
                {
                    Directory.CreateDirectory(dir);
                }

                File.Move(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, accountSucFile), Path.Combine(dir, "AccountSucFile.txt"));
            }
            catch { }
        }

        public static List<AppleAccountFullInfo> LoadAccountSucFile()
        {

            List<AppleAccountFullInfo> result = new List<AppleAccountFullInfo>();
            string accountSucFileFullPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "data", "AccountSucFile.txt");


            if (File.Exists(accountSucFileFullPath))
            {
                using (StreamReader sr = new StreamReader(accountSucFileFullPath, Encoding.Default))
                {
                    string content = sr.ReadToEnd().Trim();

                    string[] contentLines = content.Replace("----", "|").Split('\n');

                    if (contentLines.Length > 0)
                    {
                        foreach (var line in contentLines)
                        {
                            string[] ls = line.Split(new char[] { '|' });
                            if (ls.Length > 10)
                            {
                                result.Add(new AppleAccountFullInfo
                                    {
                                        AppleAccount = ls[0].Trim(),
                                        ApplePassword = ls[1].Trim(),
                                        VerifyMail = ls[2].Trim(),
                                        VerifyPassword = ls[3].Trim(),
                                        FirstQuestion = ls[4].Split(':')[0],
                                        FirstAnswer = ls[4].Split(':')[1],
                                        SecondQuestion = ls[5].Split(':')[0],
                                        SecondAnswer = ls[5].Split(':')[1],
                                        ThirdQuestion = ls[6].Split(':')[0],
                                        ThirdAnswer = ls[6].Split(':')[1],
                                        SecondName = ls[7].Split(':')[1],
                                        FirstName = ls[8].Split(':')[1],
                                        Birthday = ls[9].Split(':')[1],
                                        Country = ls[10].Split(':')[1],
                                    });
                            }
                        }
                    }
                }
            }


            return result;
        }

        public static void SaveAppleAccontToFile(List<AppleAccountFullInfo> list)
        {
            string dir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "data");
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }

            JsonHelper.SerializerToJsonFile(list,
                Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "data", "AppleAccount.json"));
        }
    }
}
