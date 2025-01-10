namespace CVB.BL.Domain.SubscriptionPck;

public class SubscriptionPeriod
{
    public Guid Id { get; set; }
    public Guid SubscriptionId { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    
    public virtual required Subscription Subscription { get; set; }
}