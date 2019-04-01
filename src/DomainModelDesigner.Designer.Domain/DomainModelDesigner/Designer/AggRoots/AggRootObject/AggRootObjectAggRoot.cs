using DomainModelDesigner.Designer.Enums;
using DomainModelDesigner.Designer.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;

namespace DomainModelDesigner.Designer.Entities
{
    public class AggRootObjectAggRoot : AuditedAggregateRoot<Guid>
    {
        public virtual Guid AppId { get; private set; }

        /// <summary>
        /// 聚合根所属的领域
        /// </summary>
        public virtual Guid DomainId { get; private set; }

        /// <summary>
        /// 类的名称
        /// </summary>
        public virtual string Name { get; private set; }

        /// <summary>
        /// 类的描述
        /// </summary>
        public virtual string Descriptions { get; private set; }

        /// <summary>
        /// Id列的类型
        /// </summary>
        public virtual FieldTypeEnum IdType
        {
            get
            {
                return FieldTypeEnum.GetById<FieldTypeEnum>(_idType);
            }
        }
        private int _idType;

        /// <summary>
        /// 是否将id作为主键
        /// </summary>
        public virtual bool IdIsKey { get; private set; }

        /// <summary>
        /// 哪些列一起作为组合主键，多个列用逗号隔开，格式: "CreatTime,Code"
        /// </summary>
        public virtual string KeyFields { get; private set; }

        private List<IndexEntity> _indexs = new List<IndexEntity>();
        /// <summary>
        /// 索引信息
        /// </summary>
        public virtual IReadOnlyList<IndexEntity> Indexs => _indexs;

        private List<FieldEntity> _fields = new List<FieldEntity>();
        public virtual IReadOnlyList<FieldEntity> Fields => _fields;

        protected AggRootObjectAggRoot() { }

        public AggRootObjectAggRoot(Guid appId, Guid domainEntityId, bool idIsKey, FieldTypeEnum idType, 
            string keyFields, string name, string descriptions)
        {
            //默认是guid类型
            _idType = idType.Id;

            DomainId = domainEntityId;
            AppId = appId;

            SetName(name);

            SetDescriptions(descriptions);

            SetIdIsKey(idIsKey);

            SetKeyFields(keyFields);
        }

        public virtual void SetIdType(FieldTypeEnum typeEnum)
        {
            _idType = typeEnum.Id;
        }

        public virtual void SetIdIsKey(bool idIsKey)
        {
            IdIsKey = idIsKey;
        }

        public virtual void SetKeyFields(string keyFields)
        {
            KeyFields = keyFields;
        }

        public virtual void AddIndex(string indexName, bool isUnique, string fields)
        {
            _indexs.Add(new IndexEntity(IndexSourceEnum.AggRoot,this.Id,indexName, isUnique, fields));
        }

        public virtual void SetName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new DomainException(DesignerDomainErrorCodes.NullOrEmptyCheck)
                    .WithData("paramName", nameof(name));

            Name = name;
        }

        public virtual void SetDescriptions(string descriptions)
        {
            Descriptions = descriptions;
        }

        public virtual void AddField(string fieldName, string fieldTypeId, bool isSimpleField,
            bool isConstructorParameter, bool isMultiple, string fieldLen, string fieldDescription)
        {
            _fields.Add(new FieldEntity(fieldName, fieldTypeId, isSimpleField,
               isConstructorParameter, isMultiple, fieldLen, fieldDescription));
        }

        public virtual void ClearFields()
        {
            _fields.Clear();
        }
    }
}
