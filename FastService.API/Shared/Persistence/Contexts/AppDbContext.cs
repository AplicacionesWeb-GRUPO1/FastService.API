using FastService.API.Shared.Extensions;
using FastService.API.FastService.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace FastService.API.Shared.Persistence.Contexts;

public class AppDbContext : DbContext
{

    public DbSet<Client> Clients { get; set; }
    public DbSet<Publication> Publications { get; set; }

    public AppDbContext(DbContextOptions options) : base(options)
    {
    }


    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<Client>().ToTable("Clients");
        builder.Entity<Client>().HasKey(p => p.Id);
        builder.Entity<Client>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Client>().Property(p => p.Name).IsRequired().HasMaxLength(30);
        builder.Entity<Client>().Property(p => p.LastName).IsRequired().HasMaxLength(30);
        builder.Entity<Client>().Property(p => p.Phone).IsRequired().HasMaxLength(15);
        builder.Entity<Client>().Property(p => p.BirthdayDate).IsRequired().HasMaxLength(10);
        builder.Entity<Client>().Property(p => p.Money).IsRequired().HasMaxLength(13);

        // Relationships
        builder.Entity<Client>()
            .HasMany(p => p.Publications)
            .WithOne(p => p.Client)
            .HasForeignKey(p => p.ClientId);

        builder.Entity<Publication>().ToTable("Publications");
        builder.Entity<Publication>().HasKey(p => p.Id);
        builder.Entity<Publication>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Publication>().Property(p => p.Address).IsRequired().HasMaxLength(50);
        builder.Entity<Publication>().Property(p => p.Title).IsRequired().HasMaxLength(50);
        builder.Entity<Publication>().Property(p => p.Description).HasMaxLength(120);
        // isPublished is set to true by default
        builder.Entity<Publication>().Property(p => p.IsPublished).IsRequired().HasDefaultValue(true);
        // Apply Snake Case Naming Convention

        builder.UseSnakeCaseNamingConvention();
    }
}