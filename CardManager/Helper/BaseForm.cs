using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Collections.Specialized;

namespace Bouwa.Helper
{
    [Serializable]
    public  class BaseForm:System.Windows.Forms.Form
    {
        public NameValueCollection Parameter { get; set; }//窗体间传递参数用

        public BaseForm()
        {
            Parameter = new NameValueCollection();
        }

        public Bouwa.Helper.DataAccessor DataAccessor { get; set; }//从窗体传数据库连接或WebService连接



        /// <summary>
        /// 状态
        /// </summary>
        public enum ActionType
        {
            /// <summary>
            /// 列表
            /// </summary>
            List = 1,

            /// <summary>
            /// 新增
            /// </summary>
            Insert = 2,

            /// <summary>
            /// 修改
            /// </summary>
            Update = 3,

            /// <summary>
            /// 删除
            /// </summary>
            Delete = 4,

            /// <summary>
            /// 查看
            /// </summary>
            View = 5,

			 /// <summary>
            /// 初始化
            /// </summary>
            Init = 6,

            /// <summary>
            /// 历史
            /// </summary>
            History = 7,
        }
    }
}
