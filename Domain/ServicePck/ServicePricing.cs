namespace CVB.BL.Domain.ServicePck;

public class ServicePricing
{
    public Guid Id { get; set; }
    public Guid ServiceId { get; set; }
    public decimal BasePrice { get; set; }
    public BillingType BillingType { get; set; }
    
    public virtual Service? Service { get; set; }
}