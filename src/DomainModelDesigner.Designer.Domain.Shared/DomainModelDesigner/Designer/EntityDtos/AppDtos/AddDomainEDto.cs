using System;
using System.Collections.Generic;
using System.Text;

namespace DomainModelDesigner.Designer.EntityDtos
{
    [Serializable]
    public class AddDomainEDto
    {
        public List<AddDomainEDtoDetail> Domains { get; set; }
    }

    [Serializable]
    public class AddDomainEDtoDetail
    {
        public string Name { get; set; }

        public string Remark { get; set; }
    }
}
