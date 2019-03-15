using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Http.Client;
using Volo.Abp.Modularity;

namespace DomainModelDesigner.Designer
{
    [DependsOn(
        typeof(DesignerApplicationContractsModule),
        typeof(AbpHttpClientModule))]
    public class DesignerHttpApiClientModule : AbpModule
    {
        public const string RemoteServiceName = "Designer";

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddHttpClientProxies(
                typeof(DesignerApplicationContractsModule).Assembly,
                RemoteServiceName
            );
        }
    }
}
