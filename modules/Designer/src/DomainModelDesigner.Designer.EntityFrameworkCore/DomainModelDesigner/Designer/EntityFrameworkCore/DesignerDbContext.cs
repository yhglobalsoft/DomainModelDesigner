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

        /* Add DbSet for each Aggregate Root here. Example:
         * public DbSet<Question> Questions { get; set; }
         */

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