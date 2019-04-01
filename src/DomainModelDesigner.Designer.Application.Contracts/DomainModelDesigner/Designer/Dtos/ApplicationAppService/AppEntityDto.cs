using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace DomainModelDesigner.Designer.Dtos
{
    [Serializable]
    public class AppEntityDto : FullAuditedEntityDto<Guid>
    {
        public string AppName { get; set; }

        public List<AppEntityDtoDetail> Domains { get; set; }
    }

    [Serializable]
    public class AppEntityDtoDetail
    {
        public Guid Id { get; set; }

        public string DomainName { get; private set; }

        public string Remark { get; private set; }
    }
}
