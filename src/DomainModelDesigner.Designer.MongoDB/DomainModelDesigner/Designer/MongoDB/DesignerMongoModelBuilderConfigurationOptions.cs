using JetBrains.Annotations;
using Volo.Abp.MongoDB;

namespace DomainModelDesigner.Designer.MongoDB
{
    public class DesignerMongoModelBuilderConfigurationOptions : MongoModelBuilderConfigurationOptions
    {
        public DesignerMongoModelBuilderConfigurationOptions(
            [NotNull] string tablePrefix = DesignerConsts.DefaultDbTablePrefix)
            : base(tablePrefix)
        {
        }
    }
}