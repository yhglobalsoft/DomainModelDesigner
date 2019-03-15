using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace DomainModelDesigner.Generator.EntityFrameworkCore
{
    [ConnectionStringName("Generator")]
    public interface IGeneratorDbContext : IEfCoreDbContext
    {
        /* Add DbSet for each Aggregate Root here. Example:
         * DbSet<Question> Questions { get; }
         */
    }
}