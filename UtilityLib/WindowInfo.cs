using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilityLib
{
    public class WindowInfo
    {
        public IntPtr hWnd { get; set; }
        public string SzWindowName { get; set; }
        public string SzClassName { get; set; }
    }  
}
