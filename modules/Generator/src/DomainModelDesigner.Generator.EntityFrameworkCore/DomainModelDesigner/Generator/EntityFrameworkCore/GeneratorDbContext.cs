using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace DomainModelDesigner.Generator.EntityFrameworkCore
{
    [ConnectionStringName("Generator")]
    public class GeneratorDbContext : AbpDbContext<GeneratorDbContext>, IGeneratorDbContext
    {
        public static string TablePrefix { get; set; } = GeneratorConsts.DefaultDbTablePrefix;

        public static string Schema { get; set; } = GeneratorConsts.DefaultDbSchema;

        /* Add DbSet for each Aggregate Root here. Example:
         * public DbSet<Question> Questions { get; set; }
         */

        public GeneratorDbContext(DbContextOptions<GeneratorDbContext> options) 
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ConfigureGenerator(options =>
            {
                options.TablePrefix = TablePrefix;
                options.Schema = Schema;
            });
        }
    }
}