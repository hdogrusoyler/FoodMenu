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
    public class UserMenuController : Controller
    {
        private DataContext _context;
        public UserMenuController(DataContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var model = _context
                .Menus
                .Include(i => i.UserMenus)
                .ThenInclude(i => i.User)
                .ToList();

            return View(model);
        }

        public IActionResult EditMenu(int id)
        {
            ViewBag.Users = _context.Users.Include(p => p.UserMenus);
            return View("UserMenuEditor", _context.Menus.Find(id));
        }
        [HttpPost]
        public IActionResult EditMenu(int id, int[] userid)
        {
            Menu menu = _context
                .Menus
                .Include(s => s.UserMenus)
                .First(s => s.MenuId == id);

            menu.UserMenus = userid.Select(pid
                => new UserMenu
                {
                    MenuId = id,
                    UserId = pid
                }).ToList();
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
