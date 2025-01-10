namespace CVB.BL.Domain.Usage;

public class UsageMetrics
{
    public Guid Id { get; set; }
    public Guid UsageRecordId { get; set; }
    public int UsageCount { get; set; }
    public string? MetricType { get; set; }
    
    public virtual required UsageRecord UsageRecord { get; set; }
}