namespace CVB.BL.Domain.Service;

public class Service
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public required string Description { get; set; }
    public bool IsActive { get; set; }
    
    public virtual required ServicePricing Pricing { get; set; }
    public virtual required ServiceFeature Features { get; set; }
}