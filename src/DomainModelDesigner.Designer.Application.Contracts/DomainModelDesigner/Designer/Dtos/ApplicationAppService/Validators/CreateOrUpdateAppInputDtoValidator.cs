
//using FluentValidation;
//using FluentValidation.AspNetCore;
//using FluentValidation.Results;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.Extensions.Localization;
//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace DomainModelDesigner.Designer.Dtos.Validators
//{
//    public class CreateAppInputDtoValidator : AbstractValidator<CreateAppInputDto>
//    {
//        public CreateAppInputDtoValidator(IStringLocalizer localizer)
//        {
//            var nameMsg = localizer["App:001", "Name"];
//            var namgLenMsg = localizer["App:002", "Name", DomainFieldLengthConsts.AppConsts.AppNameLen];

//            RuleFor(p => p.Name)
//                .NotNull().WithMessage(nameMsg)
//                .NotEmpty().WithMessage(nameMsg)
//                .MaximumLength(DomainFieldLengthConsts.AppConsts.AppNameLen).WithMessage(namgLenMsg);

//            RuleFor(p => p.Domains).NotNull().WithMessage(localizer["App:001", "Domains"]);
//            RuleForEach(p => p.Domains).SetValidator(new CreateAppInputDtoDetailValidator(localizer));
//        }
//    }

//    public class CreateAppInputDtoDetailValidator : AbstractValidator<DomainDto>
//    {
//        public CreateAppInputDtoDetailValidator(IStringLocalizer localizer)
//        {
//            var nameMsg = localizer["App:001", "Name"];
//            var namgLenMsg = localizer["App:002", "Name", DomainFieldLengthConsts.AppConsts.DomainNameLen];
//            var remarkLenMsg = localizer["App:002", "Name", DomainFieldLengthConsts.AppConsts.DomainRemarkLen];

//            RuleFor(p => p.DomainName)
//                .NotNull().WithMessage(nameMsg)
//                .NotEmpty().WithMessage(nameMsg)
//                .MaximumLength(DomainFieldLengthConsts.AppConsts.DomainNameLen).WithMessage(namgLenMsg);

//            RuleFor(p => p.Remark)
//                .MaximumLength(DomainFieldLengthConsts.AppConsts.DomainRemarkLen).WithMessage(remarkLenMsg);
//        }
//    }
//}
