using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FoodMenu.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FoodMenu.Controllers
{
    public class FoodController : Controller
    {
        private DataContext _context;
        public FoodController(DataContext context)
        {
            _context = context;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View(_context.Foods);
        }

        public IActionResult Create()
        {
            return View("FoodEditor");
        }

        public IActionResult Edit(int id)
        {
            return View("FoodEditor",
                _context
                    .Foods
                    .FirstOrDefault(i => i.FoodId == id));
        }

        [HttpPost]
        public IActionResult Edit(Food entity)
        {
            if (entity.FoodId == 0)
            {
                _context.Foods.Add(entity);
            }
            else
            {
                _context.Foods.Update(entity);
            }
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        //[HttpPost]
        public IActionResult Delete(int id)
        {
            var entity = _context.Foods.FirstOrDefault(i => i.FoodId == id);
            _context.Foods.Remove(entity);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
