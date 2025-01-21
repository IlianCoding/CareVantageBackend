using CVB.API.DTOs.ServicePck;
using CVB.API.Models.ServicePck;
using CVB.BL.Managers.ServicePck;
using Microsoft.AspNetCore.Mvc;

namespace CVB.API.Controllers.ServicePck;

[ApiController]
[Route("api/[controller]")]
public class ServiceChangesController(IServiceManager serviceManager) : ControllerBase
{
    [HttpPost("add-service")]
    public IActionResult AddNewService(AddServiceDto serviceAddRequest)
    {
        if (!ModelState.IsValid) 
            return BadRequest(ModelState);
        
        var serviceResult = serviceManager.AddService(serviceAddRequest.IsActive, serviceAddRequest.Name,
            serviceAddRequest.Description, serviceAddRequest.Price, serviceAddRequest.BillingType);
        
        var serviceDto = new ServiceDto
        {
            Id = serviceResult.Id,
            IsActive = serviceResult.IsActive,
            Name = serviceResult.Features.Name,
            Description = serviceResult.Features.Description,
            Price = serviceResult.Pricing.BasePrice,
            BillingType = serviceResult.Pricing.BillingType.ToString()
        };

        return CreatedAtAction(
            actionName: "GetService",
            controllerName: "Service",
            routeValues: new { id = serviceDto.Id },
            value: serviceDto);
    }
    
    [HttpPut("change-service")]
    public IActionResult ChangeService(ChangeServiceDto serviceChangeRequest)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        
        serviceManager.ChangeService(serviceChangeRequest.Id, serviceChangeRequest.IsActive, serviceChangeRequest.Name,
            serviceChangeRequest.Description, serviceChangeRequest.Price, serviceChangeRequest.BillingType);

        return NoContent();
    }
}