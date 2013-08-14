using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Windows.Forms;

namespace Bouwa.Helper
{
    public class CurrentUser
    {
        //单态模式
        private static CurrentUser _currentUser;
        static CurrentUser()
        {
            CurrentUser._currentUser = new CurrentUser();
        }
        
        public static CurrentUser Current
        {
            get
            {
                return CurrentUser._currentUser;
            }
        }

        private CurrentUser()
        {
            
        }
        private Guid _UserId;      //用户ID
        private string _UserCode; //登录码
        private string _UserName;   //用户名
        private string _PassWord;    //密码
        private bool _isLogin;     //判断登录成功
        private Form _LoginForm;//对象登录窗体对象
        private string _PassWordKey = string.Empty; //所有的卡的密码存放处
        private Guid _NetWorkID = Guid.Empty; //网点ID
        private object _RightInfoList = new object();
        public object RightInfoList
        { get { return _RightInfoList; } set { _RightInfoList = value; } }

        //private IList<object> _RightInfoList = new List<object>();
        //public IList<object> RightInfoList
        //{ get { return _RightInfoList; } set { _RightInfoList = value; } }

        private int _PageSize = 20;
        private int _PageIndex = 1;
        private int _PageCount = 0;
        private int _TotalCount = 0;

        private int _PARKING_SYSTEM = 0;//停车系统
        /// <summary>
        /// 
        /// </summary>
        public int PARKING_SYSTEM
        {
            get { return _PARKING_SYSTEM; }
            set { _PARKING_SYSTEM = value; }
        }

        private int _PARK_BACKSTAGE = 2;//收费后台

        private int _CS_CLIENT = 4; //cs客户端
        /// <summary>
        /// 收费后台
        /// </summary>
        public int PARK_BACKSTAGE
        {
            get { return _PARK_BACKSTAGE; }
            set { _PARK_BACKSTAGE = value; }
        }

        /// <summary>
        /// cs客户端
        /// </summary>
        public int CS_CLIENT
        {
            get { return _CS_CLIENT; }
            set { _CS_CLIENT = value; }
        }

        /// <summary>
        /// 注册类型
        /// </summary>
        private string _RegisterType = "background.register.type";
        /// <summary>
        /// 注册类型
        /// </summary>
        public string RegisterType
        {
            get { return _RegisterType; }
            set { _RegisterType = value; }
        }

        /// <summary>
        /// 最大金额
        /// </summary>
        private string _maxMoney = "background.maxMoney";
        /// <summary>
        /// 最大时间
        /// </summary>
        private string _maxTime = "background.maxTime";
        /// <summary>
        /// 最大次数
        /// </summary>
        private string _maxDegree = "background.maxDegree";
        /// CS 端卡密码
        private string _cardPassword ="CS.cardPassword";

        /// <summary>
        /// 最大金额
        /// </summary>
        public string CardPassword
        {
            get { return _cardPassword; }
            set { _cardPassword = value; }
        }

        /// <summary>
        /// 最大金额
        /// </summary>
        public string MaxMoney
        {
            get { return _maxMoney; }
            set { _maxMoney = value; }
        }

        /// <summary>
        /// 最大时间
        /// </summary>
        public string MaxTime
        {
            get { return _maxTime; }
            set { _maxTime = value; }
        }

        /// <summary>
        /// 最大次数
        /// </summary>
        public string MaxDegree
        {
            get { return _maxDegree; }
            set { _maxDegree = value; }
        }

        /// <summary>
        /// 显示页数
        /// </summary>
        public int PageSize
        {
            get
            {
                return _PageSize;

            }
            set
            {
                _PageSize = value;
            }
        }
        /// <summary>
        /// 当前页
        /// </summary>
        public int PageIndex
        {
            get
            {
                return _PageIndex;
            }
            set
            {
                _PageIndex = value;
            }
        }
        /// <summary>
        /// 总页数
        /// </summary>
        public int PageCount
        {
            get
            {
                return _PageCount;
            }
            set
            {
                _PageCount = value;
            }
        }
        /// <summary>
        /// 总记录数
        /// </summary>
        public int TotalCount
        {
            get
            {
                return _TotalCount;
            }
            set
            {
                _TotalCount = value;
            }
        }
        /// <summary>
        /// 网点ID
        /// </summary>
        public Guid NetWorkID
        {
            get { return _NetWorkID; }
            set { _NetWorkID = value; }
        }
        private Guid _SAASID = Guid.Empty; //SAASID
        /// <summary>
        /// SAASID
        /// </summary>
        public Guid SAASID
        {
            get { return _SAASID; }
            set { _SAASID = value; }
        }


        /// <summary>
        /// 所有卡的密码来源
        /// </summary>
        public string PassWordKey
        {
            get { return _PassWordKey; }
            set { _PassWordKey = value; }
        }

        /// <summary>
        /// 保存登录窗体对象
        /// </summary>
        public Form LoginForm
        {
            get { return _LoginForm; }
            set { _LoginForm = value; }
        }
        /// <summary>
        /// 获取或设置 用户ID
        /// </summary>
        public Guid UserId
        {
            get
            {
                return _UserId;
            }
            set
            {
                _UserId = value;
            }
        }

        /// <summary>
        /// 获取或设置 用户登录码
        /// </summary>
        public string UserCode
        {
            get
            {
                return _UserCode;
            }
            set
            {
                _UserCode = value;
            }
        }
        /// <summary>
        /// 获取或设置 用户名
        /// </summary>
        public string UserName
        {
            get
            {
                return _UserName;
            }
            set
            {
                _UserName = value;
            }
        }
        /// <summary>
        /// 密码
        /// </summary>
        public string PassWord
        {
            get { return _PassWord; }
            set { _PassWord = value; }
        }

        /// <summary>
        /// 判断登录成功
        /// </summary>
        public bool isLogin
        {
            get { return _isLogin; }
            set { _isLogin = value; }
        }

        private DateTime _EffectDateBegin = DateTime.MinValue;
        /// <summary>
        /// 开始时间
        /// </summary>
        public DateTime EffectDateBegin
        {
            get { return _EffectDateBegin; }
            set { _EffectDateBegin = value; }
        }

        private DateTime _EffectDateEnd = DateTime.MaxValue;
        /// <summary>
        /// 结束时间
        /// </summary>
        public DateTime EffectDateEnd
        {
            get { return _EffectDateEnd; }
            set { _EffectDateEnd = value; }
        }
    }
}
