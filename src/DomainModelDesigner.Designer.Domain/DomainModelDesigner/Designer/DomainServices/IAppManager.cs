using DomainModelDesigner.Designer.Entities;
using DomainModelDesigner.Designer.EntityDtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DomainModelDesigner.Designer.DomainServices
{
    public interface IAppManager
    {
        Task<AppAggRoot> CreateAppAsync(string appName, CancellationToken cancellationToken = default(CancellationToken));

        Task<AppAggRoot> UpdateAppNameAsync(Guid appId, string newName, CancellationToken cancellationToken=default(CancellationToken));

        Task<AppAggRoot> UpdateDomainAsync(Guid appId, Guid domainId,string newName,string newRemark, CancellationToken cancellationToken = default(CancellationToken));

        Task<AppAggRoot> AddDomainAsync(Guid appId, AddDomainEDto dto, CancellationToken cancellationToken = default(CancellationToken));

        Task DeleteAppAsync(Guid id, CancellationToken cancellationToken = default(CancellationToken));

        Task<AppAggRoot> RemoveDomainAsync(Guid appId, Guid domainId, CancellationToken cancellationToken = default(CancellationToken));

    }
}
