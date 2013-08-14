using System;
using System.Collections.Generic;
using System.Text;

namespace Bouwa.Helper
{
    public static class SystemConstant
    {
        public static Guid GuidEmpty = new Guid("{00000000-0000-0000-0000-000000000000}");

        public static DateTime DateTimeEmpty = DateTime.Parse("1900-01-01");

        public static DateTime DateTimeMin = DateTime.Parse("1900-01-01");

        public static DateTime DateTimeMax = DateTime.Parse("2999-12-31");

        public static string ApplicationPath = System.Windows.Forms.Application.StartupPath;

        public static string StringEmpty = string.Empty;

        public static string PasswordKey = "~4%&@@8!1#6$0$1^8&&2*(5~";
        //出厂默认密码,12个F
        public static string CardDefaultPassword ="";

        /// <summary>
        /// 客户端初始化的标志
        /// </summary>
        public static string InitAgain = "CS.InitAgain";

        /// <summary>
        /// 客户端退卡的标志
        /// </summary>
        public static string ChangeCardIntervalTime = "CS.ChangeCardIntervalTime";

        /// <summary>
        /// 系统类型
        /// </summary>
        public enum system_type
        {
            CS_SYSTEM =1  //CS终端
        };

        /// <summary>
        /// SAAS 类型
        /// </summary>
        public enum saas_type
        {
            SAAS_TYPE = 1 //潜江
        }

        
    }

}
