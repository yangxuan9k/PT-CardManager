using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

using Bouwa.Helper;
using Bouwa.ITSP2V31.Model;

namespace Bouwa.ITSP2V31.IDAL
{
    public interface ICardTypeDAL
    {
         //MessageInfo IsValid(CardTypeInfo theCardTypeInfo, DataAccessor theDataAccessor);
  
         SystemMessageInfo Insert(ref CardTypeInfo theCardTypeInfo, DataAccessor theDataAccessor);

         SystemMessageInfo Update(CardTypeInfo theCardTypeInfo, DataAccessor theDataAccessor);
  
         SystemMessageInfo Delete(Guid theId, DataAccessor theDataAccessor);

         CardTypeInfo GetById(Guid theId, DataAccessor theDataAccessor, ref  SystemMessageInfo theSystemMessageInfo);

         IList<CardTypeInfo> SearchByCondition(Hashtable theHashtable, string OrderBy, DataAccessor theDataAccessor, int Size, int BeginSize, ref  SystemMessageInfo theSystemMessageInfo);

         IList<CardTypeInfo> SearchAll(DataAccessor theDataAccessor, ref  SystemMessageInfo theSystemMessageInfo);

         string GetRegisterType(Hashtable theHashTable, DataAccessor theDataAccessor);
     }
}
