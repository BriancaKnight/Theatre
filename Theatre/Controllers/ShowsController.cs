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
    Show thisShow = _db.Shows.FirstOrDefault(show => show.ShowId == id);
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

  
}
}