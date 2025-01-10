namespace CVB.BL.Domain.PaymentPck;

public class PaymentMethod
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public required string Provider { get; set; }
    public bool IsActive { get; set; }
}