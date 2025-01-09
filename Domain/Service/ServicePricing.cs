namespace CVB.BL.Domain.Service;

public class ServicePricing
{
    public Guid Id { get; set; }
    public Guid ServiceId { get; set; }
    public decimal BasePrice { get; set; }
    public BillingType BillingType { get; set; }
    
    public virtual required Service Service { get; set; }
}