using Domain.Commands;
using Domain.Output;

namespace Domain.Input;

public class NotificationsService
{
    private readonly IWms13Publisher _wms13Publisher;
    private readonly IWms20Publisher _wms20Publisher;

    public NotificationsService(IWms13Publisher wms13Publisher, IWms20Publisher wms20Publisher)
    {
        _wms13Publisher = wms13Publisher;
        _wms20Publisher = wms20Publisher;
    }

    public async Task Notify(CreateNotificationCommand command, bool isWms20)
    {
        if (isWms20)
        {
            await _wms20Publisher.SendToWms20(command);
            return;
        }

        await _wms13Publisher.SendToWms13(command);
    }
}