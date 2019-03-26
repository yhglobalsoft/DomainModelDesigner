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
using DomainModelDesigner.Designer.Localization;
using FluentValidation;
using System.Linq;
using Volo.Abp.Application.Dtos;

namespace DomainModelDesigner.Designer.AppServices
{
    public class ApplicationAppService :ApplicationService, IApplicationAppService
    {
        private readonly IAppManager _appManager;
        private readonly IReadOnlyAppAggRootRepository _appRepository;
        private readonly IStringLocalizer<DesignerResource> _localizer;

        public ApplicationAppService(IAppManager appManager, IReadOnlyAppAggRootRepository appAggRootRepository,
            IStringLocalizer<DesignerResource> localizer)
        {
            _appManager = appManager;
            _localizer = localizer;
            _appRepository = appAggRootRepository;
        }

        public async Task<SearchAppOutputDto> CreateAsync(CreateAppInputDto input)
        {
            new CreateAppInputDtoValidator(_localizer).ValidateAndThrow(input);

            var obj = ObjectMapper.Map<CreateAppInputDto, AppAggRoot>(input);

            var result = await _appManager.CreateAsync(obj);

            return ObjectMapper.Map<AppAggRoot, SearchAppOutputDto>(result);
        }

        public async Task DeleteAsync(Guid id)
        {
            await _appManager.DeleteAsync(id);
        }

        public async Task<SearchAppOutputDto> GetAsync(Guid id)
        {
            var obj =await _appRepository.GetAsync(id);
            if (obj != null)
                return ObjectMapper.Map<AppAggRoot, SearchAppOutputDto>(obj);

            return null;
        }

        public async Task<PagedResultDto<SearchAppOutputDto>> GetListAsync(SearchAppInputDto input)
        {
            //获取总数
            var totalCount = await _appRepository.GetCountAsync();

            var result = await _appRepository.GetListAsync(input.Sorting, input.MaxResultCount, input.SkipCount, input.Filter, false);

            return new PagedResultDto<SearchAppOutputDto>()
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List<AppAggRoot>, List<SearchAppOutputDto>>(result)
            };
        }

        public async Task<SearchAppOutputDto> UpdateAsync(Guid id, CreateAppInputDto input)
        {
            var obj = ObjectMapper.Map<CreateAppInputDto, AppAggRoot>(input);
            obj.Id = id;

            var result=await _appManager.UpdateAsync(obj);

            return ObjectMapper.Map<AppAggRoot, SearchAppOutputDto>(result);
        }

        public async Task UpdateDomainAsync(UpdateDomainInputDto dto, CancellationToken cancellationToken = default(CancellationToken))
        {
            var obj =await _appRepository.GetAsync(dto.AppId);
            if (obj == null)
                throw new Exception(_localizer["App:003"]);

            var domain = obj.DomainEntities.SingleOrDefault(p=>p.Id.Equals(dto.Domain.Id));
            if(domain==null)
                throw new Exception(_localizer["App:003"]);

            domain.SetDomainName(dto.Domain.DomainName);
            domain.SetRemark(dto.Domain.Remark);

            await _appManager.UpdateAsync(obj, cancellationToken);
        }
    }
}
