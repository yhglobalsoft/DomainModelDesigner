using DomainModelDesigner.Designer.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace DomainModelDesigner.Designer.Enums
{
    /// <summary>
    /// 索引来源
    /// </summary>
    public class IndexSourceEnum: Enumeration
    {
        /// <summary>
        /// 聚合根的索引
        /// </summary>
        public static IndexSourceEnum AggRoot = new IndexSourceEnum(1,nameof(AggRoot));

        /// <summary>
        /// 实体的索引
        /// </summary>
        public static IndexSourceEnum Entity = new IndexSourceEnum(2, nameof(Entity));

        protected IndexSourceEnum(int id, string name):base(id,name)
        {
        }
    }
}
