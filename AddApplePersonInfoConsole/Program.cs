using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using UtilityLib;
using UtilityLib.Models;

namespace AddApplePersonInfoConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                try
                {
                    string country = ConfigurationManager.AppSettings["Country"] ?? "USA";

                    List<string> dieZipList = DataHelper.GetDieZipCodeList();
                    ApplePersonInfo person = DataHelper.PersonInfoGet(country);

                    if (dieZipList != null && dieZipList.Count > 0 && dieZipList.Contains(person.ZipCode))
                    {
                        ShowInfo(person.ZipCode + " 在DieZip列表中，continue...");
                        continue;
                    }
                    DataHelper.AddPersonInfoToDB(person);

                    string intervalStr = ConfigurationManager.AppSettings["TimeInterval"];
                    int interval = 10;
                    int.TryParse(intervalStr, out interval);

                    //_timer.Interval = string.IsNullOrWhiteSpace(interval) ? 10 * 60 * 1000 : (double.TryParse(interval) * 60 * 1000);
                    //_timer.Elapsed +=_timer_Elapsed;

                    ShowInfo("添加成功");

                    ShowInfo(string.Format("睡{0} 分钟", interval));
                    Thread.Sleep(TimeSpan.FromMinutes(interval));
                }
                catch (Exception ex)
                {
                    ShowInfo("添加失败," + ex.Message);
                }
            }
        }

        private static void ShowInfo(string info)
        {
            Console.WriteLine("{0},{1}", DateTime.Now.ToString(), info);
            Logger.Log(string.Format("{0},{1}", DateTime.Now.ToString(), info));
        }
    }
}
