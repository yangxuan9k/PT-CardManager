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
    public class CardTypeInfo : BaseInfo
    {
        public static string InfoName = "卡类型";

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
        /// 实名
        /// </summary>
        public enum CardTypeInfoSubmitType_Name
        {
            /// <summary>
            /// 实名
            /// </summary>
            实名 = 1
        }

        /// <summary>
        /// 不记名
        /// </summary>
        public enum CardTypeInfoSubmitType_UnName
        {
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

        public string RowNumber { get; set; }
        
        private Guid _Id = Helper.SystemConstant.GuidEmpty;
        /// <summary>
        /// 
        /// </summary>
        public Guid Id
        { get { return _Id; } set { _Id = value; } }

        private Guid _SaasId = Helper.SystemConstant.GuidEmpty;
        /// <summary>
        /// 
        /// </summary>
        public Guid SaasId
        { get { return _SaasId; } set { _SaasId = value; } }      
      
        private string _Batch = "";
        /// <summary>
        /// 
        /// </summary>
        public string Batch
        { get { return _Batch; } set { _Batch = value; } }

        private string _Name = "";
        /// <summary>
        /// 名称
        /// </summary>
        public string Name
        { get { return _Name; } set { _Name = value; } }

        private CardTypeInfoPurpose _Purpose = CardTypeInfoPurpose.非临时;
        /// <summary>
        /// 用途
        /// </summary>
        public CardTypeInfoPurpose Purpose
        { get { return _Purpose; } set { _Purpose = value; } }

        private CardTypeInfoCostType _CostType = CardTypeInfoCostType.金额卡;
        /// <summary>
        /// 扣费类型
        /// </summary>
        public CardTypeInfoCostType CostType
        { get { return _CostType; } set { _CostType = value; } }

        private CardTypeInfoSubmitType _SubmitType = CardTypeInfoSubmitType.实名;
        /// <summary>
        /// 注册类型
        /// </summary>
        public CardTypeInfoSubmitType SubmitType
        { get { return _SubmitType; } set { _SubmitType = value; } }

        private DateTime _EffectDate = Helper.SystemConstant.DateTimeEmpty;
        /// <summary>
        /// 
        /// </summary>
        public DateTime EffectDate
        { get { return _EffectDate; } set { _EffectDate = value; } }

        private DateTime _OutDate = Helper.SystemConstant.DateTimeEmpty;
        /// <summary>
        /// 
        /// </summary>
        public DateTime OutDate
        { get { return _OutDate; } set { _OutDate = value; } }

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


        private int _DefaultTimes = 0;
        /// <summary>
        /// 预设次数
        /// </summary>
        public int DefaultTimes
        { get { return _DefaultTimes; } set { _DefaultTimes = value; } }

        private decimal _DefaultMoney = 0;
        /// <summary>
        /// 预设金额
        /// </summary>
        public decimal DefaultMoney
        { get { return _DefaultMoney; } set { _DefaultMoney = value; } }

        private int _DefaultChargesDate = 0;
        /// <summary>
        /// 预设时间
        /// </summary>
        public int DefaultChargesDate
        { get { return _DefaultChargesDate; } set { _DefaultChargesDate = value; } }


        private CardTypeInfoDefaultCardStatus _DefaultCardStatus = 0;
        /// <summary>
        /// 预设卡状态
        /// </summary>
        public CardTypeInfoDefaultCardStatus DefaultCardStatus
        { get { return _DefaultCardStatus; } set { _DefaultCardStatus = value; } }

        private CardTypeInfoDefaultChange _DefaultChange = 0;
        /// <summary>
        /// 是否预设可变
        /// </summary>
        public CardTypeInfoDefaultChange DefaultChange
        { get { return _DefaultChange; } set { _DefaultChange = value; } }


        private string _Memo = "";
        /// <summary>
        /// 备注
        /// </summary>
        public string Memo
        { get { return _Memo; } set { _Memo = value; } }

        private CardTypeInfoStatus _Status = CardTypeInfoStatus.已启用;
        /// <summary>
        /// 状态
        /// </summary>
        public CardTypeInfoStatus Status
        { get { return _Status; } set { _Status = value; } }

        private DateTime _CreateTime = Helper.SystemConstant.DateTimeEmpty;
        /// <summary>
        /// 
        /// </summary>
        public DateTime CreateTime
        { get { return _CreateTime; } set { _CreateTime = value; } }

        private Guid _CreateUser = Helper.SystemConstant.GuidEmpty;
        /// <summary>
        /// 
        /// </summary>
        public Guid CreateUser
        { get { return _CreateUser; } set { _CreateUser = value; } }

        private DateTime _ModifyTime = Helper.SystemConstant.DateTimeEmpty;
        /// <summary>
        /// 
        /// </summary>
        public DateTime ModifyTime
        { get { return _ModifyTime; } set { _ModifyTime = value; } }

        private Guid _ModifyUser = Helper.SystemConstant.GuidEmpty;
        /// <summary>
        /// 
        /// </summary>
        public Guid ModifyUser
        { get { return _ModifyUser; } set { _ModifyUser = value; } }

        /// <summary>
        /// 扩展SaasId
        /// </summary>
        private int _ext_saas_id;

        /// <summary>
        /// 扩展卡类型Id
        /// </summary>
        private int _ext_card_type_id;

        /// <summary>
        /// 扩展SaasId
        /// </summary>
        public int extSaasId
        {
            get { return _ext_saas_id; }
            set { _ext_saas_id = value; }
        }

        /// <summary>
        /// 扩展卡类型Id
        /// </summary>
        public int extCardTypeId
        {
            get { return _ext_card_type_id; }
            set { _ext_card_type_id = value; }
        }
    }
}
