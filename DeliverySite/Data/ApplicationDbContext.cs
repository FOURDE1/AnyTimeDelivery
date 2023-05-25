using DeliverySite.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DeliverySite.Data;

public class ApplicationDbContext : IdentityDbContext<RegisterApp>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<RegisterApp> RegisterApps { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<TakenOrder> TakenOrders { get; set; }

    protected override void OnModelCreating(
        ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<RegisterApp>().HasData(
            new RegisterApp
            {
                Id = 1,
                UserName = "fourde",
                Password = "HossienRaad@3",

            });
    }
}