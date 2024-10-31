using System.Text.Json.Serialization;

namespace LevelUp.Practicum.API.Models;

public sealed record Ticket(Guid Id, Guid OwnerId,Guid VehicleId)
{
    [JsonIgnore] public Passenger? Owner { get; set; }
    [JsonIgnore] public Vehicle? Vehicle { get; set; }
    public decimal Price { get; set; }
}