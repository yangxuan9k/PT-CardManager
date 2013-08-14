using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Text;
using System.Security.Cryptography;
using System.Collections;
using System.Collections.Generic;
using Bouwa.Helper.Class;

/// <summary>
/// StringUtil 的摘要说明

/// </summary>

namespace Bouwa.Helper
{
    public class StringUtil
    {
        public StringUtil()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }
        public static bool EDIT = false;
        public static int Show = 0;
        public static int Total = 0;
        /**
         * MD5加密方法
         **/
        public static string MD5(string Sourcein)
        {
            MD5CryptoServiceProvider MD5CSP = new MD5CryptoServiceProvider();
            byte[] MD5Source = Encoding.UTF8.GetBytes(Sourcein);
            byte[] MD5Out = MD5CSP.ComputeHash(MD5Source);
            return Convert.ToBase64String(MD5Out);
        }

        /// <summary>
        /// 根据开始时间和结束时间 以及时间间隔，得到一系列时间点
        /// </summary>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <param name="sleepInteval"></param>
        /// <returns></returns>
        public static List<Hashtable> getTaskAtTimes(string startTime,string endTime,string sleepInteval)
        {
            List<Hashtable> dateList = new List<Hashtable>();
            if (string.IsNullOrEmpty(startTime) || string.IsNullOrEmpty(endTime))
            {
                return dateList;
            }
            else
            {
                DateTime now = DateTime.Now;
                string tmp = now.ToString("yyyy-MM-dd") + " " + startTime;
                DateTime start = Convert.ToDateTime(tmp).AddHours(Convert.ToDouble(sleepInteval));
                DateTime taskEnd = Convert.ToDateTime(tmp).AddHours(Convert.ToDouble(sleepInteval)).AddHours(Convert.ToDouble(sleepInteval));
                tmp = now.ToString("yyyy-MM-dd") + " " + endTime;
                DateTime end = Convert.ToDateTime(tmp);
                Hashtable table = null;
                //循环计算时间点，并加入到List列表中
                while (start.CompareTo(end) <= 0)
                {
                    if (taskEnd.CompareTo(end) > 0)
                    {
                        taskEnd = end;
                    }
                    table = new Hashtable();
                    table.Add("startTime",start);
                    table.Add("endTime",taskEnd);
                    dateList.Add(table);
                    start = start.AddHours(Convert.ToDouble(sleepInteval));
                    taskEnd = taskEnd.AddHours(Convert.ToDouble(sleepInteval));
                }
            }
            return dateList;
        }

        /// <summary>
        /// 根据开始时间和结束时间 以及时间间隔，得到一系列时间点
        /// </summary>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <param name="sleepInteval"></param>
        /// <returns></returns>
        public static List<DateTime> getSelfTaskAtTimes(string startTime, string endTime, string sleepInteval)
        {
            List<DateTime> dateList = new List<DateTime>();
            if (string.IsNullOrEmpty(startTime) || string.IsNullOrEmpty(endTime))
            {
                return dateList;
            }
            else
            {
                DateTime now = DateTime.Now;
                string tmp = now.ToString("yyyy-MM-dd") + " " + startTime.Insert(startTime.Length-2,":");
                DateTime start = Convert.ToDateTime(tmp).AddSeconds(Convert.ToDouble(string.IsNullOrEmpty(sleepInteval) ? "0" : sleepInteval));
                tmp = now.ToString("yyyy-MM-dd") + " " + endTime.Insert(endTime.Length - 2, ":");
                DateTime end = Convert.ToDateTime(tmp);
                //循环计算时间点，并加入到List列表中
                while (start.CompareTo(end) <= 0)
                {
                    dateList.Add(start);
                    start = start.AddSeconds(Convert.ToDouble(sleepInteval));
                }
            }
            return dateList;
        }


        /// <summary>
        /// 读取块数据
        /// </summary>
        /// <param name="mary"></param>
        /// <returns></returns>
        public static string[] readBlock(string[] mary)
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
        /// 根据传入参数把数据格式化字符串
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public static string formatDataString(int num,int length)
        {
            if (length == 0) return string.Empty;
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < length-num.ToString().Length; i++)
            {
                sb.Append("0");
            }
            sb.Append(num);
            return sb.ToString();
        }

        /// <summary>
        /// 根据传入字符串参数把数据格式化字符串
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public static string formatDataString(string str, int length)
        {
            if (length == 0) return string.Empty;
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < length - str.ToString().Length; i++)
            {
                sb.Append("0");
            }
            sb.Append(str);
            return sb.ToString();
        }
    }
}