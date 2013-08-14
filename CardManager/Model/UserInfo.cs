using System;
using System.Collections.Generic;
using System.Text;
using Bouwa.Helper;
using Bouwa.ITSP2V31.Model;

namespace Bouwa.ITSP2V31.Model
{
    [Serializable]
    public class UserInfo : BaseInfo
    {
        IList<RightInfo> _RightInfoList = new List<RightInfo>();
        /// <summary>
        /// 权限集合
        /// </summary>
        public IList<RightInfo> RightInfoList
        { get { return _RightInfoList; } set { _RightInfoList = value; } }

        private Guid _UserId = SystemConstant.GuidEmpty;
        /// <summary>
        /// 用户ID
        /// </summary>
        public Guid UserId
        { get { return _UserId; } set { _UserId = value; } }

        private string _UserName;
        /// <summary>
        ///用户名
        /// </summary>
        public string UserName
        { get { return _UserName; } set { _UserName = value; } }

        private string _UserCode;
        /// <summary>
        ///用户编号
        /// </summary>
        public string UserCode
        { get { return _UserCode; } set { _UserCode = value; } }

        private string _PassWord;
        /// <summary>
        /// 密码
        /// </summary>
        public string PassWord
        { get { return _PassWord; } set { _PassWord = value; } }

        private Guid _NetWorkID;
        /// <summary>
        /// 网点ID
        /// </summary>
        public Guid NetWorkID
        {
            get { return _NetWorkID; }
            set { _NetWorkID = value; }
        }

        private string _UserStatus;
        /// <summary>
        /// CS用户状态
        /// </summary>
        public string UserStatus
        {
            get { return _UserStatus; }
            set { _UserStatus = value; }
        }

        private string _NetWorkStatus;
        /// <summary>
        /// 网点状态
        /// </summary>
        public string NetWorkStatus
        {
            get { return _NetWorkStatus; }
            set { _NetWorkStatus = value; }
        }

        private bool _IsPower=false;
        /// <summary>
        /// 是否有权限
        /// </summary>
        public bool IsPower
        {
            get { return _IsPower; }
            set { _IsPower = value; }
        }

    }
}
