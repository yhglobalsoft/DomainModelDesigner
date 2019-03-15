using DomainModelDesigner.DistributedEvents;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.EventBus.Distributed;

namespace DomainModelDesigner.Designer.EventHandlers
{
    public class DistributedEventHandler : IDistributedEventHandler<Event1>
    {
        public Task HandleEventAsync(Event1 eventData)
        {
            throw new NotImplementedException();
        }
    }
}
