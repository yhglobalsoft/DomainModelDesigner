using DomainModelDesigner.Designer.Entities;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace DomainModelDesigner.Designer.EntityFrameworkCore
{
    [ConnectionStringName("Designer")]
    public interface IDesignerDbContext : IEfCoreDbContext
    {
        /* Add DbSet for each Aggregate Root here. Example:
         * DbSet<Question> Questions { get; }
         */

        DbSet<AppAggRoot> AppAggRoots { get; set; }
        DbSet<DomainEntity> DomainEntities { get; set; }
        DbSet<ValueObjectAggRoot> ValueObjectAggRoots { get; set; }
        DbSet<EntityObjectAggRoot> EntityObjectAggRoots { get; set; }
        DbSet<AggRootObjectAggRoot> AggRootObjectAggRoots { get; set; }
        DbSet<IndexDesc> IndexDescs { get; set; }
    }
}