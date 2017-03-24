using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UtilityLib
{
    public class WinAPI
    {
        #region WinodwsAPI
        [DllImport("user32.dll", EntryPoint = "FindWindow")]
        public static extern IntPtr FindWindow(string IpClassName, string IpWindowName);

        [DllImport("user32.dll", EntryPoint = "FindWindowEx")]
        private static extern IntPtr FindWindowEx(IntPtr hwndParent, IntPtr hwndChildAfter, string lpszClass, string lpszWindow);

        [DllImport("user32.dll", EntryPoint = "SendMessage")]
        private static extern int SendMessage(IntPtr hWnd, int Msg, IntPtr wParam, string lParam);

        [DllImport("User32.DLL")]
        public static extern int SendMessage(IntPtr hWnd, uint Msg, int wParam, int lParam);

        [DllImport("user32.dll", EntryPoint = "PostMessageA", SetLastError = true)]
        public static extern int PostMessage(IntPtr hWnd, int Msg, Keys wParam, int lParam);

        public static int IDM_VIEWSOURCE = 2139;
        public static uint WM_COMMAND = 0x0111;

        [DllImport("user32.dll", EntryPoint = "GetParent")]
        public static extern IntPtr GetParent(IntPtr hWnd);

        [DllImport("user32.dll", EntryPoint = "GetCursorPos")]
        public static extern bool GetCursorPos(out Point pt);

        [DllImport("user32.dll", EntryPoint = "WindowFromPoint", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern IntPtr WindowFromPoint(Point pt);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int GetClassName(IntPtr hWnd, StringBuilder lpClassName, int nMaxCount);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int GetWindowText(IntPtr hWnd, [Out, MarshalAs(UnmanagedType.LPTStr)] StringBuilder lpString, int nMaxCount);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int GetWindowRect(IntPtr hwnd, ref Rectangle rc);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int GetClientRect(IntPtr hwnd, ref Rectangle rc);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int MoveWindow(IntPtr hwnd, int x, int y, int nWidth, int nHeight, bool bRepaint);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true, ExactSpelling = true)]
        public static extern int ScreenToClient(IntPtr hWnd, ref Rectangle rect);
        #endregion

        #region 封装API方法
        /// <summary>  
        /// 找到句柄  
        /// </summary>  
        /// <param name="IpClassName">类名</param>  
        /// <returns></returns>  
        public static IntPtr GetHandle(string IpClassName)
        {
            return FindWindow(IpClassName, null);
        }

        /// <summary>  
        /// 找到句柄  
        /// </summary>  
        /// <param name="p">坐标</param>  
        /// <returns></returns>  
        public static IntPtr GetHandle(Point p)
        {
            return WindowFromPoint(p);
        }

        //鼠标位置的坐标  
        public static Point GetCursorPosPoint()
        {
            Point p = new Point();
            if (GetCursorPos(out p))
            {
                return p;
            }
            return default(Point);
        }

        /// <summary>  
        /// 子窗口句柄  
        /// </summary>  
        /// <param name="hwndParent">父窗口句柄</param>  
        /// <param name="hwndChildAfter">前一个同目录级同名窗口句柄</param>  
        /// <param name="lpszClass">类名</param>  
        /// <returns></returns>  
        public static IntPtr GetChildHandle(IntPtr hwndParent, IntPtr hwndChildAfter, string lpszClass)
        {
            return FindWindowEx(hwndParent, hwndChildAfter, lpszClass, null);
        }

        /// <summary>  
        /// 全部子窗口句柄  
        /// </summary>  
        /// <param name="hwndParent">父窗口句柄</param>  
        /// <param name="className">类名</param>  
        /// <returns></returns>  
        public static List<IntPtr> GetChildHandles(IntPtr hwndParent, string className)
        {
            List<IntPtr> resultList = new List<IntPtr>();
            for (IntPtr hwndClient = GetChildHandle(hwndParent, IntPtr.Zero, className); hwndClient != IntPtr.Zero; hwndClient = GetChildHandle(hwndParent, hwndClient, className))
            {
                resultList.Add(hwndClient);
            }

            return resultList;
        }

        /// <summary>  
        /// 给窗口发送内容  
        /// </summary>  
        /// <param name="hWnd">句柄</param>  
        /// <param name="lParam">要发送的内容</param>  
        public static void SetText(IntPtr hWnd, string lParam)
        {
            SendMessage(hWnd, WM_SETTEXT, IntPtr.Zero, lParam);
        }
        private const int WM_SETTEXT = 0x000C;

        /// <summary>  
        /// 获得窗口内容或标题  
        /// </summary>  
        /// <param name="hWnd">句柄</param>  
        /// <returns></returns>  
        public static string GetText(IntPtr hWnd)
        {
            StringBuilder result = new StringBuilder(128);
            GetWindowText(hWnd, result, result.Capacity);
            return result.ToString();
        }

        /// <summary>  
        /// 找类名  
        /// </summary>  
        /// <param name="hWnd">句柄</param>  
        /// <returns></returns>  
        public static string GetClassName(IntPtr hWnd)
        {
            StringBuilder lpClassName = new StringBuilder(128);
            if (GetClassName(hWnd, lpClassName, lpClassName.Capacity) == 0)
            {
                throw new Exception("not found IntPtr!");
            }
            return lpClassName.ToString();
        }

        /// <summary>  
        /// 窗口在屏幕位置  
        /// </summary>  
        /// <param name="hWnd">句柄</param>  
        /// <returns></returns>  
        public static Rectangle GetWindowRect(IntPtr hWnd)
        {
            Rectangle result = default(Rectangle);
            GetWindowRect(hWnd, ref result);
            return result;
        }

        /// <summary>  
        /// 窗口相对屏幕位置转换成父窗口位置  
        /// </summary>  
        /// <param name="hWnd"></param>  
        /// <param name="rect"></param>  
        /// <returns></returns>  
        public static Rectangle ScreenToClient(IntPtr hWnd, Rectangle rect)
        {
            Rectangle result = rect;
            ScreenToClient(hWnd, ref result);
            return result;
        }

        /// <summary>  
        /// 窗口大小  
        /// </summary>  
        /// <param name="hWnd"></param>  
        /// <returns></returns>  
        public static Rectangle GetClientRect(IntPtr hWnd)
        {
            Rectangle result = default(Rectangle);
            GetClientRect(hWnd, ref result);
            return result;
        }

        public static void GetInfo(IntPtr vHandle)
        {
            SendMessage(vHandle, WM_COMMAND, IDM_VIEWSOURCE, (int)vHandle);
        }

        #endregion

    }
}


