using System;
using System.Collections.Generic;
using System.Text;
using Bouwa.Helper;
using Bouwa.Helper.Class;
using Bouwa.ITSP2V31.IDAL;
using Bouwa.ITSP2V31.DAL;
using Bouwa.ITSP2V31.Model;
using System.Collections;
using System.Data;
using System.Xml;

namespace Bouwa.ITSP2V31.BLL
{
  public  class CardInfoBLL
  {
      SystemMessageInfo _objMessageInfo = new SystemMessageInfo();
      private static readonly ICardInfoDAL _objICardInfoDAL = new CardInfoDAL();

        public IList<CardInfo> SearchByCondition(Hashtable theHashtable, DataAccessor theDataAccessor,int Size,int BeginSize,string strOrderBy, ref  SystemMessageInfo theSystemMessageInfo)
        {
            return _objICardInfoDAL.SearchByCondition(theHashtable, theDataAccessor,Size,BeginSize,strOrderBy, ref theSystemMessageInfo);        
        }

        public CardInfo GetById(Guid theId, DataAccessor theDataAccessor, ref  SystemMessageInfo theSystemMessageInfo)
        {
            return _objICardInfoDAL.GetById(theId, theDataAccessor, ref theSystemMessageInfo);
        }


        /// <summary>
        /// 根据卡密码返回卡上信息
        /// </summary>
        /// <param name="key">卡密码</param>
        /// <returns>返回对象</returns>
        public CardInfo GetCardInfoByCard(string key,out int status) {
            status = 0;
            try
            {
                CardInfo card = new CardInfo();
                string[] mary1 = ConvertToBytes(RFIDClass.ReadCardAndReturnStatus(key, 1));
                status = Convert.ToInt32( mary1[4]); //保存状态
                if (mary1[4] != "0")
                {
                    return card;
                }
                string kuai0 = mary1[1]; //获得所有块0的值
                string kuai1 = mary1[2]; //获得所有块1的值
                card.card_id = mary1[0];//卡内编号
                card.no = kuai0.Substring(9);//卡面编号
                card.cost_type = (Bouwa.ITSP2V31.Model.CardInfo.CardTypeInfoCostType)Convert.ToInt32(kuai1.Substring(12,1)); //扣费类型
                card.status = (Bouwa.ITSP2V31.Model.CardInfo.CardTypeInfoDefaultCardStatus)Convert.ToInt32(kuai1.Substring(13, 1)); //卡状态
                
                if (card.cost_type == CardInfo.CardTypeInfoCostType.金额卡)
                {
                    int p=int.Parse(kuai0.Substring(4, 5));
                    card.money = decimal.Parse( ((p/10)+"."+p%10+"0"));
                }
                else if (card.cost_type == CardInfo.CardTypeInfoCostType.限次卡)
                {
                    card.times = int.Parse(kuai0.Substring(4, 5));
                }
                else if (card.cost_type == CardInfo.CardTypeInfoCostType.限期卡)
                {
                    card.end_date = DateTime.Parse(ConvertToDateTimeByString("20" + kuai1.Substring(6, 6))); //最晚到期时间就是限期卡的时间
                }
                else if (card.cost_type == CardInfo.CardTypeInfoCostType.限时卡)
                {
                    card.charges_date = int.Parse(kuai0.Substring(4, 4)) * 60 + int.Parse(kuai0.Substring(8, 1)) *10;

                }
                return card; //返回对象
            }
            catch (Exception ex)
            {
                return null;
            }
            
        }
        
        /// <summary>
        /// 执行后台初始化
        /// </summary>
        /// <param name="_cardInfo">卡信息对象</param>
        /// <param name="key">密码</param>
        /// <param name="isAdd"></param>
        /// <returns></returns>
        public string InsertCardInfo(Hashtable _cardInfo,Hashtable htCardInfo, DataAccessor theDataAccessor,ref SystemMessageInfo _info)
        {
           
            //调用WebService,把theCardTypeInfo转成Hashtable再转成Xml以便调用
            //Hashtable objHashtable = _objICardInfoDAL.InfoToHashtable(_cardInfo);
            XmlDocument objXmlDocument = Helper.FormatConvert.HashtableToXml(_cardInfo);
            string message = _objICardInfoDAL.InsertCardInfo(HelperClass.EncryptDESByKey8(objXmlDocument.OuterXml));

            Dictionary<string, object> arr = new Dictionary<string, object>();
            string resoue = SystemConstant.StringEmpty;
            if (_cardInfo["status"]!=null){
                int length = _cardInfo["status"].Equals(CardTypeInfo.CardTypeInfoDefaultCardStatus.已初始化.ToString("D")) ? 1 : 2;
                for (int i = 0; i < length; i++)
                {
                    //执行数据库存放
                    arr["ICode"] = "ITSP2_RFID_CS_CarHistoryInsert";
                    arr["IVer"] = "1.0.0.1";
                    arr["saas_id"] = htCardInfo["saas_id"];
                    arr["operation_type"] = (i == 0 ? htCardInfo["operation_type_init"].ToString() : htCardInfo["operation_type_payment"].ToString()); //初始化
                    arr["card_id"] = htCardInfo["card_id"];
                    arr["no"] = htCardInfo["no"];
                    arr["address_type"] = htCardInfo["address_type"];
                    arr["network_id"] = htCardInfo["network_id"];
                    arr["operation_memo"] = (i == 0 ? htCardInfo["operation_memo_init"].ToString() : htCardInfo["operation_memo_payment"].ToString()); //操作事项
                    arr["operation_user"] = htCardInfo["operation_user"];
                    arr["card_cost_type"] = htCardInfo["cost_type"]; //当前充值卡的扣费类型
                    arr["volume"] = htCardInfo["volume"];

                    DataTable table = ConvertMethod.getDateTable("msgTable", arr);
                    string Parameter = ConvertMethod.CDataToXml(table);

                    //加密xml进行返回
                    Parameter = HelperClass.EncryptDESByKey8(Parameter);
                    resoue = _objICardInfoDAL.InsertCarInformationHistoryRecord(Parameter);
                }
            }
            //先解密成xml格式
            string str = HelperClass.DecryptDESByKey8(resoue);
            //把字符串转换成表对象
            DataSet parameterTable = ConvertMethod.CXmlToDataSet(str);
            if (parameterTable.Tables[0].Rows[0]["msgCode"].ToString() == "充值数据成功！")
            {
                return message; //未实现，默认全部成功
            }
            else
            {
                return "99";
            }
            
        }

        /// <summary>
        /// 执行充值
        /// </summary>
        /// <param name="theCardTypeInfo">实体层对象</param>
        /// <param name="key">密码</param>
        /// <param name="value">充值的数目</param>
        /// <param name="isAdd">判断是否需要写入数据库</param>
        /// <returns>0所有操作成功，1网络连接不成功，99是远程服务器方法存储失败，其他状态</returns>
        public int Update(CardInfo _cardInfo, string key,string value,bool isAdd)
        {
            try
            {
                Dictionary<string, object> arr = new Dictionary<string, object>();
                //先读卡
                string[] mary1 = ConvertToBytes(RFIDClass.ReadCardAndReturnStatus(key, 1));
                string inputValue=string.Empty;
                //先进行写卡
                int p = -1;
                if (_cardInfo.cost_type== CardInfo.CardTypeInfoCostType.金额卡)
                {
                    //获得要写入的值
                    inputValue = mary1[1].Substring(0, 4) + ConvertToStringByInt32(_cardInfo.money.ToString("0.000").Substring(0, _cardInfo.money.ToString("0.000").Length-2).Replace(".", "")) + mary1[1].Substring(9);
                    p = RFIDClass.WriterCardAndReturnStatus(_cardInfo.card_id, key, 1, 0, HelperClass.EncryptByString(inputValue));
                    //修改状态
                    p = RFIDClass.WriterCardAndReturnStatus(_cardInfo.card_id, key, 1, 1, HelperClass.EncryptByString(mary1[2].Substring(0, 13) + "2" + mary1[2].Substring(14)));
                    arr["volume"] = Convert.ToDecimal(value).ToString("0.000").Substring(0, Convert.ToDecimal(value).ToString("0.000").Length - 2); //量
                    inputValue = "充值" + Convert.ToDecimal(value).ToString("0.000").Substring(0, Convert.ToDecimal(value).ToString("0.000").Length-2) + "0元"; 
                }
                else if (_cardInfo.cost_type == CardInfo.CardTypeInfoCostType.限次卡)
                {
                    //获得要写入的值
                    inputValue = mary1[1].Substring(0, 4) + ConvertToStringByInt32(_cardInfo.times.ToString()) + mary1[1].Substring(9);
                    p = RFIDClass.WriterCardAndReturnStatus(_cardInfo.card_id, key, 1, 0, HelperClass.EncryptByString(inputValue));
                    //修改状态
                    p = RFIDClass.WriterCardAndReturnStatus(_cardInfo.card_id, key, 1, 1, HelperClass.EncryptByString(mary1[2].Substring(0, 13) + "2" + mary1[2].Substring(14)));
                    arr["volume"] = value; //量
                    inputValue = "增加" + value.ToString() + "次"; 
                }
                else if (_cardInfo.cost_type == CardInfo.CardTypeInfoCostType.限期卡)
                {
                    //获得要写入的值
                    inputValue = mary1[2].Substring(0, 6) + _cardInfo.end_date.ToString("yyyyMMdd").Substring(2) + mary1[2].Substring(12, 1) + "2" + mary1[2].Substring(14);
                    p = RFIDClass.WriterCardAndReturnStatus(_cardInfo.card_id, key, 1, 1, HelperClass.EncryptByString(inputValue));//修改对应的最晚到期时间
                    arr["volume"] =_cardInfo.end_date.ToString("yyyyMMdd"); //量
                    inputValue = "更新到期时间为" + _cardInfo.end_date.ToString("yyyy-MM-dd"); 
                }
                else if (_cardInfo.cost_type == CardInfo.CardTypeInfoCostType.限时卡)
                {
                    int g = _cardInfo.charges_date / 60 * 10 + _cardInfo.charges_date % 60 / 10;
                    //获得要写入的值
                    inputValue = mary1[1].Substring(0, 4) + ConvertToStringByInt32(g.ToString()) + mary1[1].Substring(9);
                    p = RFIDClass.WriterCardAndReturnStatus(_cardInfo.card_id, key, 1, 0, HelperClass.EncryptByString(inputValue));

                    //修改状态
                    p = RFIDClass.WriterCardAndReturnStatus(_cardInfo.card_id, key, 1, 1, HelperClass.EncryptByString(mary1[2].Substring(0, 13) + "2" + mary1[2].Substring(14)));
                    arr["volume"] = value; //量
                    inputValue = "充值" + value.ToString() + "分钟"; 
                }
                if(isAdd){
                    //判断写卡是否成功
                    if (p != 0)
                    {
                        return p;
                    }
                    else { 
                        //执行数据库存放
                        arr["ICode"] = "ITSP2_RFID_CS_CarHistoryInsert";
                        arr["IVer"] = "1.0.0.1";
                        arr["saas_id"] = _cardInfo.saas_id;
                        arr["operation_type"] = "5"; //充值
                        arr["card_id"] = _cardInfo.id;
                        arr["no"] = _cardInfo.no;
                        arr["address_type"] = "1";
                        arr["network_id"] = _cardInfo.Network_id;
                        arr["operation_memo"] = inputValue; //操作事项
                        arr["operation_user"] = _cardInfo.modify_user;
                        arr["card_cost_type"] = (int)_cardInfo.cost_type; //当前充值卡的扣费类型


                        DataTable table = ConvertMethod.getDateTable("msgTable", arr);
                        string Parameter = ConvertMethod.CDataToXml(table);

                        //加密xml进行返回
                        Parameter = HelperClass.EncryptDESByKey8(Parameter);
                        string resoue=_objICardInfoDAL.InsertCarInformationHistoryRecord(Parameter);


                        //先解密成xml格式
                        string str = HelperClass.DecryptDESByKey8(resoue);
                        //把字符串转换成表对象
                        DataSet parameterTable = ConvertMethod.CXmlToDataSet(str);
                        if (parameterTable.Tables[0].Rows[0]["msgCode"].ToString() == "充值数据成功！")
                        {
                            return 0; //未实现，默认全部成功
                        }
                        else {
                            return 99;
                        }
                    }
                
                }
                else
                { //否则就是更改值，不进行数据库的存储
                    return 0;
                }
            }
            catch (Exception ex)
            {
                Bouwa.Helper.Class.Log.WriterLine(Bouwa.Helper.Class.ELevel.error, "方法名：Update(CardInfo _cardInfo, string key)，卡信息BLL层对数据操作时出现异常！", ex.Message);
                return 1;
            }
        }

        /// <summary>
        /// 执行卡重置
        /// </summary>
        /// <param name="theCardTypeInfo">实体层对象</param>
        /// <param name="key">密码</param>
        /// <returns>0所有操作成功，1网络连接不成功，99是远程服务器方法存储失败，其他状态</returns>
        public int ResetCarInforAndCarHistoryByID(CardInfo _cardInfo, string key)
        {
            try
            {
                int cSector = 1; //保存要操作的扇区下标
                //先执行密码修改
                string[] mary = RFIDClass.UpdateCardPassWordAndReturnStatus(_cardInfo.card_id, cSector, key);
                if (mary[0] != "0") //修改密码错误就直接返回错误状态
                {
                    return Convert.ToInt32(mary[0]);
                }
                else //成功继续往下走
                {
                    //先读卡
                    string[] mary1 = ConvertToBytes(RFIDClass.ReadCardAndReturnStatus(key,cSector));
                    //保存一份副本
                    string[] maryback = new string[3];
                    for (int i = 1; i < mary1.Length - 1; i++)
                    {
                        maryback[i - 1] = mary1[i];
                    }
                    
                    //传入默认密码，执行初始化写入第一扇区
                    RFIDClass.WriterCardAndReturnStatus(_cardInfo.card_id, "", cSector, 0, "");
                    RFIDClass.WriterCardAndReturnStatus(_cardInfo.card_id, "", cSector, 1, "");
                    int p = RFIDClass.WriterCardAndReturnStatus(_cardInfo.card_id, "", cSector, 2, "");
                    if (p != 0) //如果出现异常就执行返回
                    {
                        return p;
                    }
                    else //如果初始化卡成功，则执行下一步数据库录入
                    {
                        Dictionary<string, object> arr = new Dictionary<string, object>();
                        arr["ICode"] = "ITSP2_RFID_CS_ResetCarInforAndCarHistory";
                        arr["IVer"] = "1.0.0.1";
                        arr["card_id"] = _cardInfo.card_id;
                        arr["no"] = _cardInfo.no;
                        arr["modify_user"] = _cardInfo.modify_user;


                        DataTable table = ConvertMethod.getDateTable("msgTable", arr);
                        string Parameter = ConvertMethod.CDataToXml(table);

                        //加密xml进行返回
                        Parameter = HelperClass.EncryptDESByKey8(Parameter);
                        string resoue = _objICardInfoDAL.ResetCarInforAndCarHistoryByID(Parameter);


                        //先解密成xml格式
                        string str = HelperClass.DecryptDESByKey8(resoue);
                        //把字符串转换成表对象
                        DataSet parameterTable = ConvertMethod.CXmlToDataSet(str);
                        if (parameterTable.Tables[0].Rows[0]["msgCode"].ToString() == "卡重置成功！")
                        {
                            return 0; //未实现，默认全部成功
                        }
                        else
                        {
                            //否则就是失败，需要执行还原
                            RFIDClass.WriterCardAndReturnStatus(_cardInfo.card_id, "", cSector, 0, HelperClass.EncryptByString(maryback[0]));
                            RFIDClass.WriterCardAndReturnStatus(_cardInfo.card_id, "", cSector, 1, HelperClass.EncryptByString(maryback[1]));
                            RFIDClass.WriterCardAndReturnStatus(_cardInfo.card_id, "", cSector, 2, HelperClass.EncryptByString(maryback[2]));
                            RFIDClass.UpdateCardPassWordAndReturnStatus(_cardInfo.card_id,cSector,"",key); //修改密码
                            return 99;
                        }
                    }
                    //结束
                }
            }
            catch (Exception ex)
            {
                Bouwa.Helper.Class.Log.WriterLine(Bouwa.Helper.Class.ELevel.error, "方法名：ResetCarInforAndCarHistoryByID(CardInfo _cardInfo, string key)，卡信息BLL层对数据操作时出现异常！", ex.Message);
                return 1;
            }
        }

        /// <summary>
        /// 执行退卡操作并写入卡历史表
        /// </summary>
        /// <param name="theCardTypeInfo">实体层对象</param>
        /// <param name="key">密码</param>
        /// <param name="isAdd">判断是否需要写入数据库</param>
        /// <returns>0所有操作成功，1网络连接不成功，99是远程服务器方法存储失败，其他状态</returns>
        public int UpdateCarInfoAndBackCardHistoryRecord(CardInfo _cardInfo, string key, bool isAdd)
        {
            try
            {
                Dictionary<string, object> arr = new Dictionary<string, object>();
                //先读卡
                string[] mary1 = ConvertToBytes(RFIDClass.ReadCardAndReturnStatus(key, 1));
                //先进行写卡
                int p = -1;
                //先修改卡内状态，退卡状态为 3 
                p = RFIDClass.WriterCardAndReturnStatus(_cardInfo.card_id, key, 1, 1, HelperClass.EncryptByString(mary1[2].Substring(0, 13) + ((int)_cardInfo.status) + mary1[2].Substring(14)));
                //修改最后操作时间为当前时间
                p = RFIDClass.WriterCardAndReturnStatus(_cardInfo.card_id, key, 1, 2, HelperClass.EncryptByString(DateTime.Now.ToString("yyyyMMddHHmmss") + mary1[3].Substring(12)));
                //获得对应写入后台的文字描述
                if (_cardInfo.cost_type == CardInfo.CardTypeInfoCostType.金额卡)
                {
                    arr["volume"] ="-"+ Convert.ToDecimal(_cardInfo.money).ToString("0.000").Substring(0, Convert.ToDecimal(_cardInfo.money).ToString("0.000").Length - 2); //量
                }
                else if (_cardInfo.cost_type == CardInfo.CardTypeInfoCostType.限次卡)
                {
                    arr["volume"] = "-" + _cardInfo.times; //量
                }
                else if (_cardInfo.cost_type == CardInfo.CardTypeInfoCostType.限期卡)
                {
                    arr["volume"] = _cardInfo.end_date.ToString("yyyyMMdd"); //量

                }
                else if (_cardInfo.cost_type == CardInfo.CardTypeInfoCostType.限时卡)
                {
                    int g = _cardInfo.charges_date / 60 * 10 + _cardInfo.charges_date % 60 / 10;
                    arr["volume"] = "-" + g; //量
                }
                if (isAdd)
                {
                    //判断写卡是否成功
                    if (p != 0)
                    {
                        return p;
                    }
                    else
                    {
                        //执行数据库存放
                        arr["ICode"] = "ITSP2_RFID_CS_UpdateCarInfoAndBackCardHistory";
                        arr["IVer"] = "1.0.0.1";
                        arr["saas_id"] = _cardInfo.saas_id;
                        arr["operation_type"] = "2"; //退卡
                        arr["card_id"] = _cardInfo.id;
                        arr["no"] = _cardInfo.no;
                        arr["address_type"] = "1";
                        arr["network_id"] = _cardInfo.Network_id;
                        arr["operation_memo"] = "退卡操作成功"; //操作事项
                        arr["operation_user"] = _cardInfo.modify_user;



                        DataTable table = ConvertMethod.getDateTable("msgTable", arr);
                        string Parameter = ConvertMethod.CDataToXml(table);

                        //加密xml进行返回
                        Parameter = HelperClass.EncryptDESByKey8(Parameter);
                        string resoue = _objICardInfoDAL.UpdateCarInfoAndBackCardHistoryRecord(Parameter);


                        //先解密成xml格式
                        string str = HelperClass.DecryptDESByKey8(resoue);
                        //把字符串转换成表对象
                        DataSet parameterTable = ConvertMethod.CXmlToDataSet(str);
                        if (parameterTable.Tables[0].Rows[0]["msgCode"].ToString() == "退卡操作成功！")
                        {
                            return 0; //未实现，默认全部成功
                        }
                        else
                        {
                            return 99;
                        }
                    }

                }
                else
                { //否则就是更改值，不进行数据库的存储
                    return 0;
                }
            }
            catch (Exception ex)
            {
                Bouwa.Helper.Class.Log.WriterLine(Bouwa.Helper.Class.ELevel.error, "方法名：UpdateCarInfoAndBackCardHistoryRecord(CardInfo _cardInfo, string key)，卡信息BLL层对数据操作时出现异常！", ex.Message);
                return 1;
            }
        }

        /// <summary>
        /// 执行申请换卡操作并写入卡历史表
        /// </summary>
        /// <param name="theCardTypeInfo">实体层对象</param>
        /// <param name="key">密码</param>
        /// <param name="isAdd">判断是否需要写入数据库</param>
        /// <returns>0所有操作成功，1网络连接不成功，99是远程服务器方法存储失败，其他状态</returns>
        public int UpdateCarInfoAndApplyChangeCardHistoryRecord(CardInfo _cardInfo, string key, bool isAdd)
        {
            try
            {
                int p = 0; //默认写入是全部成功
                Dictionary<string, object> arr = new Dictionary<string, object>();
                //获得对应写入后台的文字描述
                if (_cardInfo.cost_type == CardInfo.CardTypeInfoCostType.金额卡)
                {
                    arr["volume"] = "-" + Convert.ToDecimal(_cardInfo.money).ToString("0.000").Substring(0, Convert.ToDecimal(_cardInfo.money).ToString("0.000").Length - 2); //量
                }
                else if (_cardInfo.cost_type == CardInfo.CardTypeInfoCostType.限次卡)
                {
                    arr["volume"] = "-" + _cardInfo.times; //量
                }
                else if (_cardInfo.cost_type == CardInfo.CardTypeInfoCostType.限期卡)
                {
                    arr["volume"] = _cardInfo.end_date.ToString("yyyyMMdd"); //量

                }
                else if (_cardInfo.cost_type == CardInfo.CardTypeInfoCostType.限时卡)
                {
                    int g = _cardInfo.charges_date / 60 * 10 + _cardInfo.charges_date % 60 / 10;
                    arr["volume"] = "-" + g; //量
                }
                if (isAdd)
                {
                    //判断写卡是否成功
                    if (p != 0)
                    {
                        return p;
                    }
                    else
                    {
                        //执行数据库存放
                        arr["ICode"] = "ITSP2_RFID_CS_UpdateCarInfoAndApplyChangeCardHistoryRecord";
                        arr["IVer"] = "1.0.0.1";
                        arr["saas_id"] = _cardInfo.saas_id;
                        arr["operation_type"] = "3"; //挂失
                        arr["card_id"] = _cardInfo.id;
                        arr["no"] = _cardInfo.no;
                        arr["address_type"] = "1";
                        arr["network_id"] = _cardInfo.Network_id;
                        arr["operation_memo"] = "申请换卡操作成功"; //操作事项
                        arr["operation_user"] = _cardInfo.modify_user;



                        DataTable table = ConvertMethod.getDateTable("msgTable", arr);
                        string Parameter = ConvertMethod.CDataToXml(table);

                        //加密xml进行返回
                        Parameter = HelperClass.EncryptDESByKey8(Parameter);
                        string resoue = _objICardInfoDAL.UpdateCarInfoAndApplyChangeCardHistoryRecord(Parameter);


                        //先解密成xml格式
                        string str = HelperClass.DecryptDESByKey8(resoue);
                        //把字符串转换成表对象
                        DataSet parameterTable = ConvertMethod.CXmlToDataSet(str);
                        if (parameterTable.Tables[0].Rows[0]["msgCode"].ToString() == "申请换卡操作成功！")
                        {
                            return 0; //未实现，默认全部成功
                        }
                        else
                        {
                            return 99;
                        }
                    }

                }
                else
                { //否则就是更改值，不进行数据库的存储
                    return 0;
                }
            }
            catch (Exception ex)
            {
                Bouwa.Helper.Class.Log.WriterLine(Bouwa.Helper.Class.ELevel.error, "方法名：UpdateCarInfoAndApplyChangeCardHistoryRecord(CardInfo _cardInfo, string key)，卡信息BLL层对数据操作时出现异常！", ex.Message);
                return 1;
            }
        }

        /// <summary>
        /// 执行后台换卡操作
        /// </summary>
        /// <param name="_cardInfo">卡信息对象</param>
        /// <param name="key">密码</param>
        /// <param name="isAdd"></param>
        /// <returns></returns>
        public string ChangeCardInitAndBack(Hashtable _cardInfo, Hashtable htCardInfo, DataAccessor theDataAccessor, ref SystemMessageInfo _info)
        {
            //string InitParameter, string HistoryParameter, string ResetCardParameter
            //调用WebService,把theCardTypeInfo转成Hashtable再转成Xml以便调用
            //Hashtable objHashtable = _objICardInfoDAL.InfoToHashtable(_cardInfo);

            //封装初始化需要用到的参数
            XmlDocument objXmlDocument = Helper.FormatConvert.HashtableToXml(_cardInfo);
            string InitParameter = HelperClass.EncryptDESByKey8(objXmlDocument.OuterXml);

            //封装需要记录的卡历史数据
            Dictionary<string, object> arr = new Dictionary<string, object>(); 
            //执行数据库存放
            arr["ICode"] = "ITSP2_RFID_CS_CarHistoryInsert";
            arr["IVer"] = "1.0.0.1";
            arr["saas_id"] = htCardInfo["saas_id"]; 
            arr["operation_type"] =  htCardInfo["operation_type_init"].ToString(); //初始化
            arr["card_id"] = htCardInfo["card_id"];
            arr["no"] = htCardInfo["no"];
            arr["address_type"] = htCardInfo["address_type"];
            arr["network_id"] = htCardInfo["network_id"];
            arr["operation_memo"] = htCardInfo["operation_memo_init"].ToString(); //操作事项
            arr["operation_user"] = htCardInfo["operation_user"];
            arr["card_cost_type"] = htCardInfo["cost_type"]; //当前充值卡的扣费类型
            arr["volume"] = htCardInfo["volume"];

            DataTable table = ConvertMethod.getDateTable("msgTable", arr);
            DataRow dr = table.NewRow();
            dr["ICode"] = "ITSP2_RFID_CS_CarHistoryInsert";
            dr["IVer"] = "1.0.0.1";
            dr["saas_id"] = htCardInfo["saas_id"];
            dr["operation_type"] = htCardInfo["operation_type_payment"].ToString(); //初始化
            dr["card_id"] = htCardInfo["card_id"];
            dr["no"] = htCardInfo["no"];
            dr["address_type"] = htCardInfo["address_type"];
            dr["network_id"] = htCardInfo["network_id"];
            dr["operation_memo"] = htCardInfo["operation_memo_payment"].ToString(); //操作事项
            dr["operation_user"] = htCardInfo["operation_user"];
            dr["card_cost_type"] = htCardInfo["cost_type"]; //当前充值卡的扣费类型
            dr["volume"] = htCardInfo["volume"];
            
            table.Rows.Add(dr);
            string HistoryParameter = ConvertMethod.CDataToXml(table);

            //加密xml进行返回
            HistoryParameter = HelperClass.EncryptDESByKey8(HistoryParameter);

           string resoue = _objICardInfoDAL.UpdateCarInfoAndChangeCardHistoryRecord(InitParameter, HistoryParameter);

            //先解密成xml格式
            string str = HelperClass.DecryptDESByKey8(resoue);
            //把字符串转换成表对象
            DataSet parameterTable = ConvertMethod.CXmlToDataSet(str);
            //直接返回操作结果
            return parameterTable.Tables[0].Rows[0]["msgCode"].ToString();

        }

        /// <summary>
        /// 根据状态返回对应的错误信息
        /// </summary>
        /// <param name="status">状态值</param>
        /// <returns>返回对应的错误信息值</returns>
        public string ConvertMeassByStatus(int status) {
           return RFIDClass.ConvertMeassByStatus(status);
        }

        /// <summary>
        /// 将字符串转换成符合日期格式的字符串
        /// </summary>
        /// <param name="dateString">需要转换的字符串，如：20111212</param>
        /// <returns>返回转换后的值，如：2011-12-12</returns>
        private string ConvertToDateTimeByString(string dateString)
        {
            if (string.IsNullOrEmpty(dateString)) return dateString;
            if (dateString.Length <= 8)
            {
                return dateString.Substring(0, 4) + "-" + dateString.Substring(4, 2) + "-" + dateString.Substring(6);
            }
            else
            {
                return dateString.Substring(0, 4) + "-" + dateString.Substring(4, 2) + "-" + dateString.Substring(6, 2) + " " + dateString.Substring(8, 2) + ":" + dateString.Substring(10, 2) + ":" + dateString.Substring(12, 2);
            }
        }

        /// <summary>
        /// 过滤并解密数据
        /// </summary>
        /// <param name="mary">需要过滤的数组</param>
        /// <returns>返回过滤后的数据</returns>
        private string[] ConvertToBytes(string[] mary)
        {
            string[] arr = new string[mary.Length];
            arr[0] = mary[0];
            arr[4] = mary[4];
            for (int i = 1; i < mary.Length - 1; i++)
            {
                if (!string.IsNullOrEmpty(mary[i]))
                {
                    arr[i] = HelperClass.DecryptByString(mary[i]);
                }
            }
            return arr;
        }

        /// <summary>
        /// 将字符串转换成Guid
        /// </summary>
        /// <param name="guid">字符串的Guid</param>
        /// <returns></returns>
        private Guid ConvertToGuidByString(string guid) {
            if (guid.Length == 32)
            {
                string stringCon = guid.Substring(0, 8) + "-" + guid.Substring(8, 4) + "-" + guid.Substring(12, 4) + "-" + guid.Substring(16, 4) + "-" + guid.Substring(20);
                return new Guid(stringCon);
            }
            else {
                 return Guid.NewGuid();
            }
       }

        /// <summary>
        /// 将数字转换成五位字符串
        /// </summary>
        /// <param name="inty">要转换的数字</param>
        /// <returns>返回转换后的字符串</returns>
        private string ConvertToStringByInt32(string inty) {
            for (; inty.Length < 5; )
            {
                inty = "0" + inty;
            }
            return inty;
        }

        
    }
}
