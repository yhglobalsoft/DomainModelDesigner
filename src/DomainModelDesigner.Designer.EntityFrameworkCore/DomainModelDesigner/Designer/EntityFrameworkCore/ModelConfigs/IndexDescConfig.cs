using DomainModelDesigner.Designer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.DependencyInjection;

namespace DomainModelDesigner.Designer.EntityFrameworkCore.ModelConfigs
{
    public class IndexDescConfig 
    {
        public static void Config(ModelBuilder builder, DesignerModelBuilderConfigurationOptions options)
        {
            builder.Entity<IndexEntity>(b =>
            {
                b.ToTable(options.TablePrefix + "IndexDesc", options.Schema).HasKey(p => p.Id);

                b.Property(p => p.Id).ValueGeneratedOnAdd(); //id 自动生成
                b.Property(p => p.IndexName).HasMaxLength(DomainFieldLengthConsts.IndexConsts.Index_Len).IsRequired();
                b.Property(p => p.IsUnique).IsRequired();
            });
        }
    }
}
