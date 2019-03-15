using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Modularity;
using Volo.Abp.Localization;
using DomainModelDesigner.Generator.Localization;

namespace DomainModelDesigner.Generator
{
    [DependsOn(
        typeof(AbpLocalizationModule)
        )]
    public class GeneratorDomainSharedModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpLocalizationOptions>(options =>
            {
                options.Resources.Add<GeneratorResource>("en");
            });
        }
    }
}
