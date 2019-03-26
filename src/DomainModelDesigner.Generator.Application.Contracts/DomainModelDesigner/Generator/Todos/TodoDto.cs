using System;
using Volo.Abp.Application.Dtos;

namespace DomainModelDesigner.Generator.Todos
{
    public class TodoDto : EntityDto<Guid>
    {
        public string Text { get; set; }
    }
}