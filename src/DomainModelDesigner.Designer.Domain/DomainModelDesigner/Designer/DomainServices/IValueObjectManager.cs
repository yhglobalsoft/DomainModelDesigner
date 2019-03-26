using DomainModelDesigner.Designer.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DomainModelDesigner.Designer.DomainServices
{
    public interface IValueObjectManager
    {
        Task<ValueObjectAggRoot> CreateAsync(ValueObjectAggRoot obj, CancellationToken cancellation=default(CancellationToken));

        Task<ValueObjectAggRoot> UpdateAsync(ValueObjectAggRoot obj, CancellationToken cancellation = default(CancellationToken));

        Task DeleteAsync(Guid id, CancellationToken cancellation = default(CancellationToken));
    }
}
