using DomainModelDesigner.Designer.DomainServices;
using DomainModelDesigner.Designer.Repositories;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace DomainModelDesigner.Designer.Tests
{
    public class AppManager_Test: DomainTestBase
    {
        private readonly IAppManager _manager;
         
        private readonly IReadOnlyAppAggRootRepository _repository;
        public AppManager_Test()
        {
            _manager = GetRequiredService<IAppManager>();
            _repository= GetRequiredService<IReadOnlyAppAggRootRepository>();
        }

        //#region CreateAsync
        //[Fact]
        //public async Task CreateAsync_Failed_When_AppNameIsEmpty()
        //{
        //    var dto = DataBuilder.Build_CreateAppEDto();
        //    dto.AppName = "";

        //    var ex = await Assert.ThrowsAsync<DomainException>(async()=> {
        //        await _manager.CreateAsync(dto);
        //    });

        //    ex.Code.ShouldBe(DesignerDomainErrorCodes.NullOrEmptyCheck);
        //}

        //[Fact]
        //public async Task CreateAsync_Failed_When_DtoIsEmpty()
        //{
        //    var dto = DataBuilder.Build_CreateAppEDto();
        //    dto = null;

        //    var ex = await Assert.ThrowsAsync<DomainException>(async () => {
        //        await _manager.CreateAsync(dto);
        //    });

        //    ex.Code.ShouldBe(DesignerDomainErrorCodes.NullOrEmptyCheck);
        //}

        //[Fact]
        //public async Task CreateAsync_Failed_When_AppNameIsTooLong ()
        //{
        //    var dto = DataBuilder.Build_CreateAppEDto();

        //    //构造超长的AppName
        //    var maxLen = DomainFieldLengthConsts.AppConsts.AppNameLen;
        //    StringBuilder sb = new StringBuilder();
        //    for (var i = 0; i < maxLen + 1; i++)
        //    {
        //        sb.Append("A");
        //    }
        //    dto.AppName = sb.ToString();

        //    var ex = await Assert.ThrowsAsync<DomainException>(async () => {
        //        await _manager.CreateAsync(dto);
        //    });

        //    ex.Code.ShouldBe(DesignerDomainErrorCodes.IsTooLongCheck);
        //}

        //[Fact]
        //public async Task CreateAsync_Failed_When_DomainsIsNull()
        //{
        //    var dto = DataBuilder.Build_CreateAppEDto();
        //    dto.Domains = null;

        //    var ex = await Assert.ThrowsAsync<DomainException>(async () => {
        //        await _manager.CreateAsync(dto);
        //    });

        //    ex.Code.ShouldBe(DesignerDomainErrorCodes.NullOrEmptyCheck);
        //}

        //[Fact]
        //public async Task CreateAsync_Failed_When_DomainsIsEmpty()
        //{
        //    var dto = DataBuilder.Build_CreateAppEDto();
        //    dto.Domains.Clear();

        //    var ex = await Assert.ThrowsAsync<DomainException>(async () => {
        //        await _manager.CreateAsync(dto);
        //    });

        //    ex.Code.ShouldBe(DesignerDomainErrorCodes.NullOrEmptyCheck);
        //}

        //[Fact]
        //public async Task CreateAsync_Failed_When_DomainsNameIsEmpty()
        //{
        //    var dto = DataBuilder.Build_CreateAppEDto();
        //    dto.Domains[0].DomainName = "";

        //    var ex = await Assert.ThrowsAsync<DomainException>(async () => {
        //        await _manager.CreateAsync(dto);
        //    });

        //    ex.Code.ShouldBe(DesignerDomainErrorCodes.NullOrEmptyCheck);
        //}


        //[Fact]
        //public async Task CreateAsync_Failed_When_DomainsNameIsTooLong()
        //{
        //    var dto = DataBuilder.Build_CreateAppEDto();

        //    //构造超长的AppName
        //    var maxLen = DomainFieldLengthConsts.AppConsts.DomainNameLen;
        //    StringBuilder sb = new StringBuilder();
        //    for (var i = 0; i < maxLen + 1; i++)
        //    {
        //        sb.Append("A");
        //    }
        //    dto.Domains[0].DomainName = sb.ToString();


        //    var ex = await Assert.ThrowsAsync<DomainException>(async () => {
        //        await _manager.CreateAsync(dto);
        //    });

        //    ex.Code.ShouldBe(DesignerDomainErrorCodes.IsTooLongCheck);
        //}

        //[Fact]
        //public async Task CreateAsync_Failed_When_DomainsRemarkIsTooLong()
        //{
        //    var dto = DataBuilder.Build_CreateAppEDto();

        //    //构造超长的AppName
        //    var maxLen = DomainFieldLengthConsts.AppConsts.DomainRemarkLen;
        //    StringBuilder sb = new StringBuilder();
        //    for (var i = 0; i < maxLen + 1; i++)
        //    {
        //        sb.Append("A");
        //    }
        //    dto.Domains[0].Remark = sb.ToString();


        //    var ex = await Assert.ThrowsAsync<DomainException>(async () => {
        //        await _manager.CreateAsync(dto);
        //    });

        //    ex.Code.ShouldBe(DesignerDomainErrorCodes.IsTooLongCheck);
        //}

        //[Fact]
        //public async Task CreateAsync_Failed_When_AppNameIsDuplicated()
        //{
        //    var dto = DataBuilder.Build_CreateAppEDto();

        //    var result = await _manager.CreateAsync(dto);

        //    var ex = await Assert.ThrowsAsync<DomainException>(async () => {
        //        await _manager.CreateAsync(dto);
        //    });

        //    ex.Code.ShouldBe(DesignerDomainErrorCodes.IsExistsCheck);
        //}

        //[Fact]
        //public async Task CreateAsync_Failed_When_DomainNameIsDuplicated()
        //{
        //    var dto = DataBuilder.Build_CreateAppEDto();

        //    var domainName = dto.Domains[0].DomainName;
        //    dto.Domains.Add(new EntityDtos.CreateAppEDtoDetails() {
        //        DomainName= domainName,
        //        Remark=""
        //    });

        //    var ex = await Assert.ThrowsAsync<DomainException>(async () => {
        //        await _manager.CreateAsync(dto);
        //    });

        //    ex.Code.ShouldBe(DesignerDomainErrorCodes.IsExistsCheck);
        //}

        //[Fact]
        //public async Task CreateAsync_Success()
        //{
        //    var dto = DataBuilder.Build_CreateAppEDto();

        //    var result = await _manager.CreateAsync(dto);

        //    var enttity = await _repository.GetAsync(result.Id);

        //    enttity.ShouldNotBeNull();
        //}
        //#endregion

        //#region UpdateAsync
        //[Fact]
        //public async Task UpdateAppNameAsync_Failed_When_AppIsNotExists()
        //{
        //    var ex = await Assert.ThrowsAsync<DomainException>(async()=> {
        //        await _manager.UpdateAppNameAsync(Guid.NewGuid(), "newName");
        //    });

        //    ex.Code.ShouldBe(DesignerDomainErrorCodes.NoDataCheck);
        //}

        //[Fact]
        //public async Task UpdateAppNameAsync_Failed_When_AppNameIsDuplicated()
        //{
        //    var dto = DataBuilder.Build_CreateAppEDto();
        //    var entity = await _manager.CreateAsync(dto);

        //    var name = entity.AppName;

        //    dto = DataBuilder.Build_CreateAppEDto();
        //    entity = await _manager.CreateAsync(dto);

        //    var ex = await Assert.ThrowsAsync<DomainException>(async () => {
        //        await _manager.UpdateAppNameAsync(entity.Id, name);
        //    });

        //    ex.Code.ShouldBe(DesignerDomainErrorCodes.IsExistsCheck);
        //}

        //[Fact]
        //public async Task UpdateAppNameAsync_Failed_When_AppNameIsEmpty()
        //{
        //    var dto = DataBuilder.Build_CreateAppEDto();
        //    var entity = await _manager.CreateAsync(dto);

        //    var ex = await Assert.ThrowsAsync<DomainException>(async () => {
        //        await _manager.UpdateAppNameAsync(entity.Id, "");
        //    });

        //    ex.Code.ShouldBe(DesignerDomainErrorCodes.NullOrEmptyCheck);
        //}

        //[Fact]
        //public async Task UpdateAppNameAsync_Failed_When_AppNameIsTooLong()
        //{
        //    var dto = DataBuilder.Build_CreateAppEDto();
        //    var entity = await _manager.CreateAsync(dto);

        //    //构造超长的AppName
        //    var maxLen = DomainFieldLengthConsts.AppConsts.AppNameLen;
        //    StringBuilder sb = new StringBuilder();
        //    for (var i = 0; i < maxLen + 1; i++)
        //    {
        //        sb.Append("A");
        //    }

        //    var ex = await Assert.ThrowsAsync<DomainException>(async () => {
        //        await _manager.UpdateAppNameAsync(entity.Id, sb.ToString());
        //    });

        //    ex.Code.ShouldBe(DesignerDomainErrorCodes.IsTooLongCheck);
        //}

        //[Fact]
        //public async Task UpdateAppNameAsync_Failed_When_AppIdIsEmpty()
        //{
        //    var ex = await Assert.ThrowsAsync<DomainException>(async () => {
        //        await _manager.UpdateAppNameAsync(Guid.Empty,"aaa");
        //    });

        //    ex.Code.ShouldBe(DesignerDomainErrorCodes.NullOrEmptyCheck);
        //}

        //[Fact]
        //public async Task UpdateAppNameAsync_Success()
        //{
        //    var dto = DataBuilder.Build_CreateAppEDto();
        //    var entity = await _manager.CreateAsync(dto);

        //    var id = entity.Id;
        //    var name = "newName1";

        //    await _manager.UpdateAppNameAsync(entity.Id, name);

        //    entity = await _repository.GetAsync(id);

        //    entity.ShouldNotBeNull();
        //    entity.AppName.ShouldBe(name);

        //    await _manager.DeleteAsync(id);
        //}
        //#endregion

        //#region DeleteAsync
        //[Fact]
        //public async Task DeleteAsync_Failed_When_HasAggRoot()
        //{
        //    throw new NotImplementedException();
        //}
        //#endregion
    }
}
