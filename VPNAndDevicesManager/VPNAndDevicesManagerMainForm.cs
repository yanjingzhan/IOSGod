using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UtilityLib;
using UtilityLib.Models;

namespace VPNAndDevicesManager
{
    public partial class VPNAndDevicesManagerMainForm : Form
    {
        public VPNAndDevicesManagerMainForm()
        {
            InitializeComponent();
            InitControls();

        }

        private void InitControls()
        {
            this.comboBoxEdit_VPNCountry_Add.SelectedIndex = 0;
            this.dateEdit_VPNBuyDate_Add.DateTime = DateTime.Now;
            this.dateEdit_VPNDieDate_Add.DateTime = DateTime.Now;

            this.textEdit_ComputerName_Add.Text = Environment.GetEnvironmentVariable("ComputerName");

            this.navigationPane1.SelectedPageIndex = 0;
            this.textEdit_IPhoneModel_Add.Focus();
            this.textEdit_IPhoneModel_Add.SelectAll();

            this.dataGridView_IPhoneVPNData_Add.AutoGenerateColumns = false;
            this.dataGridView_ComputerVPNData_Add.AutoGenerateColumns = false;
        }

        #region VPN添加

        private bool CheckInput_AddVPN()
        {
            return !string.IsNullOrWhiteSpace(this.textEdit_VPNAccount_Add.Text) &&
                !string.IsNullOrWhiteSpace(this.textEdit_VPNAddress_Add.Text) &&
                !string.IsNullOrWhiteSpace(this.textEdit_VPNPassword_Add.Text);
        }
        private void simpleButton_AddVPN_Click(object sender, EventArgs e)
        {
            if (!CheckInput_AddVPN())
            {
                SetInfo("请填写完整");
                return;
            }

            try
            {
                DataHelper.AddVpnInfo(new UtilityLib.Models.VPNInfo
                {
                    BuyTime = this.dateEdit_VPNBuyDate_Add.DateTime.ToString(),
                    DieTime = this.dateEdit_VPNDieDate_Add.DateTime.ToString(),
                    IP = this.textEdit_VPNAddress_Add.Text.Trim(),
                    State = "normal",
                    VPNAccount = this.textEdit_VPNAccount_Add.Text.Trim(),
                    VPNPassword = this.textEdit_VPNPassword_Add.Text.Trim(),
                    Country = this.comboBoxEdit_VPNCountry_Add.Text.Trim(),
                    Seller = this.textEdit_VPNSeller_Add.Text.Trim()
                });

                SetInfo("添加成功");

                this.textEdit_VPNAccount_Add.Text = string.Empty;
                this.textEdit_VPNAddress_Add.Text = string.Empty;
                this.textEdit_VPNPassword_Add.Text = string.Empty;
            }
            catch (Exception ex)
            {
                SetInfo("添加失败," + ex.Message);
            }
        }

        #endregion

        #region 添加手机信息

        List<VPNInfo> _vpnInfoList = null;

        private bool CheckInput_AddIPhone()
        {
            return !string.IsNullOrWhiteSpace(this.textEdit_IPhoneMACAddress_Add.Text) &&
                !string.IsNullOrWhiteSpace(this.textEdit_IPhoneModel_Add.Text) &&
                !string.IsNullOrWhiteSpace(this.textEdit_IPhoneSerialNumber_Add.Text) &&
                !string.IsNullOrWhiteSpace(this.textEdit_IPUUID_Add.Text);
        }

        private void navigationPane1_SelectedPageChanged(object sender, DevExpress.XtraBars.Navigation.SelectedPageChangedEventArgs e)
        {
            if (navigationPane1.SelectedPageIndex == 1)
            {
                try
                {
                    //this.listBox_IPhoneBindingVPNAccount_Add.Items.Clear();
                    //simpleButton_IPhoneUnSelect_Add_Click(sender, e);

                    //_vpnInfoList = DataHelper.GetVPNInfo(this.checkBox_IPhoneIsOnlyShowFreeVPN_Add.Checked, "normal");

                    //foreach (var item in _vpnInfoList)
                    //{
                    //    this.listBox_IPhoneBindingVPNAccount_Add.Items.Add(item.VPNAccount + "@" + item.IP + "@" + item.Country + "_" + item.ID);
                    //}

                    button2_Click(sender, e);
                }
                catch (Exception ex)
                {
                    SetInfo(ex.Message);
                }
            }

            if (navigationPane1.SelectedPageIndex == 2)
            {
                try
                {
                    //this.listBox_ComputerVPNInfo_Add.Items.Clear();
                    //simpleButton_ComputerUnSelectVPN_Add_Click(sender, e);

                    //_vpnInfoList = DataHelper.GetVPNInfoForComputer(this.checkBox_ComputerOnlyShowFreeVPN.Checked, "normal");

                    //foreach (var item in _vpnInfoList)
                    //{
                    //    this.listBox_ComputerVPNInfo_Add.Items.Add(item.VPNAccount + "@" + item.IP + "@" + item.Country + "_" + item.ID);
                    //}

                    button1_Click(sender, e);
                }
                catch (Exception ex)
                {
                    SetInfo(ex.Message);
                }
            }

        }


        private void simpleButton_AddIPhoneDeviceInfo_Add_Click(object sender, EventArgs e)
        {
            if (!CheckInput_AddIPhone())
            {
                SetInfo("请填写完整");
                return;
            }

            try
            {
                string vpnID = string.Empty;
                //if (listBox_IPhoneBindingVPNAccount_Add.SelectedIndex > -1)
                //{
                //    string str_t = listBox_IPhoneBindingVPNAccount_Add.SelectedItem.ToString();

                //    int t_1 = str_t.LastIndexOf("_");
                //    vpnID = str_t.Substring(t_1 + 1);
                //}

                if (dataGridView_IPhoneVPNData_Add.SelectedCells.Count > 0)
                {
                    vpnID = dataGridView_IPhoneVPNData_Add.Rows[dataGridView_IPhoneVPNData_Add.SelectedCells[0].RowIndex].Cells["Column_IPhoneVPNID"].Value.ToString();
                }

                DataHelper.AddIPhoneDeviceInfo(new IPhoneDeviceInfo
                    {
                        MacAddress = this.textEdit_IPhoneMACAddress_Add.Text.Trim(),
                        PhoneModel = this.textEdit_IPhoneModel_Add.Text.Trim(),
                        SerialNumber = this.textEdit_IPhoneSerialNumber_Add.Text.Trim(),
                        UUID = this.textEdit_IPUUID_Add.Text.Trim(),
                        State = "normal"
                    }, vpnID);


                textEdit_IPhoneMACAddress_Add.Text = string.Empty;
                textEdit_IPhoneModel_Add.Text = string.Empty;
                textEdit_IPhoneSerialNumber_Add.Text = string.Empty;
                textEdit_IPUUID_Add.Text = string.Empty;

                checkBox_IPhoneIsOnlyShowFreeVPN_Add_CheckedChanged(new object(), new EventArgs());

                SetInfo("添加Iphone信息成功");
            }
            catch (Exception ex)
            {
                SetInfo("添加Iphone信息失败," + ex.Message);
            }
        }


        private void simpleButton_IPhoneUnSelect_Add_Click(object sender, EventArgs e)
        {
            this.listBox_IPhoneBindingVPNAccount_Add.ClearSelected();
            this.dataGridView_IPhoneVPNData_Add.ClearSelection();
        }


        private void checkBox_IPhoneIsOnlyShowFreeVPN_Add_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                //this.listBox_IPhoneBindingVPNAccount_Add.Items.Clear();
                //simpleButton_IPhoneUnSelect_Add_Click(sender, e);

                //_vpnInfoList = DataHelper.GetVPNInfo(this.checkBox_IPhoneIsOnlyShowFreeVPN_Add.Checked, "normal");

                //foreach (var item in _vpnInfoList)
                //{
                //    this.listBox_IPhoneBindingVPNAccount_Add.Items.Add(item.VPNAccount + "@" + item.IP + "@" + item.Country + "_" + item.ID);
                //}
                button2_Click(sender, e);
            }
            catch (Exception ex)
            {
                SetInfo(ex.Message);
            }
        }


        #endregion

        #region 添加计算机信息


        private void simpleButton_ComputerModifySysComputerName_Add_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(string.Format("确定将系统计算机名修改为 {0} ？", this.textEdit_ComputerName_Add.Text), "?", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
            {
                SystemHelper.SetComputerName(this.textEdit_ComputerName_Add.Text);
            }
        }

        private void checkBox_ComputerOnlyShowFreeVPN_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                //this.listBox_ComputerVPNInfo_Add.Items.Clear();
                //simpleButton_ComputerUnSelectVPN_Add_Click(sender, e);

                //_vpnInfoList = DataHelper.GetVPNInfoForComputer(this.checkBox_ComputerOnlyShowFreeVPN.Checked, "normal");

                //foreach (var item in _vpnInfoList)
                //{
                //    this.listBox_ComputerVPNInfo_Add.Items.Add(item.VPNAccount + "@" + item.IP + "@" + item.Country + "_" + item.ID);
                //}

                button1_Click(sender, e);
            }
            catch (Exception ex)
            {
                SetInfo(ex.Message);
            }
        }


        private bool CheckInput_AddComputer()
        {
            return !string.IsNullOrWhiteSpace(this.textEdit_ComputerName_Add.Text);
        }

        private void simpleButton_Computer_Add_Click(object sender, EventArgs e)
        {
            if (!CheckInput_AddComputer())
            {
                SetInfo("请填写完整");
                return;
            }

            try
            {
                string vpnID = string.Empty;
                //if (listBox_ComputerVPNInfo_Add.SelectedIndex > -1)
                //{
                //    string str_t = listBox_ComputerVPNInfo_Add.SelectedItem.ToString();

                //    int t_1 = str_t.LastIndexOf("_");
                //    vpnID = str_t.Substring(t_1 + 1);
                //}

                if (dataGridView_IPhoneVPNData_Add.SelectedCells.Count > 0)
                {
                    vpnID = dataGridView_IPhoneVPNData_Add.Rows[dataGridView_IPhoneVPNData_Add.SelectedCells[0].RowIndex].Cells["Column_ComputerVPNID"].Value.ToString();
                }

                DataHelper.AddComputerInfo(new ComputerInfo
                {
                    ComputerModel = this.textEdit_ComputerName_Add.Text,
                    State = "normal"
                }, vpnID);


                checkBox_ComputerOnlyShowFreeVPN_CheckedChanged(new object(), new EventArgs());

                SetInfo("添加计算机信息成功");
            }
            catch (Exception ex)
            {
                SetInfo("添加计算机信息失败," + ex.Message);
            }
        }



        #endregion

        private void SetInfo(string msg)
        {
            this.textBox_Info.Text = DateTime.Now.ToString() + "," + msg;
        }

        private void simpleButton_ComputerUnSelectVPN_Add_Click(object sender, EventArgs e)
        {
            this.listBox_ComputerVPNInfo_Add.ClearSelected();
            this.dataGridView_ComputerVPNData_Add.ClearSelection();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.dataGridView_ComputerVPNData_Add.DataSource = DataHelper.GetVPNINfoDataTable(checkBox_ComputerOnlyShowFreeVPN.Checked, "normal");
            this.dataGridView_ComputerVPNData_Add.ClearSelection();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.dataGridView_IPhoneVPNData_Add.DataSource = DataHelper.GetVPNINfoDataTable(checkBox_IPhoneIsOnlyShowFreeVPN_Add.Checked, "normal");
            this.dataGridView_IPhoneVPNData_Add.ClearSelection();
        }


    }
}
