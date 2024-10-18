using System.Text.Json.Serialization;

namespace LevelUp.Practicum.API.Models;

public sealed record Ticket(Guid Id, Guid OwnerId)
{
    [JsonIgnore]
    public Passenger? Owner { get; set; }
}