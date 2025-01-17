using CVB.API.Models.ServicePck;
using CVB.BL.Managers.ServicePck;
using Microsoft.AspNetCore.Mvc;

namespace CVB.API.Controllers.ServicePck;

[ApiController]
[Route("api/[controller]")]
public class ServiceChangesController(IServiceManager serviceManager) : ControllerBase
{
    [HttpPost]
    public IActionResult AddNewService(ServiceModel service)
    {
        var newService = serviceManager.AddService(service.IsActive, service.Features.Name,
            service.Features.Description, service.Pricing.Price, service.Pricing.BillingType);
        if (newService == null)
        {
            return 
        }
        
        return Ok(newService);
    }
}