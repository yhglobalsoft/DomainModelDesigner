using System;
using System.Collections.Generic;
using System.Text;

namespace DomainModelDesigner.Designer.EntityDtos
{
    [Serializable]
    public class CreateValueObjectEDto
    {
        public Guid DomainId { get; set; }

        public string Name { get; set; }

        public string Descriptions { get; set; }

        public List<FieldEDto> Fields { get; set; }
    }
}
