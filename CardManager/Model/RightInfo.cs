using System;
using System.Collections.Generic;
using System.Text;
using Bouwa.Helper;

namespace Bouwa.ITSP2V31.Model
{
    /// <summary>
    /// 用户权限
    /// </summary>
    [Serializable]
    public class RightInfo : BaseInfo
    {
        private Guid _Id = SystemConstant.GuidEmpty;
        /// <summary>
        /// 权限ID
        /// </summary>
        public Guid Id
        { get { return _Id; } set { _Id = value; } }

        private Guid _UserId = SystemConstant.GuidEmpty;
        /// <summary>
        /// 用户ID
        /// </summary>
        public Guid UserId
        { get { return _UserId; } set { _UserId = value; } }

        private int _FatherId = 0;
        /// <summary>
        /// 权限ID
        /// </summary>
        public int FatherId
        { get { return _FatherId; } set { _FatherId = value; } }

        private string _Code;
        /// <summary>
        /// 代码
        /// </summary>
        public string Code
        { get { return _Code; } set { _Code = value; } }

        private string _Name;
        /// <summary>
        /// 名称
        /// </summary>
        public string Name
        { get { return _Name; } set { _Name = value; } }

        private string _Path;
        /// <summary>
        /// 路径
        /// </summary>
        public string Path
        { get { return _Path; } set { _Path = value; } }

        private int _Type;
        /// <summary>
        /// 类型
        /// </summary>
        public int Type
        { get { return _Type; } set { _Type = value; } }

    }
}
