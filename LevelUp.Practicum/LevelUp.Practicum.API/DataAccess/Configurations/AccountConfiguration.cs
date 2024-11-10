using LevelUp.Practicum.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LevelUp.Practicum.API.DataAccess.Configurations;

public sealed class AccountConfiguration : IEntityTypeConfiguration<Account>
{
    public void Configure(EntityTypeBuilder<Account> builder)
    {
        builder.ToTable("account");

        builder.HasKey(a => a.Id);
        builder.Property(a => a.OwnerId)
            .HasColumnType("uuid")
            .IsRequired();
        builder.Property(a => a.Balance)
            .HasColumnType("decimal(18,2)");
        
        builder.HasOne<Passenger>(a => a.Owner)
            .WithMany(a => a.Accounts)
            .HasForeignKey(t => t.OwnerId);
    }
}