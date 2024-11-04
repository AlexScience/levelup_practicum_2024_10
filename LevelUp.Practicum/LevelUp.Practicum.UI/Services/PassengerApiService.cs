using LevelUp.Practicum.API.Models;

namespace LevelUp.Practicum.UI.Services;

public class PassengerApiService(HttpClient httpClient) : IPassengersApiService
{
    public async Task<Passenger?> GetByIdAsync(Guid id)
    {
        return await httpClient.GetFromJsonAsync<Passenger>($"/passengers/{id}");
    }

    public async Task<IEnumerable<Passenger>?> GetAllAsync()
    {
        return await httpClient.GetFromJsonAsync<IEnumerable<Passenger>>("/passengers/all");
    }

    public async Task<Guid> CreateAsync(string name)
    {
        var response = await httpClient.PostAsJsonAsync("/passengers/new", name);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<Guid>();
    }
}