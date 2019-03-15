using Volo.Abp.Modularity;

namespace DomainModelDesigner.Generator
{
    [DependsOn(
        typeof(GeneratorApplicationModule),
        typeof(GeneratorDomainTestModule)
        )]
    public class GeneratorApplicationTestModule : AbpModule
    {

    }
}
