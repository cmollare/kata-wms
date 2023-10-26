using Domain.Commands;
using Domain.Enums;
using Domain.Helpers;

namespace Domain.Models;

public record Product
{
    public string Id { get; init; } = string.Empty;
    public int CustomerId { get; init; }
    public string ProductPartnerRef { get; init; } = string.Empty;
    public string Ean { get; init; } = string.Empty;
    public string Description { get; init; } =  string.Empty;
    public double Weight { get; init; }
    public double Length { get; init; }
    public double Width { get; init; } 
    public double Height { get; init; }
}

public static class NotificationMapper
{
    public static CreateNotificationCommand ToCreateNotificationCommand(this Product product, bool isWm20)
    {
        /* Main differences between Wms20 and Wm13 : 
         * In Wms20 the customerId is a string encoded using hexadecimal whereas in Wms13 it's a string encoded using decimal
         * In Wms20 the description can be of random length whereas in Wms13 the description must be truncated to 20 characters
         * productType is computed differently in Wms20 and Wms13
         */
        return new CreateNotificationCommand
        {
            CustomerId = isWm20 ? product.CustomerId.ToString(" X") : product.CustomerId.ToString(), 
            ProductPartnerRef = product.ProductPartnerRef,
            Ean = product.ProductPartnerRef,
            Description = isWm20 ? product.Description : product.Description.Truncate(20),
            Weight = product.Weight,
            Length = product.Length,
            Width = product.Width,
            Height = product.Height,
            SizeType = product.ComputeSizeType(isWm20)
        };
    }

    private static ProductType ComputeSizeType(this Product product, bool isWms20)
    {
        return isWms20 switch
        {
            true => product.Weight < 30 && product.Length + product.Width + product.Height < 1.5 ? ProductType.P : ProductType.G,
            false => product.Weight < 20 && product is {Length: <1, Width: < 1, Height: < 1} ? ProductType.P : ProductType.G
        };
    }
}

