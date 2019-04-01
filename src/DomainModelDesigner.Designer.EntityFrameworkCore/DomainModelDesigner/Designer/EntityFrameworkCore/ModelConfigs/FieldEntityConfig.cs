using DomainModelDesigner.Designer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.DependencyInjection;

namespace DomainModelDesigner.Designer.EntityFrameworkCore.ModelConfigs
{
    public class FieldEntityConfig  
    {
        public static void Config(ModelBuilder builder, DesignerModelBuilderConfigurationOptions options)
        {
            builder.Entity<FieldEntity>(b =>
            {
                b.ToTable(options.TablePrefix + "Fields", options.Schema).HasKey(p => p.Id);

                b.Property(p => p.Id).ValueGeneratedOnAdd(); //id 自动生成
                //b.Property<int>("FieldSourceTypeId").IsRequired();//.HasColumnName("FieldSourceTypeId");
                //b.Property(p => p.FieldSourceId).IsRequired();
                b.Property(p => p.FieldName).IsRequired().HasMaxLength(DomainFieldLengthConsts.FieldConsts.NameMaxLen);
                b.Property(p => p.FieldTypeId).IsRequired();
                b.Property(p => p.IsSimpleField).IsRequired();
                b.Property(p => p.IsConstructorParameter).IsRequired();
                b.Property(p => p.IsMultiple).IsRequired();
                b.Property(p => p.FieldLen).HasMaxLength(DomainFieldLengthConsts.FieldConsts.FieldLenMaxLen);
                b.Property(p => p.FieldDescription).HasMaxLength(DomainFieldLengthConsts.FieldConsts.FieldDescMaxLen);
                
                b.UsePropertyAccessMode(PropertyAccessMode.Field);
            });
        }
    }
}
