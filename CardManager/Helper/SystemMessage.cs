using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace Bouwa.Helper
{
    public class SystemMessageInfo
    {
        public bool Success { get; set; }

        public string Code { get; set; }//信息代码

        public string SubCode { get; set; }//子信息代码(备用)

        public string Content { get; set; }//信息内容

        public string[] ContentList { get; set; }//信息内容列表(如果信息内容超出一条，则在这里记录，如一次较验实体合法性)

        public string Exception { get; set; }//记录异常

        public SystemMessageInfo()
        {
            this.Success = true;
            this.Code = "";
            this.SubCode = "";
            this.Content = "";
            this.Exception = "";
        }
    }

    public class SystemMessage
    {
        SystemMessageInfo _objSystemMessageInfo = new SystemMessageInfo();

        public SystemMessageInfo GetInfoByCode(string theCode)
        {
            XmlDocument objXmlDocument = new XmlDocument();
            string strPath="";
            try
            {
                strPath=SystemConstant.ApplicationPath + "\\../../SystemMessage\\SystemMessage.xml";
                if (System.IO.File.Exists(strPath))
                {
                    objXmlDocument.Load(strPath);
                }
                else
                {
                    strPath = SystemConstant.ApplicationPath + "\\../SystemMessage\\SystemMessage.xml";
                    if (System.IO.File.Exists(strPath))
                    {
                        objXmlDocument.Load(strPath);
                    }
                }
            }
            catch (Exception e)
            {
                throw;
            }

            XmlNodeList objXmlNodeList = objXmlDocument.SelectSingleNode("Languages").ChildNodes;
            foreach (XmlNode objXmlNode in objXmlNodeList)
            {
                if (!objXmlNode.OuterXml.StartsWith("<!--"))
                {
                    XmlElement objXmlElement = (XmlElement)objXmlNode;
                    foreach (XmlNode objXmlNode2 in objXmlElement.ChildNodes)
                    {
                        XmlElement objXmlElement2 = (XmlElement)objXmlNode2;

                        if (objXmlElement2.InnerText == theCode)
                        {
                            _objSystemMessageInfo.Code = objXmlElement2.InnerText;
                            _objSystemMessageInfo.Content = objXmlElement2.NextSibling.InnerText;

                            return _objSystemMessageInfo;
                        }
                    }
                }
            }

            return _objSystemMessageInfo;
        }
    }
}
