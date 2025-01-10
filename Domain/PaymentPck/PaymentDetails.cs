namespace CVB.BL.Domain.PaymentPck;

public class PaymentDetails
{
    public Guid Id { get; set; }
    public Guid PaymentId { get; set; }
    public decimal Amount { get; set; }
    public DateTime PaymentDate { get; set; }
    public Guid PaymentMethodId { get; set; }
    
    public virtual required Payment Payment { get; set; }
    public virtual required PaymentMethod PaymentMethod { get; set; }
}