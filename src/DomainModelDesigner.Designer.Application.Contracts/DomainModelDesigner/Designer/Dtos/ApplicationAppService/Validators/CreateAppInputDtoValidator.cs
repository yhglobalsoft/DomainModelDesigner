using DomainModelDesigner.Designer.Localization;
using FluentValidation;
using FluentValidation.AspNetCore;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Text;

namespace DomainModelDesigner.Designer.Dtos.Validators
{

    public class CreateAppInputDtoValidator : AbstractValidator<CreateAppInputDto>
    {
        public CreateAppInputDtoValidator(IStringLocalizer<DesignerResource> localizer)
        {
            var nameMsg = localizer["App:001", "Name"];
            var namgLenMsg = localizer["App:002", "Name", DomainFieldLengthConsts.AppNameLen];

            RuleFor(p => p.Name)
                .NotNull().WithMessage(nameMsg)
                .NotEmpty().WithMessage(nameMsg)
                .MaximumLength(DomainFieldLengthConsts.AppNameLen).WithMessage(namgLenMsg);

            RuleForEach(p => p.Domains).SetValidator(new CreateAppInputDtoDetailValidator(localizer));
        }
    }

    public class CreateAppInputDtoDetailValidator : AbstractValidator<CreateAppInputDtoDetail>
    {
        public CreateAppInputDtoDetailValidator(IStringLocalizer<DesignerResource> localizer)
        {
            var nameMsg = localizer["App:001", "Name"];
            var namgLenMsg = localizer["App:002", "Name", DomainFieldLengthConsts.DomainNameLen];
            var remarkLenMsg = localizer["App:002", "Name", DomainFieldLengthConsts.DomainRemarkLen];

            RuleFor(p => p.DomainName)
                .NotNull().WithMessage(nameMsg)
                .NotEmpty().WithMessage(nameMsg)
                .MaximumLength(DomainFieldLengthConsts.DomainNameLen).WithMessage(namgLenMsg);

            RuleFor(p => p.Remark)
                .MaximumLength(DomainFieldLengthConsts.DomainRemarkLen).WithMessage(remarkLenMsg);
        }
    }
}
