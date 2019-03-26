using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DomainModelDesigner.Designer.Entities;
using DomainModelDesigner.Designer.Repositories;
using Volo.Abp;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;

namespace DomainModelDesigner.Designer.DomainServices
{
    public class AppManager :DomainService, IAppManager
    {
        private readonly IReadOnlyAggRootObjectRepository _aggReporitory;
        private readonly IRepository<AppAggRoot,Guid> _repository;
        private readonly IReadOnlyAppAggRootRepository _appRepository;

        public AppManager(IReadOnlyAggRootObjectRepository aggReporitory,
            IRepository<AppAggRoot, Guid> appAggRoots, 
            IReadOnlyAppAggRootRepository appRepository)
        {
            _aggReporitory = aggReporitory;
            _repository = appAggRoots;
            _appRepository = appRepository;
        }

        public async Task<AppAggRoot> CreateAsync(AppAggRoot obj, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (obj == null)
                throw new BusinessException(DesignerDomainErrorCodes.NullOrEmptyCheck)
                    .WithData("paramName",nameof(obj));

            if (string.IsNullOrWhiteSpace(obj.AppName))
                throw new BusinessException(DesignerDomainErrorCodes.NullOrEmptyCheck)
                   .WithData("paramName", nameof(obj.AppName));

            //名称不允许重复
            var app = await _appRepository.GetByNameAsync(obj.AppName,false, cancellationToken);
            if(app!=null)
                throw new BusinessException(DesignerDomainErrorCodes.IsExistsCheck)
                .WithData("paramValue", obj.AppName);

            await _repository.InsertAsync(obj, cancellationToken: cancellationToken);
            return obj;
        }

        public async Task<AppAggRoot> UpdateAsync(AppAggRoot obj, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (obj == null)
                throw new BusinessException(DesignerDomainErrorCodes.NullOrEmptyCheck)
                    .WithData("paramName", nameof(obj));

            if (string.IsNullOrWhiteSpace(obj.AppName))
                throw new BusinessException(DesignerDomainErrorCodes.NullOrEmptyCheck)
                   .WithData("paramName", nameof(obj.AppName));

            //数据不存在，操作失败
            var result = await _appRepository.GetAsync(obj.Id, false,cancellationToken: cancellationToken);
            if (result == null)
                throw new BusinessException(DesignerDomainErrorCodes.NoDataCheck);

            //名称不能重复
            result= await _appRepository.GetByNameAsync(obj.AppName,false, cancellationToken);
            if(result!=null && !result.Id.Equals(obj.Id))
                throw new BusinessException(DesignerDomainErrorCodes.IsExistsCheck)
                .WithData("paramValue", obj.AppName);

            return await _repository.UpdateAsync(obj, cancellationToken: cancellationToken);
        }

        public async Task DeleteAsync(Guid id, CancellationToken cancellationToken = default(CancellationToken))
        {
            //如果应用下有聚合根就不允许删除
            var result =await _aggReporitory.GetByAppIdAsync(id, cancellationToken:cancellationToken);
            if (result != null && result.Count>0)
                throw new BusinessException(DesignerDomainErrorCodes.CanNotBeDelete_DataIsUsed);

            await _repository.DeleteAsync(id);
        }
    }
}
