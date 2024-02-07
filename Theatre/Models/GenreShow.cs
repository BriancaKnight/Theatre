namespace Theatre.Models
{
  public class GenreShow
  {
    public int GenreShowId { get; set; }
    public int GenreId { get; set; }
    public int ShowId { get; set; }
    public Show Show { get; set; }
    public Genre Genre { get; set; }
  }
}