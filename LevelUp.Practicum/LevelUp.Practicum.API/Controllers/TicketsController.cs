using LevelUp.Practicum.API.CustomExceptions;
using LevelUp.Practicum.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace LevelUp.Practicum.API.Controllers;

[ApiController]
[Route("[controller]")]
public sealed class TicketsController(ITicketsService ticketsService) : ControllerBase
{
    [HttpPost("bind")]
    public ActionResult<Guid> Create( Guid ownerId, Guid vehicleId)
    {
        try
        {
            var ticketId = ticketsService.Create(ownerId, vehicleId);
            return Ok(ticketId);
        }
        catch (PassengerNotFoundException e)
        {
            return NotFound(e.Message);
        }
        catch (VehicleNotFoundException e)
        {
            return NotFound(e.Message);
        }
    }
}