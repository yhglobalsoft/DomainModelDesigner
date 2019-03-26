using DomainModelDesigner.Designer.Entities;
using DomainModelDesigner.Designer.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace DomainModelDesigner.Designer.EntityFrameworkCore
{
    [DependsOn(
        typeof(DesignerDomainModule),
        typeof(AbpEntityFrameworkCoreModule)
    )]
    public class DesignerEntityFrameworkCoreModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAbpDbContext<DesignerDbContext>(options =>
            {
                options.AddDefaultRepositories<IDesignerDbContext>();

                //通过这种方式来覆盖默认仓储
                //也就是 AppAggRootResptiroy 是 IRepository<AppAggRoot,Guid>的实现类，把默认的实现类替换了
                //options.AddRepository<AppAggRoot, AppAggRootResptiroy>();
                //options.AddRepository<AggRootObjectAggRoot, AggRootRepository>();
            });
        }
    }
}