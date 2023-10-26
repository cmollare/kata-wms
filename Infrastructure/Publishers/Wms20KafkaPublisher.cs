using Domain.Commands;
using Domain.Output;

namespace Infrastructure.Publishers;

public class Wms20KafkaPublisher : IWms20Publisher
{
    public async Task SendToWms20(CreateNotificationCommand command)
    {
        await Task.Delay(5);
    }
}