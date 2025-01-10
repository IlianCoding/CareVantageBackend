using CVB.BL.Domain.PaymentPck.BillingInvoice;
using CVB.DAL.Context;
using Microsoft.EntityFrameworkCore;

namespace CVB.DAL.Repository.PaymentPck;

public class InvoiceRepository(CareVantageDbContext context) : IInvoiceRepository
{
    public Invoice GetInvoiceById(Guid id)
    {
        return context.Invoices
            .Include(d => d.Details)
            .SingleOrDefault();
    }

    public void UpdateInvoice(Invoice invoice)
    {
        context.Invoices.Update(invoice);
    }

    public void DeleteInvoiceById(Guid id)
    {
        Invoice invoice = GetInvoiceById(id);
        context.Invoices.Remove(invoice);
    }

    public IEnumerable<Invoice> GetAllInvoices()
    {
        return context.Invoices
            .Include(d => d.Details)
            .ToList();
    }
}