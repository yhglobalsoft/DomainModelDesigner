using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp;
using Volo.Abp.Domain.Entities;
using System.Linq;

namespace DomainModelDesigner.Designer.Entities
{
    /// <summary>
    /// 应用系统
    /// </summary>
    public class AppAggRoot: AggregateRoot<Guid>
    {
        /// <summary>
        /// 系统的名称
        /// </summary>
        public virtual string AppName { get; private set; }


        private List<DomainEntity> _domainEntities=new List<DomainEntity>();
        /// <summary>
        /// 领域
        /// </summary>
        public virtual IReadOnlyList<DomainEntity> DomainEntities => _domainEntities;

        protected AppAggRoot() { }

        public AppAggRoot(string appName)
        {
            SetAppName(appName);
        }

        public virtual void SetAppName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new BusinessException(DesignerDomainErrorCodes.NullOrEmptyCheck)
                    .WithData("paramName", nameof(name));

            AppName = name;
        }

        public virtual void AddDomainEntity(string name,string remark)
        {
            _domainEntities.Add(new DomainEntity(name,remark));
        }

        public virtual void RemoveDomainEntity(Guid domainId)
        {
            var obj = _domainEntities.SingleOrDefault(p=>p.Id.Equals(domainId));
            if(obj==null)
                throw new BusinessException(DesignerDomainErrorCodes.NoDataCheck)
                    .WithData("paramValue", domainId);

            _domainEntities.Remove(obj);
        }
    }
}
