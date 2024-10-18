using LevelUp.Practicum.API.DataAccess.Configurations;
using LevelUp.Practicum.API.Models;
using Microsoft.EntityFrameworkCore;

namespace LevelUp.Practicum.API.DataAccess;

public class TicketsDbContext : DbContext
{
    public DbSet<Passenger> Passengers { get; set; } = default!;
    public DbSet<Ticket> Tickets { get; set; } = default!;

    public TicketsDbContext(DbContextOptions ops) : base(ops)
    {
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new PassengersConfiguration());
        modelBuilder.ApplyConfiguration(new TicketConfiguration());
    }
}