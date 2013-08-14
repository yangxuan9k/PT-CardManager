using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;
using System.Security.Cryptography;
using System.IO;
using System.Xml;

namespace Bouwa.Helper
{
  public static class ConvertMethod
    {
        /// <summary>
        /// 返回表格架构
        /// </summary>
        /// <param name="tableName">表名称</param>
        /// <param name="arr">要添加的参数 Dictionary<string, object> </param>
        /// <returns>返回一个表对象</returns>
        public static DataTable getDateTable(string tableName, Dictionary<string, object> arr)
        {
            //创建表
            DataTable tableName2 = new DataTable(tableName);
            //创建列 
            DataColumn column;
            //循环创建列
            foreach (KeyValuePair<string, object> ar in arr)
            {
                //实例化列 
                if (ar.Value.GetType().Name == "int")
                {
                    column = new DataColumn(ar.Key, typeof(System.Int32));
                }
                else if (ar.Value.GetType().Name == "double")
                {
                    column = new DataColumn(ar.Key, typeof(System.Double));
                }
                else if (ar.Value.GetType().Name == "DateTime")
                {
                    column = new DataColumn(ar.Key, typeof(System.DateTime));
                }
                else
                {
                    column = new DataColumn(ar.Key, typeof(System.String));
                }
                //添加到表格内
                tableName2.Columns.Add(column);
            }
            DataRow dr = tableName2.NewRow();
            //循环创建列
            foreach (KeyValuePair<string, object> ar in arr)
            {
                dr[ar.Key] = arr[ar.Key];
            }
            tableName2.Rows.Add(dr);
            //返回表格结构
            return tableName2;
        }

        /// <summary> 
        /// 将DataTable对象转换成XML字符串 
        /// </summary> 
        /// <param name="dt">DataTable对象</param> 
        /// <returns>XML字符串</returns> 
        public static string CDataToXml(DataTable dt)
        {
            if (dt != null)
            {
                MemoryStream ms = null;
                XmlTextWriter XmlWt = null;
                try
                {
                    ms = new MemoryStream();
                    //根据ms实例化XmlWt 
                    XmlWt = new XmlTextWriter(ms, Encoding.Unicode);
                    //获取ds中的数据 
                    dt.WriteXml(XmlWt);
                    int count = (int)ms.Length;
                    byte[] temp = new byte[count];
                    ms.Seek(0, SeekOrigin.Begin);
                    ms.Read(temp, 0, count);
                    //返回Unicode编码的文本 
                    UnicodeEncoding ucode = new UnicodeEncoding();
                    string returnValue = ucode.GetString(temp).Trim();
                    return "<?xml version=\"1.0\" encoding=\"UTF-8\"?>" + returnValue;
                }
                catch (System.Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    //释放资源 
                    if (XmlWt != null)
                    {
                        XmlWt.Close();
                        ms.Close();
                        ms.Dispose();
                    }
                }
            }
            else
            {
                return "";
            }
        }

        #region 加密解密的方法

        /// <summary>
        /// DES加密字符串
        /// </summary>
        /// <param name="encryptString">待加密的字符串</param>
        /// <param name="encryptKey">加密密钥,要求为8位</param>
        /// <returns>加密成功返回加密后的字符串，失败返回源串</returns>
        public static string EncryptDESByKey8(string encryptString, string encryptKey)
        {
            try
            {
                byte[] rgbKey = Encoding.UTF8.GetBytes(encryptKey.Substring(0, 8));
                byte[] rgbIV = { 0x12, 0x34, 0x56, 0x78, 0x90, 0xAB, 0xCD, 0xEF }; //默认密钥向量
                byte[] inputByteArray = Encoding.UTF8.GetBytes(encryptString);
                DESCryptoServiceProvider dCSP = new DESCryptoServiceProvider();
                MemoryStream mStream = new MemoryStream();
                CryptoStream cStream = new CryptoStream(mStream, dCSP.CreateEncryptor(rgbKey, rgbIV), CryptoStreamMode.Write);
                cStream.Write(inputByteArray, 0, inputByteArray.Length);
                cStream.FlushFinalBlock();
                return Convert.ToBase64String(mStream.ToArray());
            }
            catch
            {
                return null;
            }

        }

        /// <summary>
        /// DES解密字符串
        /// </summary>
        /// <param name="decryptString">待解密的字符串</param>
        /// <param name="decryptKey">解密密钥,要求为8位,和加密密钥相同</param>
        /// <returns>解密成功返回解密后的字符串，失败返源串</returns>
        public static string DecryptDESByKey8(string decryptString, string decryptKey)
        {
            try
            {
                byte[] rgbKey = Encoding.UTF8.GetBytes(decryptKey);
                byte[] rgbIV = { 0x12, 0x34, 0x56, 0x78, 0x90, 0xAB, 0xCD, 0xEF }; //默认密钥向量
                byte[] inputByteArray = Convert.FromBase64String(decryptString);
                DESCryptoServiceProvider DCSP = new DESCryptoServiceProvider();
                MemoryStream mStream = new MemoryStream();
                CryptoStream cStream = new CryptoStream(mStream, DCSP.CreateDecryptor(rgbKey, rgbIV), CryptoStreamMode.Write);
                cStream.Write(inputByteArray, 0, inputByteArray.Length);

                cStream.FlushFinalBlock();

                return Encoding.UTF8.GetString(mStream.ToArray());

            }
            catch
            {
                return null;
            }
        }

        #endregion

        /// <summary> 
        /// 将Xml内容字符串转换成DataSet对象 
        /// </summary> 
        /// <param name="xmlStr">Xml内容字符串</param> 
        /// <returns>DataSet对象</returns> 
        public static DataSet CXmlToDataSet(string xmlStr)
        {
            if (!string.IsNullOrEmpty(xmlStr))
            {
                StringReader StrStream = null;
                XmlTextReader Xmlrdr = null;
                try
                {
                    DataSet ds = new DataSet();
                    //读取字符串中的信息 
                    StrStream = new StringReader(xmlStr);
                    //获取StrStream中的数据 
                    Xmlrdr = new XmlTextReader(StrStream);
                    //ds获取Xmlrdr中的数据 
                    ds.ReadXml(Xmlrdr);
                    return ds;
                }
                catch (Exception e)
                {
                    throw e;
                }
                finally
                {
                    //释放资源 
                    if (Xmlrdr != null)
                    {
                        Xmlrdr.Close();
                        StrStream.Close();
                        StrStream.Dispose();
                    }
                }
            }
            else
            {
                return null;
            }
        }
    }
}
