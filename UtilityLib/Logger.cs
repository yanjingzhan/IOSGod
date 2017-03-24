using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilityLib
{
    public class Logger
    {
        public static void Log(string info)
        {
            string dir = AppDomain.CurrentDomain.BaseDirectory + "log";
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }

            using (StreamWriter sw = new StreamWriter(Path.Combine(dir, DateTime.Now.ToString("yyyy-MM-dd") + ".txt"), true))
            {
                sw.WriteLine(string.Format("{0},{1}", DateTime.Now.ToString(), info));
            }
        }
    }
}
