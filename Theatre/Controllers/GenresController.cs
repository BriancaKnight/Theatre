using Microsoft.AspNetCore.Mvc;
using Theatre.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Theatre.Controllers
{
public class GenresController: Controller
{
  private readonly TheatreContext _db;
  public GenresController(TheatreContext db)
  {
    _db = db;
  }
  public ActionResult Index()
  {
   return View(_db.Genres.ToList());
  }
}
}