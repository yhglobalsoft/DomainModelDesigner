using Volo.Abp.Data;
using Volo.Abp.MongoDB;

namespace DomainModelDesigner.Generator.MongoDB
{
    [ConnectionStringName("Generator")]
    public interface IGeneratorMongoDbContext : IAbpMongoDbContext
    {
        /* Define mongo collections here. Example:
         * IMongoCollection<Question> Questions { get; }
         */
    }
}
