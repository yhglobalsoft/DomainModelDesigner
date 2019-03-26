using System;
using System.Collections.Generic;
using System.Text;

namespace DomainModelDesigner.Designer.Dtos
{
    public class DeleteDomainInputDto
    {
        public Guid AppId { get; set; }

        public Guid DomainId { get; set; }
    }
}
