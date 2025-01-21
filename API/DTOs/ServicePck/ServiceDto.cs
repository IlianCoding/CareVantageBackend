namespace CVB.API.DTOs.ServicePck;

public class ServiceDto
{
    public Guid Id { get; set; }
    public bool IsActive { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public string BillingType { get; set; }
}