using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Xml;

using Bouwa.Helper;
using Bouwa.ITSP2V31.Model;
using System.Data;
using Bouwa.Helper.Class;

namespace Bouwa.ITSP2V31.DAL
{
    [Serializable]
    public class CardInfoDAL : Bouwa.ITSP2V31.IDAL.ICardInfoDAL
   {
       public CardInfo GetById(Guid theId, DataAccessor theDataAccessor, ref  SystemMessageInfo theSystemMessageInfo)
        {
            SystemMessage _objSystemMessage = new SystemMessage();
            SystemMessageInfo _objSystemMessageInfo = new SystemMessageInfo();
           if (theId == SystemConstant.GuidEmpty) return null;

           //调用WebService,把theCardTypeInfo转成Hashtable再转成Xml以便调用
           Hashtable objHashtable = new Hashtable();
           objHashtable.Add("id", theId);
           XmlDocument objXmlDocument = Helper.FormatConvert.HashtableToXml(objHashtable);

           CardInfo objCardInfoInfo = null;
           DataSet objDataSet = new DataSet();
           try
           {
               string[] strReturnXml = ServiceWrapper.Current.SelectCardInfoByCondition(objXmlDocument.OuterXml, 1, 1, "[status] DESC");
               objDataSet = Helper.FormatConvert.XmlToDataSet(strReturnXml[1]);
               try
               {
                   if (objDataSet.Tables.Count > 0)
                   {
                       foreach (DataRow objDataRow in objDataSet.Tables[0].Rows)
                       {
                           objCardInfoInfo = GetInfoFromDataRow(objDataRow);
                       }
                   }
               }
               catch (Exception e)
               {
                   _objSystemMessageInfo = _objSystemMessage.GetInfoByCode("WebServiceParseToInfoFail");
                   _objSystemMessageInfo.Success = false;
                   _objSystemMessageInfo.Exception = e.Message;
               }
           }
           catch (Exception e)
           {
               _objSystemMessageInfo = _objSystemMessage.GetInfoByCode("WebServiceConnectFail");
               _objSystemMessageInfo.Success = false;
               _objSystemMessageInfo.Exception = e.Message;
           }

           theSystemMessageInfo = _objSystemMessageInfo;
           return objCardInfoInfo;
       }

        /// <summary>
        /// 插入初始化信息
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
       public string InsertCardInfo(string parameter)
       {
           if (string.IsNullOrEmpty(parameter)) return "";
           return  ServiceWrapper.Current.InsertCardInfo(parameter);
       }

       public IList<CardInfo> SearchByCondition(Hashtable theHashtable, DataAccessor theDataAccessor,int Size,int BeginSize,string strOrderBy, ref  SystemMessageInfo theSystemMessageInfo)
       {
           SystemMessage _objSystemMessage = new SystemMessage();
           SystemMessageInfo _objSystemMessageInfo = new SystemMessageInfo();

           IList<CardInfo> objIListCardTypeInfo = new List<CardInfo>();
           XmlDocument objXmlDocument = Helper.FormatConvert.HashtableToXml(theHashtable);

           DataSet objDataSet = new DataSet();
           try
           {
               string[] strReturnXml = ServiceWrapper.Current.SelectCardInfoByCondition(objXmlDocument.OuterXml, Size, BeginSize, strOrderBy);

               CurrentUser.Current.TotalCount = Int32.Parse(strReturnXml[0].ToString());

               objDataSet = Helper.FormatConvert.XmlToDataSet(strReturnXml[1]);
               try
               {
                   if (objDataSet.Tables.Count > 0)
                   {
                       foreach (DataRow objDataRow in objDataSet.Tables[0].Rows)
                       {
                           CardInfo objCardTypeInfo = GetInfoFromDataRow(objDataRow);
                           objIListCardTypeInfo.Add(objCardTypeInfo);
                       }
                   }
               }
               catch (Exception e)
               {
                   _objSystemMessageInfo = _objSystemMessage.GetInfoByCode("WebServiceParseToInfoFail");
                   _objSystemMessageInfo.Success = false;
                   _objSystemMessageInfo.Exception = e.Message;
               }
           }
           catch (Exception e)
           {
               _objSystemMessageInfo = _objSystemMessage.GetInfoByCode("WebServiceConnectFail");
               _objSystemMessageInfo.Success = false;
               _objSystemMessageInfo.Exception = e.Message;
           }

           theSystemMessageInfo = _objSystemMessageInfo;
           return objIListCardTypeInfo;
       }

       public CardInfo GetInfoFromDataRow(DataRow theDataRow)
       {
           CardInfo objCardInfoInfo = new CardInfo();
           objCardInfoInfo.id = new Guid(theDataRow["id"].ToString());
           //objCardInfoInfo.saas_id = new Guid(theDataRow["saas_id"].ToString());
           objCardInfoInfo.batch = theDataRow["batch"].ToString();
           objCardInfoInfo.no = theDataRow["no"].ToString();
           objCardInfoInfo.memo = theDataRow["memo"].ToString();
           objCardInfoInfo.cost_type = (CardInfo.CardTypeInfoCostType)int.Parse(theDataRow["cost_type"].ToString());
           objCardInfoInfo.purpose = (CardInfo.CardTypeInfoPurpose)int.Parse(theDataRow["purpose"].ToString());
           objCardInfoInfo.submit_type = (CardInfo.CardTypeInfoSubmitType)int.Parse(theDataRow["submit_type"].ToString());
           objCardInfoInfo.status = (CardInfo.CardTypeInfoDefaultCardStatus)int.Parse(theDataRow["status"].ToString());
           objCardInfoInfo.CreateTime = DateTime.Parse(theDataRow["create_time"].ToString());
           objCardInfoInfo.efffect_date = DateTime.Parse(theDataRow["efffect_date"].ToString());
           objCardInfoInfo.end_date = DateTime.Parse(theDataRow["end_date"].ToString());
           objCardInfoInfo.charges_date = Int32.Parse(theDataRow["charges_date"].ToString());
           objCardInfoInfo.money = decimal.Parse(theDataRow["money"].ToString() == "" ? "0" : theDataRow["money"].ToString());
           objCardInfoInfo.times = Int32.Parse(theDataRow["times"].ToString());
           objCardInfoInfo.CardType = theDataRow["card_type"].ToString();
           objCardInfoInfo.MaxChargesDate = Int32.Parse(theDataRow["max_charges_date"].ToString());
           objCardInfoInfo.MaxMoney = decimal.Parse(theDataRow["max_money"].ToString() == "" ? "0" : theDataRow["max_money"].ToString());
           objCardInfoInfo.MaxTimes = Int32.Parse(theDataRow["max_times"].ToString());
           objCardInfoInfo.card_id = theDataRow["card_id"].ToString();
           objCardInfoInfo.RowNumber = theDataRow["rowNumber"].ToString();
           objCardInfoInfo.Card_type_id = new Guid(theDataRow["card_type_id"].ToString());
           objCardInfoInfo.modify_time = DateTime.Parse(theDataRow["modify_time"].ToString());
           return objCardInfoInfo;
       }

       public Hashtable InfoToHashtable(CardInfo theCardInfo)
       {
           Hashtable objHashtable = new Hashtable();
           objHashtable.Add("id", theCardInfo.id);
           objHashtable.Add("saas_id", theCardInfo.saas_id);
           objHashtable.Add("card_type", theCardInfo.CardType);
           objHashtable.Add("card_id",theCardInfo.card_id);
           objHashtable.Add("no", theCardInfo.no);

           objHashtable.Add("batch", theCardInfo.batch);
           objHashtable.Add("purpose", theCardInfo.purpose);
           objHashtable.Add("cost_type", theCardInfo.cost_type);
           objHashtable.Add("submit_type", theCardInfo.submit_type);
           objHashtable.Add("efffect_date", theCardInfo.efffect_date);
           objHashtable.Add("end_date", theCardInfo.end_date);

           objHashtable.Add("times", theCardInfo.times);
           objHashtable.Add("money", theCardInfo.money);
           objHashtable.Add("charges_date", theCardInfo.charges_date);

           objHashtable.Add("max_times", theCardInfo.MaxTimes);
           objHashtable.Add("max_money", theCardInfo.MaxMoney);
           objHashtable.Add("max_charges_date", theCardInfo.MaxChargesDate);

           objHashtable.Add("memo", theCardInfo.memo);
           objHashtable.Add("status", theCardInfo.status.ToString("D"));
           objHashtable.Add("create_user", theCardInfo.create_user);
           objHashtable.Add("create_time", theCardInfo.create_time);
           objHashtable.Add("modify_user", theCardInfo.modify_user);
           objHashtable.Add("modify_time", theCardInfo.modify_time);
           return objHashtable;
       }

       /// <summary>
       /// 执行会员卡充值
       /// </summary>
       /// <param name="Parameter">需要传送的参数</param>
       /// <returns></returns>
       public string InsertCarInformationHistoryRecord(string Parameter)
       {
           try
           {
               return ServiceWrapper.Current.InsertCarInformationHistoryRecord(Parameter);
           }
           catch (Exception e)
           {
               throw new Exception(e.Message);
           }
       }

       /// <summary>
       /// 执行卡重置
       /// </summary>
       /// <param name="Parameter">需要传送的参数</param>
       /// <returns></returns>
       public string ResetCarInforAndCarHistoryByID(string Parameter)
       {
           try
           {
               return ServiceWrapper.Current.ResetCarInforAndCarHistoryByID(Parameter);
           }
           catch (Exception e)
           {
               throw new Exception(e.Message);
           }
       }

       /// <summary>
       /// 执行退卡操作并写入卡历史表
       /// </summary>
       /// <param name="Parameter">需要传送的参数</param>
       /// <returns></returns>
       public string UpdateCarInfoAndBackCardHistoryRecord(string Parameter)
       {
           try
           {
               return ServiceWrapper.Current.UpdateCarInfoAndBackCardHistoryRecord(Parameter);
           }
           catch (Exception e)
           {
               throw new Exception(e.Message);
           }
       }

       /// <summary>
       /// 执行退卡操作并写入卡历史表
       /// </summary>
       /// <param name="Parameter">需要传送的参数</param>
       /// <returns></returns>
       public string UpdateCarInfoAndApplyChangeCardHistoryRecord(string Parameter)
       {
           try
           {
               return ServiceWrapper.Current.UpdateCarInfoAndApplyChangeCardHistoryRecord(Parameter);
           }
           catch (Exception e)
           {
               throw new Exception(e.Message);
           }
       }

        /// <summary>
       /// 执行换卡操作,写入卡历史表,同时备份原来的卡信息
        /// </summary>
        /// <param name="InitParameter">初始化参数</param>
        /// <param name="HistoryParameter">卡历史参数</param>
        /// <param name="ResetCardParameter">备份卡信息参数</param>
        /// <returns></returns>
       public string UpdateCarInfoAndChangeCardHistoryRecord(string InitParameter, string HistoryParameter)
       {
           try
           {
               return ServiceWrapper.Current.UpdateCarInfoAndChangeCardHistoryRecord( InitParameter,  HistoryParameter);
           }
           catch (Exception e)
           {
               throw new Exception(e.Message);
           }
       }
    }
}
