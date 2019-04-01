using DomainModelDesigner.Designer.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace DomainModelDesigner.Designer.Enums
{
    /// <summary>
    /// 字段的来源
    /// </summary>
    public class FieldSourceEnum:Enumeration
    {
        /// <summary>
        /// 聚合根的字段
        /// </summary>
        public static FieldSourceEnum AggRoot = new FieldSourceEnum(1, nameof(AggRoot));

        /// <summary>
        /// 实体的字段
        /// </summary>
        public static FieldSourceEnum EntityObject = new FieldSourceEnum(2, nameof(EntityObject));

        /// <summary>
        /// 值对象的字段
        /// </summary>
        public static FieldSourceEnum ValueObject = new FieldSourceEnum(3, nameof(ValueObject));

        protected FieldSourceEnum(int id, string name) : base(id, name)
        {
        }
    }
}
