using DomainModelDesigner.Designer.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;

namespace DomainModelDesigner.Designer.Entities
{
    /// <summary>
    /// 值对象聚合根
    /// </summary>
    public class ValueObjectAggRoot :AuditedAggregateRoot<Guid>
    {
        /// <summary>
        /// 值对象所属的领域
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

        private List<FieldEntity> _fields=new List<FieldEntity>();
        public virtual IReadOnlyList<FieldEntity> Fields => _fields;

        protected ValueObjectAggRoot() { }

        public ValueObjectAggRoot(Guid domainId,string name, string descriptions) 
        {
            DomainId = domainId;

            SetName(name);

            SetDescriptions(descriptions);
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
            _fields.Add(new FieldEntity(fieldName, fieldTypeId, isSimpleField, isConstructorParameter,
              isMultiple, fieldLen, fieldDescription));
        }

        public virtual void ClearFields()
        {
            _fields.Clear();
        }
    }
}
