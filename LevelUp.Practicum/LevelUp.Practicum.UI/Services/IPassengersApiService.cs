using LevelUp.Practicum.API.Models;

namespace LevelUp.Practicum.UI.Services;

public interface IPassengersApiService
{
    Task<Passenger?> GetByIdAsync(Guid id);
    Task<IEnumerable<Passenger>?> GetAllAsync();
    Task<Guid> CreateAsync(string name);
}