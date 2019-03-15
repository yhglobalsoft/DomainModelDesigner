using Volo.Abp.Data;
using Volo.Abp.MongoDB;

namespace DomainModelDesigner.Designer.MongoDB
{
    [ConnectionStringName("Designer")]
    public class DesignerMongoDbContext : AbpMongoDbContext, IDesignerMongoDbContext
    {
        public static string CollectionPrefix { get; set; } = DesignerConsts.DefaultDbTablePrefix;

        /* Add mongo collections here. Example:
         * public IMongoCollection<Question> Questions => Collection<Question>();
         */

        protected override void CreateModel(IMongoModelBuilder modelBuilder)
        {
            base.CreateModel(modelBuilder);

            modelBuilder.ConfigureDesigner(options =>
            {
                options.CollectionPrefix = CollectionPrefix;
            });
        }
    }
}