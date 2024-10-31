using LevelUp.Practicum.API.DataAccess;
using LevelUp.Practicum.API.Models;

namespace LevelUp.Practicum.API.Services;

public sealed class TicketsService(TicketsDbContext context) : ITicketsService
{
    public Guid Create(Guid ownerId, Guid vehicleId)
    {
        var passenger = context.Passengers.Find(ownerId);
        if (passenger == null)
        {
            throw new PassengerNotFoundException(ownerId);
        }

        var vehicle = context.Vehicles.Find(vehicleId);
        if (vehicle == null)
        {
            throw new VehicleNotFoundException(vehicleId);
        }

        var ticket = new Ticket(Guid.NewGuid(), ownerId, vehicleId)
        {
            Price = vehicle.TicketPrice
        };

        context.Tickets.Add(ticket);
        context.SaveChanges();

        return ticket.Id;
    }
    
}