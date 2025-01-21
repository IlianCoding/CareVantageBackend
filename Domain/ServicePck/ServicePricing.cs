using System.ComponentModel.DataAnnotations;

namespace CVB.BL.Domain.ServicePck;

public class ServicePricing
{
    public Guid Id { get; set; }
    public Guid ServiceId { get; set; }
    
    [Required(ErrorMessage = "Base price is required.")]
    [Range(0, 15000, ErrorMessage = "Base price must be a number between 0 and 50.")]
    public decimal BasePrice { get; set; }
    public BillingType BillingType { get; set; }
    
    public virtual Service? Service { get; set; }
}