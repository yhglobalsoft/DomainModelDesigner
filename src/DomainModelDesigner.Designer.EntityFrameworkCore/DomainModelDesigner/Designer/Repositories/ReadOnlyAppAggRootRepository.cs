using DomainModelDesigner.Designer.Entities;
using DomainModelDesigner.Designer.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using System.Threading;
using System.Linq.Dynamic.Core;

namespace DomainModelDesigner.Designer.Repositories
{
    public class ReadOnlyAppAggRootRepository : 
        EfCoreRepository<IDesignerDbContext, AppAggRoot, Guid>,
        IReadOnlyAppAggRootRepository
    {
        public ReadOnlyAppAggRootRepository(IDbContextProvider<IDesignerDbContext> contextProvider):base(contextProvider)
        {
        }

        public async Task<AppAggRoot> GetByNameAsync(string name, bool includeDetails = true, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (includeDetails)
                return await DbContext.AppAggRoots.AsTracking().Include(p=>p.DomainEntities)
                 .SingleOrDefaultAsync(p => string.Equals(p.AppName, name, StringComparison.OrdinalIgnoreCase));
            else
                return await DbContext.AppAggRoots.AsTracking()
                 .SingleOrDefaultAsync(p => string.Equals(p.AppName, name, StringComparison.OrdinalIgnoreCase));

        }

        public async Task<List<AppAggRoot>> GetListAsync(string sorting = null, int maxResultCount = int.MaxValue, int skipCount = 0, string filter = null, bool includeDetails = false, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (includeDetails)
            {
                return await DbContext.AppAggRoots.AsNoTracking()
                 .Include(p => p.DomainEntities)
                 .WhereIf(
                     !filter.IsNullOrWhiteSpace(),
                     u => u.AppName.Contains(filter)
                 )
                 .OrderBy(sorting ?? nameof(AppAggRoot.AppName))
                 .PageBy(skipCount, maxResultCount)
                 .ToListAsync(cancellationToken);
            }
            else
            {
                return await DbContext.AppAggRoots.AsNoTracking()
                 .WhereIf(
                     !filter.IsNullOrWhiteSpace(),
                     u => u.AppName.Contains(filter)
                 )
                 .OrderBy(sorting ?? nameof(AppAggRoot.AppName))
                 .PageBy(skipCount, maxResultCount)
                 .ToListAsync(cancellationToken);
            }
        }
    }
}
