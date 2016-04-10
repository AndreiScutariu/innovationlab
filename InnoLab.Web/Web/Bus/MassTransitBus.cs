using System;
using MassTransit;
using Web.Bus.Consumers;

namespace Web.Bus
{
    public class MassTransitBus 
    {
        static IBusControl _instanceControl;

        public static IBus Instance => _instanceControl;

        public static void Start()
        {
            _instanceControl = ConfigureBus();
            _instanceControl.Start();
        }

        public static void Stop()
        {
            _instanceControl.Stop();
        }

        static IBusControl ConfigureBus()
        {
            return MassTransit.Bus.Factory.CreateUsingRabbitMq(x =>
            {
                var host = x.Host(new Uri("rabbitmq://localhost/"), h => { });
                x.ReceiveEndpoint(host, "InnoLab_Sub", e => e.Consumer<SomethingHappenedConsumer>());
            });
        }
    }
}