using DomainModelDesigner.Designer.Entities;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace DomainModelDesigner.Designer.EntityFrameworkCore
{
    [ConnectionStringName("Designer")]
    public class DesignerDbContext : AbpDbContext<DesignerDbContext>, IDesignerDbContext
    {
        public static string TablePrefix { get; set; } = DesignerConsts.DefaultDbTablePrefix;

        public static string Schema { get; set; } = DesignerConsts.DefaultDbSchema;

        public DbSet<AppAggRoot> AppAggRoots { get; set; }
        public DbSet<DomainEntity> DomainEntities { get; set; }
        public DbSet<ValueObjectAggRoot> ValueObjectAggRoots { get; set; }
        public DbSet<EntityObjectAggRoot> EntityObjectAggRoots { get; set; }

        public DbSet<AggRootObjectAggRoot> AggRootObjectAggRoots { get; set; }
        public DbSet<IndexDesc> IndexDescs { get; set; }

        public DesignerDbContext(DbContextOptions<DesignerDbContext> options) 
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ConfigureDesigner(options =>
            {
                options.TablePrefix = TablePrefix;
                options.Schema = Schema;
            });
        }
    }
}