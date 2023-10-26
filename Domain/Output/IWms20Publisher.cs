using Domain.Commands;

namespace Domain.Output;

public interface IWms20Publisher
{
    Task SendToWms20(CreateNotificationCommand command);
}