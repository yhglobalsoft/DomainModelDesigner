using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DomainModelDesigner.Designer.DomainServices
{
    public static class Extentions
    {
        /// <summary>
        /// 判断list中某个字段是否有重复
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <param name="keySelector"></param>
        /// <returns></returns>
        public static bool IsDuplicated<T>(this List<T> list,Func<T,string> keySelector) where T : class
        {
            if (list == null)
                return false;

            var result = list
                .GroupBy(x => keySelector(x))
                .Select(x => new { name = x.Key, count = x.Count() });

            if (result.Where(p => p.count > 1).Count() > 0)
                return true;

            return false;
        }
    }
}
