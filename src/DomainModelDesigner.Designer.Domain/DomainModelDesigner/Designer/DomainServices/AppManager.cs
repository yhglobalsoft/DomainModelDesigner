using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DomainModelDesigner.Designer.Entities;
using DomainModelDesigner.Designer.EntityDtos;
using DomainModelDesigner.Designer.Repositories;
using DomainModelDesigner.Designer.Tools;
using Volo.Abp;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;

namespace DomainModelDesigner.Designer.DomainServices
{
    public class AppManager : DomainService, IAppManager
    {
        private readonly IReadOnlyAggRootObjectRepository _aggReporitory;
        private readonly IRepository<AppAggRoot, Guid> _repository;
        private readonly IReadOnlyAppAggRootRepository _appRepository;
        private readonly ICheck _check;

        public AppManager(IReadOnlyAggRootObjectRepository aggReporitory,
            IRepository<AppAggRoot, Guid> appAggRoots,
            IReadOnlyAppAggRootRepository appRepository,
            ICheck check)
        {
            _aggReporitory = aggReporitory;
            _repository = appAggRoots;
            _appRepository = appRepository;
            _check = check;
        }

        public async Task DeleteAppAsync(Guid id, CancellationToken cancellationToken = default(CancellationToken))
        {
            //如果应用下有聚合根就不允许删除
            var result = await _aggReporitory.GetByAppIdAsync(id, cancellationToken: cancellationToken);
            if (result != null && result.Count > 0)
                throw new DomainException(DesignerDomainErrorCodes.CanNotBeDelete_DataIsUsed);

            await _repository.DeleteAsync(id);
        }

        public async Task<AppAggRoot> CreateAppAsync(string appName, CancellationToken cancellationToken = default)
        {
            _check.IsNullOrWhiteSpace(appName, nameof(appName))
                .IsTooLong(DomainFieldLengthConsts.AppConsts.AppNameLen, appName, nameof(appName));

            //应用名称不允许重复
            var app = await _appRepository.GetByNameAsync(appName, false, cancellationToken);
            if (app != null && app.Count()>0)
                throw new DomainException(DesignerDomainErrorCodes.IsExistsCheck)
                .WithData("paramValue", appName);

            //构造聚合根
            var entity = new AppAggRoot(appName);
          
            return await _repository.InsertAsync(entity, cancellationToken: cancellationToken);
        }

        public async Task<AppAggRoot> AddDomainAsync(Guid appId, AddDomainEDto dto, CancellationToken cancellationToken = default)
        {
            #region 参数验证
            _check.GuidIsNull(appId)
                .IsNull<AddDomainEDto>(dto)
                .IsNullForEach<AddDomainEDtoDetail>(dto.Domains,(domain)=> {

                    _check.IsNullOrWhiteSpace(domain.Name, nameof(domain.Name))
                               .IsTooLong(DomainFieldLengthConsts.AppConsts.DomainNameLen,domain.Name,nameof(domain.Name))
                               .IsTooLong(DomainFieldLengthConsts.AppConsts.DomainRemarkLen, domain.Remark, nameof(domain.Remark));

                });
            #endregion

            #region 数据逻辑验证
            //判断集合中名称是否有重复
            var nameIsDup =dto.Domains.IsDuplicated<AddDomainEDtoDetail>(p=>p.Name);
            if(nameIsDup)
                throw new DomainException(DesignerDomainErrorCodes.IsExistsCheck).WithData("paramValue", "DomainName");

            //数据不存在
            var aggRoot = await _appRepository.GetAsync(appId);
            if(aggRoot==null)
                throw new DomainException(DesignerDomainErrorCodes.NoDataCheck);

            //判断要新增的域的名称是否已被占用
            foreach (var domain in aggRoot.DomainEntities)
            {
                dto.Domains.ForEach(p=> {
                    if (string.Equals(domain.DomainName,p.Name,StringComparison.OrdinalIgnoreCase))
                        throw new DomainException(DesignerDomainErrorCodes.IsExistsCheck).WithData("paramValue", "DomainName");
                });
            }
            #endregion

            dto.Domains.ForEach(p=> {
                aggRoot.AddDomainEntity(p.Name,p.Remark);
            });

            return await _repository.UpdateAsync(aggRoot,cancellationToken:cancellationToken);
        }

        public async Task<AppAggRoot> UpdateAppNameAsync(Guid appId, string newName, CancellationToken cancellationToken = default(CancellationToken))
        {
            _check.GuidIsNull(appId)
                       .IsNullOrWhiteSpace(newName,nameof(newName))
                       .IsTooLong(DomainFieldLengthConsts.AppConsts.AppNameLen,newName,nameof(newName));

            #region 数据逻辑验证
            var entity = await _appRepository.GetAsync(appId, false, cancellationToken);

            //如果不存在或已被删除
            if (entity == null)
                throw new DomainException(DesignerDomainErrorCodes.NoDataCheck);

            var list = await _appRepository.GetByNameAsync(newName, false, cancellationToken);
            //名称已存在不能重复
            if (
                list != null &&
                list.SingleOrDefault(p => !p.Id.Equals(appId))!=null
                )
            {
                throw new DomainException(DesignerDomainErrorCodes.IsExistsCheck).WithData("paramValue", newName);
            }
            #endregion

            entity.SetAppName(newName);

            return await _repository.UpdateAsync(entity, cancellationToken: cancellationToken);
        }

        public async Task<AppAggRoot> UpdateDomainAsync(Guid appId, Guid domainId, string newName, string newRemark, CancellationToken cancellationToken = default)
        {
            #region 参数基本验证
            _check.GuidIsNull(appId)
                .IsNullOrWhiteSpace(newName, nameof(newName))
                .IsTooLong(DomainFieldLengthConsts.AppConsts.DomainNameLen, newName, nameof(newName));

            _check.GuidIsNull(domainId)
                .IsTooLong(DomainFieldLengthConsts.AppConsts.DomainRemarkLen, newRemark, nameof(newRemark));
            #endregion

            #region 数据逻辑验证
            var entity = await _appRepository.GetAsync(appId, true, cancellationToken);

            //如果不存在或已被删除
            if (entity == null)
                throw new DomainException(DesignerDomainErrorCodes.NoDataCheck);

            if (entity.DomainEntities == null)
                throw new DomainException(DesignerDomainErrorCodes.NoDataCheck);

            var domain = entity.DomainEntities.SingleOrDefault(p => p.Id.Equals(domainId));
            if (domain == null)
                throw new DomainException(DesignerDomainErrorCodes.NoDataCheck);

            //在这个应用中判断是否有其他领域占用了这个名字
            var obj = entity.DomainEntities.SingleOrDefault(p => {
                return string.Equals(p.DomainName, newName, StringComparison.OrdinalIgnoreCase)
                  && !p.Id.Equals(domainId);
            });

            if (obj != null)
                throw new DomainException(DesignerDomainErrorCodes.IsExistsCheck).WithData("paramValue", newName);
            #endregion

            domain.SetDomainName(newName);
            domain.SetRemark(newRemark);

            return await _repository.UpdateAsync(entity, cancellationToken: cancellationToken);
        }

        public async Task<AppAggRoot> RemoveDomainAsync(Guid appId, Guid domainId, CancellationToken cancellationToken = default)
        {
            #region 参数基本验证
            _check.GuidIsNull(appId)
                       .GuidIsNull(domainId);
            #endregion

            #region 数据逻辑验证
            var entity = await _appRepository.GetAsync(appId, true, cancellationToken);

            //如果不存在或已被删除
            if (entity == null)
                throw new DomainException(DesignerDomainErrorCodes.NoDataCheck);

            if (entity.DomainEntities != null && entity.DomainEntities.Count > 0)
            {
                var domain = entity.DomainEntities.SingleOrDefault(p => p.Id.Equals(domainId));

                if (domain != null)
                    entity.RemoveDomainEntity(domainId);
            }
            #endregion

            return await _repository.UpdateAsync(entity);
        }

        //#region 私有
        ///// <summary>
        ///// 判断集合中的域名是否重复
        ///// </summary>
        ///// <param name="list"></param>
        ///// <returns></returns>
        //private bool domainNameIsDuplicated(List<AddDomainEDtoDetail> list)
        //{
        //    if (list == null)
        //        return false;

        //    var result = list
        //        .GroupBy(x => x.Name)
        //        .Select(x => new { name = x.Key, count = x.Count() });

        //    if (result.Where(p => p.count > 1).Count() > 0)
        //        return true;

        //    return false;
        //}



        //#endregion
    }
}
