using DomainModelDesigner.Designer.Dtos;
using DomainModelDesigner.Designer.Dtos.ValueObjectAppService;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace DomainModelDesigner.Designer.AppServices
{
    public interface IValueObjectAppService: 
        IAsyncCrudAppService<ValueObjectEntityDto,Guid, SearchValueObjectInputDto,CreateValueObjectInputDto>
    {
        Task<ValueObjectEntityDto> UpdateAsync(Guid id,UpdateValueObjectInputDto dto);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entityId">ValueObject 实体的id</param>
        /// <param name="fieldId">字段的id</param>
        /// <param name="dto"></param>
        /// <returns></returns>
        Task<ValueObjectEntityDto> UpdateFieldAsync(Guid entityId,Guid fieldId, FieldDto dto);
    }
}
