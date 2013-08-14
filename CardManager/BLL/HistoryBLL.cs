using System;
using System.Collections.Generic;
using System.Text;

using Bouwa.Helper;
using Bouwa.ITSP2V31.IDAL;
using Bouwa.ITSP2V31.DAL;
using Bouwa.ITSP2V31.Model;
using System.Collections;

namespace Bouwa.ITSP2V31.BLL
{
   public class HistoryBLL
   {
       SystemMessageInfo _objMessageInfo = new SystemMessageInfo();
       private static readonly IHistoryDAL _objIHistoryDAL = new HistoryDAL();

       public IList<HistoryInfo> SearchByCondition(Dictionary<string, object> arr, DataAccessor theDataAccessor, ref  SystemMessageInfo theSystemMessageInfo)
       {
           return _objIHistoryDAL.SearchByCondition(arr, theDataAccessor, ref theSystemMessageInfo);
       }

       public IList<HistoryInfo> SearchByCondition(Hashtable theHashtable, string strOrderBy, int Size, int BeginSize, DataAccessor theDataAccessor, ref  SystemMessageInfo theSystemMessageInfo)
       {
           return _objIHistoryDAL.SearchByCondition(theHashtable, strOrderBy, Size, BeginSize, theDataAccessor, ref theSystemMessageInfo);
       }
    }
}
