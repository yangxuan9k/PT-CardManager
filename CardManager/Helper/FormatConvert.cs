using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;
using System.Xml;
using System.IO;

namespace Bouwa.Helper
{
    public static class FormatConvert
    {
        public static DataSet XmlToDataSet(string theXml)
        {
            DataSet objDataSet = new DataSet();
            System.IO.StringReader reader = new System.IO.StringReader(theXml);
            objDataSet.ReadXml(reader);
            reader.Close();
            return objDataSet;
        }

        public static Hashtable XmlToHashtable(XmlDocument theXmlDocument)
        {           
            Hashtable objHashtable = new Hashtable();
            XmlNodeList objXmlNodeList = theXmlDocument.DocumentElement.ChildNodes;
            foreach (XmlElement objXmlElement in objXmlNodeList)
            {
                objHashtable.Add(objXmlElement["Key"].InnerText, objXmlElement["Value"].InnerText);
            }
            return objHashtable;
        }

        public static XmlDocument HashtableToXml(Hashtable theHashtable)
        {
            XmlDocument objXmlDocument = new XmlDocument();
            XmlDeclaration objXmlDeclaration = objXmlDocument.CreateXmlDeclaration("1.0", "gb2312", "yes");


            XmlElement objXmlElementRoot = objXmlDocument.CreateElement("Root"); //根元素  
            foreach (DictionaryEntry objDictionaryEntry in theHashtable)
            {
                if (objDictionaryEntry.Value != null)
                {
                    XmlElement objXmlElementElement = objXmlDocument.CreateElement("Element");
                    XmlElement objXmlElementKey = objXmlDocument.CreateElement("Key");
                    objXmlElementKey.InnerText = objDictionaryEntry.Key.ToString();
                    XmlElement objXmlElementValue = objXmlDocument.CreateElement("Value");
                    objXmlElementValue.InnerText = objDictionaryEntry.Value.ToString();
                    objXmlElementElement.AppendChild(objXmlElementKey);
                    objXmlElementElement.AppendChild(objXmlElementValue);
                    objXmlElementRoot.AppendChild(objXmlElementElement);
                }
            }
            objXmlDocument.AppendChild(objXmlDeclaration);
            objXmlDocument.AppendChild(objXmlElementRoot);
            return objXmlDocument;


        }

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
