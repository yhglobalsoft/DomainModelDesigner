using Volo.Abp.DependencyInjection;
using Volo.Abp.Guids;

namespace DomainModelDesigner.Generator
{
    public class GeneratorTestDataBuilder : ITransientDependency
    {
        private readonly IGuidGenerator _guidGenerator;
        private GeneratorTestData _testData;

        public GeneratorTestDataBuilder(
            IGuidGenerator guidGenerator,
            GeneratorTestData testData)
        {
            _guidGenerator = guidGenerator;
            _testData = testData;
        }

        public void Build()
        {
            
        }
    }
}