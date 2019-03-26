using Microsoft.Extensions.DependencyInjection;
using DomainModelDesigner.Designer.Localization;
using Volo.Abp.Application;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;
using FluentValidation.AspNetCore;
using DomainModelDesigner.Designer.Dtos.Validators;

namespace DomainModelDesigner.Designer
{
    [DependsOn(
        typeof(DesignerDomainSharedModule),
        typeof(AbpDddApplicationModule)
        )]
    public class DesignerApplicationContractsModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<PermissionOptions>(options =>
            {
                options.DefinitionProviders.Add<DesignerPermissionDefinitionProvider>();
            });

            Configure<VirtualFileSystemOptions>(options =>
            {
                options.FileSets.AddEmbedded<DesignerApplicationContractsModule>();
            });

            Configure<AbpLocalizationOptions>(options =>
            {
                options.Resources
                    .Get<DesignerResource>()
                    .AddVirtualJson("/DomainModelDesigner/Designer/Localization/ApplicationContracts");
            });

            //context.Services.AddScoped<IValidatorInterceptor, CreateAppInputDtoValidator>();

        }
    }
}
