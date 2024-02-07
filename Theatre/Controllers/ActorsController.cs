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



}
}
