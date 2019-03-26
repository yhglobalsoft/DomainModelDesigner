using Volo.Abp.Data;
using Volo.Abp.MongoDB;

namespace DomainModelDesigner.Generator.MongoDB
{
    [ConnectionStringName("Generator")]
    public class GeneratorMongoDbContext : AbpMongoDbContext, IGeneratorMongoDbContext
    {
        public static string CollectionPrefix { get; set; } = GeneratorConsts.DefaultDbTablePrefix;

        /* Add mongo collections here. Example:
         * public IMongoCollection<Question> Questions => Collection<Question>();
         */

        protected override void CreateModel(IMongoModelBuilder modelBuilder)
        {
            base.CreateModel(modelBuilder);

            modelBuilder.ConfigureGenerator(options =>
            {
                options.CollectionPrefix = CollectionPrefix;
            });
        }
    }
}