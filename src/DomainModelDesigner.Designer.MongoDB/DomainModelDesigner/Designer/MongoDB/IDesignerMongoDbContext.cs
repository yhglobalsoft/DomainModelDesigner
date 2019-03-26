using Volo.Abp.Data;
using Volo.Abp.MongoDB;

namespace DomainModelDesigner.Designer.MongoDB
{
    [ConnectionStringName("Designer")]
    public interface IDesignerMongoDbContext : IAbpMongoDbContext
    {
        /* Define mongo collections here. Example:
         * IMongoCollection<Question> Questions { get; }
         */
    }
}
