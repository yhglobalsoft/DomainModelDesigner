using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace DomainModelDesigner.Designer.Dtos
{
    [Serializable]
    public class SearchValueObjectInputDto: PagedAndSortedResultRequestDto
    {
        public string Filter { get; set; }
    }
}
