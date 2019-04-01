using System;
using System.Collections.Generic;
using System.Text;

namespace DomainModelDesigner.Designer.Dtos
{
    [Serializable]
    public class CreateValueObjectInputDto
    {
        /// <summary>
        /// 所属领域
        /// </summary>
        public Guid DomainId { get; set; }

        /// <summary>
        /// 类名
        /// </summary>
        public string Name { get; set; }

        public string Desc { get; set; }

        public List<FieldDto> Fields { get; set; }
    }



}
