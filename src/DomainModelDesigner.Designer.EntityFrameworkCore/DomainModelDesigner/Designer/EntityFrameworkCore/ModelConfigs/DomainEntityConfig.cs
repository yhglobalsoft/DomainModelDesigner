using DomainModelDesigner.Designer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.DependencyInjection;

namespace DomainModelDesigner.Designer.EntityFrameworkCore.ModelConfigs
{
    public class DomainEntityConfig 
    {
        public static void Config(ModelBuilder builder, DesignerModelBuilderConfigurationOptions options)
        {
            builder.Entity<DomainEntity>(b =>
            {
                b.ToTable(options.TablePrefix + "Domains", options.Schema).HasKey(p => p.Id);

                b.Property(p => p.Id).ValueGeneratedOnAdd(); //id 自动生成
                b.Property(p => p.DomainName).HasMaxLength(DomainFieldLengthConsts.AppConsts.DomainNameLen).IsRequired();
                b.Property(p => p.Remark).HasMaxLength(DomainFieldLengthConsts.AppConsts.DomainRemarkLen);
            });
        }
    }
}
