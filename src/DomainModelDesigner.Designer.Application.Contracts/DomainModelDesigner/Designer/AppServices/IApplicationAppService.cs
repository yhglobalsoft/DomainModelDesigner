using DomainModelDesigner.Designer.Dtos;
using DomainModelDesigner.Designer.Dtos.ApplicationAppService;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace DomainModelDesigner.Designer.AppServices
{
    public interface IApplicationAppService //:IAsyncCrudAppService<AppEntityDto,Guid,SearchAppInputDto,CreateAppInputDto>
    {
        Task<AppEntityDto> CreateAppAsync(string appName);

        Task<AppEntityDto> CreateDomainAsync(Guid appId, CreateDomainDto dto);

        Task<AppEntityDto> UpdateDomainAsync(Guid appId,Guid domainId, string domainName,string domainRemark);

        Task RemoveDomainAsync(Guid appId, Guid domainId);

        Task UpdateAppNameAsync(Guid appId, string name);

        Task DeleteAppAsync(Guid appId);

        Task<AppEntityDto> GetAsync(Guid appId);

        Task<PagedResultDto<AppEntityDto>> GetListAsync(SearchAppInputDto input);
    }
}
