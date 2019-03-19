using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
//added
using chefsNdishes.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;


namespace chefsNdishes.Controllers
{
    public class HomeController : Controller
    {
        private Context dbContext;
        public HomeController(Context context)
        {
            dbContext = context;
        }

        // GET: /Home/
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            // Grabs all chefs table
            ViewModel Chefs = new ViewModel();
            Chefs.Chefs = dbContext.Chefs.Include(use => use.CreatedDish).ToList();
            // List<Chef> AllChefs = dbContext.Chefs.ToList();
            return View(Chefs);
        }

// =================================GET: NEW CHEF=======================
        [HttpGet("/new")]
        public IActionResult NewChef()
        {
            return View();
        }
// =================================POST: NEW CHEF=======================
        [HttpPost("/addchef")]
        public IActionResult addchef(Chef chef)
        {
            // If validation is true
            if(ModelState.IsValid)
            {
                dbContext.Add(chef);
                dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View("NewChef");
        }

// =================================GET ALL DISHES=======================
        [HttpGet("dishes")]
        public IActionResult Dishes()
        {
            // List of all dishes
            List<Dish> dishes = dbContext.Dishes.Include(use => use.Creator).ToList();
            return View(dishes);
        }

// =================================GET NEW DISHES=======================
        [HttpGet("/dish/new")]
        public IActionResult NewDish()
        {
            //creating new chef model
            ViewModel chefs = new ViewModel();
            chefs.Chefs = dbContext.Chefs.ToList();
            // chefs.Dish = new Dish();
            return View(chefs);
        }

        [HttpPost("dish/new")]
        public IActionResult CreateDish(Dish dishe)
        {
            // If validation is true
            if(ModelState.IsValid)
            {
                dbContext.Dishes.Add(dishe);
                dbContext.SaveChanges();
                return RedirectToAction("Dishes");
            }
            ViewModel chefs = new ViewModel();
            chefs.Chefs = dbContext.Chefs.ToList();
            // chefs.dish = new Dish();
            return View("NewDish", chefs);
        }

    }
}
