using Volo.Abp.Modularity;

namespace DomainModelDesigner.Designer
{
    [DependsOn(
        typeof(DesignerApplicationModule),
        typeof(DesignerDomainTestModule)
        )]
    public class DesignerApplicationTestModule : AbpModule
    {

    }
}
