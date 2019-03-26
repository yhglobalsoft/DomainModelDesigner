using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Volo.Abp.Application.Dtos;
using FluentValidation;
//using FluentValidation.Attributes;
using DomainModelDesigner.Designer.Localization;
using Volo.Abp.ExceptionHandling;

namespace DomainModelDesigner.Designer.Dtos
{
    [Serializable]
    //[Validator(typeof(CreateAppInputDtoValidator))]
    public class CreateAppInputDto:IEntityDto
    {
        //[Required(ErrorMessage ="")]
        public string Name { get; set; }
        
        public List<CreateAppInputDtoDetail> Domains { get; set; }

    }

    [Serializable]
    public class CreateAppInputDtoDetail
    {
        public string DomainName { get; set; }

        public string Remark { get; set; }
    }
}
