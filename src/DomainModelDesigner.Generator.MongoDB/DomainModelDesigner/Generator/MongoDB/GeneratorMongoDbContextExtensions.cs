using System;
using Volo.Abp;
using Volo.Abp.MongoDB;

namespace DomainModelDesigner.Generator.MongoDB
{
    public static class GeneratorMongoDbContextExtensions
    {
        public static void ConfigureGenerator(
            this IMongoModelBuilder builder,
            Action<MongoModelBuilderConfigurationOptions> optionsAction = null)
        {
            Check.NotNull(builder, nameof(builder));

            var options = new GeneratorMongoModelBuilderConfigurationOptions();

            optionsAction?.Invoke(options);
        }
    }
}