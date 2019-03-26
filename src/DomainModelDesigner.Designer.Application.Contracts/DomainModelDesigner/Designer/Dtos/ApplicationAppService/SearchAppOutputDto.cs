using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace DomainModelDesigner.Designer.Dtos
{
    public class SearchAppOutputDto : FullAuditedEntityDto<Guid>
    {
        public string AppName { get; set; }

        public List<SearchAppOutputDtoDetail> Domains { get; set; }
    }


    public class SearchAppOutputDtoDetail
    {
        public string DomainName { get; private set; }

        public string Remark { get; private set; }
    }
}
