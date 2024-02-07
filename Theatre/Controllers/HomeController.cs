using Microsoft.AspNetCore.Mvc;
using Theatre.Models;
using System.Collections.Generic;
using System.Linq;

namespace Theatre.Controllers
{
  public class HomeController : Controller
  {
    private readonly TheatreContext _db;

    public HomeController(TheatreContext db)
    {
      _db = db;
    }

    [HttpGet("/")]
    public ActionResult Index()
    {
      Actor[] actors = _db.Actors.ToArray();
      Show[] shows = _db.Shows.ToArray();
      Genre[] genres = _db.Genres.ToArray();
      Dictionary<string, object[]> model = new Dictionary<string, object[]>();
      model.Add("actors", actors);
      model.Add("shows", shows);
      model.Add("genres", genres);
      return View(model);
    }
  }
}