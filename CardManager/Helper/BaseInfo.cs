using System;
using System.Collections.Generic;
using System.Text;

namespace Bouwa.Helper
{
    [Serializable]
    public abstract class BaseInfo
    {
        //public string ValidateTag { get; protected set; }

        //public virtual bool IsValid()
        //{
        //    var validateResults = Validation.Validate<T>(this as T);
        //    if (!validateResults.IsValid)
        //    {
        //        foreach (var item in validateResults)
        //            ValidateTag += string.Format(@"{0}:{1}\n", item.Key, item.Message);
        //        return false;
        //    }
        //    return true;
        //}

        public DateTime CreateUserId { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime ModifyUserId { get; set; }
        public DateTime ModifyTime { get; set; }
    }
}
