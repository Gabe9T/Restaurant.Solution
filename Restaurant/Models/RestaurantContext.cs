using Microsoft.EntityFrameworkCore;

namespace Restaurant.Models
{
  public class RestaurantContext : DbContext
  {
    public DbSet<Cuisine> Cuisines { get; set; }
    // public DbSet<Item> Items { get; set; }

    public RestaurantContext(DbContextOptions options) : base(options) { }
  }
}