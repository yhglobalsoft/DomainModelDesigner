using JetBrains.Annotations;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace DomainModelDesigner.Designer.EntityFrameworkCore
{
    public class DesignerModelBuilderConfigurationOptions : ModelBuilderConfigurationOptions
    {
        public DesignerModelBuilderConfigurationOptions(
            [NotNull] string tablePrefix = DesignerConsts.DefaultDbTablePrefix,
            [CanBeNull] string schema = DesignerConsts.DefaultDbSchema)
            : base(
                tablePrefix,
                schema)
        {

        }
    }
}