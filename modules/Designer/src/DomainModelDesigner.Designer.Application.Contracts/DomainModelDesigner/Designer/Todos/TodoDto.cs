using System;
using Volo.Abp.Application.Dtos;

namespace DomainModelDesigner.Designer.Todos
{
    public class TodoDto : EntityDto<Guid>
    {
        public string Text { get; set; }
    }
}