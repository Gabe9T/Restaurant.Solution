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
            ViewBag.PageTitle = "View All Items";
            return View(model);
    
        }

        public ActionResult Create()
        {
            ViewBag.CuisineId = new SelectList(_db.Cuisines, "CuisineId", "Name");
            return View();
        }
 
        [HttpPost]
        public ActionResult Create(Diner diner)
        {
            if (diner.CuisineId == 0)
            {
                return RedirectToAction("Create");
            }
            _db.Diners.Add(diner);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            Diner thisDiner = _db.Diners.FirstOrDefault(diner => diner.DinerId == id);
            return View(thisDiner);
        }

        public ActionResult Edit(int id)
        {
            var thisDiner = _db.Diners.FirstOrDefault(diner => diner.DinerId == id);
            return View(thisDiner);
        }
        [HttpPost]
        public ActionResult Edit(Diner diner)
        {
            _db.Diners.Update(diner);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        
        public ActionResult Delete(int id)
        {
            var thisDiner = _db.Diners.FirstOrDefault(diner=> diner.DinerId == id);
            return View(thisDiner);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            var thisDiner = _db.Diners.FirstOrDefault(diner => diner.DinerId == id);
            _db.Diners.Remove(thisDiner);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

    [HttpPost]
    public ActionResult Search(Search searchTerm)
    {
        IQueryable<Diner> results = _db.Diners
            .Where(diner => diner.Name.Contains(searchTerm));
        return View(model);
    }
    }
}