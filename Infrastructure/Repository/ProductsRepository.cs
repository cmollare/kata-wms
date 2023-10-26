using Domain.Commands;
using Domain.Models;
using Domain.Output;

namespace Infrastructure.Repository;

// This class imitates interactions with some database.
public class ProductsRepository : IProductsRepository
{
    private readonly List<ProductDto> _products = new();
    public async Task<Product> CreateProduct(CreateProductCommand command)
    {
        await Task.Delay(30);
        
        var product =  new ProductDto
        {
            Id = Guid.NewGuid(),
            CustomerId = command.CustomerId,
            ProductPartnerRef = command.ProductPartnerRef,
            Ean = command.Ean,
            Description = command.Description,
            Weight = command.Weight,
            Length = command.Length,
            Width = command.Width,
            Height = command.Height
        };
        
        _products.Add(product);

        return product.ToProduct();
    }
    
    public async Task<IEnumerable<Product>> GetProducts()
    {
        await Task.Delay(30);

        return _products.Select(x=>x.ToProduct());
    }
}