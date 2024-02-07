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
}
}