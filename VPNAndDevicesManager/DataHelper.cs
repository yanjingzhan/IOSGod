using DataBaseLib;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UtilityLib.Models;

namespace VPNAndDevicesManager
{
    public class DataHelper
    {
        public static void AddVpnInfo(VPNInfo vpnInfo)
        {
            try
            {
                string sqlCmd_Get = string.Format("SELECT COUNT(*) FROM [VPNInfo] WHERE [VPNAccount] = '{0}' AND [IP] = '{1}'", vpnInfo.VPNAccount, vpnInfo.IP);
                object count = SqlHelper.Instance.ExecuteScalar(sqlCmd_Get);
                if (Convert.ToInt32(count) == 0)
                {
                    string sqlCmd_Insert =
                               string.Format("INSERT INTO [dbo].[VPNInfo] ([VPNAccount],[VPNPassword],[Seller],[ManageURL],[ManageName],[ManagePassword],[BuyTime],[DieTime],[UpdateTime],[State],[IP],[ContainQQCount],[Country]) VALUES " +
                               "('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}')",
                               vpnInfo.VPNAccount, vpnInfo.VPNPassword, vpnInfo.Seller, vpnInfo.ManageURL, vpnInfo.ManageName, vpnInfo.ManagePassword,
                               vpnInfo.BuyTime, vpnInfo.DieTime, DateTime.Now.ToString(), vpnInfo.State, vpnInfo.IP, "0", vpnInfo.Country);
                    SqlHelper.Instance.ExecuteCommand(sqlCmd_Insert);

                }
                else
                {
                    throw new Exception(vpnInfo.VPNAccount + "，已经在数据库中了");
                }
            }
            catch
            {
                throw;
            }
        }

        public static void EditVpnInfo(VPNInfo vpnInfo)
        {
            try
            {
                string sqlCmd_Get = string.Format("UPDATE [dbo].[VPNInfo] SET [VPNAccount] = '{0}',[VPNPassword] = '{1}',[Seller] = '{2}',[BuyTime] = '{3}',[DieTime] = '{4}',[UpdateTime] = '{5}',[IP] = '{6}',[Country] = '{7}' WHERE [ID] = {8}",
                    vpnInfo.VPNAccount, vpnInfo.VPNPassword, vpnInfo.Seller, vpnInfo.BuyTime, vpnInfo.DieTime, DateTime.Now, vpnInfo.IP, vpnInfo.Country, vpnInfo.ID);

                SqlHelper.Instance.ExecuteCommand(sqlCmd_Get);

            }
            catch
            {
                throw;
            }
        }

        public static void DeleteVPNInfo(string vpnInfoID)
        {
            try
            {
                string sqlCmd_Get = string.Format("DELETE FROM [dbo].[VPNInfo] WHERE [ID] = {0}",
                    vpnInfoID);

                SqlHelper.Instance.ExecuteCommand(sqlCmd_Get);

                sqlCmd_Get = string.Format("DELETE FROM [dbo].[IPhoneAndVPN] WHERE [VPNID] = {0}",
                    vpnInfoID);

                SqlHelper.Instance.ExecuteCommand(sqlCmd_Get);

                sqlCmd_Get = string.Format("DELETE FROM [dbo].[ComputerAndVPN] WHERE [VPNID] = {0}",
                    vpnInfoID);

                SqlHelper.Instance.ExecuteCommand(sqlCmd_Get);

            }
            catch
            {
                throw;
            }
        }

        public static List<VPNInfo> GetVPNInfo(bool onlyFreeVPN, string state)
        {
            try
            {
                string sqlCmd = string.Format("SELECT * FROM [VPNInfo] WHERE [State] = '{0}'", state);
                if (onlyFreeVPN)
                {
                    sqlCmd = string.Format("SELECT * FROM [VPNInfo] a WHERE a.[State]='{0}' AND a.ID NOT IN (SELECT [VPNID] FROM IPhoneAndVPN)", state);
                }


                DataTable infoTable = SqlHelper.Instance.ExecuteDataTable(sqlCmd);

                if (infoTable == null || infoTable.Rows.Count == 0)
                {
                    throw new Exception("没有可用VPN");
                }

                List<VPNInfo> result = new List<VPNInfo>();
                for (int i = 0; i < infoTable.Rows.Count; i++)
                {
                    VPNInfo t = new VPNInfo
                    {
                        VPNAccount = infoTable.Rows[i]["VPNAccount"].ToString(),
                        VPNPassword = infoTable.Rows[i]["VPNPassword"].ToString(),
                        BuyTime = infoTable.Rows[i]["BuyTime"].ToString(),
                        DieTime = infoTable.Rows[i]["DieTime"].ToString(),
                        IP = infoTable.Rows[i]["IP"].ToString(),
                        ID = int.Parse(infoTable.Rows[i]["ID"].ToString()),
                        State = infoTable.Rows[i]["State"].ToString(),
                        UpdateTime = infoTable.Rows[i]["UpdateTime"].ToString(),
                        Country = infoTable.Rows[i]["Country"].ToString().Trim(),
                        Seller = infoTable.Rows[i]["Country"].ToString().Trim(),
                    };

                    result.Add(t);
                }

                return result;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static DataTable GetVPNINfoDataTable(bool onlyFreeVPN, string state)
        {
            try
            {
                string sqlCmd = string.Format("SELECT * FROM (SELECT * FROM [VPNInfo] A left JOIN (SELECT com.ComputerModel,cav.VPNID FROM [ComputerAndVPN] cav,[ComputerDeviceInfo] com WHERE com.ID = cav.ComputerID) B ON A.ID=B.VPNID WHERE A.State='{0}') AS C left JOIN (SELECT M.ID,N.SerialNumber FROM [VPNInfo] M left JOIN (SELECT iphone.SerialNumber,iav.VPNID FROM [IPhoneAndVPN] iav,[IPhoneDeviceInfo] iphone WHERE iphone.ID = iav.IPhoneID) N ON M.ID=N.VPNID WHERE M.State='{0}') O ON O.ID=C.ID", state);
                if (onlyFreeVPN)
                {
                    sqlCmd = string.Format("SELECT * FROM [VPNInfo] a WHERE a.[State]='{0}' AND a.ID NOT IN (SELECT [VPNID] FROM ComputerAndVPN) AND a.ID NOT IN (SELECT [VPNID] FROM IPhoneAndVPN)", state);
                }


                DataTable infoTable = SqlHelper.Instance.ExecuteDataTable(sqlCmd);

                List<DataRow> dataRowList = new List<DataRow>();

                for (int i = 0; i < infoTable.Rows.Count; i++)
                {
                    for (int j = i + 1; j < infoTable.Rows.Count; j++)
                    {
                        if (infoTable.Rows[j]["ID"].ToString() == infoTable.Rows[i]["ID"].ToString())
                        {
                            if (infoTable.Rows[j]["ComputerModel"].ToString() != infoTable.Rows[i]["ComputerModel"].ToString())
                            {
                                infoTable.Rows[i]["ComputerModel"] = infoTable.Rows[i]["ComputerModel"].ToString() + "," + infoTable.Rows[j]["ComputerModel"].ToString();
                            }

                            if (infoTable.Rows[j]["SerialNumber"].ToString() != infoTable.Rows[i]["SerialNumber"].ToString())
                            {
                                infoTable.Rows[i]["SerialNumber"] = infoTable.Rows[i]["SerialNumber"].ToString() + "," + infoTable.Rows[j]["SerialNumber"].ToString();
                            }

                            if (!dataRowList.Contains(infoTable.Rows[j]))
                            {
                                dataRowList.Add(infoTable.Rows[j]);
                            }
                        }
                    }
                }

                foreach (var item in dataRowList)
                {
                    infoTable.Rows.Remove(item);
                }

                return infoTable;

            }
            catch (Exception)
            {

                throw;
            }

        }

        public static void AddIPhoneDeviceInfo(IPhoneDeviceInfo iphoneDeviceInfo, string VPNID)
        {
            try
            {
                string sqlCmd = string.Format("SELECT COUNT(*) FROM [IPhoneDeviceInfo] WHERE [UUID] = '{0}'", iphoneDeviceInfo.UUID);

                object count = SqlHelper.Instance.ExecuteScalar(sqlCmd);
                if (Convert.ToInt32(count) == 0)
                {
                    sqlCmd = string.Format("INSERT INTO [IPhoneDeviceInfo] ([PhoneModel],[SerialNumber],[MacAddress],[UUID],[AddTime],[UpdateTime],[State]) VALUES " +
                            "('{0}','{1}','{2}','{3}','{4}','{5}','{6}')",
                              iphoneDeviceInfo.PhoneModel, iphoneDeviceInfo.SerialNumber, iphoneDeviceInfo.MacAddress, iphoneDeviceInfo.UUID, DateTime.Now.ToString(), DateTime.Now.ToString(), iphoneDeviceInfo.State);

                    SqlHelper.Instance.ExecuteCommand(sqlCmd);

                    if (!string.IsNullOrWhiteSpace(VPNID))
                    {
                        sqlCmd = string.Format("SELECT [ID] FROM [IPhoneDeviceInfo] WHERE [UUID] = '{0}'", iphoneDeviceInfo.UUID);
                        object id_t = SqlHelper.Instance.ExecuteScalar(sqlCmd);


                        sqlCmd = string.Format("INSERT INTO [IPhoneAndVPN] ([IPhoneID],[VPNID],[State],[AddTime],[UpdateTime]) VALUES " +
                            "('{0}','{1}','{2}','{3}','{4}')",
                            id_t.ToString(), VPNID, "normal", DateTime.Now.ToString(), DateTime.Now.ToString());

                        SqlHelper.Instance.ExecuteCommand(sqlCmd);
                    }
                }
                else
                {
                    throw new Exception(iphoneDeviceInfo.UUID + "，已经在数据库中了");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }


        public static List<VPNInfo> GetVPNInfoForComputer(bool onlyFreeVPN, string state)
        {
            try
            {
                string sqlCmd = string.Format("SELECT * FROM [VPNInfo] WHERE [State] = '{0}'", state);
                if (onlyFreeVPN)
                {
                    sqlCmd = string.Format("SELECT * FROM [VPNInfo] a WHERE a.[State]='{0}' AND a.ID NOT IN (SELECT [VPNID] FROM [ComputerAndVPN])", state);
                }


                DataTable infoTable = SqlHelper.Instance.ExecuteDataTable(sqlCmd);

                if (infoTable == null || infoTable.Rows.Count == 0)
                {
                    throw new Exception("没有可用VPN");
                }

                List<VPNInfo> result = new List<VPNInfo>();
                for (int i = 0; i < infoTable.Rows.Count; i++)
                {
                    VPNInfo t = new VPNInfo
                    {
                        VPNAccount = infoTable.Rows[i]["VPNAccount"].ToString(),
                        VPNPassword = infoTable.Rows[i]["VPNPassword"].ToString(),
                        BuyTime = infoTable.Rows[i]["BuyTime"].ToString(),
                        DieTime = infoTable.Rows[i]["DieTime"].ToString(),
                        IP = infoTable.Rows[i]["IP"].ToString(),
                        ID = int.Parse(infoTable.Rows[i]["ID"].ToString()),
                        State = infoTable.Rows[i]["State"].ToString(),
                        UpdateTime = infoTable.Rows[i]["UpdateTime"].ToString(),
                        Country = infoTable.Rows[i]["Country"].ToString().Trim(),
                    };

                    result.Add(t);
                }

                return result;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static void AddComputerInfo(ComputerInfo computerInfo, string VPNID)
        {
            try
            {
                string sqlCmd = string.Format("SELECT COUNT(*) FROM [ComputerDeviceInfo] WHERE [ComputerModel] = '{0}'", computerInfo.ComputerModel);

                object count = SqlHelper.Instance.ExecuteScalar(sqlCmd);
                if (Convert.ToInt32(count) == 0)
                {
                    sqlCmd = string.Format("INSERT INTO [ComputerDeviceInfo] ([ComputerModel],[AddTime],[UpdateTime],[State]) VALUES " +
                            "('{0}','{1}','{2}','{3}')",
                              computerInfo.ComputerModel, DateTime.Now.ToString(), DateTime.Now.ToString(), computerInfo.State);

                    SqlHelper.Instance.ExecuteCommand(sqlCmd);

                    if (!string.IsNullOrWhiteSpace(VPNID))
                    {
                        sqlCmd = string.Format("SELECT [ID] FROM [ComputerDeviceInfo] WHERE [ComputerModel] = '{0}'", computerInfo.ComputerModel);
                        object id_t = SqlHelper.Instance.ExecuteScalar(sqlCmd);


                        sqlCmd = string.Format("INSERT INTO [ComputerAndVPN] ([ComputerID],[VPNID],[State],[AddTime],[UpdateTime]) VALUES " +
                            "('{0}','{1}','{2}','{3}','{4}')",
                            id_t.ToString(), VPNID, "normal", DateTime.Now.ToString(), DateTime.Now.ToString());

                        SqlHelper.Instance.ExecuteCommand(sqlCmd);
                    }
                }
                else
                {
                    throw new Exception(computerInfo.ComputerModel + "，已经在数据库中了");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
