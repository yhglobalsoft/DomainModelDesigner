using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DomainModelDesigner.Designer.DomainServices;
using DomainModelDesigner.Designer.Dtos;
using DomainModelDesigner.Designer.Entities;
using DomainModelDesigner.Designer.Repositories;
using Volo.Abp.Application.Services;
using Microsoft.Extensions.DependencyInjection;
using DomainModelDesigner.Designer.Dtos.Validators;
using Microsoft.Extensions.Localization;
using FluentValidation;
using System.Linq;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Localization;
using DomainModelDesigner.Designer.EntityDtos;
using DomainModelDesigner.Designer.Tools;
using DomainModelDesigner.Designer.Dtos.ApplicationAppService;

namespace DomainModelDesigner.Designer.AppServices 
{
    public class ApplicationAppService :ApplicationService, IApplicationAppService
    {
        private readonly IAppManager _appManager;
        private readonly ICheck _check;
        private readonly IReadOnlyAppAggRootRepository _appRepository;

        public ApplicationAppService(IAppManager appManager,
            IReadOnlyAppAggRootRepository appAggRootRepository,
            ICheck check)
        {
            _appManager = appManager;
            _appRepository = appAggRootRepository;
            _check = check;
        }

        public async Task<AppEntityDto> CreateAppAsync(string appName)
        {
            _check.IsNullOrWhiteSpace(appName, nameof(appName))
                       .IsTooLong(DomainFieldLengthConsts.AppConsts.AppNameLen, appName, nameof(appName));

            var result = await _appManager.CreateAppAsync(appName);

            return ObjectMapper.Map<AppAggRoot, AppEntityDto>(result);
        }

        public async Task<AppEntityDto> CreateDomainAsync(Guid appId, CreateDomainDto dto)
        {
            _check.GuidIsNull(appId)
                       .IsNull<CreateDomainDto>(dto)
                       .IsNullForEach<CreateDomainDtoDetail>(dto.Domains, (domain) =>
                       {

                           _check.IsNullOrWhiteSpace(domain.Name, nameof(domain.Name))
                                      .IsTooLong(DomainFieldLengthConsts.AppConsts.DomainNameLen, domain.Remark, nameof(domain.Remark));

                       });

            var eDto = ObjectMapper.Map<CreateDomainDto, AddDomainEDto>(dto);

            var result = await _appManager.AddDomainAsync(appId, eDto);

            return ObjectMapper.Map<AppAggRoot, AppEntityDto>(result);
        }

        public async Task DeleteAppAsync(Guid appId)
        {
            await _appManager.DeleteAppAsync(appId);
        }

        public async Task<AppEntityDto> GetAsync(Guid appId)
        {
            var result =await _appRepository.GetAsync(appId);

            return ObjectMapper.Map<AppAggRoot, AppEntityDto>(result);
        }

        public async Task<PagedResultDto<AppEntityDto>> GetListAsync(SearchAppInputDto input)
        {
            //获取总数
            var totalCount = await _appRepository.GetCountAsync();

            var result = await _appRepository.GetListAsync(input.Sorting, input.MaxResultCount, input.SkipCount, input.Filter, false);

            return new PagedResultDto<AppEntityDto>()
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List<AppAggRoot>, List<AppEntityDto>>(result)
            };
        }

        public async Task RemoveDomainAsync(Guid appId, Guid domainId)
        {
            await _appManager.RemoveDomainAsync(appId,domainId);
        }

        public async Task UpdateAppNameAsync(Guid appId, string name)
        {
            await _appManager.UpdateAppNameAsync(appId,name);
        }

        public async Task<AppEntityDto> UpdateDomainAsync(Guid appId, Guid domainId, string domainName, string domainRemark)
        {
            var result =await _appManager.UpdateDomainAsync(appId, domainId, domainName, domainRemark);

            return ObjectMapper.Map<AppAggRoot, AppEntityDto>(result);
        }

    }
}
