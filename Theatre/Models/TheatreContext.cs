using Microsoft.EntityFrameworkCore;

namespace Theatre.Models
{
  public class TheatreContext: DbContext
  {
    public DbSet<Actor> Actors { get; set; }
    public DbSet<Show> Shows { get; set; }
    public DbSet<ActorShow> ActorShows { get; set; }
    public DbSet<Genre> Genres { get; set; }
    public DbSet<GenreShow> GenreShows { get; set; }

    public TheatreContext(DbContextOptions options) : base (options) { }
  }
}