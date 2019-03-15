using Volo.Abp;
using Volo.Abp.Modularity;

namespace DomainModelDesigner.Generator
{
    public abstract class GeneratorTestBase<TStartupModule> : AbpIntegratedTest<TStartupModule> 
        where TStartupModule : IAbpModule
    {
        protected override void SetAbpApplicationCreationOptions(AbpApplicationCreationOptions options)
        {
            options.UseAutofac();
        }
    }
}
