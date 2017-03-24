using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace UtilityLib
{
    public class Win32ApiWrapper
    {
        public const int WM_KEYDOWN = 0x100;
        public const int WM_KEYUP = 0x101;
        public const int VK_CONTROL = 0x11;
        public const int VK_F5 = 0x74;
        public const int KEYEVENTF_KEYUP = 0x2;
        public const int VK_MENU = 0x12;
        public const int WM_SETTEXT = 0xC;
        public const int WM_CLEAR = 0x303;
        public const int BN_CLICKED = 0;
        public const int WM_LBUTTONDOWN = 0x201;
        public const int WM_LBUTTONUP = 0x202;
        public const int WM_CLOSE = 0x10;
        public const int WM_COMMAND = 0x111;
        public const int WM_SYSKEYDOWN = 0x104;
        public const int GW_HWNDNEXT = 2;
        public const int WM_CLICK = 0x00F5;

        private static Dictionary<string, byte> keycode = new Dictionary<string, byte>();

        private delegate bool WNDENUMPROC(IntPtr hWnd, int lParam);

        static Win32ApiWrapper()
        {
            keycode.Add("A", 65);
            keycode.Add("B", 66);
            keycode.Add("C", 67);
            keycode.Add("D", 68);
            keycode.Add("E", 69);
            keycode.Add("F", 70);
            keycode.Add("G", 71);
            keycode.Add("H", 72);
            keycode.Add("I", 73);
            keycode.Add("J", 74);
            keycode.Add("K", 75);
            keycode.Add("L", 76);
            keycode.Add("M", 77);
            keycode.Add("N", 78);
            keycode.Add("O", 79);
            keycode.Add("P", 80);
            keycode.Add("Q", 81);
            keycode.Add("R", 82);
            keycode.Add("S", 83);
            keycode.Add("T", 84);
            keycode.Add("U", 85);
            keycode.Add("V", 86);
            keycode.Add("W", 87);
            keycode.Add("X", 88);
            keycode.Add("Y", 89);
            keycode.Add("Z", 90);
            keycode.Add("0", 48);
            keycode.Add("1", 49);
            keycode.Add("2", 50);
            keycode.Add("3", 51);
            keycode.Add("4", 52);
            keycode.Add("5", 53);
            keycode.Add("6", 54);
            keycode.Add("7", 55);
            keycode.Add("8", 56);
            keycode.Add("9", 57);
            keycode.Add(".", 0x6E);
            keycode.Add("LEFT", 0x25);
            keycode.Add("UP", 0x26);
            keycode.Add("RIGHT", 0x27);
            keycode.Add("DOWN", 0x28);
            keycode.Add("-", 0x6D);
        }

        [DllImport("Gdi32.dll")]
        public extern static int BitBlt(IntPtr hDC, int x, int y, int nWidth, int nHeight, IntPtr hSrcDC, int xSrc, int ySrc, int dwRop);

        [DllImport("user32.dll")]
        public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("user32.dll")]
        public extern static IntPtr GetWindow(IntPtr hWnd, int wCmd);

        [DllImport("user32.dll", EntryPoint = "SendMessage")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, IntPtr wParam, string lParam);

        [DllImport("user32.dll ")]
        public static extern IntPtr FindWindowEx(IntPtr parent, IntPtr childe, string strclass, string FrmText);

        [DllImport("user32.DLL", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        public static extern bool SetForegroundWindow(IntPtr hWnd);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        internal static extern int GetWindowText(IntPtr hWnd, StringBuilder lpString, int nMaxCount);

        [DllImport("user32.dll")]
        private static extern int GetWindowTextW(IntPtr hWnd, [MarshalAs(UnmanagedType.LPWStr)]StringBuilder lpString, int nMaxCount);

        [DllImport("user32.dll")]
        private static extern bool EnumWindows(WNDENUMPROC lpEnumFunc, int lParam);

        [DllImport("user32.dll")]
        private static extern int GetClassNameW(IntPtr hWnd, [MarshalAs(UnmanagedType.LPWStr)]StringBuilder lpString, int nMaxCount);

        [DllImport("user32.dll")]
        private static extern bool EnumChildWindows(IntPtr hWndParent, WNDENUMPROC lpEnumFunc, int lParam);

        [DllImport("user32.dll", EntryPoint = "SendMessage")]
        public static extern int SendTxtMessage(int hWnd,
            // handle to destination window                 
            int Msg, // message                 
            int wParam, // first message parameter                 
            char[] lParam             // int  lParam // second message parameter             
            );

        [DllImport("user32.dll", EntryPoint = "SendMessage")]
        public static extern int SendMessage(
            int hWnd, // handle to destination window                 
            int Msg, // message                 
            int wParam, // first message parameter                  
            int lParam // second message parameter           
            );

        [DllImport("user32.dll")]
        public static extern void keybd_event(byte bVk, byte bScan, uint dwFlags, int dwExtraInfo);


        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        static public extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int x, int y, int Width, int Height, uint flags);

        [DllImport("user32.dll", EntryPoint = "SetWindowPos")]
        public static extern bool SetWindowPos(IntPtr hWnd, int HWND_TOPMOST, int x, int y, int Width, int Height, uint flags);


        [DllImport("user32.dll", CharSet = CharSet.Auto, EntryPoint = "PostMessage")]
        public static extern IntPtr PostMessage(IntPtr hwndParent, int hwndChildAfter, IntPtr wParam, string lpszWindow);



        /// <summary>  
        /// 获取桌面所有的窗口  
        /// </summary>  
        /// <returns></returns>  
        public static WindowInfo[] GetAllDesktopWindows()
        {
            List<WindowInfo> wndList = new List<WindowInfo>();
            EnumWindows(delegate(IntPtr hWnd, int lParam)
            {
                WindowInfo wnd = new WindowInfo();
                StringBuilder sb = new StringBuilder(256);
                wnd.hWnd = hWnd;
                GetWindowTextW(hWnd, sb, sb.Capacity);
                wnd.SzWindowName = sb.ToString();
                GetClassNameW(hWnd, sb, sb.Capacity);
                wnd.SzClassName = sb.ToString();
                wndList.Add(wnd);
                return true;
            }, 0);

            return wndList.ToArray();
        }


        public static List<WindowInfo> GetWindowByParentHwndAndClassName(IntPtr parentHwnd, string className)
        {
            List<WindowInfo> wndList = new List<WindowInfo>();
            EnumChildWindows(parentHwnd, delegate(IntPtr hWnd, int lParam)
            {
                WindowInfo wnd = new WindowInfo();
                StringBuilder sb = new StringBuilder(256);
                wnd.hWnd = hWnd;
                GetWindowTextW(hWnd, sb, sb.Capacity);
                wnd.SzWindowName = sb.ToString();
                GetClassNameW(hWnd, sb, sb.Capacity);
                wnd.SzClassName = sb.ToString();
                wndList.Add(wnd);
                return true;
            }, 0);
            return wndList.Where(o => o.SzClassName == className).ToList();
        }



        public static List<WindowInfo> GetChildWindowsByParentHwnd(IntPtr parentHwnd)
        {
            List<WindowInfo> childWndList = new List<WindowInfo>();
            EnumChildWindows(parentHwnd, delegate(IntPtr hWnd, int lParam)
            {
                WindowInfo wnd = new WindowInfo();
                StringBuilder sb = new StringBuilder(256);
                wnd.hWnd = hWnd;
                GetWindowTextW(hWnd, sb, sb.Capacity);
                wnd.SzWindowName = sb.ToString();
                GetClassNameW(hWnd, sb, sb.Capacity);
                wnd.SzClassName = sb.ToString();
                childWndList.Add(wnd);
                return true;
            }, 0);

            return childWndList;
        }



    }
}
