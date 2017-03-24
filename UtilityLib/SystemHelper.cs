using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace UtilityLib
{
    public class SystemHelper
    {

        [DllImport("kernel32.dll", EntryPoint = "SetComputerNameW")]
        public static extern int SetComputerName(
             string lpComputerName);
        [MarshalAs(UnmanagedType.LPStr)]
        string lpComputerName;

        [DllImport("kernel32.dll", EntryPoint = "SetComputerNameEx")]
        public static extern int apiSetComputerNameEx(int type, string lpComputerName);
        public string GetComputerName()
        {
            try
            {
                return System.Environment.GetEnvironmentVariable("ComputerName");
            }
            catch
            {
                return "unknow";
            }
        }

        public static void SetComputerName2(string name)
        {
            apiSetComputerNameEx(5, name);
        }
    }
}
