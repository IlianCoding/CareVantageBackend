using CVB.BL.Domain.ServicePck;
using CVB.BL.Managers.ServicePck;
using Microsoft.AspNetCore.Mvc;

namespace CVB.API.Controllers.ServicePck;

[ApiController]
[Route("/api/[controller]")]
public class ServiceController(IServiceManager serviceManager) : ControllerBase
{
    [HttpGet("{id}")]
    public ActionResult<Service> GetService(Guid id)
    {
        Service service = serviceManager.ReadService(id);
        if (service == null)
        {
            return NotFound();
        }
        
        return Ok(service);
    }
    
    [HttpGet]
    public ActionResult<IEnumerable<Service>> GetServices()
    {
        IEnumerable<Service> services = serviceManager.ReadServices();
        if (!services.Any())
        {
            return NoContent();
        }

        return Ok(services);
    }
    
    [HttpGet("top-5-services")]
    public ActionResult<IEnumerable<Service>> GetTop5Services()
    {
        IEnumerable<Service> services = serviceManager.ReadServices();
        if (!services.Any())
        {
            return NoContent();
        }
        
        return Ok(services);
    }
}