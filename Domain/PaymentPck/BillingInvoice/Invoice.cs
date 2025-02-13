﻿namespace CVB.BL.Domain.PaymentPck.BillingInvoice;

public class Invoice
{
    public Guid Id { get; set; }
    public Guid PaymentId { get; set; }
    
    public virtual required Payment Payment { get; set; }
    public virtual required InvoiceDetails Details { get; set; }
}