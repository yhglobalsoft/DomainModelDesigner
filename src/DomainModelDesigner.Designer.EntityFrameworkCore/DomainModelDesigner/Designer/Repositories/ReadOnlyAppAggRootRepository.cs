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

        /// <summary>
        /// 重写本方法的原因：基类中的方法在查不到数据时会抛异常
        /// </summary>
        /// <param name="id"></param>
        /// <param name="includeDetails"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public override async Task<AppAggRoot> GetAsync(Guid id, bool includeDetails = true, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (includeDetails)
                return await DbContext.AppAggRoots.AsTracking().Include(p => p.DomainEntities)
                 .SingleOrDefaultAsync(p => p.Id.Equals(id));
            else
                return await DbContext.AppAggRoots.AsTracking()
                .SingleOrDefaultAsync(p => p.Id.Equals(id));
        }

        public async Task<List<AppAggRoot>> GetByNameAsync(string name, bool includeDetails = true, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (includeDetails)
                return await DbContext.AppAggRoots.AsTracking().Include(p => p.DomainEntities)
                           .Where(p => string.Equals(p.AppName, name, StringComparison.OrdinalIgnoreCase)).ToListAsync();
            else
                return await DbContext.AppAggRoots.AsTracking()
                          .Where(p => string.Equals(p.AppName, name, StringComparison.OrdinalIgnoreCase)).ToListAsync();
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
