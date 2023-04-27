using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CRUDelicious.Models;

namespace CRUDelicious.Controllers
{
    public class HomeController : Controller
    {
        private DeliciousContext dbContext;
        public HomeController(DeliciousContext context)
        {
            dbContext = context;
        }
		[HttpGet("")]
        public IActionResult Index()
        {
            return View(dbContext.Dishes.OrderByDescending(d => d.CreatedAt));
        }
        [HttpGet("new")]
        public IActionResult New() => View();
        
        [HttpGet("{dishId}")]
        public IActionResult Show(int dishId)
        {
            Dish model = dbContext.Dishes.FirstOrDefault(d => d.DishId == dishId);
            if(model == null)
                return RedirectToAction("Index");
            return View(model);
        }

        [HttpGet("{dishId}/edit")]
        public IActionResult Edit(int dishId)
        {
            Dish model = dbContext.Dishes.FirstOrDefault(d => d.DishId == dishId);
            if(model == null)
                return RedirectToAction("Index");
            return View(model);
        }

        [HttpPost("create")]
        public IActionResult Create(Dish newDish)
        {
            if(ModelState.IsValid)
            {
                dbContext.Dishes.Add(newDish);
                dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View("New");
        }

        [HttpPost("{dishId}/update")]
        public IActionResult Update(Dish dish, int dishId)
        {
            Dish toUpdate = dbContext.Dishes.FirstOrDefault(d => d.DishId == dishId);
            if(ModelState.IsValid)
            {
                toUpdate.Name = dish.Name;
                toUpdate.Chef = dish.Chef;
                toUpdate.Tastiness = dish.Tastiness;
                toUpdate.Calories = dish.Calories;
                toUpdate.Description = dish.Description;
                toUpdate.UpdatedAt = DateTime.Now;
                dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View("Edit", dish);
        }
        
        [HttpGet("{dishId}/delete")]
        public IActionResult Delete(int dishId)
        {
            Dish toDelete = dbContext.Dishes.FirstOrDefault(d => d.DishId == dishId);
            if(toDelete == null)
                return RedirectToAction("Index");
            dbContext.Dishes.Remove(toDelete);
            dbContext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}s