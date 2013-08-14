using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Bouwa.Helper;
using Bouwa.ITSP2V31.Model;
using System.Collections;

namespace Bouwa.ITSP2V31.IDAL
{
    public interface ILoginDAL
    {
        /// <summary>
        /// 根据SAASID跟用户账户密码查询该C/S用户是否存在
        /// </summary>
        /// <param name="theHashtable"></param>
        /// <param name="theDataAccessor"></param>
        /// <param name="theSystemMessageInfo"></param>
        /// <returns></returns>
        UserInfo SelectUserCountByID(Dictionary<string, object> arr, DataAccessor theDataAccessor, ref  SystemMessageInfo theSystemMessageInfo);

        bool IsRightByUserIdRightInfoListRightCode(Guid theUserId, IList<RightInfo> theRightInfoList, string theRightCode, DataAccessor theDataAccessor, ref SystemMessageInfo theSystemMessageInfo);

        RightInfo GetRightInfoFromDataRow(DataRow theDataRow);

        bool Programkeep(string systemVersion, out string URL);
    }
}
