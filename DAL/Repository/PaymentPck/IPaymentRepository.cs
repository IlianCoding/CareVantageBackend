using CVB.BL.Domain.PaymentPck;

namespace CVB.DAL.Repository.PaymentPck;

public interface IPaymentRepository
{
    public Payment GetPaymentById(Guid id);
    public void AddPayment(Payment payment);
    public void UpdatePayment(Payment payment);
    public void DeletePaymentById(Guid id);
    public IEnumerable<Payment> GetAllPayments();
}