using LevelUp.Practicum.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace LevelUp.Practicum.API.Controllers;

[ApiController]
[Route("[controller]")]
public sealed class VehicleController(IVehicleService vehicleService) : ControllerBase
{
    [HttpPost("new")]
    public ActionResult<Guid> Create([FromBody] string name, decimal ticketPrice)
    {
        var guid = vehicleService.Create(name, ticketPrice);
        return Ok(guid);
    }
}