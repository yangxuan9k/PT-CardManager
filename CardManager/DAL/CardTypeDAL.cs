using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;
using System.Collections;
using System.Xml;

using Bouwa.Helper;
using Bouwa.ITSP2V31.Model;

namespace Bouwa.ITSP2V31.DAL
{
    [Serializable]
    public class CardTypeDAL : Bouwa.ITSP2V31.IDAL.ICardTypeDAL
    {

        //public MessageInfo IsValid(CardTypeInfo theCardTypeInfo, DataAccessor theDataAccessor)
        //{
        //    _objMessageInfo.Success = true;
        //    return _objMessageInfo;
        //}

        public SystemMessageInfo Insert(ref CardTypeInfo theCardTypeInfo, DataAccessor theDataAccessor)
        {
            SystemMessage _objSystemMessage = new SystemMessage();
            SystemMessageInfo _objSystemMessageInfo = new SystemMessageInfo();

            //调用WebService,把theCardTypeInfo转成Hashtable再转成Xml以便调用
            Hashtable objHashtable = InfoToHashtable(theCardTypeInfo);
            XmlDocument objXmlDocument = Helper.FormatConvert.HashtableToXml(objHashtable);
            //Hashtable objHashtable2=  Helper.FormatConvert.XmlToHashtable(objXmlDocument);
            try
            {
               // Itsp2WebServiceNamespace.Itsp2WebService objItsp2WebService = new Itsp2WebServiceNamespace.Itsp2WebService();

                ServiceWrapper.Current.InsertCardTypeByCondition(objXmlDocument.OuterXml);
                //objItsp2WebService.InsertCardTypeByCondition(objXmlDocument.OuterXml);

            }
            catch (Exception e)
            {
                _objSystemMessageInfo = _objSystemMessage.GetInfoByCode("WebServiceConnectFail");
                _objSystemMessageInfo.Success = false;
                _objSystemMessageInfo.Exception = e.Message;
                return _objSystemMessageInfo;
            }

            _objSystemMessageInfo = _objSystemMessage.GetInfoByCode("DataSaveSucceeded");
            return _objSystemMessageInfo;
        }

        public SystemMessageInfo Update(CardTypeInfo theCardTypeInfo, DataAccessor theDataAccessor)
        {
            SystemMessage _objSystemMessage = new SystemMessage();
            SystemMessageInfo _objSystemMessageInfo = new SystemMessageInfo();

            //调用WebService,把theCardTypeInfo转成Hashtable再转成Xml以便调用
            Hashtable objHashtable = InfoToHashtable(theCardTypeInfo);
            XmlDocument objXmlDocument = Helper.FormatConvert.HashtableToXml(objHashtable);
            //Hashtable objHashtable2=  Helper.FormatConvert.XmlToHashtable(objXmlDocument);
            try
            {
                //Itsp2WebServiceNamespace.Itsp2WebService objItsp2WebService = new Itsp2WebServiceNamespace.Itsp2WebService();
                //objItsp2WebService.UpdateCardTypeByCondition(objXmlDocument.OuterXml);
                ServiceWrapper.Current.UpdateCardTypeByCondition(objXmlDocument.OuterXml);

            }
            catch (Exception e)
            {
                _objSystemMessageInfo = _objSystemMessage.GetInfoByCode("WebServiceConnectFail");
                _objSystemMessageInfo.Success = false;
                _objSystemMessageInfo.Exception = e.Message;
                return _objSystemMessageInfo;
            }

            _objSystemMessageInfo = _objSystemMessage.GetInfoByCode("DataSaveSucceeded");
            return _objSystemMessageInfo;
        }

        public SystemMessageInfo Delete(Guid theId, DataAccessor theDataAccessor)
        {
            SystemMessage _objSystemMessage = new SystemMessage();
            SystemMessageInfo _objSystemMessageInfo = new SystemMessageInfo();

            if (theId == SystemConstant.GuidEmpty) return null;

            //调用WebService,把theCardTypeInfo转成Hashtable再转成Xml以便调用
            //Hashtable objHashtable = new Hashtable();
            //objHashtable.Add("id", theId);
            //这里的后台写法仅支持传一个对象删除的方法
            CardTypeInfo objCardTypeInfoCondition = new CardTypeInfo();
            objCardTypeInfoCondition.Id = theId;
            Hashtable objHashtable = InfoToHashtable(objCardTypeInfoCondition);           
            XmlDocument objXmlDocument = Helper.FormatConvert.HashtableToXml(objHashtable);         
         
            try
            {
                //Itsp2WebServiceNamespace.Itsp2WebService objItsp2WebService = new Itsp2WebServiceNamespace.Itsp2WebService();
                //objItsp2WebService.UpdateCardTypeByCondition(objXmlDocument.OuterXml);
                ServiceWrapper.Current.UpdateCardTypeByCondition(objXmlDocument.OuterXml);

            }
            catch (Exception e)
            {
                _objSystemMessageInfo = _objSystemMessage.GetInfoByCode("WebServiceConnectFail");
                _objSystemMessageInfo.Success = false;
                _objSystemMessageInfo.Exception = e.Message;
                return _objSystemMessageInfo;
            }

            _objSystemMessageInfo = _objSystemMessage.GetInfoByCode("DataDeleteSucceeded");
            return _objSystemMessageInfo;
        }

        public CardTypeInfo GetById(Guid theId, DataAccessor theDataAccessor, ref  SystemMessageInfo theSystemMessageInfo)
        {
            SystemMessage _objSystemMessage = new SystemMessage();
            SystemMessageInfo _objSystemMessageInfo = new SystemMessageInfo();
            if (theId == SystemConstant.GuidEmpty) return null;

            //调用WebService,把theCardTypeInfo转成Hashtable再转成Xml以便调用
            Hashtable objHashtable = new Hashtable();
            objHashtable.Add("id", theId);
            //这里的后台写法仅支持传一个对象删除的方法
            //CardTypeInfo objCardTypeInfoCondition = new CardTypeInfo();
            //objCardTypeInfoCondition.Id = theId;
            //Hashtable objHashtable = InfoToHashtable(objCardTypeInfoCondition);
            XmlDocument objXmlDocument = Helper.FormatConvert.HashtableToXml(objHashtable);      

            CardTypeInfo objCardTypeInfo = null;
            DataSet objDataSet = new DataSet();
            try
            {
                //Itsp2WebServiceNamespace.Itsp2WebService objItsp2WebService = new Itsp2WebServiceNamespace.Itsp2WebService();
                //string strReturnXml = objItsp2WebService.SelectCardTypeByCondition(objXmlDocument.OuterXml);

                string[] strReturnXml = ServiceWrapper.Current.SelectCardTypeByCondition(objXmlDocument.OuterXml, "effect_date desc",1,1);
                objDataSet = Helper.FormatConvert.XmlToDataSet(strReturnXml[1]);
                try
                {
                    if (objDataSet.Tables.Count > 0)
                    {
                        foreach (DataRow objDataRow in objDataSet.Tables[0].Rows)
                        {
                            objCardTypeInfo = GetInfoFromDataRow(objDataRow);
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
            return objCardTypeInfo;
        }

        public IList<CardTypeInfo> SearchByCondition(Hashtable theHashtable,string OrderBy, DataAccessor theDataAccessor,int Size,int BeginSize, ref  SystemMessageInfo theSystemMessageInfo)
        {
            SystemMessage _objSystemMessage = new SystemMessage();
            SystemMessageInfo _objSystemMessageInfo = new SystemMessageInfo();

            IList<CardTypeInfo> objIListCardTypeInfo = new List<CardTypeInfo>();
            XmlDocument objXmlDocument = Helper.FormatConvert.HashtableToXml(theHashtable);
           
            DataSet objDataSet = new DataSet();
            try
            {
                string[] strReturnXml = ServiceWrapper.Current.SelectCardTypeByCondition(objXmlDocument.OuterXml, OrderBy,Size,BeginSize);
                CurrentUser.Current.TotalCount = Int32.Parse(strReturnXml[0].ToString());
               
                objDataSet = Helper.FormatConvert.XmlToDataSet(strReturnXml[1]);
                try
                {
                    if (objDataSet.Tables.Count > 0)
                    {
                        foreach (DataRow objDataRow in objDataSet.Tables[0].Rows)
                        {
                            CardTypeInfo objCardTypeInfo = GetInfoFromDataRow(objDataRow);
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

        public IList<CardTypeInfo> SearchAll(DataAccessor theDataAccessor, ref  SystemMessageInfo theSystemMessageInfo)
        {
            SystemMessage _objSystemMessage = new SystemMessage();
            SystemMessageInfo _objSystemMessageInfo = new SystemMessageInfo();

            //调用WebService,把theCardTypeInfo转成Hashtable再转成Xml以便调用
            IList<CardTypeInfo> objIListCardTypeInfo = new List<CardTypeInfo>();
            DataSet objDataSet = new DataSet();
            try
            {
                //Itsp2WebServiceNamespace.Itsp2WebService objItsp2WebService = new Itsp2WebServiceNamespace.Itsp2WebService();
                //string strReturnXml = objItsp2WebService.GetCarType();

               string strReturnXml= ServiceWrapper.Current.GetCarType();

                objDataSet = Helper.FormatConvert.XmlToDataSet(strReturnXml);
            }
            catch (Exception e)
            {
                _objSystemMessageInfo = _objSystemMessage.GetInfoByCode("WebServiceConnectFail");
                _objSystemMessageInfo.Success = false;
                _objSystemMessageInfo.Exception = e.Message;
                return null;
            }

            try
            {
                if (objDataSet.Tables.Count > 0)
                {
                    foreach (DataRow objDataRow in objDataSet.Tables[0].Rows)
                    {
                        CardTypeInfo objCardTypeInfo = GetInfoFromDataRow(objDataRow);
                        objIListCardTypeInfo.Add(objCardTypeInfo);
                    }
                }
            }
            catch (Exception e)
            {
                _objSystemMessageInfo = _objSystemMessage.GetInfoByCode("WebServiceParseToInfoFail");
                _objSystemMessageInfo.Success = false;
                _objSystemMessageInfo.Exception = e.Message;
                return null;
            }

            theSystemMessageInfo = _objSystemMessageInfo;
            return objIListCardTypeInfo;
        }


        public string GetRegisterType(Hashtable theHashTable, DataAccessor theDataAccessor)
        {
            SystemMessage _objSystemMessage = new SystemMessage();
            SystemMessageInfo _objSystemMessageInfo = new SystemMessageInfo();
            string RegisterType = string.Empty;
            XmlDocument objXmlDocument = Helper.FormatConvert.HashtableToXml(theHashTable);

            DataSet objDataSet = new DataSet();
            try
            {
                string strReturnXml = ServiceWrapper.Current.GetRegisterType(objXmlDocument.OuterXml);

                objDataSet = Helper.FormatConvert.XmlToDataSet(strReturnXml);
                if (objDataSet.Tables.Count > 0)
                {
                    RegisterType = objDataSet.Tables[0].Rows[0]["tcit_parameter_value"] == null ? "全部" : objDataSet.Tables[0].Rows[0]["tcit_parameter_value"].ToString();
                }
            }
            catch (Exception e)
            {
                _objSystemMessageInfo = _objSystemMessage.GetInfoByCode("WebServiceConnectFail");
                _objSystemMessageInfo.Success = false;
                _objSystemMessageInfo.Exception = e.Message;
            }
            //theSystemMessageInfo = _objSystemMessageInfo;
            return RegisterType;
        }

        public CardTypeInfo GetInfoFromDataRow(DataRow theDataRow)
        {
            CardTypeInfo objCardTypeInfo = new CardTypeInfo();
            objCardTypeInfo.Id = new Guid(theDataRow["id"].ToString());
            objCardTypeInfo.SaasId = new Guid(theDataRow["saas_id"].ToString());
            objCardTypeInfo.Batch = theDataRow["batch"].ToString();
            objCardTypeInfo.Name = theDataRow["name"].ToString();
            objCardTypeInfo.Memo = theDataRow["memo"].ToString();
            objCardTypeInfo.CostType = (CardTypeInfo.CardTypeInfoCostType)int.Parse(theDataRow["cost_type"].ToString());
            objCardTypeInfo.Purpose = (CardTypeInfo.CardTypeInfoPurpose)int.Parse(theDataRow["purpose"].ToString());
            objCardTypeInfo.SubmitType = (CardTypeInfo.CardTypeInfoSubmitType)int.Parse(theDataRow["submit_type"].ToString());
            objCardTypeInfo.Status = (CardTypeInfo.CardTypeInfoStatus)int.Parse(theDataRow["status"].ToString());
            objCardTypeInfo.CreateTime = DateTime.Parse(theDataRow["create_time"].ToString());
            objCardTypeInfo.EffectDate = DateTime.Parse(theDataRow["effect_date"].ToString());
            objCardTypeInfo.OutDate = DateTime.Parse(theDataRow["out_date"].ToString());
            objCardTypeInfo.MaxChargesDate = Int32.Parse(theDataRow["max_charges_date"].ToString());
            objCardTypeInfo.MaxMoney = decimal.Parse(theDataRow["max_money"].ToString() == "" ? "0" : theDataRow["max_money"].ToString());
            objCardTypeInfo.MaxTimes = Int32.Parse(theDataRow["max_times"].ToString());
            objCardTypeInfo.DefaultChargesDate = Int32.Parse(theDataRow["default_charges_date"].ToString());
            objCardTypeInfo.DefaultMoney = decimal.Parse(theDataRow["default_money"].ToString() == "" ? "0" : theDataRow["default_money"].ToString());
            objCardTypeInfo.DefaultTimes = Int32.Parse(theDataRow["default_times"].ToString());
            objCardTypeInfo.DefaultChange = (CardTypeInfo.CardTypeInfoDefaultChange)int.Parse(theDataRow["default_change"].ToString());
            objCardTypeInfo.DefaultCardStatus = (CardTypeInfo.CardTypeInfoDefaultCardStatus)int.Parse(theDataRow["default_card_status"].ToString());
            objCardTypeInfo.RowNumber = theDataRow["rowNumber"].ToString();
            objCardTypeInfo.extSaasId = Int32.Parse(string.IsNullOrEmpty(theDataRow["ext_saas_id"].ToString()) ? "0" : theDataRow["ext_saas_id"].ToString());
            objCardTypeInfo.extCardTypeId = Int32.Parse(string.IsNullOrEmpty(theDataRow["ext_card_type_id"].ToString()) ? "0" : theDataRow["ext_card_type_id"].ToString());
            return objCardTypeInfo;
        }

        //针对WebSerice转换成Hashtable来转输

        public Hashtable InfoToHashtable(CardTypeInfo theCardTypeInfo)
        {
            Hashtable objHashtable = new Hashtable();
            objHashtable.Add("id", theCardTypeInfo.Id);
            objHashtable.Add("saas_id", theCardTypeInfo.SaasId);
            objHashtable.Add("batch", theCardTypeInfo.Batch);
            objHashtable.Add("name", theCardTypeInfo.Name);
            objHashtable.Add("purpose", theCardTypeInfo.Purpose);
            objHashtable.Add("cost_type", theCardTypeInfo.CostType);
            objHashtable.Add("submit_type", theCardTypeInfo.SubmitType);
            objHashtable.Add("effect_date", theCardTypeInfo.EffectDate);
            objHashtable.Add("out_date", theCardTypeInfo.OutDate);
            objHashtable.Add("max_times", theCardTypeInfo.MaxTimes);
            objHashtable.Add("max_money", theCardTypeInfo.MaxMoney);
            objHashtable.Add("max_charges_date", theCardTypeInfo.MaxChargesDate);

            objHashtable.Add("default_charges_date", theCardTypeInfo.DefaultChargesDate);
            objHashtable.Add("default_money", theCardTypeInfo.DefaultMoney);
            objHashtable.Add("default_times", theCardTypeInfo.DefaultTimes);
            objHashtable.Add("default_change", theCardTypeInfo.DefaultChange.ToString("D"));
            objHashtable.Add("default_card_status", theCardTypeInfo.DefaultCardStatus.ToString("D"));

            objHashtable.Add("memo", theCardTypeInfo.Memo);
            objHashtable.Add("status", theCardTypeInfo.Status.ToString("D"));
            objHashtable.Add("create_user", theCardTypeInfo.CreateUser);
            objHashtable.Add("create_time", theCardTypeInfo.CreateTime);
            objHashtable.Add("modify_user", theCardTypeInfo.ModifyUser);
            objHashtable.Add("modify_time", theCardTypeInfo.ModifyTime);
            return objHashtable;
        }
    }
}
