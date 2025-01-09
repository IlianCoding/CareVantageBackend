namespace CVB.BL.Domain.Payment;

public enum PaymentStatus
{
    InProgress = 0,
    Paid = 1,
    Failed = 2,
    Canceled = 3,
    Refunded = 4,
    Unpaid = 5,
    Expired = 6
}