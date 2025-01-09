namespace CVB.BL.Domain.Payment;

public class PaymentTransaction
{
    public Guid Id { get; set; }
    public Guid PaymentId { get; set; }
    public required string TransactionId { get; set; }
    public Guid? RefundedPaymentId { get; set; }
    
    public virtual required Payment Payment { get; set; }
}