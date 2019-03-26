using DomainModelDesigner.Designer.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Services;

namespace DomainModelDesigner.Designer.AppServices
{
    public interface IValueObjectAppService: IAsyncCrudAppService<ValueObjectEntityDto,Guid, GetValueObjectInputDto,CreateValueObjectInputDto>
    {
    }
}
