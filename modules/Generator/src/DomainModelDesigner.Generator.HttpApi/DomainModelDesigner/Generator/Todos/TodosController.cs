﻿using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.AspNetCore.Mvc;

namespace DomainModelDesigner.Generator.Todos
{
    [RemoteService]
    [Area("Generator")]
    [Route("api/Generator/todos")]
    [Authorize]
    public class TodosController : AbpController
    {
        private readonly ITodoAppService _todoAppService;

        public TodosController(ITodoAppService todoAppService)
        {
            _todoAppService = todoAppService;
        }

        [HttpGet]
        [Route("")]
        public Task<PagedResultDto<TodoDto>> GetListAsync()
        {
            return _todoAppService.GetListAsync();
        }
    }
}
