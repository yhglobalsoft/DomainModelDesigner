using DomainModelDesigner.Designer.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;

namespace DomainModelDesigner.Designer.Entities
{
    public class FieldEntity : Entity<Guid>
    {
        ////字段所属的类型
        //private int _fieldSource;
        //public FieldSourceEnum FieldSource
        //{
        //    get
        //    {
        //        return FieldSourceEnum.GetById<FieldSourceEnum>(_fieldSource);
        //    }
        //}

        ////字段属于实体的Id
        //public Guid FieldSourceId { get; private set; }

        public virtual string FieldName { get; private set; }

        public virtual string FieldTypeId { get; private set; }

        /// <summary>
        /// 是否是简单类型(非自定义类型都属于简单类型)
        /// </summary>
        public virtual bool IsSimpleField { get; private set; }

        /// <summary>
        /// 是否作为构造函数的参数
        /// </summary>
        public virtual bool IsConstructorParameter { get; private set; }

        /// <summary>
        /// 字段是否是集合
        /// </summary>
        public virtual bool IsMultiple { get; private set; }

        /// <summary>
        /// 字段长度
        /// </summary>
        public virtual string FieldLen { get; private set; }

        /// <summary>
        /// 字段的说明
        /// </summary>
        public virtual string FieldDescription { get; private set; }

        protected FieldEntity()
        {
            /* 此构造函数是提供给ORM用来从数据库中获取实体.
             */

        }

        public FieldEntity(string fieldName, string fieldTypeId, bool isSimpleField,bool isConstructorParameter, 
            bool isMultiple, string fieldLen, string fieldDescription)
        {
            SetFieldName(fieldName);

            SetFieldTypeId(fieldTypeId);

            SetIsSimpleField(isSimpleField);

            SetIsConstructorParameter(isConstructorParameter);

            SetIsMultiple(isMultiple);

            SetFieldLen(fieldLen);

            SetFieldDescription(fieldDescription);
        }

        public virtual void SetFieldName(string fieldName)
        {
            if (string.IsNullOrWhiteSpace(fieldName))
                throw new DomainException(DesignerDomainErrorCodes.NullOrEmptyCheck)
                    .WithData("paramName", nameof(fieldName));

            FieldName = fieldName;
        }

        public virtual void SetFieldTypeId(string fieldTypeId)
        {
            if (string.IsNullOrWhiteSpace(fieldTypeId))
                throw new DomainException(DesignerDomainErrorCodes.NullOrEmptyCheck)
                    .WithData("paramName", nameof(fieldTypeId));

            FieldTypeId = fieldTypeId;
        }

        public virtual void SetIsSimpleField(bool isSimpleField)
        {
            IsSimpleField = isSimpleField;
        }

        public virtual void SetIsConstructorParameter(bool isConstructorParameter)
        {
            IsConstructorParameter = isConstructorParameter;
        }

        public virtual void SetIsMultiple(bool isMultiple)
        {
            IsMultiple = isMultiple;
        }

        public virtual void SetFieldLen(string fieldLen)
        {
            FieldLen = fieldLen;
        }

        public virtual void SetFieldDescription(string desc)
        {
            FieldDescription = desc;
        }
    }
}
