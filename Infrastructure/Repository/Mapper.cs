using Domain.Models;

namespace Infrastructure.Repository;

public static class Mapper
{
    public static Product ToProduct(this ProductDto productDto)
    {
        return new Product
        {
            Id = productDto.Id.ToString(),
            CustomerId = productDto.CustomerId,
            ProductPartnerRef = productDto.ProductPartnerRef,
            Ean = productDto.Ean,
            Description = productDto.Description,
            Weight = productDto.Weight,
            Length = productDto.Length,
            Width = productDto.Width,
            Height = productDto.Height
        };
    }
}