using DomainModelDesigner.Designer.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace DomainModelDesigner.Designer
{
    [DependsOn(
        typeof(DesignerEntityFrameworkCoreTestModule)
        )]
    public class DesignerDomainTestModule : AbpModule
    {
        
    }
}
