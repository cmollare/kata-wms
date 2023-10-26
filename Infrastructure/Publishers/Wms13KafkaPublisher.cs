using Domain.Commands;
using Domain.Output;

namespace Infrastructure.Publishers;

public class Wms13KafkaPublisher : IWms13Publisher
{
    public async Task SendToWms13(CreateNotificationCommand command)
    {
        await Task.Delay(5);
    }
}