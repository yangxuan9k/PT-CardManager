using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Xml;
using System.Reflection;

namespace Bouwa.Helper.Class
{

    /// <summary>
    /// 日志记录错误级别
    /// </summary>
    public enum ELevel
    {
        debug, error
    }


    /// <summary>
    /// 日志操作类
    /// </summary>
    public class Log
    {
        
        /// <summary>
        /// 执行写日志的操作
        /// </summary>
        /// <param name="Level">错误级别</param>
        /// <param name="msg">要写入的消息</param>
        public static void WriterLine(ELevel Level, string msg, string value)//加入时期判断默认保留当天日志
        {
            string path = System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().ManifestModule.FullyQualifiedName) + "\\Log\\errorLog";
            string errorMes=null; //存放错误信息
            try
            {
                int SaveDate = GetDeleteLogDay(); //默认保留30天
                path = System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().ManifestModule.FullyQualifiedName) + "\\Log\\" + Level.ToString() + "Log";
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                if (SaveDate==0)
                {
                    SaveDate = 15;
                }
                //保留多少天原始日志
                DeleteLog(path, SaveDate);
            }
            catch (Exception ex)
            {
                errorMes=ex.Message; //存放错误信息
            }
            finally {
                if(errorMes==null)
                    WriteEnd(Level, path, msg, value);
                else
                WriteEnd(Level,path,"系统写日志时报错",errorMes);
            }
            
        }

        /// <summary>
        /// 最终写日记操作
        /// </summary>
        /// <param name="Level">错误级别</param>
        /// <param name="path">日志存放路径</param>
        /// <param name="msg">说明解释</param>
        /// <param name="value">错误信息</param>
        private static void WriteEnd(ELevel Level, string path,string msg,string value)
        {
            try
            {
                string date = string.Format("{0}\\{1}.txt", path, GetLogFileName());
                //创建日志文件
                StreamWriter writer = new StreamWriter(date, true, System.Text.Encoding.GetEncoding("GB2312"));
                writer.WriteLine("");
                writer.WriteLine("错误级别为：" + Level.ToString() + "                       记录时间：" + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"));
                writer.WriteLine("说明解释为：" + msg);
                writer.WriteLine("异常信息：" + value);
                writer.WriteLine("---------------------------------------------------------------------------------------------");
                writer.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// 返回保留日志天数
        /// </summary>
        /// <returns>返回保留日志天数</returns>
        private static int GetDeleteLogDay()
        {
            try
            {
                return Convert.ToInt32(GetAppSettingsByName("SaveDate"));
            }
            catch
            {
                return 30;//默认保留30天
            }
        }

        /// <summary>
        /// 返回一个日志的名称
        /// </summary>
        /// <returns>日志名称</returns>
        private static string GetLogFileName()
        {
            return string.Format(DateTime.Now.ToString("yyyy-MM-dd"));
        }

        /// <summary>
        /// 删除多少天之前的日志
        /// </summary>
        /// <param name="Tou">前半部分路径</param>
        /// <param name="day">天数</param>
        private static void DeleteLog(string Tou, int day)
        {
            try
            {
                DirectoryInfo  directory=new DirectoryInfo(Tou);
                int leng=directory.GetFiles().Length-day;
                //说明有过期的日志
                for (int i = 0; i < leng; i++)
			    {
    			   File.Delete(directory.GetFiles()[i].FullName);
			    }
            }
            catch (Exception ex)
            {
                WriterLine(ELevel.error, "删除系统日志时报错", ex.Message);
            } 
        }

        /// <summary>
        /// 返回该节点的值
        /// 读取格式：
        ///     <?xml version="1.0" encoding="UTF-8"?>
        ///     <configuration>
        ///         <BeginImage value="D:\IIS\Photo\" remark="本地文件夹所在"></BeginImage>
        ///         <FromIamge value="\\192.168.0.103\test\" remark="目标文件夹所在"></FromIamge>
        ///         <TimerDate value="30" remark="设定移动时间，以秒为单位"></TimerDate>
        ///         <SaveDate value="15" remark="日志保存的时间"></SaveDate>
        ///         <con value="server=.;database=itsp2;uid=sa;pwd=123"></con>
        ///         <imagePath value="D:\photo\"></imagePath>
        ///     </configuration>
        /// </summary>
        /// <param name="nodeName">节点名称</param>
        /// <returns>返回节点的value值</returns>
        public static string GetAppSettingsByName(string nodeName)
        {
            try
            {
                string path = System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().ManifestModule.FullyQualifiedName) + "\\Web.config";
                XmlDocument xmlConfig = new XmlDocument();
                string XMLPath = System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase;
                xmlConfig.Load(path);
                return xmlConfig["configuration"][nodeName].GetAttribute("value");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 返回该路径配置文件的某个节点的值
        /// </summary>
        /// <param name="nodeName">节点名称</param>
        /// <param name="path">配置文件路径</param>
        /// <returns>返回值</returns>
        public static string GetAppSettingsByName(string nodeName,string path)
        {
            try
            {
                XmlDocument xmlConfig = new XmlDocument();
                string XMLPath = System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase;
                xmlConfig.Load(path);
                return xmlConfig["configuration"][nodeName].GetAttribute("value");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 设置该路径配置文件的某个节点的值
        /// </summary>
        /// <param name="nodeName">节点名称</param>
        /// <param name="path">配置文件路径</param>
        /// <returns>返回值</returns>
        public static bool SetAppSettingsByName(string nodeName,string value, string path)
        {
            try
            {
                XmlDocument xmlConfig = new XmlDocument();
                string XMLPath = System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase;
                xmlConfig.Load(path);
                xmlConfig["configuration"][nodeName].SetAttribute("value", value);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
