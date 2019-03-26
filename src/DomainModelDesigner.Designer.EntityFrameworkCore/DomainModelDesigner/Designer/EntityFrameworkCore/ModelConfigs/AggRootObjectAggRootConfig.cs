﻿using DomainModelDesigner.Designer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace DomainModelDesigner.Designer.EntityFrameworkCore.ModelConfigs
{
    public class AggRootObjectAggRootConfig
    {
        public static void Config(ModelBuilder builder, string tablePrefix, string schema)
        {
            builder.Entity<AggRootObjectAggRoot>(b =>
            {
                b.ToTable(tablePrefix + "AggRoots", schema).HasKey(p => p.Id);

                b.Property(p => p.Id).ValueGeneratedOnAdd(); //id 自动生成
                b.Property(p => p.Name).HasMaxLength(DomainFieldLengthConsts.ValueObjectConsts.ValueObjectNameLen).IsRequired();
                b.Property(p => p.Descriptions).HasMaxLength(DomainFieldLengthConsts.ValueObjectConsts.ValueObjectDescriptionLen);
                b.Property(p => p.FieldName).HasMaxLength(DomainFieldLengthConsts.ValueObjectConsts.ValueObjectFieldNameLen).IsRequired();
                b.Property(p => p.FieldTypeId).HasMaxLength(DomainFieldLengthConsts.ValueObjectConsts.ValueObjectFieldTypeIdLen).IsRequired();
                b.Property(p => p.IsSimpleField).IsRequired();
                b.Property(p => p.IsConstructorParameter).IsRequired();
                b.Property(p => p.IsMultiple).IsRequired();
                b.Property(p => p.FieldLen).HasMaxLength(DomainFieldLengthConsts.ValueObjectConsts.ValueObjectFieldLenLen).IsRequired();
                b.Property(p => p.FieldDescription).HasMaxLength(DomainFieldLengthConsts.ValueObjectConsts.ValueObjectFieldDescriptionLen).IsRequired();

                b.Property(p => p.DomainEntityId).IsRequired();

                b.Property<int>("IdTypeId").IsRequired();
                b.Ignore(p => p.IdTypeEnum);

                b.Property(p => p.IdIsKey).IsRequired();
                b.Property(p => p.KeyFields).HasMaxLength(DomainFieldLengthConsts.IndexConsts.Index_Fields_Len);

                b.ConfigureExtraProperties();
            });
        }
    }
}