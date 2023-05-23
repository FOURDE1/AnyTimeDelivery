using DeliverySite.Models;
using Microsoft.EntityFrameworkCore;

namespace DeliverySite.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<RegisterApp> RegisterApps { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<TakenOrder> TakenOrders { get; set; }
}