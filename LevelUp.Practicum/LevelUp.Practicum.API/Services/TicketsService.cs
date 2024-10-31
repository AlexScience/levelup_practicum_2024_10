using LevelUp.Practicum.API.CustomExceptions;
using LevelUp.Practicum.API.DataAccess;
using LevelUp.Practicum.API.Models;
using Microsoft.EntityFrameworkCore;

namespace LevelUp.Practicum.API.Services;

public sealed class TicketsService(TicketsDbContext context) : ITicketsService
{
    public Guid Create(Guid ownerId, Guid vehicleId)
    {
        var passenger = context.Passengers.Include(p => p.Accounts).FirstOrDefault(p => p.Id == ownerId);
        if (passenger == null)
        {
            throw new PassengerNotFoundException(ownerId);
        }

        var vehicle = context.Vehicles.Find(vehicleId);
        if (vehicle == null)
        {
            throw new VehicleNotFoundException(vehicleId);
        }
        
        var account = passenger.Accounts.FirstOrDefault();
        if (account == null)
        {
            throw new AccountNotFoundException();
        }
        
        if (account.Balance < vehicle.TicketPrice)
        {
            throw new InvalidOperationException("Недостаточно средств на счёте.");
        }
        
        account.Balance -= vehicle.TicketPrice;
        
        var ticket = new Ticket(Guid.NewGuid(), ownerId, vehicleId)
        {
            Price = vehicle.TicketPrice
            
        };

        context.Tickets.Add(ticket);
        context.Accounts.Update(account);
        context.SaveChanges();

        return ticket.Id;
    }
    
}