//using DomainModelDesigner.Designer.AppServices;
//using Microsoft.Extensions.Localization;
//using System;
//using System.Collections.Generic;
//using System.Text;
//using System.Threading.Tasks;
//using Volo.Abp.Localization;
//using Xunit;

//namespace DomainModelDesigner.Designer
//{
//    public class ValueObjectAppService_Test : DesignerApplicationTestBase
//    {
//        private readonly IValueObjectAppService _services;
//        private readonly IApplicationAppService _appServices;
//        private readonly IStringLocalizer<DefaultResource> _localizer;
//        public ValueObjectAppService_Test()
//        {
//            _services = GetRequiredService<IValueObjectAppService>();
//            _localizer = GetRequiredService<IStringLocalizer<DefaultResource>>();
//            _appServices = GetRequiredService<IApplicationAppService>();
//        }

//        #region CreateAsync_Test
//        [Fact]
//        public async Task CreateAsync_Success()
//        {
//            var appDto = DataBuilder.Build_CreateAppInputDto();
//            var entity=await _appServices.CreateAsync(appDto);

//            var dto = DataBuilder.Build_CreateValueObjectInputDto(entity.Domains[0].Id);

//            var obj = await _services.CreateAsync(dto);

//            var result = await _services.GetAsync(obj.Id);

//            Assert.NotNull(result);
//        }

//        [Fact]
//        public async Task CreateAsync_DomainIdIsEmpty_ShouldBeValidateError()
//        {
//            var dto = DataBuilder.Build_CreateValueObjectInputDto(Guid.Empty);

//            await Assert.ThrowsAsync<FluentValidation.ValidationException>(async () => {
//                await _services.CreateAsync(dto);
//            });

//        }

//        [Fact]
//        public async Task CreateAsync_NameIsEmpty_ShouldBeValidateError()
//        {
//            var dto = DataBuilder.Build_CreateValueObjectInputDto(Guid.NewGuid());
//            dto.Name = "";

//            await Assert.ThrowsAsync<FluentValidation.ValidationException>(async () => {
//                await _services.CreateAsync(dto);
//            });

//        }

//        [Fact]
//        public async Task CreateAsync_NameIsTooLong_ShouldBeValidateError()
//        {
//            var dto = DataBuilder.Build_CreateValueObjectInputDto(Guid.NewGuid());

//            StringBuilder str = new StringBuilder();
//            for (int i = 0; i < DomainFieldLengthConsts.ValueObjectConsts.ValueObjectNameLen+1;i++)
//            {
//                str.Append("A");
//            }
//            dto.Name = str.ToString();

//            await Assert.ThrowsAsync<FluentValidation.ValidationException>(async () => {
//                await _services.CreateAsync(dto);
//            });

//        }

//        [Fact]
//        public async Task CreateAsync_FieldsIsNull_ShouldBeValidateError()
//        {
//            var dto = DataBuilder.Build_CreateValueObjectInputDto(Guid.NewGuid());
//            dto.Fields = null;

//            await Assert.ThrowsAsync<FluentValidation.ValidationException>(async () => {
//                await _services.CreateAsync(dto);
//            });
//        }

//        [Fact]
//        public async Task CreateAsync_Failed_When_NameIsExists()
//        {
//            var dto = DataBuilder.Build_CreateValueObjectInputDto(Guid.NewGuid());
//            await _services.CreateAsync(dto);

//            var ex =await Assert.ThrowsAsync<DomainException>(async ()=> {
//                await _services.CreateAsync(dto);
//            });

//            Assert.Equal(ex.Code, DesignerDomainErrorCodes.IsExistsCheck);
//        }
//        #endregion

//        #region DeleteAsync_Test
//        [Fact]
//        public async Task DeleteAsync_Success()
//        {
//            var dto = DataBuilder.Build_CreateValueObjectInputDto(Guid.NewGuid());
//            var entity= await _services.CreateAsync(dto);

//            await _services.DeleteAsync(entity.Id);

//            entity = await _services.GetAsync(entity.Id);

//            Assert.Null(entity);

//        }
//        #endregion

//        #region UpdateAsync_Test
//        [Fact]
//        public async Task UpdateAsync_ReName_Success()
//        {
//            var dto = DataBuilder.Build_CreateValueObjectInputDto(Guid.NewGuid());
//            var entity = await _services.CreateAsync(dto);

//            var newName = $"{entity.Name}_1";
//            await _services.UpdateAsync(entity.Id, new Dtos.ValueObjectAppService.UpdateValueObjectInputDto()
//            {
//                Name = newName
//            });

//            entity = await _services.GetAsync(entity.Id);

//            Assert.Equal(entity.Name.ToLower(), newName.ToLower());
//        }

//        [Fact]
//        public async Task UpdateAsync_Failed_When_NameIsExists()
//        {
//            var dto1 = DataBuilder.Build_CreateValueObjectInputDto(Guid.NewGuid());

//            var obj1 = await _services.CreateAsync(dto1);

//            var fieldName = dto1.Fields[0].FieldName;

//            dto1.Fields.Clear();
//           // dto1.Fields.Add(new );

//        } 
//        #endregion
//    }
//}
