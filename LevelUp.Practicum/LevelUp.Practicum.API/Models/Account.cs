using System.Text.Json.Serialization;

namespace LevelUp.Practicum.API.Models;

public record Account(Guid Id, Guid OwnerId)
{
    
    public decimal Balance { get; set; }

    [JsonIgnore] 
    public Passenger? Owner { get; set; }
}