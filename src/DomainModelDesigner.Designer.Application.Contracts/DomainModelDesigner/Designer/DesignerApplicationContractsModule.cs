using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Application;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;
using FluentValidation.AspNetCore;
using DomainModelDesigner.Designer.Dtos.Validators;
using Volo.Abp.Localization.ExceptionHandling;

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
                    .Get<DefaultResource>()
                    .AddVirtualJson("/DomainModelDesigner/Designer/Localization/ApplicationContracts");
            });

            Configure<ExceptionLocalizationOptions>(options =>
            {
                options.MapCodeNamespace("App", typeof(DefaultResource));
            });

            //context.Services.AddScoped<IValidatorInterceptor, CreateAppInputDtoValidator>();

        }
    }
}
