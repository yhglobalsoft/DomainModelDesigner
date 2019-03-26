using System;
using DomainModelDesigner.Designer.Entities;
using DomainModelDesigner.Designer.EntityFrameworkCore.ModelConfigs;
using DomainModelDesigner.Designer.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Volo.Abp;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace DomainModelDesigner.Designer.EntityFrameworkCore
{
    public static class DesignerDbContextModelCreatingExtensions
    {
        public static void ConfigureDesigner(
            this ModelBuilder builder,
            Action<DesignerModelBuilderConfigurationOptions> optionsAction = null)
        {
            Check.NotNull(builder, nameof(builder));

            var options = new DesignerModelBuilderConfigurationOptions();

            optionsAction?.Invoke(options);

            AppAggRootConfig.Config(builder, options.TablePrefix, options.Schema);
            AggRootObjectAggRootConfig.Config(builder, options.TablePrefix, options.Schema);
            DomainEntityConfig.Config(builder, options.TablePrefix, options.Schema);
            EntityObjectAggRootConfig.Config(builder, options.TablePrefix, options.Schema);
            IndexDescConfig.Config(builder, options.TablePrefix, options.Schema);
            ValueObjectAggRootConfig.Config(builder, options.TablePrefix, options.Schema);
        }
    }
}