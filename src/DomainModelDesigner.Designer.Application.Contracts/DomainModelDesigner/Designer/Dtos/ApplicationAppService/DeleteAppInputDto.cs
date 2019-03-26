using System;
using System.Collections.Generic;
using System.Text;

namespace DomainModelDesigner.Designer.Dtos
{
    [Serializable]
    public class DeleteAppInputDto
    {
        public Guid AppId { get; set; }
    }
}
