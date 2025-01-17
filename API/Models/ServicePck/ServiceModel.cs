namespace CVB.API.Models.ServicePck;

public class ServiceModel
{
    public Guid Id { get; set; }
    public bool IsActive { get; set; }
    public ServicePricingModel Pricing { get; set; }
    public ServiceFeatureModel Features { get; set; }
    public int ReviewCount { get; set; }
}