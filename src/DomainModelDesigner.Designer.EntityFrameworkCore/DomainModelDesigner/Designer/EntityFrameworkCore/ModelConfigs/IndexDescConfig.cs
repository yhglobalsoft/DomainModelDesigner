using DomainModelDesigner.Designer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DomainModelDesigner.Designer.EntityFrameworkCore.ModelConfigs
{
    public class IndexDescConfig
    {
        public static void Config(ModelBuilder builder, string tablePrefix, string schema)
        {
            builder.Entity<IndexDesc>(b =>
            {
                b.ToTable(tablePrefix + "IndexDesc", schema).HasKey(p => p.Id);

                b.Property(p => p.Id).ValueGeneratedOnAdd(); //id 自动生成
                b.Property(p => p.IndexName).HasMaxLength(DomainFieldLengthConsts.IndexConsts.Index_Len).IsRequired();
                b.Property(p => p.IsUnique).IsRequired();
            });
        }
    }
}
