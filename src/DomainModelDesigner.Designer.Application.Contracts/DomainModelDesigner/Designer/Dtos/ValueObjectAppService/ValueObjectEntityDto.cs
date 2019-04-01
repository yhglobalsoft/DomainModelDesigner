using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace DomainModelDesigner.Designer.Dtos
{
    [Serializable]
    public class ValueObjectEntityDto : FullAuditedEntityDto<Guid>
    {
        /// <summary>
        /// 聚合根所属的领域
        /// </summary>
        public Guid DomainId { get; private set; }

        /// <summary>
        /// 类的名称
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// 类的描述
        /// </summary>
        public string Descriptions { get; private set; }

        public List<FieldEntityDto> Fields { get; set; }
    }
}
