using System;
using System.Collections.Generic;
using System.Text;

namespace Bouwa.Helper
{
   public class NameValueDataType
    {
       string _Name = "";
       /// <summary>
       /// 
       /// </summary>
       public string Name
       { get { return _Name; } set { _Name = value; } }   

       string _Value = "";
       /// <summary>
       /// 
       /// </summary>
       public string Value
       { get { return _Value; } set { _Value = value; } }   

        NameValueDataType(string theName, string theValue)
       {
           _Name = theName;
           _Value = theValue;
       }
    }


}
