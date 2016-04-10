using System.Threading.Tasks;
using MassTransit;
using MessageContracts;
using Web.Hubs;

namespace Web.Bus.Consumers
{
    public class SomethingHappenedConsumer : IConsumer<InnoEvent>
    {
        public Task Consume(ConsumeContext<InnoEvent> context)
        {
            var chatHub = new ChatHubWrraper();
            chatHub.Send(context.Message.What);

            //TODO use chrome notifications

            return Task.FromResult(0);
        }
    }
}