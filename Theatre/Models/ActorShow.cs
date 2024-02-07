namespace Theatre.Models
{
  public class ActorShow
  {
    public int ActorShowId { get; set; }
    public int ActorId { get; set; }
    public Actor Actor { get; set; }
    public int ShowId { get; set; }
    public Show Show { get; set; }
  }
}