using CVB.BL.Domain.ServicePck;
using CVB.DAL.Context;
using Microsoft.EntityFrameworkCore;

namespace CVB.DAL.Repository.ServicePck;

public class ServiceRepository(CareVantageDbContext context) : IServiceRepository
{
    public Service GetServiceById(Guid id)
    {
        return context.Services
            .Include(d => d.Pricing)
            .Include(f => f.Features)
            .SingleOrDefault();
    }

    public void CreateService(Service service)
    {
        context.Services.Add(service);
    }

    public void UpdateService(Service service)
    {
        context.Services.Update(service);
    }

    public void DeleteServiceById(Guid id)
    {
        Service service = GetServiceById(id);
        context.Services.Remove(service);
    }

    public IEnumerable<Service> GetTop5ActiveServices()
    {
        return context.Services
            .Include(d => d.Pricing)
            .Include(f => f.Features)
            .Where(s => s.IsActive)
            .OrderByDescending(s => s.Features.PurchaseCount)
            .Take(5)
            .ToList();
    }

    public IEnumerable<Service> GetAllServices()
    {
        return context.Services
            .Include(d => d.Pricing)
            .Include(f => f.Features)
            .ToList();
    }
}