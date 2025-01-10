using CVB.BL.Domain.PaymentPck;
using CVB.DAL.Context;
using Microsoft.EntityFrameworkCore;

namespace CVB.DAL.Repository.PaymentPck;

public class PaymentRepository(CareVantageDbContext context) : IPaymentRepository
{
    public Payment GetPaymentById(Guid id)
    {
        return context.Payments
            .Include(d => d.Transaction)
            .Include(d => d.Details)
            .ThenInclude(m => m.PaymentMethod)
            .SingleOrDefault();
    }

    public void AddPayment(Payment payment)
    {
        context.Payments.Add(payment);
    }

    public void UpdatePayment(Payment payment)
    {
        context.Payments.Update(payment);
    }

    public void DeletePaymentById(Guid id)
    {
        Payment payment = GetPaymentById(id);
        context.Payments.Remove(payment);
    }

    public IEnumerable<Payment> GetAllPayments()
    {
        return context.Payments
            .Include(d => d.Transaction)
            .Include(d => d.Details)
            .ThenInclude(m => m.PaymentMethod)
            .ToList();
    }
}