namespace CVB.BL.Domain.Service;

public class ServiceFeature
{
    public Guid Id { get; set; }
    public Guid ServiceId { get; set; }
    public required string Name { get; set; }
    public required string Description { get; set; }
    
    public virtual required Service Service { get; set; }
}