using System;
using System.Collections.Generic;
using System.Text;

namespace DomainModelDesigner.Designer.Dtos.ApplicationAppService
{
    [Serializable]
    public class CreateDomainDto
    {
        public List<CreateDomainDtoDetail> Domains { get; set; }
    }

    [Serializable]
    public class CreateDomainDtoDetail
    {
        public string Name { get; set; }

        public string Remark { get; set; }
    }
}
