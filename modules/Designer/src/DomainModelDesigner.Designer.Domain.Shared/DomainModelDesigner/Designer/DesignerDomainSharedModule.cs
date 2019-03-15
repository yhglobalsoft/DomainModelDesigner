using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Modularity;
using Volo.Abp.Localization;
using DomainModelDesigner.Designer.Localization;

namespace DomainModelDesigner.Designer
{
    [DependsOn(
        typeof(AbpLocalizationModule)
        )]
    public class DesignerDomainSharedModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpLocalizationOptions>(options =>
            {
                options.Resources.Add<DesignerResource>("en");
            });
        }
    }
}
