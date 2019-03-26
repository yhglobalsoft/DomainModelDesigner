using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DomainModelDesigner.Designer.DomainServices;
using DomainModelDesigner.Designer.Dtos;
using DomainModelDesigner.Designer.Dtos.ValueObjectAppService.Validators;
using DomainModelDesigner.Designer.Entities;
using DomainModelDesigner.Designer.Localization;
using DomainModelDesigner.Designer.Repositories;
using FluentValidation;
using Microsoft.Extensions.Localization;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace DomainModelDesigner.Designer.AppServices
{
    public class ValueObjectAppService : ApplicationService, IValueObjectAppService
    {
        private readonly IReadOnlyValueObjectRepository _repository;
        private readonly IValueObjectManager _manager;
        public ValueObjectAppService(IReadOnlyValueObjectRepository repository, IValueObjectManager manager)
        {
            _repository = repository;
            _manager = manager;
        }

        public async Task<ValueObjectEntityDto> CreateAsync(CreateValueObjectInputDto input)
        {
            new CreateValueObjectInputDtoValidator(L).ValidateAndThrow(input);

            var obj = ObjectMapper.Map<CreateValueObjectInputDto, ValueObjectAggRoot>(input);

            var result= await _manager.CreateAsync(obj);

            return  ObjectMapper.Map<ValueObjectAggRoot, ValueObjectEntityDto>(result);
        }

        public async Task DeleteAsync(Guid id)
        {
            await _manager.DeleteAsync(id);
        }

        public async Task<ValueObjectEntityDto> GetAsync(Guid id)
        {
            var obj =await _repository.GetAsync(id);

            return ObjectMapper.Map<ValueObjectAggRoot, ValueObjectEntityDto>(obj);
        }

        public async Task<PagedResultDto<ValueObjectEntityDto>> GetListAsync(GetValueObjectInputDto input)
        {
            //获取总数
            var totalCount = await _repository.GetCountAsync();

            var result = await _repository.GetListAsync(input.Sorting, input.MaxResultCount, input.SkipCount, input.Filter);

            return new PagedResultDto<ValueObjectEntityDto>()
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List<ValueObjectAggRoot>, List<ValueObjectEntityDto>>(result)
            };
        }

        public async Task<ValueObjectEntityDto> UpdateAsync(Guid id, CreateValueObjectInputDto input)
        {
            var obj = await _repository.GetAsync(id);
            if (obj == null)
                throw new Exception(L["App:003"]);

            obj.SetDescriptions(input.Desc);
            //obj.SetFieldDescription(input);

            await _manager.UpdateAsync(obj);

            return null;
        }
    }
}
