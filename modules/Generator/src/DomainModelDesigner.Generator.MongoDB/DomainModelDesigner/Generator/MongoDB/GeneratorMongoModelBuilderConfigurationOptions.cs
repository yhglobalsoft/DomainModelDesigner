using JetBrains.Annotations;
using Volo.Abp.MongoDB;

namespace DomainModelDesigner.Generator.MongoDB
{
    public class GeneratorMongoModelBuilderConfigurationOptions : MongoModelBuilderConfigurationOptions
    {
        public GeneratorMongoModelBuilderConfigurationOptions(
            [NotNull] string tablePrefix = GeneratorConsts.DefaultDbTablePrefix)
            : base(tablePrefix)
        {
        }
    }
}