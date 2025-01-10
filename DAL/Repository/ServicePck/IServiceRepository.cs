using CVB.BL.Domain.ServicePck;

namespace CVB.DAL.Repository.ServicePck;

public interface IServiceRepository
{
    public Service GetServiceById(Guid id);
    public void CreateService(Service service);
    public void UpdateService(Service service);
    public void DeleteServiceById(Guid id);
    public IEnumerable<Service> GetAllServices();
}