using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

using Bouwa.Helper;
using Bouwa.ITSP2V31.Model;

namespace Bouwa.ITSP2V31.IDAL
{
   public interface ICardInfoDAL
    {
        CardInfo GetById(Guid theId, DataAccessor theDataAccessor, ref  SystemMessageInfo theSystemMessageInfo);

        IList<CardInfo> SearchByCondition(Hashtable theHashtable, DataAccessor theDataAccessor, int Size, int BeginSize,string strOrderBy, ref  SystemMessageInfo theSystemMessageInfo);

        string InsertCarInformationHistoryRecord(string Parameter);

        string InsertCardInfo(string parameter);

        string ResetCarInforAndCarHistoryByID(string Parameter);

        string UpdateCarInfoAndBackCardHistoryRecord(string Parameter);

        string UpdateCarInfoAndApplyChangeCardHistoryRecord(string Parameter);

        string UpdateCarInfoAndChangeCardHistoryRecord(string InitParameter, string HistoryParameter);
    }
}
