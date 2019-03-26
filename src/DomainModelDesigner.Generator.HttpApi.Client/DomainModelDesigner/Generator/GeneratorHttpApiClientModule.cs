using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Http.Client;
using Volo.Abp.Modularity;

namespace DomainModelDesigner.Generator
{
    [DependsOn(
        typeof(GeneratorApplicationContractsModule),
        typeof(AbpHttpClientModule))]
    public class GeneratorHttpApiClientModule : AbpModule
    {
        public const string RemoteServiceName = "Generator";

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddHttpClientProxies(
                typeof(GeneratorApplicationContractsModule).Assembly,
                RemoteServiceName
            );
        }
    }
}
