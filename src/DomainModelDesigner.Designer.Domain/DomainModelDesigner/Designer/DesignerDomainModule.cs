﻿
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Domain;
using Volo.Abp.Localization;
using Volo.Abp.Localization.ExceptionHandling;
using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;

namespace DomainModelDesigner.Designer
{
    [DependsOn(
        typeof(DesignerDomainSharedModule),
        typeof(AbpDddDomainModule)
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
                options.Resources.Get<DefaultResource>().AddVirtualJson("/DomainModelDesigner/Designer/Localization/Domain");
            });

            Configure<ExceptionLocalizationOptions>(options =>
            {
                options.MapCodeNamespace("DE", typeof(DefaultResource));
            });
        }
    }
}
