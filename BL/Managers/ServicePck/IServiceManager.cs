using CVB.BL.Domain.ServicePck;

namespace CVB.BL.Managers.ServicePck;

public interface IServiceManager
{
    public Service ReadService(Guid id);
    public void AddService(bool isActive, string name, string description, decimal basePrice, string billingType);
    public void ChangeService(bool isActive, string name, string description, decimal basePrice, string billingType);
    public void RemoveService(Guid id);
    public IEnumerable<Service> ReadServices();
}