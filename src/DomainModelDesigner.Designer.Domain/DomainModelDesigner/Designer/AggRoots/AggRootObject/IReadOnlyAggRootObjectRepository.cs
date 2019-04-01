using DomainModelDesigner.Designer.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace DomainModelDesigner.Designer.Repositories
{
    public interface IReadOnlyAggRootObjectRepository :
        IReadOnlyBasicRepository<AggRootObjectAggRoot, Guid>,
        IReadOnlyBasicRepository<AggRootObjectAggRoot>
    {
        Task<AggRootObjectAggRoot> GetByNameAsync(string name, CancellationToken cancellationToken);

        Task<List<AggRootObjectAggRoot>> GetByAppIdAsync(Guid appId, CancellationToken cancellationToken);
    }
}
