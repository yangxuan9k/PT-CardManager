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
    public class CardTypeBLL //: ICardTypeManage
    {
        SystemMessageInfo _objMessageInfo = new SystemMessageInfo();
        private static readonly ICardTypeDAL _objICardTypeDAL = new CardTypeDAL();
      
        public SystemMessageInfo IsValid(CardTypeInfo theCardTypeInfo,DataAccessor theDataAccessor)
        {
            _objMessageInfo.Success = true;
            return _objMessageInfo;
        }
       
        public SystemMessageInfo Insert(ref CardTypeInfo theCardTypeInfo, DataAccessor theDataAccessor)
        {
            return _objICardTypeDAL.Insert(ref theCardTypeInfo, theDataAccessor);
        }

        public SystemMessageInfo Update(CardTypeInfo theCardTypeInfo, DataAccessor theDataAccessor)
        {
            return _objICardTypeDAL.Update(theCardTypeInfo, theDataAccessor);
        }

        public SystemMessageInfo Delete(Guid theId, DataAccessor theDataAccessor)
        {
            return _objICardTypeDAL.Delete(theId, theDataAccessor);
        }

        public CardTypeInfo GetById(Guid theId, DataAccessor theDataAccessor,ref SystemMessageInfo theSystemMessageInfo)
        {
            return _objICardTypeDAL.GetById(theId, theDataAccessor,ref theSystemMessageInfo);
        }

        public IList<CardTypeInfo> SearchByCondition(Hashtable theHashtable, string OrderBy, DataAccessor theDataAccessor, int Size, int BeginSize, ref  SystemMessageInfo theSystemMessageInfo)
        {
            return _objICardTypeDAL.SearchByCondition(theHashtable,OrderBy, theDataAccessor,Size,BeginSize, ref theSystemMessageInfo);
        }

        public IList<CardTypeInfo> SearchAll(DataAccessor theDataAccessor,ref SystemMessageInfo theSystemMessageInfo)
        {
            return _objICardTypeDAL.SearchAll(theDataAccessor,ref theSystemMessageInfo);
        }


        public string GetRegisterType(Hashtable theHashTable, DataAccessor theDataAccessor)
        {
            return _objICardTypeDAL.GetRegisterType(theHashTable, theDataAccessor);
        }
    }
}
