using System;
using System.Collections.Generic;

namespace Theatre.Models
{
  public class Actor
  {
    public int ActorId { get; set; }
    public string ActorName { get; set; }
    public List <ActorShow> ActorShowJoinEntities { get; }
  }
}