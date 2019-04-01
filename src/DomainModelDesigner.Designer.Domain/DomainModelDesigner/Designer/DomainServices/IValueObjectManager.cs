using DomainModelDesigner.Designer.Entities;
using DomainModelDesigner.Designer.EntityDtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DomainModelDesigner.Designer.DomainServices
{
    public interface IValueObjectManager
    {
        //Task<ValueObjectAggRoot> CreateAsync(CreateValueObjectEDto obj, CancellationToken cancellation = default(CancellationToken));

        //Task<ValueObjectAggRoot> UpdateAsync(Guid id,string name,string desc, CancellationToken cancellation = default(CancellationToken));

        //Task<ValueObjectAggRoot> UpdateFieldAsync(Guid id,Guid fieldId, FieldEDto dto, CancellationToken cancellation = default(CancellationToken));

        Task<ValueObjectAggRoot> CreateAsync(ValueObjectAggRoot obj, CancellationToken cancellation = default(CancellationToken));

        Task<ValueObjectAggRoot> UpdateAsync(ValueObjectAggRoot obj, CancellationToken cancellation = default(CancellationToken));

        Task DeleteAsync(Guid id, CancellationToken cancellation = default(CancellationToken));
    }
}
