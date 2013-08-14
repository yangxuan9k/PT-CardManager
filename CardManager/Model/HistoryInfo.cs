using System;
using System.Collections.Generic;
using System.Text;
using Bouwa.Helper;

namespace Bouwa.ITSP2V31.Model
{
    [Serializable]
    public class HistoryInfo : BaseInfo
    {
        public static string InfoName = "卡历史";

        /// <summary>
        /// 操作类型
        /// </summary>
        public enum OperationCardType
        {
            禁用 = 0 ,
            初始化 = 1, 
            退卡 = 2, 
            挂失 = 3 ,
            消费 = 4 ,
            充值 = 5,
            卡重置 = 6
        }
        /// <summary>
        /// 网点类型
        /// </summary>
        public enum AddressCardType
        {
             营业网点 = 1,
            停车场消费 = 2 
        }

        /// <summary>
        /// 操作运算符
        /// </summary>
        public enum Operation
        {
            大于等于 = 0,
            小于等于 = 1,
            等于 = 2,
            介于 = 3,
            为空 = 4
        } 

        private Guid _SAASID = Helper.SystemConstant.GuidEmpty;
        /// <summary>
        /// SAASＩＤ
        /// </summary>
        public Guid SAASID
        {
            get { return _SAASID; }
            set { _SAASID = value; }
        }

        private OperationCardType _OperationType;
        /// <summary>
        /// 操作类型
        /// </summary>
        public OperationCardType OperationType
        {
            get { return _OperationType; }
            set { _OperationType = value; }
        }

        private AddressCardType _AddressType;
        /// <summary>
        /// 网点类型
        /// </summary>
        public AddressCardType AddressType
        {
            get { return _AddressType; }
            set { _AddressType = value; }
        }

        private string _CardID;
        /// <summary>
        /// 卡ID 号
        /// </summary>
        public string CardID
        {
            get { return _CardID; }
            set { _CardID = value; }
        }

        private string _No;
        /// <summary>
        /// 卡面编号
        /// </summary>
        public string No
        {
            get { return _No; }
            set { _No = value; }
        }

        private DateTime _OperationTime = Helper.SystemConstant.DateTimeEmpty;
        /// <summary>
        /// 操作时间
        /// </summary>
        public DateTime OperationTime
        {
            get { return _OperationTime; }
            set { _OperationTime = value; }
        }

        private string _NetWork = "";
        /// <summary>
        /// 地点
        /// </summary>
        public string NetWork
        {
            get { return _NetWork; }
            set { _NetWork = value; }
        }

        private string _OperationMemo = "";
        /// <summary>
        /// 操作事项
        /// </summary>
        public string OperationMemo
        {
            get { return _OperationMemo; }
            set { _OperationMemo = value; }
        }

        private string _OperationUser;
        /// <summary>
        /// 操作人
        /// </summary>
        public string OperationUser
        {
            get { return _OperationUser; }
            set { _OperationUser = value; }
        }
        private string _RowNumber;
        /// <summary>
        /// 序号
        /// </summary>
        public string RowNumber
        {
            get { return _RowNumber; }
            set { _RowNumber = value; }
        }
    }
}
