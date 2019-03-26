﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DomainModelDesigner.Designer.Entities;
using DomainModelDesigner.Designer.Repositories;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;

namespace DomainModelDesigner.Designer.DomainServices
{
    public class ValueObjectManager : DomainService, IValueObjectManager
    {
        private readonly IReadOnlyValueObjectRepository _readOnlyRepository;
        private readonly IRepository<ValueObjectAggRoot, Guid> _repository;
        public ValueObjectManager(IReadOnlyValueObjectRepository readOnlyValueObjectRepository, 
            IRepository<ValueObjectAggRoot, Guid> valueObjectAggRoots)
        {
            _readOnlyRepository = readOnlyValueObjectRepository;
            _repository = valueObjectAggRoots;
        }

        public async Task<ValueObjectAggRoot> CreateAsync(ValueObjectAggRoot obj, CancellationToken cancellation = default)
        {
            var entity =await _readOnlyRepository.GetByNameAsync(obj.DomainEntityId, obj.Name,cancellation);
            if(entity!=null)
                throw new BusinessException(DesignerDomainErrorCodes.IsExistsCheck)
             .WithData("paramValue", obj.Name);

            return await _repository.InsertAsync(obj, cancellationToken:cancellation);
        }

        public async Task DeleteAsync(Guid id, CancellationToken cancellation = default)
        {
            await _repository.DeleteAsync(id, cancellationToken: cancellation);
        }

        public async Task<ValueObjectAggRoot> UpdateAsync(ValueObjectAggRoot obj, CancellationToken cancellation = default)
        {
            var entity =await _repository.GetAsync(obj.Id,cancellationToken:cancellation);
            if (entity == null)
                throw new BusinessException(DesignerDomainErrorCodes.NoDataCheck);

            //名称不能重复
            var list = await _readOnlyRepository.GetByNameAsync(obj.DomainEntityId,obj.Name, cancellation);
            if (list != null &&
                 list.Find(p =>
                 string.Equals(p.Name, obj.Name, StringComparison.OrdinalIgnoreCase) &&
                 !p.Id.Equals(obj.Id))!=null
               )
            {
                throw new BusinessException(DesignerDomainErrorCodes.IsExistsCheck)
               .WithData("paramValue", obj.Name);
            }

           return await _repository.UpdateAsync(obj, cancellationToken: cancellation);
        }
    }
}
