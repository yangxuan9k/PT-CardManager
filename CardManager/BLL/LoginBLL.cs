using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using Bouwa.Helper;
using Bouwa.ITSP2V31.IDAL;
using Bouwa.ITSP2V31.DAL;
using Bouwa.ITSP2V31.Model;

namespace Bouwa.ITSP2V31.BLL
{
    public class LoginBLL
    {
        SystemMessageInfo _objMessageInfo = new SystemMessageInfo();
        private static readonly ILoginDAL _objILoginDAL = new LoginDAL();

        /// <summary>
        /// 根据SAASID跟用户账户密码查询该C/S用户是否存在
        /// </summary>
        /// <param name="theHashtable"></param>
        /// <param name="theDataAccessor"></param>
        /// <param name="theSystemMessageInfo"></param>
        /// <returns></returns>
        public UserInfo SelectUserCountByID(Dictionary<string, object> arr, DataAccessor theDataAccessor, ref  SystemMessageInfo theSystemMessageInfo)
        {
            return _objILoginDAL.SelectUserCountByID(arr, theDataAccessor, ref theSystemMessageInfo);
        }

        private bool IsRightByUserIdRightInfoListRightCode(Guid theUserId, IList<RightInfo> theRightInfoList, string theRightCode, DataAccessor theDataAccessor, ref SystemMessageInfo theSystemMessageInfo)
        {
            return _objILoginDAL.IsRightByUserIdRightInfoListRightCode(theUserId, theRightInfoList, theRightCode, theDataAccessor, ref  theSystemMessageInfo);
        }

        public  bool IsRightByUserIdRightInfoListRightCode(string theRightCode, DataAccessor theDataAccessor, ref SystemMessageInfo theSystemMessageInfo)
        {
            return _objILoginDAL.IsRightByUserIdRightInfoListRightCode(CurrentUser.Current.UserId, (List<RightInfo>)CurrentUser.Current.RightInfoList, theRightCode, theDataAccessor, ref  theSystemMessageInfo);
        }

        /// <summary>
        /// 检查是否有新版本
        /// </summary>
        /// <param name="systemVersion">系统版本</param>
        /// <param name="URL">输出参数</param>
        /// <returns></returns>
        public bool Programkeep(string systemVersion, out string URL)
        {
            return _objILoginDAL.Programkeep(systemVersion,out URL);
        }
    }
}
