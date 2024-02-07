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
 public class ActorsController : Controller
{
private readonly TheatreContext _db;


 public ActorsController(TheatreContext db)
   {
     _db = db;
   }


 public ActionResult Index()
 {
   List<Actor> model = _db.Actors.ToList();
   return View(model);
 }

  public ActionResult Create()
  {
    return View();
  }

  [HttpPost]
  public ActionResult Create(Actor actor)
  {
   _db.Actors.Add(actor);
   _db.SaveChanges();
   return RedirectToAction("Index");
  }

  public ActionResult Details(int id)
  {
    Actor thisActor = _db.Actors
                            .Include(actor => actor.ActorShowJoinEntities)
                            .ThenInclude(join => join.Show)
                            .FirstOrDefault(actor => actor.ActorId == id);
    return View(thisActor);
  }
  
  public ActionResult Edit(int id)
  {
    Actor thisActor = _db.Actors.FirstOrDefault(actor => actor.ActorId == id);
    return View(thisActor);
  }

  [HttpPost]
  public ActionResult Edit(Actor actor)
  {
    _db.Actors.Update(actor);
    _db.SaveChanges();
    return RedirectToAction("Index");
  }

  public ActionResult Delete(int id)
  {
    Actor thisActor = _db.Actors.FirstOrDefault(actor => actor.ActorId == id);
    return View(thisActor);
  }  

  [HttpPost, ActionName("Delete")]
  public ActionResult DeleteConfirmed(int id)
  {
    Actor thisActor = _db.Actors.FirstOrDefault(actor => actor.ActorId == id);
    _db.Actors.Remove(thisActor);
    _db.SaveChanges();
    return RedirectToAction("Index");
  }

  public ActionResult AddShow(int id)
  {
    Actor thisActor = _db.Actors.FirstOrDefault(actor => actor.ActorId == id);
    ViewBag.ShowId = new SelectList(_db.Shows, "ShowId", "ShowName");
    return View(thisActor);
  }

  [HttpPost]
  public ActionResult AddShow(Actor actor, int showId)
  {
    #nullable enable
    ActorShow? actorShowJoinEntity = _db.ActorShows.FirstOrDefault(join => (join.ShowId == showId && join.ActorId == actor.ActorId));
    #nullable disable
    if (actorShowJoinEntity == null && showId != 0)
    {
      _db.ActorShows.Add(new ActorShow() { ShowId = showId, ActorId = actor.ActorId});
      _db.SaveChanges();
    }
    return RedirectToAction("Details", new { id = actor.ActorId });
  }
}
}
