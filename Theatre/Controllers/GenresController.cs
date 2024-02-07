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
  
  public ActionResult Create()
  {
    return View();
  }
  
  [HttpPost]
  public ActionResult Create(Genre genre)
  {
    _db.Genres.Add(genre);
    _db.SaveChanges();
    return RedirectToAction("Index");
  }
}
}