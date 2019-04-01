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


    }
}
