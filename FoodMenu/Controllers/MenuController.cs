using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FoodMenu.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FoodMenu.Controllers
{
    public class MenuController : Controller
    {
        private DataContext _context;
        public MenuController(DataContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var model = _context
                .Menus
                .Include(i => i.FoodMenus)
                .ThenInclude(i => i.Food)
                .ToList();

            return View(model);
        }

        public IActionResult Create()
        {
            return View("MenuDateEditor");
        }

        public IActionResult Edit(int id)
        {
            return View("MenuDateEditor",
                _context
                    .Menus
                    .FirstOrDefault(i => i.MenuId == id));
        }

        [HttpPost]
        public IActionResult Edit(Menu entity)
        {
            if (entity.MenuId == 0)
            {
                _context.Menus.Add(entity);
            }
            else
            {
                _context.Menus.Update(entity);
            }
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        //[HttpPost]
        public IActionResult Delete(int id)
        {
            var entity = _context.Menus.FirstOrDefault(i => i.MenuId == id);
            _context.Menus.Remove(entity);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult EditMenu(int id)
        {
            ViewBag.Foods = _context.Foods.Include(p => p.FoodMenus);
            return View("MenuEditor", _context.Menus.Find(id));
        }
        [HttpPost]
        public IActionResult EditMenu(int id, int[] foodid)
        {
            Menu menu = _context
                .Menus
                .Include(s => s.FoodMenus)
                .First(s => s.MenuId == id);

            menu.FoodMenus = foodid.Select(pid
                => new Models.FoodMenu
                {
                    MenuId = id,
                    FoodId = pid
                }).ToList();
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
