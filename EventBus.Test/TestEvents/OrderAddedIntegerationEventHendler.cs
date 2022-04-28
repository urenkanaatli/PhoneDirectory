using EventBus.Base.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventBus.Test.TestEvents
{
    internal class OrderAddedIntegerationEventHendler : IIntegrationEventHandler<OrderAddedIntegerationEvent>
    {
        public  Task Handle(OrderAddedIntegerationEvent @event)
        {


           return Task.CompletedTask;
        }
    }
}
