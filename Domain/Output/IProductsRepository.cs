using Domain.Commands;
using Domain.Models;

namespace Domain.Output;

public interface IProductsRepository
{
    Task<Product> CreateProduct(CreateProductCommand command);
    Task<IEnumerable<Product>> GetProducts();
}