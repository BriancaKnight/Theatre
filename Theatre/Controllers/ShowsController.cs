using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Theatre.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System;


namespace Theatre.Controllers
{
 public class ShowsController : Controller
{
private readonly TheatreContext _db;


 public ShowsController(TheatreContext db)
   {
     _db = db;
   }


 public ActionResult Index()
 {
   List<Show> model = _db.Shows.ToList();
   return View(model);
 }

   public ActionResult Create()
  {
    return View();
  }

  [HttpPost]
  public ActionResult Create(Show show)
  {
   _db.Shows.Add(show);
   _db.SaveChanges();
   return RedirectToAction("Index");
  }
  
  public ActionResult Details(int id)
  {
    Show thisShow = _db.Shows
                        .Include(show => show.ActorShowJoinEntities)
                        .ThenInclude(join => join.Actor)
                        .FirstOrDefault(show => show.ShowId == id);
    return View(thisShow);
  }
  
    public ActionResult Edit(int id)
  {
    Show thisShow = _db.Shows.FirstOrDefault(show => show.ShowId == id);
    return View(thisShow);
  }

  [HttpPost]
  public ActionResult Edit(Show show)
  {
    _db.Shows.Update(show);
    _db.SaveChanges();
    return RedirectToAction("Index");
  }
  public ActionResult Delete(int id)
  {
    Show thisShow = _db.Shows.FirstOrDefault(show => show.ShowId == id);
    return View(thisShow);
  }  

  [HttpPost, ActionName("Delete")]
  public ActionResult DeleteConfirmed(int id)
  {
    Show thisShow = _db.Shows.FirstOrDefault(show => show.ShowId == id);
    _db.Shows.Remove(thisShow);
    _db.SaveChanges();
    return RedirectToAction("Index");
  }

    public ActionResult AddActor(int id)
  {
    Show thisShow = _db.Shows.FirstOrDefault(show => show.ShowId == id);
    ViewBag.ActorId = new SelectList(_db.Actors, "ActorId", "ActorName");
    return View(thisShow);
  }

  [HttpPost]
  public ActionResult AddActor(Show show, int actorId)
  {
    #nullable enable
    ActorShow? actorShowJoinEntity = _db.ActorShows.FirstOrDefault(join => (join.ActorId == actorId && join.ShowId == show.ShowId));
    #nullable disable
    if (actorShowJoinEntity == null && actorId != 0)
    {
      _db.ActorShows.Add(new ActorShow() { ActorId = actorId, ShowId = show.ShowId});
      _db.SaveChanges();
    }
    return RedirectToAction("Details", new { id = show.ShowId });
  }
  
  [HttpPost]
  public ActionResult DeleteJoin(int joinId)
  {
    ActorShow joinEntry = _db.ActorShows.FirstOrDefault(entry => entry.ActorShowId == joinId);
    _db.ActorShows.Remove(joinEntry);
    _db.SaveChanges();
    return RedirectToAction("Index");
  }
}
}