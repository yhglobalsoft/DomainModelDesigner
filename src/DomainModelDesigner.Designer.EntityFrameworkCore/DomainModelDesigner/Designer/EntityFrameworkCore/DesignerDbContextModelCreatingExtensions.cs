using System;
using DomainModelDesigner.Designer.Entities;
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

            builder.Entity<AppAggRoot>(b =>
            {
                b.ToTable(options.TablePrefix + "Apps", options.Schema).HasKey(p=>p.Id);

                b.Property(p => p.Id).ValueGeneratedOnAdd(); //id 自动生成
                b.Property(p => p.AppName).HasMaxLength(DomainFieldLengthConsts.AppNameLen).IsRequired();

                //调用Abp的扩展方法，来处理 Dictionary<string, object>类型字段的映射
                b.ConfigureExtraProperties();

                b.UsePropertyAccessMode(PropertyAccessMode.Field);
            });

            builder.Entity<DomainEntity>(b =>
            {
                b.ToTable(options.TablePrefix + "Domains", options.Schema).HasKey(p => p.Id);

                b.Property(p => p.Id).ValueGeneratedOnAdd(); //id 自动生成
                b.Property(p => p.DomainName).HasMaxLength(DomainFieldLengthConsts.DomainNameLen).IsRequired();
                b.Property(p => p.Remark).HasMaxLength(DomainFieldLengthConsts.DomainRemarkLen);
            });

            builder.Entity<ValueObjectAggRoot>(b=> {

                b.ToTable(options.TablePrefix + "ValueObjects", options.Schema).HasKey(p => p.Id);
                b.Property(p => p.Id).ValueGeneratedOnAdd(); //id 自动生成

                b.Property(p => p.Name).HasMaxLength(DomainFieldLengthConsts.ValueObjectNameLen).IsRequired();
                b.Property(p => p.Descriptions).HasMaxLength(DomainFieldLengthConsts.ValueObjectDescriptionLen);
                b.Property(p => p.FieldName).HasMaxLength(DomainFieldLengthConsts.ValueObjectFieldNameLen).IsRequired();
                b.Property(p => p.FieldTypeId).HasMaxLength(DomainFieldLengthConsts.ValueObjectFieldTypeIdLen).IsRequired();
                b.Property(p => p.IsSimpleField).IsRequired();
                b.Property(p => p.IsConstructorParameter).IsRequired();
                b.Property(p => p.IsMultiple).IsRequired();
                b.Property(p => p.FieldLen).HasMaxLength(DomainFieldLengthConsts.ValueObjectFieldLenLen).IsRequired();
                b.Property(p => p.FieldDescription).HasMaxLength(DomainFieldLengthConsts.ValueObjectFieldDescriptionLen).IsRequired();

                b.ConfigureExtraProperties();

                b.HasIndex(p=>p.Name).HasName("idx_Name");
            });

            builder.Entity<EntityObjectAggRoot>(b =>
            {
                b.ToTable(options.TablePrefix + "Entities", options.Schema).HasKey(p => p.Id);

                b.Property(p => p.Id).ValueGeneratedOnAdd(); //id 自动生成
                b.Property(p => p.Name).HasMaxLength(DomainFieldLengthConsts.ValueObjectNameLen).IsRequired();
                b.Property(p => p.Descriptions).HasMaxLength(DomainFieldLengthConsts.ValueObjectDescriptionLen);
                b.Property(p => p.FieldName).HasMaxLength(DomainFieldLengthConsts.ValueObjectFieldNameLen).IsRequired();
                b.Property(p => p.FieldTypeId).HasMaxLength(DomainFieldLengthConsts.ValueObjectFieldTypeIdLen).IsRequired();
                b.Property(p => p.IsSimpleField).IsRequired();
                b.Property(p => p.IsConstructorParameter).IsRequired();
                b.Property(p => p.IsMultiple).IsRequired();
                b.Property(p => p.FieldLen).HasMaxLength(DomainFieldLengthConsts.ValueObjectFieldLenLen).IsRequired();
                b.Property(p => p.FieldDescription).HasMaxLength(DomainFieldLengthConsts.ValueObjectFieldDescriptionLen).IsRequired();

                b.Property<int>("IdTypeId").IsRequired();
                b.Ignore(p => p.IdTypeEnum);

                b.Property(p => p.IdIsKey).IsRequired();
                b.Property(p => p.KeyFields).HasMaxLength(DomainFieldLengthConsts.Index_Fields_Len);

                b.ConfigureExtraProperties();


            });

            builder.Entity<AggRootObjectAggRoot>(b =>
            {
                b.ToTable(options.TablePrefix + "AggRoots", options.Schema).HasKey(p => p.Id);

                b.Property(p => p.Id).ValueGeneratedOnAdd(); //id 自动生成
                b.Property(p => p.Name).HasMaxLength(DomainFieldLengthConsts.ValueObjectNameLen).IsRequired();
                b.Property(p => p.Descriptions).HasMaxLength(DomainFieldLengthConsts.ValueObjectDescriptionLen);
                b.Property(p => p.FieldName).HasMaxLength(DomainFieldLengthConsts.ValueObjectFieldNameLen).IsRequired();
                b.Property(p => p.FieldTypeId).HasMaxLength(DomainFieldLengthConsts.ValueObjectFieldTypeIdLen).IsRequired();
                b.Property(p => p.IsSimpleField).IsRequired();
                b.Property(p => p.IsConstructorParameter).IsRequired();
                b.Property(p => p.IsMultiple).IsRequired();
                b.Property(p => p.FieldLen).HasMaxLength(DomainFieldLengthConsts.ValueObjectFieldLenLen).IsRequired();
                b.Property(p => p.FieldDescription).HasMaxLength(DomainFieldLengthConsts.ValueObjectFieldDescriptionLen).IsRequired();

                b.Property(p => p.DomainEntityId).IsRequired();

                b.Property<int>("IdTypeId").IsRequired();
                b.Ignore(p => p.IdTypeEnum);

                b.Property(p => p.IdIsKey).IsRequired();
                b.Property(p => p.KeyFields).HasMaxLength(DomainFieldLengthConsts.Index_Fields_Len);

                b.ConfigureExtraProperties();


            });

            builder.Entity<IndexDesc>(b =>
            {
                b.ToTable(options.TablePrefix + "IndexDesc", options.Schema).HasKey(p => p.Id);

                b.Property(p => p.Id).ValueGeneratedOnAdd(); //id 自动生成
                b.Property(p => p.IndexName).HasMaxLength(DomainFieldLengthConsts.Index_Len).IsRequired();
                b.Property(p => p.IsUnique).IsRequired();
            });

        }
    }
}