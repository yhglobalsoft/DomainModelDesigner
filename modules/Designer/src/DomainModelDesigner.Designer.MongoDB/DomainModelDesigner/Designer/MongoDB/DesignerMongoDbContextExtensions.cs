using System;
using Volo.Abp;
using Volo.Abp.MongoDB;

namespace DomainModelDesigner.Designer.MongoDB
{
    public static class DesignerMongoDbContextExtensions
    {
        public static void ConfigureDesigner(
            this IMongoModelBuilder builder,
            Action<MongoModelBuilderConfigurationOptions> optionsAction = null)
        {
            Check.NotNull(builder, nameof(builder));

            var options = new DesignerMongoModelBuilderConfigurationOptions();

            optionsAction?.Invoke(options);
        }
    }
}