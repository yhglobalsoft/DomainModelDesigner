using DomainModelDesigner.Designer.AppServices;
using DomainModelDesigner.Designer.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.AspNetCore.Mvc;

namespace DomainModelDesigner.Designer.Controllers
{
    [RemoteService]
    [Route("api/app")]
    public class AppController:AbpController
    {
        private readonly IApplicationAppService _service;
        public AppController(IApplicationAppService service)
        {
            _service = service;
        }

        [HttpPost]
        [Route("create")]
        public async Task<Guid> CreateAsync([FromBody]CreateAppInputDto dto)
        {
           var result= await  _service.CreateAsync(dto);

            return result.Id;
        }

        [HttpPost]
        [Route("delete")]
        public async Task DeleteAsync(Guid id)
        {
            await _service.DeleteAsync(id);
        }

        [HttpPost]
        [Route("get")]
        public async Task<SearchAppOutputDto> GetAsync(Guid id)
        {
            return await _service.GetAsync(id);
        }

        [HttpPost]
        [Route("getlist")]
        public async Task<PagedResultDto<SearchAppOutputDto>> GetListAsync(SearchAppInputDto input)
        {
            return await _service.GetListAsync(input);
        }

        /// <summary>
        /// 切换为英文
        /// </summary>
        /// <returns></returns>
        [Route("ChangeLanguage")]
        [HttpPost]
        public IActionResult SetLanguage()
        {
            Response.Cookies.Append(
                CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture("zh-Hans")),
                new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1) }
            );

            return Content("111");
        }

        [HttpPost]
        [Route("update")]
        public async Task<SearchAppOutputDto> UpdateAsync(Guid id, CreateAppInputDto input)
        {
            return await _service.UpdateAsync(id,input);
        }

        [HttpPost]
        [Route("updateDomain")]
        public async Task UpdateDomainAsync(Guid id,UpdateDomainInputDto dto, CancellationToken cancellationToken = default(CancellationToken))
        {
            await _service.UpdateDomainAsync(id,dto);
        }
    }
}
