﻿namespace CVB.BL.Domain.Payment.BillingInvoice;

public enum InvoiceStatus
{
    Draft = 0,
    Issued = 1,
    Paid = 2,
    Overdue = 3,
    Cancelled = 4
}