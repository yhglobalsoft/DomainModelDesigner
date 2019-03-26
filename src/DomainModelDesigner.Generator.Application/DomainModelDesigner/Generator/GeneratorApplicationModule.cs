using Microsoft.Extensions.DependencyInjection;
using Volo.Abp;
using Volo.Abp.AutoMapper;
using Volo.Abp.EventBus.RabbitMq;
using Volo.Abp.Modularity;
using Volo.Abp.Settings;

namespace DomainModelDesigner.Generator
{
    [DependsOn(
        typeof(GeneratorDomainModule),
        typeof(GeneratorApplicationContractsModule),
        typeof(AbpAutoMapperModule),
        typeof(AbpEventBusRabbitMqModule)
        )]
    public class GeneratorApplicationModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpAutoMapperOptions>(options =>
            {
                options.AddProfile<GeneratorApplicationAutoMapperProfile>(validate: true);
            });

            Configure<SettingOptions>(options =>
            {
                options.DefinitionProviders.Add<GeneratorSettingDefinitionProvider>();
            });

            Configure<RabbitMqEventBusOptions>(options =>
            {
                options.ClientName = "DMD.Generator";
                options.ExchangeName = "DMD";
            });
        }

        public override void OnApplicationInitialization(ApplicationInitializationContext context)
        {
            ////订阅分布式事件
            //var eventBus = context.ServiceProvider.GetService<IDistributedEventBus>();
            //eventBus.Subscribe<Event1, DistributedEventHandler>();
        }
    }
}
