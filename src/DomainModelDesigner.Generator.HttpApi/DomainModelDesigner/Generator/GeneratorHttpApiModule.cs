using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Modularity;

namespace DomainModelDesigner.Generator
{
    [DependsOn(
        typeof(GeneratorApplicationContractsModule),
        typeof(AbpAspNetCoreMvcModule))]
    public class GeneratorHttpApiModule : AbpModule
    {
        
    }
}
