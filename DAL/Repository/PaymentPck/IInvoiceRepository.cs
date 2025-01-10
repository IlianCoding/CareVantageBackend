using CVB.BL.Domain.PaymentPck.BillingInvoice;

namespace CVB.DAL.Repository.PaymentPck;

public interface IInvoiceRepository
{
    public Invoice GetInvoiceById(Guid id);
    public void UpdateInvoice(Invoice invoice);
    public void DeleteInvoiceById(Guid id);
    public IEnumerable<Invoice> GetAllInvoices();
}