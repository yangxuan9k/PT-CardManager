using System;
using System.Collections.Generic;
using System.Text;

using Bouwa.Helper;
using Bouwa.ITSP2V31.Model;
using System.Data;
using System.Collections;
using System.Xml;
using System.Configuration;

namespace Bouwa.ITSP2V31.DAL
{
    [Serializable]
    public class HistoryDAL : Bouwa.ITSP2V31.IDAL.IHistoryDAL
    {
        SystemMessage _objSystemMessage = new SystemMessage();
        SystemMessageInfo _objSystemMessageInfo = new SystemMessageInfo();

        public IList<HistoryInfo> SearchByCondition(Dictionary<string, object> arr, DataAccessor theDataAccessor, ref  SystemMessageInfo theSystemMessageInfo)
        {
            HistoryInfo objHistoryInfo = new HistoryInfo();
            IList<HistoryInfo> _objIHistoryInfo = new List<HistoryInfo>();
            //转换为Datatable
            DataTable dt = ConvertMethod.getDateTable("table", arr);
            //dataTable转换为XML
            string objXmlDocument = Helper.ConvertMethod.CDataToXml(dt);

            ////加密xml进行返回
            string Parameter = ConvertMethod.EncryptDESByKey8(objXmlDocument, ConfigurationSettings.AppSettings["password"]);

            DataSet objDataSet = new DataSet();
            try
            {
                string strReturnXml = ServiceWrapper.Current.SelectCarInformationHistoryRecord(Parameter);

                //先解密成xml格式
                strReturnXml = ConvertMethod.DecryptDESByKey8(strReturnXml, ConfigurationSettings.AppSettings["password"]);

                objDataSet = Helper.FormatConvert.CXmlToDataSet(strReturnXml);
                CurrentUser.Current.TotalCount = Int32.Parse(objDataSet.Tables["tb_card_historycount"].Rows[0]["count"].ToString());
                try
                {
                    if (objDataSet.Tables.Count > 2)
                    {
                        foreach (DataRow objDataRow in objDataSet.Tables["tb_card_history"].Rows)
                        {
                            objHistoryInfo = GetInfoFromDataRow(objDataRow);
                            _objIHistoryInfo.Add(objHistoryInfo);
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
            return _objIHistoryInfo;
        }


        public IList<HistoryInfo> SearchByCondition(Hashtable theHashtable,string strOrderBy,int Size,int BeginSize, DataAccessor theDataAccessor, ref  SystemMessageInfo theSystemMessageInfo)
        {
            IList<HistoryInfo> objIListHistoryInfo = new List<HistoryInfo>();
            XmlDocument objXmlDocument = Helper.FormatConvert.HashtableToXml(theHashtable);

            DataSet objDataSet = new DataSet();
            try
            {
                string[] strReturnXml = ServiceWrapper.Current.SelectCarInformationHistoryRecordTwo(objXmlDocument.OuterXml, Size, BeginSize,strOrderBy);
                CurrentUser.Current.TotalCount = Int32.Parse(strReturnXml[0].ToString());

                objDataSet = Helper.FormatConvert.XmlToDataSet(strReturnXml[1]);
                try
                {
                    if (objDataSet.Tables.Count > 0)
                    {
                        foreach (DataRow objDataRow in objDataSet.Tables[0].Rows)
                        {
                            HistoryInfo objHistoryInfo = GetInfoFromDataRow(objDataRow);
                            objIListHistoryInfo.Add(objHistoryInfo);
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
            return objIListHistoryInfo;
        }

        public HistoryInfo GetInfoFromDataRow(DataRow theDataRow)
        {
            HistoryInfo objHistoryInfo = new HistoryInfo();
            //objHistoryInfo.SAASID = new Guid(theDataRow["saas_id"].ToString());
            //objHistoryInfo.No = theDataRow["no"].ToString();
            objHistoryInfo.NetWork = theDataRow["network"].ToString();
            objHistoryInfo.OperationMemo = theDataRow["operation_memo"].ToString();
            objHistoryInfo.OperationTime = DateTime.Parse(theDataRow["operation_time"].ToString());
            objHistoryInfo.OperationType = (HistoryInfo.OperationCardType)int.Parse(theDataRow["operation_type"].ToString());
            objHistoryInfo.AddressType = (HistoryInfo.AddressCardType)int.Parse(theDataRow["address_type"].ToString());
            objHistoryInfo.OperationUser = theDataRow["username"].ToString();
            objHistoryInfo.RowNumber = theDataRow["rowNumber"].ToString();
            return objHistoryInfo;
        }

        //public Hashtable InfoToHashtable(HistoryInfo theHistoryInfo)
        //{
        //    Hashtable objHashtable = new Hashtable();
        //    objHashtable.Add("no",theHistoryInfo.)
        //    return objHashtable;
        //}
    }
}
