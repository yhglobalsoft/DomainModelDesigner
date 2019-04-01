using System;
using System.Collections.Generic;
using System.Text;

namespace DomainModelDesigner.Designer.Dtos.ValueObjectAppService
{
    [Serializable]
    public class UpdateValueObjectInputDto
    {
        public string Name { get; set; }

        public string Desc { get; set; }
    }
}
