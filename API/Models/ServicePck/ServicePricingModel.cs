using CVB.BL.Domain.ServicePck;

namespace CVB.API.Models.ServicePck;

public class ServicePricingModel
{
    public decimal Price { get; set; }
    public string BillingType { get; set; }
}