using LevelUp.Practicum.API.DataAccess;
using LevelUp.Practicum.API.Models;
using Microsoft.EntityFrameworkCore;

namespace LevelUp.Practicum.API.Services;

public sealed class PassengersService(TicketsDbContext context) : IPassengersService
{
    public Passenger? GetById(Guid id)
    {
        return context.Passengers
            .Include(p => p.Tickets)
            .FirstOrDefault(p => p.Id.Equals(id));
    }

    public Guid Create(string name)
    {
        var passenger = new Passenger(Guid.NewGuid(), name);
        context.Passengers.Add(passenger);
        context.SaveChanges();

        return passenger.Id;
    }
}