using LevelUp.Practicum.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace LevelUp.Practicum.API.Controllers;

[ApiController]
[Route("[controller]")]
public sealed class TicketsController(ITicketsService ticketsService) : ControllerBase
{
    [HttpPost("/bind")]
    public ActionResult<Guid> Create([FromBody] Guid ownerId)
    {
        try
        {
            var guid = ticketsService.Create(ownerId);
            return Ok(guid);
        }
        catch (PassengerNotFoundException e)
        {
            return NotFound(e.Message);
        }
    }
}