using EventBus.Base;
using EventBus.Base.Abstraction;
using EventBus.Factory;
using EventBus.Test.TestEvents;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NUnit.Framework;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EventBus.Test
{
    public class EventBusTest
    {

   

        private readonly IServiceCollection _serviceCollection;
        public EventBusTest()
        {
            _serviceCollection = new ServiceCollection();

            _serviceCollection.AddLogging(conf => conf.AddConsole());


        }
        [Test]
        public void ShouldSubscriceRabbitMQEvent()
        {

            _serviceCollection.AddSingleton<IEventBus>((sp) =>
            {

                EventBusConfig eventBusConfig = new EventBusConfig
                {

                    ConnectionRetryCount = 4,
                    SubscriberClientAppName = "EventBus.Test",
                    DefaultTopicName = "MyTopic",
                    EventBusType = Base.Enums.EventBusType.RabbitMQ,
                    EventNameSuffix = "IntegerationEvent"

                };
                return EventBusFactory.Create(eventBusConfig, sp);
            });

            var sp = _serviceCollection.BuildServiceProvider();

            var serviceBus = sp.GetRequiredService<IEventBus>();

            serviceBus.Subscribe<OrderAddedIntegerationEvent, OrderAddedIntegerationEventHendler>();

            Thread.Sleep(2000);




        }
        [Test]
        public void ShouldSendMesseageRabbitMQEvent()
        {

            _serviceCollection.AddSingleton<IEventBus>((sp) =>
            {

                EventBusConfig eventBusConfig = new EventBusConfig
                {

                    ConnectionRetryCount = 4,
                    SubscriberClientAppName = "EventBus.Test",
                    DefaultTopicName = "MyTopic",
                    EventBusType = Base.Enums.EventBusType.RabbitMQ,
                    EventNameSuffix = "IntegerationEvent"

                };
                return EventBusFactory.Create(eventBusConfig, sp);
            });

            var sp = _serviceCollection.BuildServiceProvider();

            var eventBus = sp.GetRequiredService<IEventBus>();

            eventBus.Publish(new OrderAddedIntegerationEvent(Guid.NewGuid(), DateTime.Now));

        }

       


    }
}
