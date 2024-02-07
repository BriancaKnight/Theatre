using System;
using System.Collections.Generic;

namespace Theatre.Models
{
  public class Show
  {
    public int ShowId { get; set; }
    public string ShowName { get; set; }
    public List<ActorShow> ActorShowJoinEntities { get; }
  }
}