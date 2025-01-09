namespace CVB.BL.Domain.Payment.BillingInvoice;

public class InvoiceDetails
{
    public Guid Id { get; set; }
    public Guid InvoiceId { get; set; }
    public required string InvoiceNumber { get; set; }
    public DateTime InvoiceDate { get; set; }
    public DateTime DueDate { get; set; }
    public decimal TotalAmount { get; set; }
    public InvoiceStatus Status { get; set; }
    
    public virtual required BillingInvoice.Invoice Invoice { get; set; }
}