using System;
using System.Collections.Generic;
using System.Text;
using Bouwa.Helper;
using Bouwa.ITSP2V31.Model;
using System.Xml;
using System.Collections;
using System.Data;
using System.Configuration;

namespace Bouwa.ITSP2V31.DAL
{
    [Serializable]
    public class LoginDAL : Bouwa.ITSP2V31.IDAL.ILoginDAL
    {

        /// <summary>
        /// 根据SAASID跟用户账户密码查询该C/S用户是否存在
        /// </summary>
        /// <param name="theHashtable"></param>
        /// <param name="theDataAccessor"></param>
        /// <param name="theSystemMessageInfo"></param>
        /// <returns></returns>
        public UserInfo SelectUserCountByID(Dictionary<string, object> arr, DataAccessor theDataAccessor, ref  SystemMessageInfo theSystemMessageInfo)
        {
            SystemMessage _objSystemMessage = new SystemMessage();
            SystemMessageInfo _objSystemMessageInfo = new SystemMessageInfo();

            UserInfo objUserInfo = new UserInfo();

            //转换为Datatable
            DataTable dt = ConvertMethod.getDateTable("table", arr);
            //dataTable转换为XML
            string objXmlDocument = Helper.ConvertMethod.CDataToXml(dt);

            ////加密xml进行返回
            string Parameter = ConvertMethod.EncryptDESByKey8(objXmlDocument, ConfigurationSettings.AppSettings["password"]);

            DataSet objDataSet = new DataSet();
            try
            {
                string strReturnXml = ServiceWrapper.Current.ClientUserAuthentication(Parameter);

                //先解密成xml格式
                strReturnXml = ConvertMethod.DecryptDESByKey8(strReturnXml, ConfigurationSettings.AppSettings["password"]);

                objDataSet = Helper.FormatConvert.CXmlToDataSet(strReturnXml);
                try
                {
                    if (objDataSet.Tables.Count > 1)
                    {
                        foreach (DataRow objDataRow in objDataSet.Tables["tb_user"].Rows)
                        {
                            objUserInfo = GetInfoFromDataRow(objDataRow);
                        }
                    }
                    if (objDataSet.Tables.Count == 3)
                    {
                        objUserInfo.IsPower = true;
                        foreach (DataRow objDataRow in objDataSet.Tables["tb_right"].Rows)
                        {
                            //解析权限 2012.01.04 zhangwenjin add
                            objUserInfo.RightInfoList.Add(GetRightInfoFromDataRow(objDataRow));
                        }
                    }
                    if (objDataSet.Tables.Count == 1)
                    {
                        return null;
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
            return objUserInfo;
        }

        /// <summary>
        /// 对象属性赋值
        /// </summary>
        /// <param name="theDataRow"></param>
        /// <returns></returns>
        public UserInfo GetInfoFromDataRow(DataRow theDataRow)
        {
            UserInfo objUserInfo = new UserInfo();
            objUserInfo.UserId = new Guid(theDataRow["tus_user_id"].ToString());
            objUserInfo.UserName = theDataRow["tus_user_name"].ToString();
            objUserInfo.UserCode = theDataRow["tus_user_code"].ToString();
            objUserInfo.PassWord = StringUtil.MD5(theDataRow["tus_password"].ToString());
            objUserInfo.UserStatus = theDataRow["tus_status"].ToString();

            if (theDataRow.Table.Columns.Contains("network_id"))
            {
                objUserInfo.NetWorkID = new Guid(theDataRow["network_id"].ToString());
            }
            return objUserInfo;
        }

        public RightInfo GetRightInfoFromDataRow(DataRow theDataRow)
        {
            RightInfo objRightInfo = new RightInfo();
            objRightInfo.Id = new Guid(theDataRow["tbri_id"].ToString());
            objRightInfo.Code = theDataRow["tbri_code"].ToString();
            objRightInfo.Name = theDataRow["tbri_name"].ToString();
            objRightInfo.FatherId = int.Parse(theDataRow["tbri_father_id"].ToString());
            objRightInfo.Path = theDataRow["tbri_right_path"].ToString();
            objRightInfo.Type = int.Parse(theDataRow["tbri_right_type"].ToString());
            objRightInfo.UserId = new Guid(theDataRow["tsur_user_id"].ToString());
            return objRightInfo;
        }

        public bool IsRightByUserIdRightInfoListRightCode(Guid theUserId, IList<RightInfo> theRightInfoList, string theRightCode, DataAccessor theDataAccessor, ref SystemMessageInfo theSystemMessageInfo)
        {
            bool bolReturn = false;
            foreach (RightInfo objRightInfo in theRightInfoList)
            {
                if (objRightInfo.UserId == theUserId && objRightInfo.Code == theRightCode)
                {
                    return true;
                }
            }
            return bolReturn;
        }

        /// <summary>
        /// 检查是否有新版本
        /// </summary>
        /// <param name="systemVersion">系统版本</param>
        /// <param name="URL">输出参数</param>
        /// <returns></returns>
        public bool Programkeep(string systemVersion, out string URL)
        {
            try
            {
                return ServiceWrapper.Current.Programkeep(systemVersion,2,out URL);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
