using System.Threading.Tasks;
using Volo.Abp.Modularity;
using Xunit;

namespace DomainModelDesigner.Designer
{
    public abstract class MyEntityRepository_Tests<TStartupModule> : DesignerTestBase<TStartupModule>
        where TStartupModule : IAbpModule
    {
        [Fact]
        public async Task Test1()
        {

        }
    }
}
