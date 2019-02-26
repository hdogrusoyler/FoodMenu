using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FoodMenu.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FoodMenu.Controllers
{
    public class UserController : Controller
    {
        private DataContext _context;
        public UserController(DataContext context)
        {
            _context = context;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View(_context.Users);
        }

        public IActionResult Create()
        {
            return View("UserEditor");
        }

        public IActionResult Edit(int id)
        {
            return View("UserEditor",
                _context
                    .Users
                    .FirstOrDefault(i => i.UserId == id));
        }

        [HttpPost]
        public IActionResult Edit(User entity)
        {
            if (entity.UserId == 0)
            {
                _context.Users.Add(entity);
            }
            else
            {
                _context.Users.Update(entity);
            }
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        //[HttpPost]
        public IActionResult Delete(int id)
        {
            var entity = _context.Users.FirstOrDefault(i => i.UserId == id);
            _context.Users.Remove(entity);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
