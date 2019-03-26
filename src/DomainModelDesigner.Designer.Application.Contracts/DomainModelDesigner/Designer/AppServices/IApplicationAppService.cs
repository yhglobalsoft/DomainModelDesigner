using DomainModelDesigner.Designer.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace DomainModelDesigner.Designer.AppServices
{
    public interface IApplicationAppService:
        IAsyncCrudAppService<SearchAppOutputDto,Guid,SearchAppInputDto,CreateAppInputDto>
    {
        Task UpdateDomainAsync(Guid appId, UpdateDomainInputDto dto, CancellationToken cancellationToken = default(CancellationToken));

        //Task<Guid> CreateAsync(CreateAppInputDto dto, CancellationToken cancellationToken=default(CancellationToken));

        //Task UpdateAsync(UpdateAppInputDto dto, CancellationToken cancellationToken = default(CancellationToken));

        //Task UpdateDomainAsync(UpdateDomainInputDto dto, CancellationToken cancellationToken = default(CancellationToken));

        //Task DeleteAsync(Guid id, CancellationToken cancellationToken = default(CancellationToken));

        //Task DeleteDomainAsync(DeleteDomainInputDto dto, CancellationToken cancellationToken = default(CancellationToken));


    }
}
