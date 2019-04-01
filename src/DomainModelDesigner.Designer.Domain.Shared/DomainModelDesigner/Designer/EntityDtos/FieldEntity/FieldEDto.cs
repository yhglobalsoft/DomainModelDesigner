using System;
using System.Collections.Generic;
using System.Text;

namespace DomainModelDesigner.Designer.EntityDtos
{
    public class FieldEDto
    {
        public string FieldName { get; set; }

        public string FieldTypeId { get; set; }

        public bool IsSimpleField { get; set; }

        /// <summary>
        /// 是否作为构造函数的参数
        /// </summary>
        public bool IsConstructorParameter { get; set; }

        /// <summary>
        /// 字段是否是集合
        /// </summary>
        public bool IsMultiple { get; set; }

        /// <summary>
        /// 字段长度
        /// </summary>
        public string FieldLen { get; private set; }

        /// <summary>
        /// 字段的说明
        /// </summary>
        public string FieldDescription { get; set; }
    }
}
