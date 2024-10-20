using LevelUp.Practicum.API.Models;
using LevelUp.Practicum.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace LevelUp.Practicum.API.Controllers;

[ApiController]
[Route("[controller]")]
public sealed class PassengersController(IPassengersService passengersService) : ControllerBase
{
    [HttpGet("/{id:guid}")]
    public ActionResult<Passenger> GetById(Guid id)
    {
        var passenger = passengersService.GetById(id);
        if (passenger == null)
        {
            return NotFound();
        }

        return Ok(passenger);
    }

    [HttpGet("/all")]
    public ActionResult<IEnumerable<Passenger>> GetAll()
    {
        var passengers = passengersService.GetAll();
        return Ok(passengers);
    }
    
    [HttpPost("/new")]
    public ActionResult<Guid> Create([FromBody]string name)
    {
        var guid = passengersService.Create(name);
        return Ok(guid);
    }
}