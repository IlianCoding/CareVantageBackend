using CVB.BL.Domain.ReviewPck;
using CVB.BL.Domain.ServicePck;
using CVB.BL.Utils.UnitOfWorkPck;
using CVB.DAL.Repository.ServicePck;

namespace CVB.BL.Managers.ServicePck;

public class ServiceManager(IUnitOfWorkCareVantage unitOfWork, IServiceRepository repository) : IServiceManager
{
    public Service ReadService(Guid id)
    {
        throw new NotImplementedException();
    }

    public void AddService(bool isActive, string name, string description, decimal basePrice, string billingType)
    {
        try
        {
            unitOfWork.BeginTransaction();
            repository.CreateService(InitializingService(isActive, name, description, basePrice, billingType));
            unitOfWork.CommitTransaction();
        }
        catch (Exception e)
        {
            unitOfWork.RollbackTransaction();
            throw new ApplicationException("Er is een fout opgetreden bij het toevoegen van de service", e);
        }
    }

    public void ChangeService(bool isActive, string name, string description, decimal basePrice, string billingType)
    {
        throw new NotImplementedException();
    }

    public void RemoveService(Guid id)
    {
        unitOfWork.BeginTransaction();
        repository.DeleteServiceById(id);
        unitOfWork.CommitTransaction();
    }

    public IEnumerable<Service> ReadServices()
    {
        return repository.GetAllServices();
    }

    private Service InitializingService(bool isActive, string name, string description, decimal basePrice,
        string billingType)
    {
        if (!Enum.TryParse<BillingType>(billingType, out var billingTypeEnum))
        {
            throw new ArgumentException($"Ongeldige waarde voor BillingType: {billingType}");
        }
        
        return new Service
        {
            IsActive = isActive,
            Pricing = new ServicePricing
            {
                BasePrice = basePrice,
                BillingType = billingTypeEnum
            },
            Features = new ServiceFeature
            {
                Name = name,
                Description = description,
                PurchaseCount = 0,
                Rating = 0,
                CreatedAt = DateOnly.FromDateTime(DateTime.UtcNow),
                UpdatedAt = DateOnly.FromDateTime(DateTime.UtcNow)
            },
            Reviews = new List<Review>()
        };
    }
}