using FluentValidation;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Text;

namespace DomainModelDesigner.Designer.Dtos.ValueObjectAppService.Validators
{
    public class UpdateValueObjectInputDtoValidator: AbstractValidator<UpdateValueObjectInputDto>
    {
        public UpdateValueObjectInputDtoValidator(IStringLocalizer localizer)
        {
            RuleFor(p => p.Name)
              .NotEmpty().WithMessage(localizer["App:001", "Name"])
              .NotNull().WithMessage(localizer["App:001", "Name"])
              .MaximumLength(DomainFieldLengthConsts.ValueObjectConsts.ValueObjectNameLen)
               .WithMessage(localizer["App:002", "Name", DomainFieldLengthConsts.ValueObjectConsts.ValueObjectNameLen]);

            RuleFor(p => p.Desc)
                .MaximumLength(DomainFieldLengthConsts.ValueObjectConsts.ValueObjectDescriptionLen)
                .WithMessage(localizer["App:002", "Desc", DomainFieldLengthConsts.ValueObjectConsts.ValueObjectDescriptionLen]);

        }
    }
}
