using Microsoft.Extensions.DependencyInjection;
using Volo.Abp;
using Volo.Abp.Authorization;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace DomainModelDesigner.Generator
{
    [DependsOn(
        typeof(AbpAutofacModule),
        typeof(AbpTestBaseModule),
        typeof(AbpAuthorizationModule),
        typeof(GeneratorDomainModule)
        )]
    public class GeneratorTestBaseModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAlwaysAllowAuthorization();
        }

        public override void OnApplicationInitialization(ApplicationInitializationContext context)
        {
            SeedTestData(context);
        }

        private static void SeedTestData(ApplicationInitializationContext context)
        {
            using (var scope = context.ServiceProvider.CreateScope())
            {
                scope.ServiceProvider
                    .GetRequiredService<GeneratorTestDataBuilder>()
                    .Build();
            }
        }
    }
}
