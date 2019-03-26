using DomainModelDesigner.Designer.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp;

namespace DomainModelDesigner.Designer.Entities
{
    public class AggRootObjectAggRoot : AggregateRootBase
    {
        public virtual Guid AppId { get; private set; }
        /// <summary>
        /// 聚合根所属的领域
        /// </summary>
        public virtual Guid DomainEntityId { get; private set; }

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
        public virtual FieldTypeEnum IdTypeEnum
        {
            get
            {
                return FieldTypeEnum.GetById(_idTypeId);
            }
        }
        private int _idTypeId;

        /// <summary>
        /// 是否将id作为主键
        /// </summary>
        public virtual bool IdIsKey { get; private set; }

        /// <summary>
        /// 哪些列一起作为组合主键，多个列用逗号隔开，格式: "CreatTime,Code"
        /// </summary>
        public virtual string KeyFields { get; private set; }

        private List<IndexDesc> _indexs = new List<IndexDesc>();
        /// <summary>
        /// 索引信息
        /// </summary>
        public virtual IReadOnlyList<IndexDesc> Indexs => _indexs;


        public AggRootObjectAggRoot(Guid appId, Guid domainEntityId,bool idIsKey, string keyFields, string name, string descriptions, string fieldName,
            string fieldTypeId, bool isSimpleField, bool isConstructorParameter, bool isMultiple, string fieldLen, string fieldDescription) :
            base(fieldName, fieldTypeId, isSimpleField, isConstructorParameter, isMultiple, fieldLen, fieldDescription)
        {
            //默认是guid类型
            _idTypeId = FieldTypeEnum.UUID.Id;

            DomainEntityId = domainEntityId;
            AppId = appId;

            SetName(name);

            SetDescriptions(descriptions);

            SetIdIsKey(idIsKey);

            SetKeyFields(keyFields);
        }

        public virtual void SetIdType(FieldTypeEnum typeEnum)
        {
            _idTypeId = typeEnum.Id;
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
            _indexs.Add(new IndexDesc(indexName, isUnique, fields));
        }

        public virtual void SetName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new BusinessException(DesignerDomainErrorCodes.NullOrEmptyCheck)
                    .WithData("paramName", nameof(name));

            Name = name;
        }

        public virtual void SetDescriptions(string descriptions)
        {
            Descriptions = descriptions;
        }
    }
}
