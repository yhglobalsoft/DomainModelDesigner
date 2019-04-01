using DomainModelDesigner.Designer.AppServices;
using DomainModelDesigner.Designer.Dtos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.AspNetCore.Mvc;

namespace DomainModelDesigner.Designer.Controllers
{
    [RemoteService]
    [Route("api/valueObject")]
    public class ValueObjectController : AbpController //, IValueObjectAppService
    {
        private readonly IValueObjectAppService _service;
        public ValueObjectController(IValueObjectAppService service)
        {
            _service = service;
        }

        [Route("create")]
        [HttpPost]
        public async Task<ValueObjectEntityDto> CreateAsync(CreateValueObjectInputDto input)
        {
            return await _service.CreateAsync(input);
        }

        [Route("delete")]
        [HttpPost]
        public Task DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        [Route("get")]
        [HttpPost]
        [HttpGet]
        public Task<ValueObjectEntityDto> GetAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        [Route("getList")]
        [HttpPost]
        [HttpGet]
        public Task<PagedResultDto<ValueObjectEntityDto>> GetListAsync(SearchValueObjectInputDto input)
        {
            throw new NotImplementedException();
        }

        [Route("update")]
        [HttpPost]
        public Task<ValueObjectEntityDto> UpdateAsync(Guid id, CreateValueObjectInputDto input)
        {
            throw new NotImplementedException();
        }
    }
}
