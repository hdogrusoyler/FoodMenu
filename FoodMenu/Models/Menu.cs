using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodMenu.Models
{
    public class Menu
    {
        public int MenuId { get; set; }
        public DateTime MenuDate { get; set; }

        public IEnumerable<FoodMenu> FoodMenus { get; set; }
        public IEnumerable<UserMenu> UserMenus { get; set; }
    }
}
