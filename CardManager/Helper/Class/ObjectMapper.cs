using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Linq;

namespace Bouwa.Helper.Class
{
     ///<summary>
     /// 对象转换类
     /// </summary>
     public class ObjectMapper  
     {
         /// <summary>
         /// 方法通过LINQ将源对象和目标对象相对应的属性对放置在List<PropertyMapper>集合中，
         /// 每一个PropertyMapper对应一个SourceProperty和TargetProperty
         /// </summary>
         /// <param name="sourceType">类型一</param>
         /// <param name="targetType">类型二</param>
         /// <returns></returns>
         public static IList<PropertyMapper> GetMapperProperties(Type sourceType, Type targetType)
         {
             var sourceProperties = sourceType.GetProperties();
             var targetProperties = targetType.GetProperties();
 
             return (from s in sourceProperties
                     from t in targetProperties
                     where s.Name == t.Name && s.CanRead && t.CanWrite && s.PropertyType == t.PropertyType
                     select new PropertyMapper
                               {
                                   SourceProperty = s,
                                   TargetProperty = t
                               }).ToList();
         }       
 
         /// <summary>
         /// 方法将源对象的属性值赋给目标对象的属性。
         /// 其中必须满足以下条件：s.Name == t.Name && s.CanRead && t.CanWrite && s.PropertyType == t.PropertyType，
         /// 也就是两个对象之间赋值的属性名，属性类型必须相同，而且源对象的属性必须可读，目标对象的属性可写。
         /// </summary>
         /// <param name="source">数据来源对象</param>
         /// <param name="target">需要写入的对象</param>
         public static void CopyProperties(object source, object target)
         {
             var sourceType = source.GetType();
             var targetType = target.GetType();
             var mapperProperties = GetMapperProperties(sourceType, targetType);
 
             for (int index = 0,count=mapperProperties.Count; index < count; index++)
             {
                 var property = mapperProperties[index];
                 var sourceValue = property.SourceProperty.GetValue(source, null);
                 property.TargetProperty.SetValue(target, sourceValue, null);
             }
         }
     }

      /// <summary>
     /// 转换实体对象
     /// </summary>
     public class PropertyMapper
     {
         /// <summary>
         ///  转换属性一
         /// </summary>
         public PropertyInfo SourceProperty
         {
             get;
             set;
         }
 
         /// <summary>
         /// 转换属性二
         /// </summary>
         public PropertyInfo TargetProperty
         {
             get;
             set;
         }
     }



}
