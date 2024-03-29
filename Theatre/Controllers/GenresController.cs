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

  public ActionResult Details(int id)
  {
    Genre thisGenre = _db.Genres
                          .Include(genre => genre.GenreShowJoinEntities)
                          .ThenInclude(join => join.Show)
                          .FirstOrDefault(genre => genre.GenreId == id);
    return View(thisGenre);
  }

  public ActionResult AddShow(int id)
  {
    Genre thisGenre = _db.Genres.FirstOrDefault(genres => genres.GenreId == id);
    ViewBag.ShowId = new SelectList(_db.Shows, "ShowId", "ShowName");
    return View(thisGenre);
  }

  [HttpPost]
  public ActionResult AddShow(Genre genre, int showId)
  {
    #nullable enable
    GenreShow? joinEntity = _db.GenreShows.FirstOrDefault(join => (join.ShowId == showId && join.GenreId == genre.GenreId));
    #nullable disable
    if (joinEntity == null && showId !=0)
    {
      _db.GenreShows.Add(new GenreShow() {ShowId = showId, GenreId = genre.GenreId });
      _db.SaveChanges();
    }
    return RedirectToAction("Details", new { id = genre.GenreId });
  }
  
  public ActionResult Edit(int id)
  {
    Genre thisGenre = _db.Genres.FirstOrDefault(genres => genres.GenreId == id);
    return View(thisGenre);
  }

  [HttpPost]
  public ActionResult Edit(Genre genre)
  {
    _db.Genres.Update(genre);
    _db.SaveChanges();
    return RedirectToAction("Index");
  }

  public ActionResult Delete(int id)
  {
    Genre thisGenre = _db.Genres.FirstOrDefault(genres => genres.GenreId == id);
    return View(thisGenre);
  }

  [HttpPost, ActionName("Delete")]
  public ActionResult DeleteConfirmed(int id)
  {
    Genre thisGenre = _db.Genres.FirstOrDefault(genres => genres.GenreId == id);
    _db.Genres.Remove(thisGenre);
    _db.SaveChanges();
    return RedirectToAction("Index");
  }
  
  [HttpPost]
  public ActionResult GenreDeleteJoin(int joinId)
  {
    GenreShow joinEntry = _db.GenreShows.FirstOrDefault(entry => entry.GenreShowId == joinId);
    _db.GenreShows.Remove(joinEntry);
    _db.SaveChanges();
    return RedirectToAction("Index");
  }
}
}