using CVB.BL.Domain.ReviewPck;

namespace CVB.BL.Domain.ServicePck;

public class Service
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public required string Description { get; set; }
    public bool IsActive { get; set; }
    
    public virtual required ServicePricing Pricing { get; set; }
    public virtual required ServiceFeature Features { get; set; }
    public virtual ICollection<Review>? Reviews { get; set; }
}