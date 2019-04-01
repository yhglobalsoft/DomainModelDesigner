using DomainModelDesigner.Designer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.DependencyInjection;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace DomainModelDesigner.Designer.EntityFrameworkCore.ModelConfigs
{
    public class ValueObjectAggRootConfig
    {
        public static void Config(ModelBuilder builder, DesignerModelBuilderConfigurationOptions options)
        {
            builder.Entity<ValueObjectAggRoot>(b =>
            {

                b.ToTable(options.TablePrefix + "ValueObjects", options.Schema).HasKey(p => p.Id);
                b.Property(p => p.Id).ValueGeneratedOnAdd(); //id 自动生成

                b.Property(p => p.DomainId).IsRequired();
                b.Property(p => p.Name).HasMaxLength(DomainFieldLengthConsts.ValueObjectConsts.ValueObjectNameLen).IsRequired();
                b.Property(p => p.Descriptions).HasMaxLength(DomainFieldLengthConsts.ValueObjectConsts.ValueObjectDescriptionLen);

                ////指定外键
                //b.HasMany(p => p.Fields).WithOne().HasForeignKey(p=>p.FieldSourceId);

                b.ConfigureExtraProperties();

                b.HasIndex(p => p.Name).HasName("idx_Name");

                ////设置从表级联删除
                b.HasMany(p => p.Fields).WithOne().OnDelete(DeleteBehavior.Cascade);
            });
        }
    }
}
