using JetBrains.Annotations;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace DomainModelDesigner.Generator.EntityFrameworkCore
{
    public class GeneratorModelBuilderConfigurationOptions : ModelBuilderConfigurationOptions
    {
        public GeneratorModelBuilderConfigurationOptions(
            [NotNull] string tablePrefix = GeneratorConsts.DefaultDbTablePrefix,
            [CanBeNull] string schema = GeneratorConsts.DefaultDbSchema)
            : base(
                tablePrefix,
                schema)
        {

        }
    }
}