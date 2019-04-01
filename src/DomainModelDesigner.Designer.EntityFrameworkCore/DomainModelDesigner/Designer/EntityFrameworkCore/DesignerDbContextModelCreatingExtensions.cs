using System;
using DomainModelDesigner.Designer.Entities;
using DomainModelDesigner.Designer.EntityFrameworkCore.ModelConfigs;
using DomainModelDesigner.Designer.Inf;
using DomainModelDesigner.Designer.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
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

            #region EF模型配置
            FieldEntityConfig.Config(builder, options);
            AppAggRootConfig.Config(builder, options);
            AggRootObjectAggRootConfig.Config(builder, options);
            DomainEntityConfig.Config(builder, options);
            EntityObjectAggRootConfig.Config(builder, options);
            IndexDescConfig.Config(builder, options);
            ValueObjectAggRootConfig.Config(builder, options);
            #endregion
        }
    }
}