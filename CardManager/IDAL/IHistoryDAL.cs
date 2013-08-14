using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

using Bouwa.Helper;
using Bouwa.ITSP2V31.Model;

namespace Bouwa.ITSP2V31.IDAL
{
    public interface IHistoryDAL
    {
        IList<HistoryInfo> SearchByCondition(Dictionary<string, object> arr, DataAccessor theDataAccessor, ref  SystemMessageInfo theSystemMessageInfo);

        IList<HistoryInfo> SearchByCondition(Hashtable theHashtable, string strOrderBy, int Size, int BeginSize, DataAccessor theDataAccessor, ref  SystemMessageInfo theSystemMessageInfo);
    }
}
