using DomainModelDesigner.Designer.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Domain.Entities;

namespace DomainModelDesigner.Designer.Entities
{
    /// <summary>
    /// 索引描述信息
    /// </summary>
    public class IndexEntity:Entity<Guid>
    {
        /// <summary>
        /// 索引所属
        /// </summary>
        public IndexSourceEnum IndexSourceTypeId
        {
            get
            {
                return IndexSourceEnum.GetById<IndexSourceEnum>(_indexSourceTypeId);
            }
        }
        private int _indexSourceTypeId;

        /// <summary>
        /// 索引所属对象的id(如果是聚合根的索引就是聚合根id，是实体的索引就是实体id)
        /// </summary>
        public Guid IndexSourceId { get; private set; }

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

        protected IndexEntity() { }

        public IndexEntity(IndexSourceEnum indexSourceTypeId,Guid indexSourceId, string indexName,bool isUnique,string fields)
        {
            _indexSourceTypeId = indexSourceTypeId.Id;
            IndexSourceId = indexSourceId;
            IndexName = IndexName;
            IsUnique = isUnique;
            Fields = fields;
        }
    }
}
