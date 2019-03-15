using DomainModelDesigner.Designer.Localization;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Localization;
using Volo.Abp.Localization.ExceptionHandling;
using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;

namespace DomainModelDesigner.Designer
{
    [DependsOn(
        typeof(DesignerDomainSharedModule)
        )]
    public class DesignerDomainModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<VirtualFileSystemOptions>(options =>
            {
                options.FileSets.AddEmbedded<DesignerDomainModule>();
            });

            Configure<AbpLocalizationOptions>(options =>
            {
                options.Resources.Get<DesignerResource>().AddVirtualJson("/DomainModelDesigner/Designer/Localization/Domain");
            });

            Configure<ExceptionLocalizationOptions>(options =>
            {
                options.MapCodeNamespace("Designer", typeof(DesignerResource));
            });
        }
    }
}
