using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Volo.Abp.Application.Dtos;
using FluentValidation;
//using FluentValidation.Attributes;
using Volo.Abp.ExceptionHandling;

namespace DomainModelDesigner.Designer.Dtos
{
    //[Serializable]
    //public class CreateAppInputDto 
    //{
    //    public string Name { get; set; }
        
    //    //public List<CreateAppInputDtoDetail> Domains { get; set; }
    //}

    [Serializable]
    public class DomainDto
    {
        public string DomainName { get; set; }

        public string Remark { get; set; }
    }
}
