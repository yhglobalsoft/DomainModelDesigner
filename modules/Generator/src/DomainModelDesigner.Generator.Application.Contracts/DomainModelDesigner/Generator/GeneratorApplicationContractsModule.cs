using Microsoft.Extensions.DependencyInjection;
using DomainModelDesigner.Generator.Localization;
using Volo.Abp.Application;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;

namespace DomainModelDesigner.Generator
{
    [DependsOn(
        typeof(GeneratorDomainSharedModule),
        typeof(AbpDddApplicationModule)
        )]
    public class GeneratorApplicationContractsModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<PermissionOptions>(options =>
            {
                options.DefinitionProviders.Add<GeneratorPermissionDefinitionProvider>();
            });

            Configure<VirtualFileSystemOptions>(options =>
            {
                options.FileSets.AddEmbedded<GeneratorApplicationContractsModule>();
            });

            Configure<AbpLocalizationOptions>(options =>
            {
                options.Resources
                    .Get<GeneratorResource>()
                    .AddVirtualJson("/DomainModelDesigner/Generator/Localization/ApplicationContracts");
            });
        }
    }
}
