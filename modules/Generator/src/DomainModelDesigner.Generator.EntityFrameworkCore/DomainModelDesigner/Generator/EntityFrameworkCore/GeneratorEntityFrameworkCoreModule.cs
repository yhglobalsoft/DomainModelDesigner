using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace DomainModelDesigner.Generator.EntityFrameworkCore
{
    [DependsOn(
        typeof(GeneratorDomainModule),
        typeof(AbpEntityFrameworkCoreModule)
    )]
    public class GeneratorEntityFrameworkCoreModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAbpDbContext<GeneratorDbContext>(options =>
            {
                /* Add custom repositories here. Example:
                 * options.AddRepository<Question, EfCoreQuestionRepository>();
                 */
            });
        }
    }
}