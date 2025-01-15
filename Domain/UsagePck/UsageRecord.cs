namespace CVB.BL.Domain.UsagePck;

public class UsageRecord
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public Guid ServiceId { get; set; }
    public DateTime UsageDate { get; set; }
    
    public virtual required UsageMetrics Metrics { get; set; }
}