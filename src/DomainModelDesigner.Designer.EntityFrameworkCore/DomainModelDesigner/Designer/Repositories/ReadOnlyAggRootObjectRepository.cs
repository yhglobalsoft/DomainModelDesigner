using DomainModelDesigner.Designer.Entities;
using DomainModelDesigner.Designer.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.DependencyInjection;

namespace DomainModelDesigner.Designer.Repositories
{
    public class ReadOnlyAggRootObjectRepository :
        EfCoreRepository<IDesignerDbContext, AggRootObjectAggRoot, Guid>,
        IReadOnlyAggRootObjectRepository
    {
        public ReadOnlyAggRootObjectRepository(IDbContextProvider<IDesignerDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        /// <summary>
        /// 重写本方法的原因：基类中的方法在查不到数据时会抛异常
        /// </summary>
        /// <param name="id"></param>
        /// <param name="includeDetails"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async override Task<AggRootObjectAggRoot> GetAsync(Guid id, bool includeDetails = true, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (includeDetails)
                return await DbContext.AggRootObjectAggRoots.AsTracking().Include(p => p.Indexs)
                 .SingleOrDefaultAsync(p => p.Id.Equals(id));
            else
                return await DbContext.AggRootObjectAggRoots.AsTracking()
                   .SingleOrDefaultAsync(p => p.Id.Equals(id));
        }

        public Task<List<AggRootObjectAggRoot>> GetByAppIdAsync(Guid appId, CancellationToken cancellationToken)
        {
            var result = DbContext.AggRootObjectAggRoots.AsNoTracking().Where(p => p.AppId.Equals(appId));

            List<AggRootObjectAggRoot> list = null;
            if (result != null && result.Count() > 0)
                list = result.ToList();

            return Task.FromResult<List<AggRootObjectAggRoot>>(list);
        }

        public async Task<AggRootObjectAggRoot> GetByNameAsync(string name, CancellationToken cancellationToken)
        {
            return await DbContext.AggRootObjectAggRoots.AsNoTracking()
                 .SingleOrDefaultAsync(p => string.Equals(p.Name, name, StringComparison.OrdinalIgnoreCase));
        }
    }
}
