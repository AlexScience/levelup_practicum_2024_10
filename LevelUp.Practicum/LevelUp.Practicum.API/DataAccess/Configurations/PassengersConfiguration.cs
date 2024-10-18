using LevelUp.Practicum.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LevelUp.Practicum.API.DataAccess.Configurations;

public sealed class PassengersConfiguration : IEntityTypeConfiguration<Passenger>
{
    public void Configure(EntityTypeBuilder<Passenger> builder)
    {
        builder.ToTable("passengers");

        builder.HasKey(p => p.Id);
        builder.Property(p => p.Name)
            .HasColumnType("text")
            .HasMaxLength(100)
            .IsRequired();
    }
}