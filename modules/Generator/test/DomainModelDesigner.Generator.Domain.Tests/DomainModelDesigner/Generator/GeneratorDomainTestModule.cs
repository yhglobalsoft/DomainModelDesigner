using DomainModelDesigner.Generator.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace DomainModelDesigner.Generator
{
    [DependsOn(
        typeof(GeneratorEntityFrameworkCoreTestModule)
        )]
    public class GeneratorDomainTestModule : AbpModule
    {
        
    }
}
