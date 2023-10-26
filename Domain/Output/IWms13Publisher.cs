using Domain.Commands;

namespace Domain.Output;

public interface IWms13Publisher
{
    Task SendToWms13(CreateNotificationCommand command);
}