using Volo.Abp.DependencyInjection;
using Volo.Abp.Guids;

namespace DomainModelDesigner.Designer
{
    public class DesignerTestDataBuilder : ITransientDependency
    {
        private readonly IGuidGenerator _guidGenerator;
        private DesignerTestData _testData;

        public DesignerTestDataBuilder(
            IGuidGenerator guidGenerator,
            DesignerTestData testData)
        {
            _guidGenerator = guidGenerator;
            _testData = testData;
        }

        public void Build()
        {
            
        }
    }
}