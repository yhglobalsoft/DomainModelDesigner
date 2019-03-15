using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Modularity;

namespace DomainModelDesigner.Designer
{
    [DependsOn(
        typeof(DesignerApplicationContractsModule),
        typeof(AbpAspNetCoreMvcModule))]
    public class DesignerHttpApiModule : AbpModule
    {
        
    }
}
