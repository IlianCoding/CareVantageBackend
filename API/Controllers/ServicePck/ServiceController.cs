using CVB.BL.Managers.ServicePck;
using Microsoft.AspNetCore.Mvc;

namespace CVB.API.Controllers.ServicePck;

[ApiController]
[Route("/api/controller")]
public class ServiceController : ControllerBase
{
    private readonly IServiceManager _serviceManager;
    public ActionResult GetServices()
    {
        
    }
}