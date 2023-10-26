using Domain.Commands;
using Domain.Models;
using Domain.Output;
using Domain.WmsNotifications;
using Microsoft.Extensions.Options;

namespace Domain.Input;

public class ProductsService
{
    private readonly IProductsRepository _repository;
    private readonly IOptionsMonitor<Wms20Configuration> _wmsConfiguration;
    private readonly NotificationsService _notificationsService;

    public ProductsService(IProductsRepository repository, IOptionsMonitor<Wms20Configuration> wmsConfiguration, NotificationsService notificationsService)
    {
        _repository = repository;
        _wmsConfiguration = wmsConfiguration;
        _notificationsService = notificationsService;
    }

    public async Task CreateProduct(CreateProductCommand command)
    {
        var product = await _repository.CreateProduct(command);
        var isWms20 = _wmsConfiguration.CurrentValue.AllowedCustomerIds.Contains(command.CustomerId);
        
        var notificationCommand = product.ToCreateNotificationCommand(isWms20);
        await _notificationsService.Notify(notificationCommand, isWms20);
    }

    public async Task<IEnumerable<Product>> GetProducts()
    {
        return await _repository.GetProducts();
    }
}


// TODO:
// Now we want to add a new WMS — WM30.
//
// Here is how the notification command should be generated:
// * The customerId is encoded in hexadecimal
// * The description has a max length of 30
// * The productType is computed as in Wms20
// * All of the dimensions and weight are rounded to 2 fractional digits 
// * Ean and ProductPartnerRef remains unchanged


// Once the correct notification is generated, it needs to be sent to a new kafkaPublisher. 