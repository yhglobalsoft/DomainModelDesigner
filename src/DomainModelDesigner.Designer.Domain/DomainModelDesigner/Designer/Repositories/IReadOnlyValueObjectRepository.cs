using DomainModelDesigner.Designer.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace DomainModelDesigner.Designer.Repositories
{
    public interface IReadOnlyValueObjectRepository : 
        IReadOnlyBasicRepository<ValueObjectAggRoot,Guid>, 
        IReadOnlyBasicRepository<ValueObjectAggRoot>
    {
        Task<List<ValueObjectAggRoot>> GetByNameAsync(Guid domainId,string name, CancellationToken cancellation=default(CancellationToken));


        Task<List<ValueObjectAggRoot>> GetListAsync(string sorting = null, int maxResultCount = int.MaxValue, int skipCount = 0, string filter = null, CancellationToken cancellationToken = default(CancellationToken));
    }
}
