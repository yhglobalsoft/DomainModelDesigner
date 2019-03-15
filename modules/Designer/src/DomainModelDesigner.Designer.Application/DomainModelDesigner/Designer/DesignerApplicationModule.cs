using DomainModelDesigner.Designer.EventHandlers;
using DomainModelDesigner.DistributedEvents;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp;
using Volo.Abp.AutoMapper;
using Volo.Abp.EventBus.Distributed;
using Volo.Abp.EventBus.RabbitMq;
using Volo.Abp.Modularity;
using Volo.Abp.Settings;

namespace DomainModelDesigner.Designer
{
    [DependsOn(
        typeof(DesignerDomainModule),
        typeof(DesignerApplicationContractsModule),
        typeof(AbpEventBusRabbitMqModule),
        typeof(AbpAutoMapperModule)
        )]
    public class DesignerApplicationModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpAutoMapperOptions>(options =>
            {
                options.AddProfile<DesignerApplicationAutoMapperProfile>(validate: true);
            });

            Configure<SettingOptions>(options =>
            {
                options.DefinitionProviders.Add<DesignerSettingDefinitionProvider>();
            });

            Configure<RabbitMqEventBusOptions>(options =>
            {
                options.ClientName = "DMD.Designer";
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
