using System;
using System.Collections.Generic;
using System.Text;

namespace DomainModelDesigner.Designer.Dtos
{
    [Serializable]
    public class UpdateDomainInputDto
    {
        public string DomainName { get; set; }
        public string Remark { get; set; }
    }

    //[Serializable]
    //public class UpdateDomainInputDtoDetail
    //{
    //    public string DomainName { get; set; }
    //    public string Remark { get; set; }
    //}
        
}
