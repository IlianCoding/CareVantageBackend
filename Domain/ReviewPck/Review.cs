using CVB.BL.Domain.ServicePck;

namespace CVB.BL.Domain.ReviewPck;

public class Review
{
    public Guid Id { get; set; }
    public Guid ServiceId { get; set; }
    public Guid UserId { get; set; }
    
    public virtual required Service Service { get; set; }
    public virtual required ReviewDetails ReviewDetails { get; set; }
}