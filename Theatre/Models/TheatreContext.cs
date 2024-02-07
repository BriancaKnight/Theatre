using Microsoft.EntityFrameworkCore;

namespace Theatre.Models
{
  public class TheatreContext: DbContext
  {
    public DbSet<Actor> Actors { get; set; }
    public DbSet<Show> Shows { get; set; }

    public TheatreContext(DbContextOptions options) : base (options) {}
  }
}