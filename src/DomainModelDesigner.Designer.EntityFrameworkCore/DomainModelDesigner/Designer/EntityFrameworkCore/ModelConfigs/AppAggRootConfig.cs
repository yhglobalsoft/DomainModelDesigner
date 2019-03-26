using DomainModelDesigner.Designer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace DomainModelDesigner.Designer.EntityFrameworkCore.ModelConfigs
{
    public class AppAggRootConfig
    {
        public static void Config(ModelBuilder builder,string tablePrefix,string schema)
        {
            builder.Entity<AppAggRoot>(b =>
            {
                b.ToTable(tablePrefix + "Apps", schema).HasKey(p => p.Id);

                b.Property(p => p.Id).ValueGeneratedOnAdd(); //id 自动生成
                b.Property(p => p.AppName).HasMaxLength(DomainFieldLengthConsts.AppConsts.AppNameLen).IsRequired();

                //调用Abp的扩展方法，来处理 Dictionary<string, object>类型字段的映射
                b.ConfigureExtraProperties();

                b.UsePropertyAccessMode(PropertyAccessMode.Field);
            });
        }
    }
}
