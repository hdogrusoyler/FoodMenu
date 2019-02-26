using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodMenu.Models
{
    public class UserMenu
    {
        public int UserId { get; set; }
        public User User { get; set; }

        public int MenuId { get; set; }
        public Menu Menu { get; set; }
    }
}
