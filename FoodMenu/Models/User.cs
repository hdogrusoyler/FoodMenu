using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodMenu.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int TCKN { get; set; }
        public string Password { get; set; }
        public bool isAdmin { get; set; }

        public IEnumerable<UserMenu> UserMenus { get; set; }
    }
}
