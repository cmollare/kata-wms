using Domain.Enums;

namespace Domain.Commands;

public record CreateNotificationCommand
{
    public string CustomerId { get; init; } = string.Empty;
    public string ProductPartnerRef { get; init; } = string.Empty;
    public string Ean { get; init; } = string.Empty;
    public string Description { get; init; } = string.Empty;
    public double Weight { get; init; }
    public double Length { get; init; }
    public double Width { get; init; }
    public double Height { get; init; }
    public ProductType SizeType { get; init; }
}