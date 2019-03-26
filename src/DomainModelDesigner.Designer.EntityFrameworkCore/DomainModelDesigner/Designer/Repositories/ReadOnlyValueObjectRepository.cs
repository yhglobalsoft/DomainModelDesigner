using DomainModelDesigner.Designer.Entities;
using DomainModelDesigner.Designer.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;

namespace DomainModelDesigner.Designer.Repositories
{
    public class ReadOnlyValueObjectRepository : 
        EfCoreRepository<IDesignerDbContext, ValueObjectAggRoot, Guid>,
        IReadOnlyValueObjectRepository
    {
        public ReadOnlyValueObjectRepository(IDbContextProvider<IDesignerDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        public async Task<List<ValueObjectAggRoot>> GetByNameAsync(Guid domainId, string name, CancellationToken cancellation = default(CancellationToken))
        {
           return await DbContext.ValueObjectAggRoots.AsNoTracking().
                Where(p => 
                    string.Equals(p.Name, name, StringComparison.OrdinalIgnoreCase) &&
                    p.DomainEntityId.Equals(domainId)
                ).ToListAsync();
        }


        public async Task<List<ValueObjectAggRoot>> GetListAsync(string sorting = null, 
            int maxResultCount = int.MaxValue, int skipCount = 0, string filter = null, 
            CancellationToken cancellationToken = default(CancellationToken))
        {
            return await DbContext.ValueObjectAggRoots.AsNoTracking()
                   .WhereIf(
                       !filter.IsNullOrWhiteSpace(),
                       u => u.Name.Contains(filter)
                   )
                   .OrderBy(sorting ?? nameof(ValueObjectAggRoot.Name))
                   .PageBy(skipCount, maxResultCount)
                   .ToListAsync(cancellationToken);
        }
    }
}
