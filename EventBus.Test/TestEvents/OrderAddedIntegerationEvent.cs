using EventBus.Base.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventBus.Test.TestEvents
{
    internal class OrderAddedIntegerationEvent : IntegrationEvent
    {
        public OrderAddedIntegerationEvent(Guid id, DateTime createdDate) : base(id, createdDate)
        {
        }
    }
}
