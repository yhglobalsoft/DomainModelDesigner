using System;
using System.Collections.Generic;
using System.Text;

namespace DomainModelDesigner.Designer.Dtos
{
    [Serializable]
    public class UpdateDomainInputDto
    {
        public UpdateDomainInputDtoDetail Domain { get; set; }
    }

    [Serializable]
    public class UpdateDomainInputDtoDetail
    {
        public Guid Id { get; set; }
        public string DomainName { get; set; }
        public string Remark { get; set; }
    }
        
}
