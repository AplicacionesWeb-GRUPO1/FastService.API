using FastService.API.Shared.Extensions;
using FastService.API.FastService.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace FastService.API.Shared.Persistence.Contexts;

public class AppDbContext : DbContext
{

    public DbSet<Client> Clients { get; set; }
    public DbSet<Publication> Publications { get; set; }
    
    public DbSet<Expert> Experts { get; set; }
    public DbSet<Contract> Contracts { get; set; }

    public DbSet<Gallery> Galleries { get; set; }

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
        builder.Entity<Client>().Property(p => p.Avatar).IsRequired().HasMaxLength(100);
        builder.Entity<Client>().Property(p => p.Role).IsRequired().HasMaxLength(10);

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
        builder.Entity<Publication>().Property(p => p.Description).HasMaxLength(300);
        builder.Entity<Publication>().Property(p => p.IsPublished).IsRequired().HasDefaultValue(true);
        builder.Entity<Publication>().Property(p => p.Image).IsRequired().HasMaxLength(100);


        // Relationships
        builder.Entity<Publication>()
            .HasMany(p => p.Contracts)
            .WithOne(p => p.Publication)
            .HasForeignKey(p => p.PublicationId);


        builder.Entity<Expert>().ToTable("Experts");
        builder.Entity<Expert>().HasKey(p => p.Id);
        builder.Entity<Expert>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Expert>().Property(p => p.Name).IsRequired().HasMaxLength(30);
        builder.Entity<Expert>().Property(p => p.LastName).IsRequired().HasMaxLength(50);
        builder.Entity<Expert>().Property(p => p.Phone).IsRequired().HasMaxLength(15);
        builder.Entity<Expert>().Property(p => p.BirthdayDate).IsRequired().HasMaxLength(10);
        builder.Entity<Expert>().Property(p => p.Money).IsRequired().HasMaxLength(13);
        builder.Entity<Expert>().Property(p => p.Rating).IsRequired().HasMaxLength(5);
        builder.Entity<Expert>().Property(p => p.Avatar).IsRequired().HasMaxLength(100);
        builder.Entity<Expert>().Property(p => p.Role).IsRequired().HasMaxLength(10);
        // Relationships
        builder.Entity<Expert>()
            .HasMany(p => p.Contracts)
            .WithOne(p => p.Expert)
            .HasForeignKey(p => p.ExpertId);

        builder.Entity<Contract>().ToTable("Contracts");
        builder.Entity<Contract>().HasKey(p => p.Id);
        builder.Entity<Contract>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Contract>().Property(p => p.Price).IsRequired().HasMaxLength(10);
        builder.Entity<Contract>().Property(p => p.Date).IsRequired().HasMaxLength(10);


        //Relationships
        builder.Entity <Expert>()
            .HasMany(p => p.Galleries)
            .WithOne(p => p.Expert)
            .HasForeignKey(p => p.ExpertId);



        builder.Entity<Gallery>().ToTable("Galleries");
        builder.Entity<Gallery>().HasKey(p => p.Id);
        builder.Entity<Gallery>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Gallery>().Property(p => p.ImgUrl).IsRequired().HasMaxLength(200);


        // Apply Snake Case Naming Convention

        builder.UseSnakeCaseNamingConvention();
    }
}