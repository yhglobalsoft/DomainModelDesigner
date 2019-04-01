//using DomainModelDesigner.Designer.AppServices;
//using DomainModelDesigner.Designer.Dtos;
//using Microsoft.Extensions.Localization;
//using System;
//using System.Collections.Generic;
//using System.Text;
//using System.Threading.Tasks;
//using Volo.Abp;
//using Volo.Abp.Domain.Entities;
//using Volo.Abp.Localization;
//using Xunit;

//namespace DomainModelDesigner.Designer
//{
//    public class ApplicationAppService_Test: DesignerApplicationTestBase
//    {
//        private readonly IApplicationAppService _services;
//        private readonly IStringLocalizer<DefaultResource> _localizer;
//        public ApplicationAppService_Test()
//        {
//            _services= GetRequiredService<IApplicationAppService>();
//            _localizer= GetRequiredService<IStringLocalizer<DefaultResource>>();
//        }

//        #region CreateAsync_Test
//        [Fact]
//        public async Task CreateAsync_Success()
//        {
//            var dto =DataBuilder.Build_CreateAppInputDto();

//            var result=await _services.CreateAsync(dto);

//            Assert.NotNull(result);
//            Assert.NotEqual(result.Id.ToString().ToLower(),Guid.Empty.ToString().ToLower());
//        }

//        [Fact]
//        public async Task CreateAsync_Failed_When_AppNameIsExists()
//        {
//            var dto = DataBuilder.Build_CreateAppInputDto();

//            await _services.CreateAsync(dto);

//            await Assert.ThrowsAsync<DomainException>(async ()=> {
//                await _services.CreateAsync(dto);
//            });
//        }

//        [Fact]
//        public async Task CreateAsync_AppNameEmpty_ShouldValidateError()
//        {
//            var dto = DataBuilder.Build_CreateAppInputDto();
//            dto.Name = "";

//            await Assert.ThrowsAsync<FluentValidation.ValidationException>(async ()=> {
//                await _services.CreateAsync(dto);
//            });
//        }

//        [Fact]
//        public async Task CreateAsync_DomainEmpty_ShouldValidateError()
//        {
//            var dto = DataBuilder.Build_CreateAppInputDto();
//            dto.Domains = null;

//            await Assert.ThrowsAsync<FluentValidation.ValidationException>(async () => {
//                await _services.CreateAsync(dto);
//            });
//        }

//        [Fact]
//        public async Task CreateAsync_DomainNameEmpty_ShouldValidateError()
//        {
//            var dto = DataBuilder.Build_CreateAppInputDto();
//            dto.Domains[0].DomainName = "";

//            await Assert.ThrowsAsync<FluentValidation.ValidationException>(async () => {
//                await _services.CreateAsync(dto);
//            });
//        }
//        #endregion

//        #region DeleteAsync_Test
//        [Fact]
//        public async Task DeleteAsync_Success()
//        {
//            var dto = DataBuilder.Build_CreateAppInputDto();

//            var obj=await _services.CreateAsync(dto);

//            await _services.DeleteAsync(obj.Id);

//            obj = await _services.GetAsync(obj.Id);

//            Assert.Null(obj);
//        }
//        #endregion

//        #region UpdateAsync_Test
//        [Fact]
//        public async Task UpdateAsync_Success()
//        {
//            var dto = DataBuilder.Build_CreateAppInputDto();
//            var entity=await _services.CreateAsync(dto);

//            dto.Name = $"1aa{dto.Name}";
//            dto.Domains[0].Remark = "aaa";

//            await _services.UpdateAsync(entity.Id, dto);

//            entity =await _services.GetAsync(entity.Id);
//            Assert.NotNull(entity);

//            bool flag = entity.AppName.Equals(dto.Name) && entity.Domains[0].Remark.Equals("aaa");
//            Assert.True(flag);
//        }

//        [Fact]
//        public async Task UpdateAsync_Failed_When_AppIsNotExists()
//        {
//            var dto = DataBuilder.Build_CreateAppInputDto();
//            var entity = await _services.CreateAsync(dto);

//            await _services.DeleteAsync(entity.Id);

//            var ex = await Assert.ThrowsAsync<AppServiceException>(async () =>
//            {
//                await _services.UpdateAsync(entity.Id, dto);
//            });

//            Assert.Equal(ex.Code, _localizer["App:003"]);
//        }

//        [Fact]
//        public async Task UpdateAsync_AppNameEmpty_ShouldValidateError()
//        {
//            var dto = DataBuilder.Build_CreateAppInputDto();

//            var entity=await _services.CreateAsync(dto);

//            dto.Name = "";

//           await Assert.ThrowsAsync<FluentValidation.ValidationException>(async () => {
//               await _services.UpdateAsync(entity.Id, dto);
//           });
//        }

//        [Fact]
//        public async Task UpdateAsync_DomainNameEmpty_ShouldValidateError()
//        {
//            var dto = DataBuilder.Build_CreateAppInputDto();

//            var entity = await _services.CreateAsync(dto);

//            dto.Domains[0].DomainName = "";

//            await Assert.ThrowsAsync<FluentValidation.ValidationException>(async () => {
//                await _services.UpdateAsync(entity.Id, dto);
//            });
//        }
//        #endregion

//        #region UpdateDomainAsync_Test
//        [Fact]
//        public async Task UpdateDomainAsync_Success()
//        {
//            var dto = DataBuilder.Build_CreateAppInputDto();
//            var entity = await _services.CreateAsync(dto);

//            var domainName = "domain_1";
//            var remark = "remark_1";

//            await _services.UpdateDomainAsync(entity.Id,entity.Domains[0].Id, domainName, remark);

//            entity = await _services.GetAsync(entity.Id);

//            Assert.NotNull(entity);

//            bool flag = entity.Domains[0].DomainName.Equals(domainName) && entity.Domains[0].Remark.Equals(remark);
//            Assert.True(flag);
//        }
//        #endregion
//    }
//}
