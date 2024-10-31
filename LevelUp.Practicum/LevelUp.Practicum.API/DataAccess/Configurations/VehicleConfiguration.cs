using LevelUp.Practicum.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LevelUp.Practicum.API.DataAccess.Configurations;

public class VehicleConfiguration : IEntityTypeConfiguration<Vehicle>
{
    public void Configure(EntityTypeBuilder<Vehicle> builder)
    {
        builder.ToTable("vehicle");

        builder.HasKey(v => v.Id);
        builder.Property(v => v.Name)
            .HasColumnType("text")
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(v => v.TicketPrice)
            .HasColumnType("decimal(18,2)")
            .IsRequired();
    }
}