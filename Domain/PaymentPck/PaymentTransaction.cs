namespace CVB.BL.Domain.PaymentPck;

public class PaymentTransaction
{
    public Guid Id { get; set; }
    public Guid PaymentId { get; set; }
    public required string TransactionId { get; set; }
    public Guid? RefundedPaymentId { get; set; }
    
    public virtual required PaymentPck.Payment Payment { get; set; }
}