using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;

using Bouwa.Helper;
using Bouwa.ITSP2V31.BLL;
using Bouwa.ITSP2V31.Model;
using System.Configuration;
using Bouwa.Helper.Class;
using System.Net;
using System.IO;
using System.Diagnostics;
using System.Threading;

namespace Bouwa.ITSP2V31.WIN
{
    public partial class Login : Bouwa.Helper.BaseForm
    {
        SystemMessageInfo _objSystemMessageInfo = new SystemMessageInfo();
        LoginBLL _objCardTypeBLL = new LoginBLL();
        CardTypeBLL _objCardBLL = new CardTypeBLL();
        public Login()
        {
            InitializeComponent();
        }


        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (this.tbxUserName.Text == string.Empty)
            {
                MessageBoxForm.Show("帐号不能为空！",MessageBoxButtons.OK);
                this.tbxUserName.Focus();
            }
            else if (this.tbxPassWord.Text == string.Empty)
            {
                MessageBoxForm.Show("密码不能为空！", MessageBoxButtons.OK);
                this.tbxPassWord.Focus();
            }
            else
            {
                LoginUser();
            }
        }

        private void LoginUser()
        {
            Dictionary<string, object> arr = new Dictionary<string, object>();
            arr["userCode"] = this.tbxUserName.Text.Trim();
            arr["password"] = StringUtil.MD5(this.tbxPassWord.Text.Trim());
            arr["ICode"] = "ITSP2_RFID_CS_Login";

            UserInfo objUserInfo = _objCardTypeBLL.SelectUserCountByID(arr, null, ref _objSystemMessageInfo);

            //声明HashTable
            Hashtable table = new Hashtable();
            table.Add("tcit_system", (int)CurrentUser.Current.PARKING_SYSTEM);
            table.Add("tcit_type", (int)CurrentUser.Current.CS_CLIENT);
            table.Add("tcit_code", CurrentUser.Current.CardPassword);
            string configValue = _objCardBLL.GetRegisterType(table, null);
            if (!_objSystemMessageInfo.Success)
            {
                MessageBoxForm.Show(_objSystemMessageInfo, MessageBoxButtons.OK);
                return;
            }
            
            if (objUserInfo != null)
            {
                if (!objUserInfo.UserStatus.Equals("1"))
                {
                    MessageBoxForm.Show("该帐号已被禁用登入，请联系管理员！", MessageBoxButtons.OK);
                    this.tbxUserName.Focus();
                    return;

                }
                if (!objUserInfo.IsPower)
                {
                    MessageBoxForm.Show("该帐号未分配权限，请联系管理员！", MessageBoxButtons.OK);
                    this.tbxUserName.Focus();
                    return;
                }
                if (objUserInfo.NetWorkID.ToString() == Guid.Empty.ToString())
                {
                    MessageBoxForm.Show("该帐号未分配网点或网点未被启用，请联系管理员！", MessageBoxButtons.OK);
                    this.tbxUserName.Focus();
                    return;
                }
                else
                {
                    this.tbxUserName.Focus();
                    CurrentUser.Current.UserId = objUserInfo.UserId;
                    CurrentUser.Current.NetWorkID = objUserInfo.NetWorkID;
                    CurrentUser.Current.PassWord = objUserInfo.PassWord;
                    CurrentUser.Current.SAASID =new Guid(ConfigurationSettings.AppSettings["saas_id"].ToString());
                    CurrentUser.Current.RightInfoList = (object)objUserInfo.RightInfoList;//20120104 zhangwenjin add
                    //设置卡初始化密码
                    CurrentUser.Current.PassWordKey = HelperClass.DecryptByString(configValue);
                    MDIParent MP = new MDIParent();
                    MP.Show();
                    this.Hide();
                    CurrentUser.Current.LoginForm = this;
                    //清空文本框的值
                    this.tbxUserName.Text = this.tbxPassWord.Text = string.Empty;                  
                }
            }
            else
            {
                MessageBoxForm.Show("帐号或密码不正确！", MessageBoxButtons.OK);
                this.tbxUserName.Focus();
            } 
        }
        /// <summary>
        /// 关闭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClose_Click(object sender, EventArgs e)
        {
            //if (MessageBoxForm.Show("确认关闭？","提示", MessageBoxButtons.OKCancel,MessageBoxIcon.Information) == DialogResult.OK)
            //{
                CurrentUser.Current.PassWord = CurrentUser.Current.UserCode = CurrentUser.Current.UserName = string.Empty;
                CurrentUser.Current.UserId = Guid.Empty;
                Application.Exit();
           //}
        }

        private void Login_Load(object sender, EventArgs e)
        {
            this.tbxUserName.Focus();
            string Config = string.Empty;
            try
            {
                //配置文件读取
                Config = System.Configuration.ConfigurationSettings.AppSettings["Itsp2WebServiceNamespace"];
           
              
            }
            catch (Exception ex)
            {
                MessageBoxForm.Show("配置不正确，请联系管理员！", MessageBoxButtons.OK);
            }

            ServiceWrapper.Init();
            ServiceWrapper.SetURL(Config);
            //检查更新
            CheckDownlaod();
        }

        /// <summary>
        /// 用户名按下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbxUserName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == 13)
            {
                if (this.tbxUserName.Text == string.Empty)
                {
                    MessageBoxForm.Show("帐号不能为空！", MessageBoxButtons.OK);
                    this.tbxUserName.Focus();
                }
                this.tbxPassWord.Focus();
            }
        }

        /// <summary>
        /// 密码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbxPassWord_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == 13)
            {
                if (this.tbxPassWord.Text == string.Empty)
                {
                    MessageBoxForm.Show("密码不能为空！", MessageBoxButtons.OK);
                    this.tbxPassWord.Focus();
                }
                else
                {
                    LoginUser();
                }
            }
        }

        /// <summary>
        /// 用户名改变
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbxUserName_TextChanged(object sender, EventArgs e)
        {
            this.tbxPassWord.Text = string.Empty;
        }

        /// <summary>
        /// 检查更新
        /// </summary>
        private void CheckDownlaod() {
            try
            {
                string systemVersion;
                systemVersion = RFVersionInfo.GetSystemVersion();

                //检查新版本
                if (_objCardTypeBLL.Programkeep(systemVersion, out URL))
                {
                    //说明有更新
                    if (!string.IsNullOrEmpty(URL))
                    {
                        this.tbxUserName.Enabled = false;
                        this.tbxPassWord.Enabled = false;
                        this.btnLogin.Enabled = false;
                        this.btnClose.Enabled = false;
                        MessageBoxForm.Show("系统有新版本，稍后将进行系统更新！", MessageBoxButtons.OK);
                        _request = (HttpWebRequest)HttpWebRequest.Create(URL);
                        _request.BeginGetResponse(new AsyncCallback(ResponseReceived), null);

                    }
                }
            }
            catch (Exception ex)
            {
               // MessageBoxForm.Show("连接不到网络，请检查网络连接！", MessageBoxButtons.OK);
                Log.WriterLine(ELevel.error,"检查更新",ex.Message);
            }
        }


        #region 自动更新

        private HttpWebRequest _request;
        private HttpWebResponse _response;
        private FileStream _fs;
        private byte[] _dataBuffer;
        private const int DataBlockSize = 65536;   //数据缓冲区大小
        string URL = string.Empty; //保存下载地址

        /// <summary>
        /// 接收响应
        /// </summary>
        /// <param name="res"></param>
        void ResponseReceived(IAsyncResult res)
        {
            try
            {
                _response = (HttpWebResponse)_request.EndGetResponse(res);
            }
            catch (WebException /*ex*/)
            {
                MessageBoxForm.Show("下载错误！", MessageBoxButtons.OK);
                return;
            }
            Cursor.Current = Cursors.WaitCursor;
            _dataBuffer = new byte[DataBlockSize];
            _fs = new FileStream(RFVersionInfo.GetCurrentDirectory() + @"\" + "Update_CS.exe", FileMode.Create);

            _response.GetResponseStream().BeginRead(_dataBuffer, 0, DataBlockSize, new AsyncCallback(OnDataRead), this);
            Cursor.Current = Cursors.Default;
        }

        /// <summary>
        ///  读取数据
        /// </summary>
        /// <param name="res"></param>
        void OnDataRead(IAsyncResult res)
        {
            //结束读取
            int nBytes = _response.GetResponseStream().EndRead(res);

            _fs.Write(_dataBuffer, 0, nBytes);

            if (nBytes > 0)
            {
                _response.GetResponseStream().BeginRead(_dataBuffer, 0, DataBlockSize, new AsyncCallback(OnDataRead), this);
            }
            else
            {
                _fs.Close();
                _fs = null;
                Cursor.Current = Cursors.WaitCursor;
                int index = URL.LastIndexOf(@"/") > URL.LastIndexOf(@"\") ? URL.LastIndexOf(@"/") : URL.LastIndexOf(@"\");

                //获得需要执行的程序
                string execFileName=RFVersionInfo.GetCurrentDirectory() + @"\" + URL.Substring(index + 1);

                if (File.Exists(execFileName))
                {
                    //由进程重新打开
                    Process.Start(execFileName, null);
                    Cursor.Current = Cursors.Default;
                    Thread.Sleep(500);
                    Process.GetCurrentProcess().Kill();
                }
                else { 
                    //提示用户
                    MessageBoxForm.Show("未找到启动文件：" + execFileName + "，请联系管理员！", MessageBoxButtons.OK);
                }
                Application.Exit();
            }
        }

        #endregion


    }
}
