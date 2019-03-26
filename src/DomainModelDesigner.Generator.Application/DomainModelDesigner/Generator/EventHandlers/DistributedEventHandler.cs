using DomainModelDesigner.DistributedEvents;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.EventBus.Distributed;

namespace DomainModelDesigner.Generator.EventHandlers
{
    public class DistributedEventHandler : IDistributedEventHandler<Event1>
    {
        private readonly IDistributedEventBus _bus;
        public DistributedEventHandler(IDistributedEventBus bus)
        {
            _bus = bus;
        }

        public Task HandleEventAsync(Event1 eventData)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 发布分布式事件
        /// </summary>
        /// <returns></returns>
        private async Task PublishAyncTest()
        {
           await _bus.PublishAsync<Event1>(new Event1() { Code="001"});
        }
    }
}
