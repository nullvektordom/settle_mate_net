using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SettleMate.Web.Data.Entities;

namespace SettleMate.Web.Data;

public class AppDbContext : IdentityDbContext<User, IdentityRole<Guid>, Guid>
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Household> Households => Set<Household>();
    public DbSet<HouseHoldMember> HouseHoldMembers => Set<HouseHoldMember>();
    public DbSet<Transaction> Transactions => Set<Transaction>();

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder); // required for identity tables

        // 1. HouseholdMembers (join table with extra data)
        builder.Entity<HouseHoldMember>()
            .HasKey(hm => new { hm.UserId, hm.HouseHoldId });

        builder.Entity<HouseHoldMember>()
            .Property(hm => hm.MonthlySalary).HasPrecision(10, 2);

        builder.Entity<HouseHoldMember>()
            .Property(hm => hm.SplitRatio).HasPrecision(5, 2);

        // 2. Transaction configuration
        builder.Entity<Transaction>(entity =>
        {
            entity.Property(e => e.Amount).HasPrecision(10, 2);
            entity.Property(e => e.Category).HasMaxLength(50);
            entity.Property(e => e.Description).HasMaxLength(500);
            entity.Property(e => e.RecieptPath).HasMaxLength(500);
            
            // Map JSON string to postgres jsonb for high-performance queries
            entity.Property(e => e.AppliedRatioJson).HasColumnType("jsonb");
            
            // Relationships
            entity.HasOne(e => e.Household)
                .WithMany(h => h.Transactions)
                .HasForeignKey(e => e.HouseHoldId);
            
            entity.HasOne(e => e.Payer)
                .WithMany()
                .HasForeignKey(e => e.PayerId)
                .OnDelete(DeleteBehavior.Restrict);
            
        });
    }
}