using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;
using System.Text;
using System.IO;
using Bouwa.Helper;

namespace Bouwa.ITSP2V31.Model
{
    [Serializable]
    public class CardInfo : BaseInfo
    {
        public static string InfoName = "卡信息";

        /// <summary>
        /// 状态
        /// </summary>
        public enum CardTypeInfoStatus
        {
            /// <summary>
            /// 已启用
            /// </summary>
            已启用 = 1,

            /// <summary>
            /// 已禁用
            /// </summary>
            已禁用 = 0
        }

        /// <summary>
        /// 用途
        /// </summary>
        public enum CardTypeInfoPurpose
        {
            /// <summary>
            /// 非临时
            /// </summary>
            非临时 = 1,

            /// <summary>
            /// 临时
            /// </summary>
            临时 = 0
        }

        /// <summary>
        /// 扣费类型
        /// </summary>
        public enum CardTypeInfoCostType
        {
            /// <summary>
            /// 金额卡
            /// </summary>
            金额卡 = 1,

            /// <summary>
            /// 限时卡
            /// </summary>
            限时卡 = 2,

            /// <summary>
            /// 限期卡
            /// </summary>
            限期卡 = 3,

            /// <summary>
            /// 限次卡
            /// </summary>
            限次卡 = 4
        }

        /// <summary>
        /// 扣费类型
        /// </summary>
        public enum CardTypeInfoCostTypeQianJiang
        {
            /// <summary>
            /// 金额卡
            /// </summary>
            金额卡 = 1,

            /// <summary>
            /// 限期卡
            /// </summary>
            限期卡 = 3,

        }
        /// <summary>
        /// 注册类型
        /// </summary>
        public enum CardTypeInfoSubmitType
        {
            /// <summary>
            /// 实名
            /// </summary>
            实名 = 1,

            /// <summary>
            /// 不记名
            /// </summary>
            不记名 = 0
        }

        /// <summary>
        /// 预设卡状态
        /// </summary>
        public enum CardTypeInfoDefaultCardStatus
        {
            /// <summary>
            /// 禁用
            /// </summary>
            已禁用 = 0,

            /// <summary>
            /// 初始化
            /// </summary>
            已初始化 = 1,

            /// <summary>
            /// 已充值
            /// </summary>
            已充值 = 2,

            /// <summary>
            /// 退卡
            /// </summary>
            已退卡 = 3,

            /// <summary>
            /// 挂失
            /// </summary>
            已挂失 = 4,

            /// <summary>
            /// 制卡审批
            /// </summary>
            制卡审批 = 5,

            /// <summary>
            /// 已重置
            /// </summary>
            已重置 = 6,

            /// <summary>
            /// 空白卡
            /// </summary>
            空白卡 = 255
        }

        /// <summary>
        /// 是否预设可变
        /// </summary>
        public enum CardTypeInfoDefaultChange
        {
            /// <summary>
            /// 可变
            /// </summary>
            可变 = 1,

            /// <summary>
            /// 不可变
            /// </summary>
            不可变 = 0
        }

        public CardInfo()
        { }
        #region Model
        private Guid _id = Helper.SystemConstant.GuidEmpty;
        private Guid _member_id;
        private Guid _saas_id;
        private string _card_id;
        private string _no;
        private Guid _card_type;
        private string _batch;
        private CardTypeInfoPurpose _purpose;
        private CardTypeInfoCostType _cost_type;
        private CardTypeInfoSubmitType _submit_type;
        private int _times;
        private decimal _money;
        private int _charges_date;
        private DateTime _efffect_date;
        private DateTime _end_date;
        private CardTypeInfoDefaultCardStatus _status = 0;
        private string _memo;
        private DateTime _create_time = Helper.SystemConstant.DateTimeEmpty;
        private Guid _create_user;
        private DateTime _modify_time = Helper.SystemConstant.DateTimeEmpty;
        private Guid _modify_user;
        private string _systemcode = string.Empty;
        private DateTime _lastoperation_time = Helper.SystemConstant.DateTimeEmpty;
        private string _CardType = "";             //卡类型名称
        private Guid _network_id; //网点ID
        private decimal _maxCount;//最大限额
        private Guid _card_type_id;//卡类型ID

        /// <summary>
        /// 卡类型ID
        /// </summary>
        public Guid Card_type_id
        {
            get { return _card_type_id; }
            set { _card_type_id = value; }
        }

        /// <summary>
        /// 最大限额
        /// </summary>
        public decimal MaxCount
        {
            get { return _maxCount; }
            set { _maxCount = value; }
        }

        /// <summary>
        /// 网点ID
        /// </summary>
        public Guid Network_id
        {
            get { return _network_id; }
            set { _network_id = value; }
        }

        private int _MaxTimes = 0;
        /// <summary>
        ///  上限次数
        /// </summary>
        public int MaxTimes
        { get { return _MaxTimes; } set { _MaxTimes = value; } }

        private decimal _MaxMoney = 0;
        /// <summary>
        /// 上限金额
        /// </summary>
        public decimal MaxMoney
        { get { return _MaxMoney; } set { _MaxMoney = value; } }

        private int _MaxChargesDate = 0;
        /// <summary>
        /// 上限时间
        /// </summary>
        public int MaxChargesDate
        { get { return _MaxChargesDate; } set { _MaxChargesDate = value; } }

        /// <summary>
        /// 卡类型名称
        /// </summary>
        public string CardType
        {
            get { return _CardType; }
            set { _CardType = value; }
        }


        /// <summary>
        /// 最后操作时间
        /// </summary>
        public DateTime Lastoperation_time
        {
            get { return _lastoperation_time; }
            set { _lastoperation_time = value; }
        }

        /// <summary>
        /// 系统编号
        /// </summary>
        public string Systemcode
        {
            get { return _systemcode; }
            set { _systemcode = value; }
        }

        /// <summary>
        /// 卡在后台数据库的ID号
        /// </summary>
        public Guid id
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 会员ID号
        /// </summary>
        public Guid member_id
        {
            set { _member_id = value; }
            get { return _member_id; }
        }
        /// <summary>
        /// SAASID号
        /// </summary>
        public Guid saas_id
        {
            set { _saas_id = value; }
            get { return _saas_id; }
        }
        /// <summary>
        /// 卡内的ID号
        /// </summary>
        public string card_id
        {
            set { _card_id = value; }
            get { return _card_id; }
        }
        /// <summary>
        /// 卡面编号
        /// </summary>
        public string no
        {
            set { _no = value; }
            get { return _no; }
        }
        /// <summary>
        /// 卡类型ID
        /// </summary>
        public Guid card_type
        {
            set { _card_type = value; }
            get { return _card_type; }
        }
        /// <summary>
        /// 批次
        /// </summary>
        public string batch
        {
            set { _batch = value; }
            get { return _batch; }
        }
        /// <summary>
        /// 用途
        /// </summary>
        public CardTypeInfoPurpose purpose
        {
            set { _purpose = value; }
            get { return _purpose; }
        }
        /// <summary>
        /// 扣费类型
        /// </summary>
        public CardTypeInfoCostType cost_type
        {
            set { _cost_type = value; }
            get { return _cost_type; }
        }
        /// <summary>
        /// 注册类型
        /// </summary>
        public CardTypeInfoSubmitType submit_type
        {
            set { _submit_type = value; }
            get { return _submit_type; }
        }
        /// <summary>
        /// 剩余操作次数
        /// </summary>
        public int times
        {
            set { _times = value; }
            get { return _times; }
        }
        /// <summary>
        /// 剩余金额
        /// </summary>
        public decimal money
        {
            set { _money = value; }
            get { return _money; }
        }
        /// <summary>
        /// 剩余计费时间
        /// </summary>
        public int charges_date
        {
            set { _charges_date = value; }
            get { return _charges_date; }
        }
        /// <summary>
        /// 生效日期
        /// </summary>
        public DateTime efffect_date
        {
            set { _efffect_date = value; }
            get { return _efffect_date; }
        }
        /// <summary>
        /// 停用日期
        /// </summary>
        public DateTime end_date
        {
            set { _end_date = value; }
            get { return _end_date; }
        }
        /// <summary>
        /// 卡的状态
        /// </summary>
        public CardTypeInfoDefaultCardStatus status
        {
            set { _status = value; }
            get { return _status; }
        }
        /// <summary>
        /// 备注
        /// </summary>
        public string memo
        {
            set { _memo = value; }
            get { return _memo; }
        }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime create_time
        {
            set { _create_time = value; }
            get { return _create_time; }
        }
        /// <summary>
        /// 创建人
        /// </summary>
        public Guid create_user
        {
            set { _create_user = value; }
            get { return _create_user; }
        }
        /// <summary>
        /// 更新时间
        /// </summary>
        public DateTime modify_time
        {
            set { _modify_time = value; }
            get { return _modify_time; }
        }
        /// <summary>
        /// 更新人
        /// </summary>
        public Guid modify_user
        {
            set { _modify_user = value; }
            get { return _modify_user; }
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

        

        #endregion Model
    }
}
