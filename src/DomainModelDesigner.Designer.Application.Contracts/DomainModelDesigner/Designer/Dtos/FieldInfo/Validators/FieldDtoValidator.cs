using FluentValidation;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Text;

namespace DomainModelDesigner.Designer.Dtos.Validators
{
    public class FieldDtoValidator: AbstractValidator<FieldDto>
    {
        public FieldDtoValidator(IStringLocalizer localizer)
        {
            RuleFor(p => p.FieldName)
                .NotEmpty().WithMessage(localizer["App:001", "FieldName"])
                .NotNull().WithMessage(localizer["App:001", "FieldName"])
                .MaximumLength(DomainFieldLengthConsts.FieldConsts.NameMaxLen)
                .WithMessage(localizer["App:002", "FieldName", DomainFieldLengthConsts.FieldConsts.NameMaxLen]);


            RuleFor(p => p.FieldTypeId)
               .NotEmpty().WithMessage(localizer["App:001", "FieldTypeId"])
               .NotNull().WithMessage(localizer["App:001", "FieldTypeId"])
               .MaximumLength(DomainFieldLengthConsts.FieldConsts.FieldTypeMaxLen)
               .WithMessage(localizer["App:002", "FieldTypeId", DomainFieldLengthConsts.FieldConsts.FieldTypeMaxLen]);

            RuleFor(p => p.FieldLen)
                .MaximumLength(DomainFieldLengthConsts.FieldConsts.FieldLenMaxLen)
                .WithMessage(localizer["App:002", "FieldLen", DomainFieldLengthConsts.FieldConsts.FieldLenMaxLen]);

            RuleFor(p => p.FieldDescription)
                .MaximumLength(DomainFieldLengthConsts.FieldConsts.FieldDescMaxLen)
                .WithMessage(localizer["App:002", "FieldDescription", DomainFieldLengthConsts.FieldConsts.FieldDescMaxLen]);
        }
    }
}
