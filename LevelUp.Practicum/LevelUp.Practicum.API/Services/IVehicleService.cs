namespace LevelUp.Practicum.API.Services;

public interface IVehicleService
{
    Guid Create(string name, decimal ticketPrice);
}