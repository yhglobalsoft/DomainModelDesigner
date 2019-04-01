using DomainModelDesigner.Designer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.DependencyInjection;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace DomainModelDesigner.Designer.EntityFrameworkCore.ModelConfigs
{
    public class AggRootObjectAggRootConfig 
    {
        public static void Config(ModelBuilder builder, DesignerModelBuilderConfigurationOptions options)
        {
            builder.Entity<AggRootObjectAggRoot>(b =>
            {
                b.ToTable(options.TablePrefix + "AggRoots", options.Schema).HasKey(p => p.Id);

                b.Property(p => p.Id).ValueGeneratedOnAdd(); //id 自动生成
                b.Property(p => p.Name).HasMaxLength(DomainFieldLengthConsts.ValueObjectConsts.ValueObjectNameLen).IsRequired();
                b.Property(p => p.Descriptions).HasMaxLength(DomainFieldLengthConsts.ValueObjectConsts.ValueObjectDescriptionLen);

                b.Property<int>("IdTypeId").IsRequired();
                //b.Ignore(p => p.IdTypeEnum);

                b.Property(p => p.IdIsKey).IsRequired();
                b.Property(p => p.KeyFields).HasMaxLength(DomainFieldLengthConsts.IndexConsts.Index_Fields_Len);

                b.ConfigureExtraProperties();

                //设置从表级联删除
                b.HasMany(p => p.Indexs).WithOne().OnDelete(DeleteBehavior.Cascade);
                b.HasMany(p => p.Fields).WithOne().OnDelete(DeleteBehavior.Cascade);
            });
        }
    }
}
