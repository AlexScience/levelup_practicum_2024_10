using LevelUp.Practicum.API.CustomExceptions;
using LevelUp.Practicum.API.Models;
using LevelUp.Practicum.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace LevelUp.Practicum.API.Controllers;

[ApiController]
[Route("[controller]")]
public sealed class AccountController(IAccountService accountService) : ControllerBase
{
    [HttpPost("/create")]
    public ActionResult<Guid> Create([FromBody] Guid ownerId)
    {
        try
        {
            var guid = accountService.Create(ownerId);
            return Ok(guid);
        }
        catch (PassengerNotFoundException e)
        {
            return NotFound(e.Message);
        }
        
    }

    [HttpGet("/GetAll")]
    public ActionResult<IEnumerable<Account>> GetAll()
    {
        var accounts = accountService.GetAll();

        return Ok(accounts);
    }
    
    [HttpPost("topup/{accountId}")]
    public IActionResult TopUpAccount(Guid accountId, decimal amount)
    {
        if (amount <= 0)
        {
            return BadRequest("Сумма пополнения должна быть больше нуля.");
        }
        
        var result = accountService.TopUpAccount(accountId, amount);
        
        return Ok(result.Message);
    }

}