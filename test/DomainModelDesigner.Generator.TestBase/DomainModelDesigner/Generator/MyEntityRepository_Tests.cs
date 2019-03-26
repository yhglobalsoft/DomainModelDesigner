using System.Threading.Tasks;
using Volo.Abp.Modularity;
using Xunit;

namespace DomainModelDesigner.Generator
{
    public abstract class MyEntityRepository_Tests<TStartupModule> : GeneratorTestBase<TStartupModule>
        where TStartupModule : IAbpModule
    {
        [Fact]
        public async Task Test1()
        {

        }
    }
}
