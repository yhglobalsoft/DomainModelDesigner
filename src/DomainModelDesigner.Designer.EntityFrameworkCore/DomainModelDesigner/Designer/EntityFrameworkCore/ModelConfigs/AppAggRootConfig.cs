using DomainModelDesigner.Designer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.DependencyInjection;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace DomainModelDesigner.Designer.EntityFrameworkCore.ModelConfigs
{
    public class AppAggRootConfig 
    {
        public static void Config(ModelBuilder builder, DesignerModelBuilderConfigurationOptions options)
        {
            builder.Entity<AppAggRoot>(b =>
            {
                b.ToTable(options.TablePrefix + "Apps", options.Schema).HasKey(p => p.Id);

                b.Property(p => p.Id).ValueGeneratedOnAdd(); //id 自动生成
                b.Property(p => p.AppName).HasMaxLength(DomainFieldLengthConsts.AppConsts.AppNameLen).IsRequired();

                //调用Abp的扩展方法，来处理 Dictionary<string, object>类型字段的映射
                b.ConfigureExtraProperties();

                b.UsePropertyAccessMode(PropertyAccessMode.Field);

                //设置外键的删除策略（EfCore不需要显示设置外键,自己会根据依赖关系建外键关系）
                b.HasMany(p => p.DomainEntities).WithOne().OnDelete(DeleteBehavior.Cascade);
            });
        }
    }
}
