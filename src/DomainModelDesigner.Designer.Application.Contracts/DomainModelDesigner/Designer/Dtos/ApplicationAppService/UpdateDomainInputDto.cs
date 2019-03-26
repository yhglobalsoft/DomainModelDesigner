using System;
using System.Collections.Generic;
using System.Text;

namespace DomainModelDesigner.Designer.Dtos
{
    public class UpdateDomainInputDto
    {
        public Guid AppId { get; set; }

        public UpdateDomainInputDtoDetail Domain { get; set; }
    }

    public class UpdateDomainInputDtoDetail
    {
        public Guid Id { get; set; }
        public string DomainName { get; set; }
        public string Remark { get; set; }
    }
        
}
