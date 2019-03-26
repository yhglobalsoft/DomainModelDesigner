using Microsoft.Extensions.DependencyInjection;
using DomainModelDesigner.Generator.Localization;
using Volo.Abp.Localization;
using Volo.Abp.Localization.ExceptionHandling;
using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;

namespace DomainModelDesigner.Generator
{
    [DependsOn(
        typeof(GeneratorDomainSharedModule)
        )]
    public class GeneratorDomainModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<VirtualFileSystemOptions>(options =>
            {
                options.FileSets.AddEmbedded<GeneratorDomainModule>();
            });

            Configure<AbpLocalizationOptions>(options =>
            {
                options.Resources.Get<GeneratorResource>().AddVirtualJson("/DomainModelDesigner/Generator/Localization/Domain");
            });

            Configure<ExceptionLocalizationOptions>(options =>
            {
                options.MapCodeNamespace("Generator", typeof(GeneratorResource));
            });
        }
    }
}
