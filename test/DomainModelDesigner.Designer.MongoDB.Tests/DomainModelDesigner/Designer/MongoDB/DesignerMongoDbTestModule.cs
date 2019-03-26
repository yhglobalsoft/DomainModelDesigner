using Microsoft.Extensions.DependencyInjection;
using Mongo2Go;
using Volo.Abp;
using Volo.Abp.Data;
using Volo.Abp.Modularity;

namespace DomainModelDesigner.Designer.MongoDB
{
    [DependsOn(
        typeof(DesignerTestBaseModule),
        typeof(DesignerMongoDbModule)
        )]
    public class DesignerMongoDbTestModule : AbpModule
    {
        private MongoDbRunner _mongoDbRunner;

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            _mongoDbRunner = MongoDbRunner.Start();

            Configure<DbConnectionOptions>(options =>
            {
                options.ConnectionStrings.Default = _mongoDbRunner.ConnectionString;
            });
        }

        public override void OnApplicationShutdown(ApplicationShutdownContext context)
        {
            _mongoDbRunner.Dispose();
        }
    }
}