using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Domain.Entities;

namespace DomainModelDesigner.Designer.Entities
{
    /// <summary>
    /// 索引描述信息
    /// </summary>
    public class IndexDesc:Entity<Guid>
    {
        /// <summary>
        /// 索引名称
        /// </summary>
        public virtual string IndexName { get; private set; }

        /// <summary>
        /// 是否是唯一索引
        /// </summary>
        public virtual bool IsUnique { get; private set; }

        /// <summary>
        /// 组成索引的列，多个用逗号隔开
        /// </summary>
        public virtual string Fields { get; private set; }

        protected IndexDesc() { }

        public IndexDesc(string indexName,bool isUnique,string fields) {
            IndexName = IndexName;
            IsUnique = isUnique;
            Fields = fields;
        }
    }

    //public class IndexType : Enumeration
    //{
    //    //唯一索引
    //    public static IndexType UNIQUE = new IndexType(1, nameof(UNIQUE));

    //    //普通索引
    //    public static IndexType NORMAL = new IndexType(1, nameof(NORMAL));

    //    public IndexType(int id,string value):base(id,value) { }
    //}
}
