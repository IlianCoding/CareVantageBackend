﻿using CVB.BL.Domain.Payment.BillingInvoice;

namespace CVB.BL.Domain.Payment;

public class Payment
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public PaymentStatus Status { get; set; }
    
    public virtual required PaymentDetails Details { get; set; }
    public virtual required PaymentTransaction Transaction { get; set; }
    public virtual required Invoice Invoice { get; set; }
}