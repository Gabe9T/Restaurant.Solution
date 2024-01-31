using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Restaurant.Controllers
{
    public class DinersController : Controller 
    {
        private readonly RestaurantContext _db;
        public DinersController(RestaurantContext db)
        {
            _db = db;
        }

        public ActionResult Index()
        {
            List<Diner> model = _db.Diners.Include(diner => diner.Cuisine).ToList();
            return View(model);
        }

        public ActionResult Create(int id)
        {
            ViewBag.Cuisine = _db.Cuisines.FirstOrDefault(cuisine => cuisine.CuisineId == id);
            return View();
        }
        // Cuisine cuisine = new SelectList(_db.Cuisines, "CuisineId", "Name");
        [HttpPost]
        public ActionResult Create(Diner diner)
        {
            if (diner.DinerId == 0)
            {
                return RedirectToAction("Create");
            }
            _db.Diners.Add(diner);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}