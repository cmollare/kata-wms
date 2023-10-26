using System.Text.RegularExpressions;
using Api.Models;
using Domain.Commands;
using Domain.Input;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductsController : ControllerBase
{
    private readonly ProductsService _productService;
    private readonly ILogger<ProductsController> _logger;

    public ProductsController(ProductsService productService, ILogger<ProductsController> logger)
    {
        _productService = productService;
        _logger = logger;
    }

    [HttpPost]
    public async Task<IActionResult> CreateProduct([FromBody] CreateProductRequest request)
    {
        // EAN Validation 
        const string pattern = "^[0-9]+$";
        if (request.Ean.Length != 8 || !Regex.IsMatch(request.Ean, pattern))
        {
            _logger.LogInformation("customerId {RequestCustomerId} tried to create a product with reference {RequestProductPartnerRef} and invalid ean", request.CustomerId, request.ProductPartnerRef);
            return BadRequest("Ean must have exactly 8 digits.");
        }
        
        var command = new CreateProductCommand
        {
            CustomerId = request.CustomerId ?? 0,
            ProductPartnerRef = request.ProductPartnerRef,
            Ean = request.Ean,
            Description = request.Description ?? string.Empty,
            Weight = request.Weight ?? 0,
            Length = request.Length ?? 0,
            Width = request.Width ?? 0,
            Height = request.Height ?? 0
        };

        await _productService.CreateProduct(command);
        
        return Ok(); 
    }
    
    
    [HttpGet]
    public async Task<IActionResult> GetProducts()
    {
        var products =await _productService.GetProducts();
        return Ok(products); 
    }
}