using System;
using System.Collections.Generic;
using System.Text;
using Bouwa.ITSP2V31.DAL.Itsp2WebServiceNamespace;

namespace Bouwa.Helper
{
    /// <summary>
    /// Service服务的封装
    /// </summary>
    public static class ServiceWrapper
    {
        //封装的调用Service的Web服务是唯一的(单态)
        private static Bouwa.ITSP2V31.DAL.Itsp2WebServiceNamespace.Itsp2WebService _serviceProvider;// WebServiceCar.Itsp2WebService _serviceProvider

        static ServiceWrapper()
        {
            ServiceWrapper._serviceProvider=new Bouwa.ITSP2V31.DAL.Itsp2WebServiceNamespace.Itsp2WebService();
            _serviceProvider.Timeout = 10000;
        }

        public static Itsp2WebService Current
        {
            get
            {
                return ServiceWrapper._serviceProvider;
            }
        }
        /// <summary>
        /// 初始化webservice
        /// </summary>
        public static void Init()
        {
            Itsp2WebService service = ServiceWrapper.Current;
        }
        /// <summary>
        /// 获得webservice的URL
        /// </summary>
        /// <param name="url"></param>
        public static void SetURL(string url)
        {
            ServiceWrapper.Current.Url = url;
        }
    }
}
