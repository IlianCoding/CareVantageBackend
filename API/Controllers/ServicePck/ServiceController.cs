using CVB.API.DTOs.ServicePck;
using CVB.BL.Domain.ServicePck;
using CVB.BL.Managers.ServicePck;
using Microsoft.AspNetCore.Mvc;

namespace CVB.API.Controllers.ServicePck;

[ApiController]
[Route("/api/[controller]")]
public class ServiceController(IServiceManager serviceManager) : ControllerBase
{
    [HttpGet("{id}")]
    public ActionResult<ServiceDto> GetService(Guid id)
    {
        Service service = serviceManager.ReadService(id);
        
        if (service == null)
        {
            return NotFound();
        }

        var serviceDto = new ServiceDto
        {
            Id = service.Id,
            IsActive = service.IsActive,
            Name = service.Features.Name,
            Description = service.Features.Description,
            Price = service.Pricing.BasePrice,
            BillingType = service.Pricing.BillingType.ToString()
        };
        
        return Ok(serviceDto);
    }
    
    [HttpGet]
    public ActionResult<IEnumerable<ServiceDto>> GetServices()
    {
        ICollection<Service> services = serviceManager.ReadServices().ToList();
        
        if (!services.Any())
        {
            return NoContent();
        }

        var serviceDtos = services.Select(service => new ServiceDto
        {
            Id = service.Id,
            IsActive = service.IsActive,
            Name = service.Features.Name,
            Description = service.Features.Description,
            Price = service.Pricing.BasePrice,
            BillingType = service.Pricing.BillingType.ToString()
        });

        return Ok(serviceDtos);
    }
    
    [HttpGet("top-5-services")]
    public ActionResult<IEnumerable<ServiceDto>> GetTop5Services()
    {
        ICollection<Service> services = serviceManager.ReadTop5ActiveServices().ToList();
        
        if (!services.Any())
        {
            return NoContent();
        }

        var top5Services = services.Select(service => new ServiceDto
        {
            Id = service.Id,
            IsActive = service.IsActive,
            Name = service.Features.Name,
            Description = service.Features.Description,
            Price = service.Pricing.BasePrice,
            BillingType = service.Pricing.BillingType.ToString()
        });
        
        return Ok(top5Services);
    }
}