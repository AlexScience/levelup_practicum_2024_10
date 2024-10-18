using LevelUp.Practicum.API.Models;

namespace LevelUp.Practicum.API.Services;

public interface IPassengersService
{
    Passenger? GetById(Guid id);
    Guid Create(string name);
}