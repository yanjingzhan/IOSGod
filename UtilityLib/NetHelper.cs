using DotRas;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace UtilityLib
{
    public class NetHelper
    {
        public static void ReConnectADSL(string ConnectionName, string userName, string password)
        {
            Process p2 = new Process();
            p2.StartInfo.FileName = "RASDIAL";
            p2.StartInfo.Arguments = ConnectionName + " /disconnect";
            p2.StartInfo.CreateNoWindow = true;
            p2.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            p2.Start();
            p2.WaitForExit();

            Thread.Sleep(1000);

            Process p3 = new Process();
            p3.StartInfo.FileName = "RASDIAL";
            p3.StartInfo.Arguments = string.Format("{0} {1} {2}", ConnectionName, userName, password);
            p3.StartInfo.CreateNoWindow = true;
            p3.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            p3.Start();
            p3.WaitForExit();
        }

        public static bool IsVpnConnected()
        {
            return (RasConnection.GetActiveConnections().Count > 0 &&
                RasConnection.GetActiveConnections()[0].GetConnectionStatus().ConnectionState == RasConnectionState.Connected);
        }

        public static bool IsVpnConnected(string vpnName)
        {
            if (RasConnection.GetActiveConnections().Count > 0)
            {
                foreach (var item in RasConnection.GetActiveConnections())
                {
                    return (item.EntryName == vpnName) && item.GetConnectionStatus().ConnectionState == RasConnectionState.Connected;
                }
            }

            return false;
        }

        public static void ConnectVPN(string ConnectionName, string userName, string password, string domain = "")
        {
            Process p3 = new Process();
            p3.StartInfo.FileName = "RASDIAL";
            p3.StartInfo.Arguments = string.IsNullOrWhiteSpace(domain)
                ? string.Format("{0} {1} {2}", ConnectionName, userName, password)
                : string.Format("{0} {1} {2} /DOMAIN:{3}", ConnectionName, userName, password, domain);

            p3.StartInfo.CreateNoWindow = true;
            p3.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            p3.Start();
            p3.WaitForExit();
        }

        /// <summary>
        /// 删除指定名称的VPN
        /// 如果VPN正在运行，一样会在电话本里删除，但是不会断开连接，所以，最好是先断开连接，再进行删除操作
        /// </summary>
        /// <param name="delVpnName"></param>
        public static void TryDeleteVPN(string delVpnName)
        {
            RasDialer dialer = new RasDialer();
            RasPhoneBook allUsersPhoneBook = new RasPhoneBook();
            allUsersPhoneBook.Open(true);
            if (allUsersPhoneBook.Entries.Contains(delVpnName))
            {
                allUsersPhoneBook.Entries.Remove(delVpnName);
            }
        }

        public static bool VPNExits(string vpnName)
        {
            RasDialer dialer = new RasDialer();
            RasPhoneBook allUsersPhoneBook = new RasPhoneBook();
            allUsersPhoneBook.Open(true);
            return (allUsersPhoneBook.Entries.Contains(vpnName));
        }

        public static void DisConnectVPN(string ConnectionName)
        {
            Process p2 = new Process();
            p2.StartInfo.FileName = "RASDIAL";
            p2.StartInfo.Arguments = ConnectionName + " /disconnect";
            p2.StartInfo.CreateNoWindow = true;
            p2.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            p2.Start();
            p2.WaitForExit();
        }

        /// <summary>
        /// 创建或更新一个VPN连接(指定VPN名称，及IP)
        /// </summary>
        public static void CreateOrUpdateVPN(string updateVPNname, string updateVPNip, bool isL2tp = false)
        {
            RasDialer dialer = new RasDialer();
            RasPhoneBook allUsersPhoneBook = new RasPhoneBook();
            allUsersPhoneBook.Open(true);
            // 如果已经该名称的VPN已经存在，则更新这个VPN服务器地址
            if (allUsersPhoneBook.Entries.Contains(updateVPNname))
            {
                allUsersPhoneBook.Entries[updateVPNname].PhoneNumber = updateVPNip;
                if (isL2tp)
                {
                    allUsersPhoneBook.Entries[updateVPNname].VpnStrategy = RasVpnStrategy.L2tpOnly;
                }
                // 不管当前VPN是否连接，服务器地址的更新总能成功，如果正在连接，则需要VPN重启后才能起作用
                allUsersPhoneBook.Entries[updateVPNname].Update();
            }
            // 创建一个新VPN
            else
            {
                RasEntry entry = null;
                if (isL2tp)
                {
                    entry = RasEntry.CreateVpnEntry(updateVPNname, updateVPNip, RasVpnStrategy.L2tpOnly, RasDevice.GetDevices().First(o => o.DeviceType == RasDeviceType.Vpn));
                }
                else
                {
                    entry = RasEntry.CreateVpnEntry(updateVPNname, updateVPNip, RasVpnStrategy.PptpFirst, RasDevice.GetDeviceByName("(PPTP)", RasDeviceType.Vpn));
                }
                allUsersPhoneBook.Entries.Add(entry);

                dialer.EntryName = updateVPNname;
                dialer.PhoneBookPath = RasPhoneBook.GetPhoneBookPath(RasPhoneBookType.AllUsers);
            }
        }

        //创建或更新一个VPN连接(指定VPN名称，及IP)
        public void CreateOrUpdateVPN2(string updateVPNname, string updateVPNip)
        {
            RasDialer dialer = new RasDialer();
            RasPhoneBook allUsersPhoneBook = new RasPhoneBook();
            allUsersPhoneBook.Open();
            // 如果已经该名称的VPN已经存在，则更新这个VPN服务器地址
            if (allUsersPhoneBook.Entries.Contains(updateVPNname))
            {
                allUsersPhoneBook.Entries[updateVPNname].PhoneNumber = updateVPNip;
                // 不管当前VPN是否连接，服务器地址的更新总能成功，如果正在连接，则需要VPN重启后才能起作用
                allUsersPhoneBook.Entries[updateVPNname].Update();
            }
            // 创建一个新VPN
            else
            {
                RasEntry entry = RasEntry.CreateVpnEntry(updateVPNname, updateVPNip, RasVpnStrategy.PptpFirst, RasDevice.GetDeviceByName("(PPTP)", RasDeviceType.Vpn));
                allUsersPhoneBook.Entries.Add(entry);
                dialer.EntryName = updateVPNname;
                dialer.PhoneBookPath = RasPhoneBook.GetPhoneBookPath(RasPhoneBookType.AllUsers);
            }
        }

        //删除指定名称的VPN 如果VPN正在运行，一样会在电话本里删除，但是不会断开连接，所以，最好是先断开连接，再进行删除操作
        public void TryDeleteVPN2(string delVpnName)
        {
            RasDialer dialer = new RasDialer();
            RasPhoneBook allUsersPhoneBook = new RasPhoneBook();
            allUsersPhoneBook.Open();
            if (allUsersPhoneBook.Entries.Contains(delVpnName))
            {
                allUsersPhoneBook.Entries.Remove(delVpnName);
            }
        }

        public static bool PingIpOrDomainName(string strIpOrDName)
        {
            try
            {
                Ping objPingSender = new Ping();
                PingOptions objPinOptions = new PingOptions();
                objPinOptions.DontFragment = true;
                string data = "";
                byte[] buffer = Encoding.UTF8.GetBytes(data);
                int intTimeout = 120;
                PingReply objPinReply = objPingSender.Send(strIpOrDName, intTimeout, buffer, objPinOptions);
                string strInfo = objPinReply.Status.ToString();
                if (strInfo == "Success")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static bool PingIpOrDomainName()
        {
            System.Net.NetworkInformation.Ping ping;
            System.Net.NetworkInformation.PingReply res;
            ping = new System.Net.NetworkInformation.Ping();
            try
            {
                res = ping.Send("www.baidu.com");
                if (res.Status != System.Net.NetworkInformation.IPStatus.Success)
                    return false;
                else
                    return true;
            }
            catch (Exception er)
            {
                return false;
            }
        }

    }
}
