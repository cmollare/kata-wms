namespace Infrastructure.Repository;

public record ProductDto
{
    public Guid Id { get; init; } 
    public int CustomerId { get; init; }
    public string ProductPartnerRef { get; init; } = string.Empty;
    public string Ean { get; init; } = string.Empty;
    public string Description { get; init; } =  string.Empty;
    public double Weight { get; init; }
    public double Length { get; init; }
    public double Width { get; init; } 
    public double Height { get; init; }
}
