using DomainModelDesigner.Designer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace DomainModelDesigner.Designer.Repositories
{
    public interface IReadOnlyAppAggRootRepository :
        IReadOnlyBasicRepository<AppAggRoot,Guid>,
        IReadOnlyBasicRepository<AppAggRoot>
    {
        Task<List<AppAggRoot>> GetByNameAsync(string name, bool includeDetails = true, CancellationToken cancellationToken=default(CancellationToken));

        Task<List<AppAggRoot>> GetListAsync(
          string sorting = null,
          int maxResultCount = int.MaxValue,
          int skipCount = 0,
          string filter = null,
          bool includeDetails = false,
         CancellationToken cancellationToken = default(CancellationToken));
    }
}
