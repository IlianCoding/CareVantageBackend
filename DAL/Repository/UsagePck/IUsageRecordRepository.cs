using CVB.BL.Domain.UsagePck;

namespace CVB.DAL.Repository.UsagePck;

public interface IUsageRecordRepository
{
    public UsageRecord GetUsageRecord(Guid id);
    public void CreateUsageRecord(UsageRecord usageRecord);
    public void UpdateUsageRecord(UsageRecord usageRecord);
    public void DeleteUsageRecordById(Guid id);
    public IEnumerable<UsageRecord> GetAllUsageRecords();
}