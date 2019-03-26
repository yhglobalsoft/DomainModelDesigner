using DomainModelDesigner.Designer.Localization;
using FluentValidation;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Text;

namespace DomainModelDesigner.Designer.Dtos.ValueObjectAppService.Validators
{
    public class CreateValueObjectInputDtoValidator: AbstractValidator<CreateValueObjectInputDto>
    {
        public CreateValueObjectInputDtoValidator(IStringLocalizer localizer)
        {

        }
    }
}
