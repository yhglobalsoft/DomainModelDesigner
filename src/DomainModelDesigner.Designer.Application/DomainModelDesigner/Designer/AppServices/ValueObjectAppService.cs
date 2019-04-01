using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DomainModelDesigner.Designer.DomainServices;
using DomainModelDesigner.Designer.Dtos;
using DomainModelDesigner.Designer.Dtos.Validators;
using DomainModelDesigner.Designer.Dtos.ValueObjectAppService;
using DomainModelDesigner.Designer.Dtos.ValueObjectAppService.Validators;
using DomainModelDesigner.Designer.Entities;
using DomainModelDesigner.Designer.Repositories;
using FluentValidation;
using Microsoft.Extensions.Localization;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using System.Linq;

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

            var entity = new ValueObjectAggRoot(input.DomainId,input.Name,input.Desc);
            foreach (var item in input.Fields)
            {
                entity.AddField(item.FieldName, item.FieldTypeId, IsSimpleField(item.FieldTypeId), item.IsConstructorParameter,
                    item.IsMultiple, item.FieldLen, item.FieldDescription);
            }

            var result = await _manager.CreateAsync(entity);

            return ObjectMapper.Map<ValueObjectAggRoot, ValueObjectEntityDto>(result);
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

        public async Task<PagedResultDto<ValueObjectEntityDto>> GetListAsync(SearchValueObjectInputDto input)
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

        [Obsolete]
        public async Task<ValueObjectEntityDto> UpdateAsync(Guid id, CreateValueObjectInputDto input)
        {
            throw new NotImplementedException();
        }

        public async Task<ValueObjectEntityDto> UpdateAsync(Guid id,UpdateValueObjectInputDto dto)
        {
            await new UpdateValueObjectInputDtoValidator(L).ValidateAndThrowAsync(dto);

            var obj =await _repository.GetAsync(id);
            if(obj==null)
                throw new AppServiceException(L["App:003"]);

            obj.SetDescriptions(dto.Desc);
            obj.SetName(dto.Name);

            var result=await _manager.UpdateAsync(obj);

            return ObjectMapper.Map<ValueObjectAggRoot, ValueObjectEntityDto>(result);
        }

        public async Task<ValueObjectEntityDto> UpdateFieldAsync(Guid entityId, Guid fieldId, FieldDto dto)
        {
            await new FieldDtoValidator(L).ValidateAndThrowAsync(dto);

            #region  验证数据在不在
            var enttiy =await  _repository.GetAsync(entityId);
            if (enttiy == null)
                throw new AppServiceException(L["App:003"]);

            if (enttiy.Fields== null)
                throw new AppServiceException(L["App:003"]);

            var field = enttiy.Fields.Single(p => p.Id.Equals(fieldId));
            if (field == null)
                throw new AppServiceException(L["App:003"]);
            #endregion

            field.SetFieldDescription(dto.FieldDescription);
            field.SetFieldLen(dto.FieldLen);
            field.SetFieldName(dto.FieldName);
            field.SetFieldTypeId(dto.FieldTypeId);
            field.SetIsConstructorParameter(dto.IsConstructorParameter);
            field.SetIsMultiple(dto.IsMultiple);
            field.SetIsSimpleField(IsSimpleField(dto.FieldTypeId));

            var result=await _manager.UpdateAsync(enttiy);

            return ObjectMapper.Map<ValueObjectAggRoot, ValueObjectEntityDto>(result);
        }

        /// <summary>
        /// 是否是简单数据类型(复杂数据类型的id是Guid型)
        /// </summary>
        /// <param name="fieldId"></param>
        /// <returns></returns>
        private bool IsSimpleField(string fieldId)
        {
            if (string.IsNullOrWhiteSpace(fieldId))
                throw new AppServiceException(L["App:001",nameof(fieldId)]);

            Guid id;
            if (Guid.TryParse(fieldId, out id))
                return false;

            return true;
        }

    }
}
