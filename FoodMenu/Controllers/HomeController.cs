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
    public class HomeController : Controller
    {
        private DataContext _context;
        public HomeController(DataContext context)
        {
            _context = context;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            var model = _context
                .Menus
                .Include(i => i.FoodMenus)
                .ThenInclude(i => i.Food)
                .ToList();

            return View(model);
        }
    }
}
