using System;
using MassTransit;

namespace Api.Bus
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
            return MassTransit.Bus.Factory.CreateUsingRabbitMq(cfg =>
            {
                cfg.Host(new Uri("rabbitmq://localhost"), h =>
                {
                    h.Username("guest");
                    h.Password("guest");
                });
            });
        }
    }
}