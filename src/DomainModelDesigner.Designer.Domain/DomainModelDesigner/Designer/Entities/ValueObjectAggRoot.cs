using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp;

namespace DomainModelDesigner.Designer.Entities
{
    /// <summary>
    /// 值对象聚合根
    /// </summary>
    public class ValueObjectAggRoot : AggregateRootBase
    {
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

        public ValueObjectAggRoot(Guid domainEntityId,string name, string descriptions,string fieldName, string fieldTypeId, 
            bool isSimpleField, bool isConstructorParameter, bool isMultiple, string fieldLen, string fieldDescription) 
            :base(fieldName, fieldTypeId, isSimpleField,isConstructorParameter, isMultiple, fieldLen, fieldDescription)
        {
            DomainEntityId = domainEntityId;

            SetName(name);

            SetDescriptions(descriptions);
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
