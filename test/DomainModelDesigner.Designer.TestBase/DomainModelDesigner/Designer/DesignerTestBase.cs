using Volo.Abp;
using Volo.Abp.Modularity;

namespace DomainModelDesigner.Designer
{
    public abstract class DesignerTestBase<TStartupModule> : AbpIntegratedTest<TStartupModule> 
        where TStartupModule : IAbpModule
    {
        protected override void SetAbpApplicationCreationOptions(AbpApplicationCreationOptions options)
        {
            options.UseAutofac();
        }
    }
}
