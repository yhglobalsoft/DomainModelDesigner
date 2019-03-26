using DomainModelDesigner.Designer.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DomainModelDesigner.Designer.DomainServices
{
    public interface IAppManager
    {
        Task<AppAggRoot> CreateAsync(AppAggRoot obj, CancellationToken cancellationToken=default(CancellationToken));

        Task<AppAggRoot> UpdateAsync(AppAggRoot obj, CancellationToken cancellationToken = default(CancellationToken));

        Task DeleteAsync(Guid id, CancellationToken cancellationToken = default(CancellationToken));
    }
}
