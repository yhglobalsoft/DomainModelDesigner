using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp;
using Volo.Abp.Domain.Entities;

namespace DomainModelDesigner.Designer.Entities
{
    /// <summary>
    /// 应用系统中的领域
    /// </summary>
    public class DomainEntity:Entity<Guid>
    {
        public virtual string DomainName { get; private set; }

        public virtual string Remark { get; private set; }

        protected DomainEntity() { }

        public DomainEntity(string domainName,string remark)
        {
            SetDomainName(domainName);

            Remark = remark;
        }

        public virtual void SetDomainName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new BusinessException(DesignerDomainErrorCodes.NullOrEmptyCheck)
                    .WithData("paramName", nameof(name));

            DomainName = name;
        }

        public virtual void SetRemark(string remark)
        {
            Remark = remark;
        }
    }
}
