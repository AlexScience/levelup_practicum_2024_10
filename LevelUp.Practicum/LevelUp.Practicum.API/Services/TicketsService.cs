using LevelUp.Practicum.API.DataAccess;
using LevelUp.Practicum.API.Models;

namespace LevelUp.Practicum.API.Services;

public sealed class TicketsService(TicketsDbContext context) : ITicketsService
{
    public Guid Create(Guid ownerId)
    {
        var passengerFound = context.Passengers.Any(p => p.Id == ownerId);
        if (!passengerFound)
        {
            throw new PassengerNotFoundException(ownerId);
        }

        var ticket = new Ticket(Guid.NewGuid(), ownerId);
        context.Tickets.Add(ticket);
        context.SaveChanges();

        return ticket.Id;
    }
}