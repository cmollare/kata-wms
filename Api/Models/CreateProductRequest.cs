using System.ComponentModel.DataAnnotations;

namespace Api.Models;

public record CreateProductRequest
{
    [Required] public int? CustomerId { get; init; }
    [Required] public string ProductPartnerRef { get; init; } = string.Empty;
    [Required] public string Ean { get; init; } = string.Empty;
    public string? Description { get; init; } 
    public double? Weight { get; init; }
    public double? Length { get; init; }
    public double? Width { get; init; }
    public double? Height { get; init; }
}

