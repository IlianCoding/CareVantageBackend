namespace CVB.BL.Domain.SubscriptionPck;

public class Subscription
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public Guid ServiceId { get; set; }
    public SubscriptionTier Tier { get; set; }
    public SubscriptionStatus Status { get; set; }
    
    public virtual required SubscriptionPeriod Period { get; set; }
    public virtual required SubscriptionPricing Pricing { get; set; }
}