using LevelUp.Practicum.API.DataAccess;
using LevelUp.Practicum.API.Models;

namespace LevelUp.Practicum.API.Services;

public sealed class VehicleService(TicketsDbContext context) : IVehicleService
{
    public Guid Create(string name, decimal ticketPrice)
    {
        if (ticketPrice < 0)
        {
            throw new ArgumentException();
        }

        var vehicle = new Vehicle(Guid.NewGuid(), name, ticketPrice);
        context.Vehicles.Add(vehicle);
        context.SaveChanges();

        return vehicle.Id;
    }
}