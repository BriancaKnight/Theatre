using System.Collections.Generic;

namespace Theatre.Models
{
  public class Genre
  {
    public int GenreId { get; set; }
    public string GenreName { get; set; }
    public List<GenreShow> GenreShowJoinEntities { get; }
  }
}