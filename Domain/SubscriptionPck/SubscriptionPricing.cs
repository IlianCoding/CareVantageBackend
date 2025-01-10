namespace CVB.BL.Domain.SubscriptionPck;

public class SubscriptionPricing
{
    public Guid Id { get; set; }
    public Guid SubscriptionId { get; set; }
    public decimal Price { get; set; }
    public BillingFrequency BillingFrequency { get; set; }
    
    public virtual required Subscription Subscription { get; set; }
}