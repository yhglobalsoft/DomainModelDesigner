using System;
using System.Collections.Generic;
using System.Text;

namespace DomainModelDesigner.Designer.Dtos
{
    public class CreateValueObjectInputDto
    {
        /// <summary>
        /// 所属领域
        /// </summary>
        public Guid DomainId { get; set; }

        /// <summary>
        /// 类名
        /// </summary>
        public string Name { get; set; }

        public string Desc { get; set; }

        public CreateValueObjectInputDtoDetail Fields { get; set; }
    }

    public class CreateValueObjectInputDtoDetail
    {
        public string FieldName { get; set; }

        public string FieldTypeId { get; set; }

        ///// <summary>
        ///// 是否是简单类型(非自定义类型都属于简单类型)
        ///// </summary>
        //public bool IsSimpleField { get; set; }

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
        public string FieldLen { get; set; }

        /// <summary>
        /// 字段的说明
        /// </summary>
        public string FieldDescription { get; set; }
    }
}
