using CVB.BL.Domain.UsagePck;
using CVB.DAL.Context;
using Microsoft.EntityFrameworkCore;

namespace CVB.DAL.Repository.UsagePck;

public class UsageRecordRepository(CareVantageDbContext context) : IUsageRecordRepository
{
    public UsageRecord GetUsageRecord(Guid id)
    {
        return context.UsageRecords
            .Include(m => m.Metrics)
            .SingleOrDefault();
    }

    public void CreateUsageRecord(UsageRecord usageRecord)
    {
        context.UsageRecords.Add(usageRecord);
    }

    public void UpdateUsageRecord(UsageRecord usageRecord)
    {
        context.UsageRecords.Update(usageRecord);
    }

    public void DeleteUsageRecordById(Guid id)
    {
        UsageRecord usageRecord = GetUsageRecord(id);
        context.UsageRecords.Remove(usageRecord);
    }

    public IEnumerable<UsageRecord> GetAllUsageRecords()
    {
        return context.UsageRecords
            .Include(m => m.Metrics)
            .ToList();
    }
}