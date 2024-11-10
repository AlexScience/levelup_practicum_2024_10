namespace LevelUp.Practicum.API.Models;

public sealed record Passenger(Guid Id, string Name)
{
    public ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();

    public ICollection<Account> Accounts { get; set; } = new List<Account>();
} 